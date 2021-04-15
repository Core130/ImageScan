using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public bool InitOpSkyScan(frmIndex frm, out string msg)
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
        public string InvoiceScan(frmIndex frm)
        {
            try
            {
                string tpImgName = "";
                int index = 0;
                string strIndex = "";
                string tmp_ImagePath = AppDomain.CurrentDomain.BaseDirectory + @"\vatinvoiceimages\tempimages";
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
                int ncells = 0;
                int nType = -2;
                string tpresult = "";
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
                    }

                    isHavePaper = billOcr.IsHavePaper();
                    if (recode == 0)      //识别后读取数据
                    {
                        tpresult = GetRecogResult(ncells);
                        string tpRcogTxt = tmp_ImagePath + strIndex + ".txt";
                        //billOcr.GetResultByTxt(tpRcogTxt);
                        billOcr.GetResultByXml(tpRcogTxt);
                        return tpresult;
                    }
                }
                return "1";
            }
            catch (Exception ex)
            {
                _logger.Info(string.Format("系统异常,{0}!", ex.ToString()));
                return string.Format("系统异常,请重新扫描,{0}!", ex.ToString());
            }
        }
        private string GetRecogResult(int ncells)
        {
            string strResult = "";
            if (ncells <= 0)
            {
                return strResult;
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
                strResult += FieldNameList[i] + ":" + FieldResultList[i] + "\r\n";
            }
            FieldNameList.Clear();
            FieldResultList.Clear();
            return strResult;
        }
    }
}
