using ImageScann.DAL;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web;

namespace ImageScann.BLL
{
    public class VatInvoiceBll
    {
        //readonly string connectionString = @"Data Source=" + AppDomain.CurrentDomain.BaseDirectory + @"\LocalImageData\InvoicePool.db;datetimeformat=CurrentCulture;Initial Catalog=sqlite;Integrated Security=True;Max Pool Size=10";
        readonly string connectionString = @"Data Source=" + AppDomain.CurrentDomain.BaseDirectory + @"\LocalImageData\InvoicePool.db;Initial Catalog=sqlite;Integrated Security=True;Max Pool Size=10";
        /// <summary>
        /// 查询发票
        /// </summary>
        /// <param name="invCode">发票代码</param>
        /// <param name="invNum">发票号码</param>
        /// <param name="sellerName">销售方名称</param>
        /// <param name="purchaserName">购买方名称</param>
        /// <param name="dateFr">开票日期开始</param>
        /// <param name="dateTo">开票日期截止</param>
        /// <param name="lastScanTime">最近上传时间</param>
        /// <param name="pageSize">页大小,0:不分页</param>
        /// <param name="pageIndex">第几页</param>
        /// <returns></returns>
        public DataSet GetVatInvoice(string invCode, string invNum, string sellerName, string purchaserName, string dateFr, string dateTo, string lastScanTime, int pageSize = 0, int pageIndex = 0)
        {
            string commandText = @"SELECT  Id, InvoiceTypeOrg, InvoiceCode, InvoiceNumber, InvoiceDate, PurchaserName,
                            PurchaserRegisterNum, PurchaserAddress, PurchaserBank, SellerName, SellerRegisterNum, SellerAddress, SellerBank, 
                            TotalAmount, TotalTaxAmount, TotalTax, Remarks, InvoicePatch, PushStatus FROM Vat_Invoice  WHERE 1=1 ";
            if (!string.IsNullOrWhiteSpace(invCode)) commandText += string.Format(" AND InvoiceCode = '{0}'", invCode);
            if (!string.IsNullOrWhiteSpace(invNum)) commandText += string.Format(" AND InvoiceNumber = '{0}'", invNum);
            if (!string.IsNullOrWhiteSpace(sellerName)) commandText += string.Format(" AND SellerName LIKE '%{0}%'", sellerName);
            if (!string.IsNullOrWhiteSpace(purchaserName)) commandText += string.Format(" AND PurchaserName LIKE '%{0}%'", purchaserName);
            if (!string.IsNullOrWhiteSpace(dateFr)) commandText += string.Format(" AND InvoiceDate >= '{0}'", dateFr);
            if (!string.IsNullOrWhiteSpace(dateTo)) commandText += string.Format(" AND InvoiceDate <= '{0}'", dateTo);
            if (!string.IsNullOrWhiteSpace(lastScanTime)) commandText += string.Format(" AND ( CreateTime >= '{0}' OR UpdateTime >= '{0}')", lastScanTime);
            if (pageSize != 0)
            {
                commandText += string.Format(" limit {0} offset {1}", pageSize, pageSize * (pageIndex - 1));
            }
            DataSet ds = SQLiteHelper.ExecuteDataSet(connectionString, commandText, null);
            return ds;
        }
        /// <summary>
        /// 新增发票
        /// </summary>
        /// <param name="invoice"></param>
        public void AddVatInvoice(VatInvoice invoice)
        {
            DataSet ds = GetVatInvoice(invoice.InvoiceCode, invoice.InvoiceNumber, "", "", "", "", "");
            if (ds.Tables[0].Rows.Count == 0)
            {
                string commandStr = @"INSERT INTO Vat_Invoice(InvoiceType,InvoiceTypeOrg, InvoiceCode, InvoiceNumber, 
                            InvoiceDate, PurchaserName, PurchaserRegisterNum, PurchaserAddress, PurchaserBank, 
                            SellerName, SellerRegisterNum, SellerAddress, SellerBank, 
                            TotalAmount, TotalTaxAmount, TotalTax,  Remarks,InvoicePatch,
                            Payee,Checker,NoteDrawer,CreateTime,UpdateTime,PushStatus) 
                            VALUES(@InvoiceType,@InvoiceTypeOrg, @InvoiceCode, @InvoiceNumber,
                            @InvoiceDate, @PurchaserName, @PurchaserRegisterNum, @PurchaserAddress, @PurchaserBank,
                            @SellerName, @SellerRegisterNum, @SellerAddress, @SellerBank, 
                            @TotalAmount, @TotalTaxAmount, @TotalTax,  @Remarks,@InvoicePatch,
                            @Payee,@Checker,@NoteDrawer,@CreateTime,@UpdateTime,@PushStatus)";
                var parameters = new object[] { invoice.InvoiceType, invoice.InvoiceTypeOrg ,invoice.InvoiceCode, invoice.InvoiceNumber,
                                        invoice.InvoiceDate,invoice.PurchaserName, invoice.PurchaserRegisterNum,invoice.PurchaserAddress,invoice.PurchaserBank,
                                        invoice.SellerName,invoice.SellerRegisterNum,invoice.SellerAddress,invoice.SellerBank,
                                        invoice.TotalAmount,invoice.TotalTaxAmount,invoice.TotalTax,invoice.Remarks,invoice.InvoicePatch,
                                        invoice.Payee,invoice.Checker,invoice.NoteDrawer,invoice.CreateTime,invoice.UpdateTime,invoice.PushStatus};
                SQLiteHelper.ExecuteNonQuery(connectionString, commandStr, parameters);
            }
            else
            {
                string commandStr = @"UPDATE Vat_Invoice SET UpdateTime = @UpdateTime 
                                WHERE  InvoiceCode = @InvoiceCode AND InvoiceNumber = @InvoiceNumber";
                var parameters = new object[] { invoice.UpdateTime, invoice.InvoiceCode, invoice.InvoiceNumber };
                SQLiteHelper.ExecuteNonQuery(connectionString, commandStr, parameters);
            }
        }

        /// <summary>
        /// 更改发票
        /// </summary>
        /// <param name="invoice"></param>
        public void UpdateVatInvoice(VatInvoice invoice)
        {
            string commandStr = @"UPDATE Vat_Invoice 
                                SET 
                                    InvoiceTypeOrg = @InvoiceTypeOrg, 
                                    InvoiceCode = @InvoiceCode, 
                                    InvoiceNumber = @InvoiceNumber, 
                                    InvoiceDate = @InvoiceDate, 
                                    PurchaserName = @PurchaserName, 
                                    PurchaserRegisterNum = @PurchaserRegisterNum,
                                    PurchaserAddress = @PurchaserAddress, 
                                    PurchaserBank = @PurchaserBank, 
                                    SellerName = @SellerName, 
                                    SellerRegisterNum = @SellerRegisterNum, 
                                    SellerAddress = @SellerAddress, 
                                    SellerBank = @SellerBank, 
                                    TotalAmount = @TotalAmount, 
                                    TotalTaxAmount = @TotalTaxAmount,
                                    TotalTax = @TotalTax WHERE Id = @id";
            var parameters = new object[] { invoice.InvoiceTypeOrg ,invoice.InvoiceCode, invoice.InvoiceNumber,
                                        invoice.InvoiceDate,invoice.PurchaserName, invoice.PurchaserRegisterNum,invoice.PurchaserAddress,invoice.PurchaserBank,
                                        invoice.SellerName,invoice.SellerRegisterNum,invoice.SellerAddress,invoice.SellerBank,
                                        invoice.TotalAmount,invoice.TotalTaxAmount,invoice.TotalTax,invoice.Id};
            SQLiteHelper.ExecuteNonQuery(connectionString, commandStr, parameters);

        }
        /// <summary>
        /// 获取发票相对路径
        /// </summary>
        /// <param name="id">记录id</param>
        /// <returns></returns>
        public string GetInvoicePatch(int id)
        {
            string commandText = string.Format(@"SELECT InvoicePatch FROM Vat_Invoice WHERE Id = '{0}'", id);
            DataSet ds = SQLiteHelper.ExecuteDataSet(connectionString, commandText, null);
            if (ds.Tables[0].Rows.Count == 0)
            {
                return "";
            }
            else
            {
                return ds.Tables[0].Rows[0]["InvoicePatch"].ToString();
            }

        }

        /// <summary>
        /// 获取图片
        /// </summary>
        /// <param name="imgPatch">图片路径</param>
        /// <returns></returns>
        public Image GetImage(string patch)
        {
            //
            // 如果图片文件的大小为0,说明这是一个非法的文件
            //
            FileInfo f = new FileInfo(patch);
            if (f.Length != 0)
            {
                return Image.FromFile(patch);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 更新发票上传状态
        /// </summary>
        /// <param name="id"></param>
        public void UpdatePushStatus(int id)
        {
            string commandStr = @"UPDATE Vat_Invoice 
                                SET 
                                    PushStatus = @PushStatus, 
                                    PushTime = @PushTime
                                    WHERE Id = @id";
            var parameters = new object[] { 1, DateTime.Now, id };
            SQLiteHelper.ExecuteNonQuery(connectionString, commandStr, parameters);

        }
        /// <summary>
        /// 获取CesToken
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public string GetCesToken(out string userName)
        {
            string result = "";
            string url = System.Configuration.ConfigurationManager.AppSettings["invoiceUrl"];
            string userId = System.Configuration.ConfigurationManager.AppSettings["cesUserId"];
            string userPassword = System.Configuration.ConfigurationManager.AppSettings["cesUserPassword"];
            var tokenData = JObject.Parse(Common.HttpPost(url + "CESApi//CheckLogin", string.Format("userID={0}&password={1}&version={2}", userId, userPassword, 2)));
            string success = tokenData["success"].ToString();
            if(Convert.ToBoolean(success))
            {
                result = tokenData["data"]["token"].ToString();
                userName = tokenData["data"]["username"].ToString();
            }
            else
            {
                userName = "";
            }
            return result;
        }
        /// <summary>
        /// 上传增值税发票
        /// </summary>
        /// <param name="invType">01:专票、02:普票</param>
        /// <param name="companyCode"></param>
        /// <param name="userID"></param>
        /// <param name="doc"></param>
        /// <param name="det"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public string InvoiceAdd(string invType, string doc, string det,string fileName, string filePatch)
        {
            string url = System.Configuration.ConfigurationManager.AppSettings["invoiceUrl"];
            string userName;
            string token = GetCesToken(out userName);
            string companyCode = "1101";
            if(!string.IsNullOrWhiteSpace(token))
            {
                string prgId;
                string requestUrl;
                string userId = System.Configuration.ConfigurationManager.AppSettings["cesUserId"];
                if (invType == "01")
                {
                    requestUrl = url + "Invoice01Api";
                    prgId = "IN006";
                }
                else if (invType == "02")
                {
                    requestUrl = url + "Invoice02Api";
                    prgId = "IN004";
                }
                else
                {
                    return "发票类型有误";
                }

                var result = JObject.Parse(Common.HttpPost(requestUrl + "/Add/", string.Format("companyCode={0}&userID={1}&doc={2}&det={3}&token={4}"
                    , companyCode, userId, doc, det, token)));
                string success = result["success"].ToString();
                string msg = result["msg"].ToString();
                if (Convert.ToBoolean(success))
                {
                    //发票推送成功后上传图片附件
                    string dataNbr = result["data"]["datanbr"].ToString();
                    string postStr = string.Format("dataNbr={0}&token={1}&prgID={2}&userID={3}&userName={4}&companyCode={5}&fileName={6}"
                        , dataNbr, HttpUtility.UrlEncode(token), prgId, userId, userName, companyCode, fileName);
                    var fileresult = JObject.Parse(Common.HttpUploadFile(url + "CESApi/UploadFile?", postStr, fileName, filePatch));
                    success = fileresult["success"].ToString();
                    msg += fileresult["msg"].ToString();
                    if (Convert.ToBoolean(success))
                    {
                        //发票和图片都处理成功才返回1
                        return "1";
                    }
                    else
                    {
                        //删除上传的发票
                        Common.HttpPost(requestUrl + "/Delete/", string.Format("dataNbr={0}&userID={1}&token={2}", dataNbr, userId, token));
                    }
                    return msg;
                }
                else
                    return msg;
            }
            else
            {
                return "配置用户密码有误";
            }
            
        }
    }
}
