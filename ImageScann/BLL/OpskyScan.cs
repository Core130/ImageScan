using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageScann.DAL;
using Newtonsoft.Json;

namespace ImageScann.BLL
{
    public class OpskyScan
    {
        private OpskyBillOcrEngine billOcr = new OpskyBillOcrEngine();
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// 启动扫描仪
        /// </summary>
        /// <returns></returns>
        public bool InitOpSkyScan(out string msg)
        {
            string strUserID = System.Configuration.ConfigurationManager.AppSettings["OpSky_UserId"];
            int recode = billOcr.InitForm(strUserID);
            if (0 != recode)
            {
                int nErroLength;
                char[] erroBuffer = new char[256];
                billOcr.GetErroInformation(recode, erroBuffer, out nErroLength);
                msg = new string(erroBuffer);
                return false;
            }
            else
            {
                msg = "启动成功";
                return true;
            }
        }

        /// <summary>
        /// 奥普斯凯普通扫描（无OCR）
        /// </summary>
        public string Scan(frmIndex frm)
        {
            try
            {
                string tpImgName = "";
                int index = 0;
                string strIndex = "";
                string tmp_ImagePath = AppDomain.CurrentDomain.BaseDirectory + @"\images\";
                if (!Directory.Exists(tmp_ImagePath)) Directory.CreateDirectory(tmp_ImagePath);
                while (true)
                {
                    strIndex = "";
                    strIndex = string.Format("{0:D4}", index);
                    tpImgName = tmp_ImagePath + strIndex + ".jpg";
                    if (!File.Exists(tpImgName))
                        break;
                    index++;
                }
                bool isHavePaper = true;
                int recode = -1;
                while (isHavePaper)
                {
                    index++;
                    strIndex = "";
                    strIndex = string.Format("{0:D4}", index);
                    tpImgName = tmp_ImagePath + strIndex + ".jpg";
                    recode = billOcr.AcquireNewImage(tpImgName);           //扫描图像
                    if (recode == 0)
                    {
                        frm.ScanBarCode(tpImgName);
                    }
                    isHavePaper = billOcr.IsHavePaper();
                }
                return "1";
            }
            catch (Exception ex)
            {
                _logger.Info(string.Format("系统异常,{0}!", ex.ToString()));
                return string.Format("系统异常,请重新扫描,{0}!", ex.ToString());
            }
        }

        /// <summary>
        /// 奥普斯凯发票扫描（OCR)
        /// </summary>
        public string InvoiceScan()
        {
            try
            {
                string tpImgName = "";
                int index = 0;
                string strIndex = "";
                string imageName = "";
                string imagePath = "";
                string tmp_ImagePath = AppDomain.CurrentDomain.BaseDirectory + @"\vatinvoiceimages\tempimages\";
                if (!Directory.Exists(tmp_ImagePath))
                {
                    Directory.CreateDirectory(tmp_ImagePath);
                }
                else
                {
                    DeleteFolder(tmp_ImagePath);
                }
                bool isHavePaper = true;
                int recode = -1;
                int ncells = 0;
                int nType = -2;
                Dictionary<string, string> invResult = new Dictionary<string, string>();
                while (isHavePaper)
                {
                    index++;
                    strIndex = "";
                    strIndex = string.Format("{0:D4}", index);
                    tpImgName = tmp_ImagePath + strIndex + ".jpg";
                    recode = billOcr.AcquireNewImage(tpImgName);           //扫描图像                  
                    //识别图像
                    if (recode == 0)
                    {
                        char[] cArrFieldName = new char[256];
                        cArrFieldName.Initialize();
                        int nFiledName = billOcr.GetFieldNameEx(cArrFieldName);

                        if (nFiledName == 0)
                        {
                            string strFieldName = new string(cArrFieldName);
                        }
                        recode = billOcr.RecognizeForm(out ncells, out nType);   //识别图像

                        if (recode == 0)      //识别后读取数据
                        {
                            invResult = GetRecogResult(ncells);
                            _logger.Info("发票识别结果:" + JsonConvert.SerializeObject(invResult));
                            if (invResult != null)
                            {
                                VatInvoice invoice = new VatInvoice();
                                VatInvoiceBll invoiceBll = new VatInvoiceBll();
                                invoice.InvoiceType = invResult["票据类型"].ToString();
                                invoice.InvoiceTypeOrg = invoice.InvoiceType == "专票" ? "增值税专用发票" : "增值税普通发票";
                                invoice.InvoiceCode = invResult["发票代码"].ToString();
                                invoice.InvoiceNumber = invResult["发票号码"].ToString();
                                invoice.InvoiceDate = invResult["开票日期"].ToString();
                                invoice.PurchaserName = invResult["购方企业名称"].ToString();
                                invoice.PurchaserRegisterNum = invResult["购方纳税号"].ToString();
                                invoice.PurchaserAddress = invResult["购买方地址及电话"].ToString();
                                invoice.PurchaserBank = invResult["购买方开户行及账号"].ToString();
                                invoice.SellerName = invResult["销方企业名称"].ToString();
                                invoice.SellerRegisterNum = invResult["销方纳税号"].ToString();
                                invoice.SellerAddress = invResult["销售方地址及电话"].ToString();
                                invoice.SellerBank = invResult["销售方开户行及账号"].ToString();
                                invoice.TotalAmount = decimal.Parse(invResult["金额"].ToString());
                                invoice.TotalTaxAmount = decimal.Parse(invResult["价税合计"].ToString());
                                invoice.TotalTax = decimal.Parse(invResult["税额"].ToString());
                                invoice.Payee = invResult["收款人"].ToString();
                                invoice.Checker = invResult["复核"].ToString();
                                invoice.NoteDrawer = invResult["开票人"].ToString();
                                invoice.Remarks = invResult["备注"].ToString();
                                invoice.CreateTime = DateTime.Now;
                                invoice.UpdateTime = DateTime.Now;
                                invoice.PushStatus = 0;

                                //按发票代码、发票号码重命名文件,并按开票日期年月建立归档文件夹
                                string imageDoc = invoice.InvoiceDate.Substring(0, 7);
                                imagePath = AppDomain.CurrentDomain.BaseDirectory + @"vatinvoiceimages\" + imageDoc + @"\";
                                if (!Directory.Exists(imagePath)) Directory.CreateDirectory(imagePath);
                                imageName = invoice.InvoiceCode + "_" + invoice.InvoiceNumber;
                                string newImagePath = imagePath + imageName + ".jpg";
                                FileInfo fileInfo = new FileInfo(tpImgName);
                                if (!File.Exists(newImagePath))
                                    fileInfo.MoveTo(Path.Combine(newImagePath));
                                invoice.InvoicePatch = imageDoc + @"\" + imageName + ".jpg";
                                invoiceBll.AddVatInvoice(invoice);
                            }
                        }
                    }
                    isHavePaper = billOcr.IsHavePaper();
                }
                return "1";
            }
            catch (Exception ex)
            {
                _logger.Info(string.Format("系统异常,{0}!", ex.ToString()));
                return string.Format("系统异常,请重新扫描,{0}!", ex.ToString());
            }
        }
        private Dictionary<string, string> GetRecogResult(int ncells)
        {
            Dictionary<string, string> dicResult = new Dictionary<string, string>();
            if (ncells <= 0)
            {
                return null;
            }
            List<string> FieldNameList = new List<string>();
            List<string> FieldResultList = new List<string>();

            int i = 0;
            int nbufferlen = 0;
            int nFontTye = -1;
            string tpresult = "";
            string tpname = "";
            for (i = 0; i < ncells; i++)
            {
                tpresult = "";
                tpname = "";

                billOcr.GetFieldName(i, null, out nbufferlen);
                char[] lpname = new char[nbufferlen];
                lpname.Initialize();
                billOcr.GetFieldName(i, lpname, out nbufferlen);
                tpname = new String(lpname);
                FieldNameList.Add(tpname);

                nbufferlen = 0;
                billOcr.GetRecognizeResult(i, null, out nbufferlen);
                char[] lpresult = new char[nbufferlen];
                lpresult.Initialize();
                billOcr.GetRecognizeResult(i, lpresult, out nbufferlen);
                tpresult = new String(lpresult);

                nFontTye = -1;
                billOcr.GetCellType(i, out nFontTye);
                if (nFontTye == 33)
                {
                    tpresult.Replace("§", "\r\n");
                }

                if (tpname == "票据类型")
                    if (tpresult == "1")
                        tpresult = "普票";
                    else
                        tpresult = "专票";

                FieldResultList.Add(tpresult);
            }

            int safeCount = Math.Min(FieldNameList.Count, FieldResultList.Count);
            for (i = 0; i < safeCount; i++)
            {
                dicResult.Add(FieldNameList[i], FieldResultList[i]);
            }
            FieldNameList.Clear();
            FieldResultList.Clear();
            return dicResult;
        }

        public static void DeleteFolder(string path)
        {
            foreach (string d in Directory.GetFileSystemEntries(path))
            {
                if (File.Exists(d))
                {
                    FileInfo fi = new FileInfo(d);
                    if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                        fi.Attributes = FileAttributes.Normal;
                    File.Delete(d);//直接删除其中的文件  
                }
                else
                {
                    DirectoryInfo d1 = new DirectoryInfo(d);
                    if (d1.GetFiles().Length != 0)
                    {
                        DeleteFolder(d1.FullName); //递归删除子文件夹
                    }
                    Directory.Delete(d);
                }
            }
        }

    }
}
