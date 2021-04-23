using ImageScann.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <param name="dateFr">开票日期开始</param>
        /// <param name="dateTo">开票日期截止</param>
        /// <param name="lastScanTime">最近上传时间</param>
        /// <returns></returns>
        public DataSet GetVatInvoice(string invCode, string invNum, string sellerName, string dateFr, string dateTo, string lastScanTime)
        {
            string commandText = @"SELECT  Id, InvoiceTypeOrg, InvoiceCode, InvoiceNumber, InvoiceDate, PurchaserName,
                            PurchaserRegisterNum, PurchaserAddress, PurchaserBank, SellerName, SellerRegisterNum, SellerAddress, SellerBank, 
                            TotalAmount, TotalTaxAmount, TotalTax, Remarks, InvoicePatch, PushStatus FROM Vat_Invoice  WHERE 1=1 ";
            if (!string.IsNullOrWhiteSpace(invCode)) commandText += string.Format(" AND InvoiceCode = '{0}'", invCode);
            if (!string.IsNullOrWhiteSpace(invNum)) commandText += string.Format(" AND InvoiceNumber = '{0}'", invNum);
            if (!string.IsNullOrWhiteSpace(sellerName)) commandText += string.Format(" AND SellerName LIKE '%{0}%'", sellerName);
            if (!string.IsNullOrWhiteSpace(dateFr)) commandText += string.Format(" AND InvoiceDate >= '{0}'", dateFr);
            if (!string.IsNullOrWhiteSpace(dateTo)) commandText += string.Format(" AND InvoiceDate <= '{0}'", dateTo);
            if (!string.IsNullOrWhiteSpace(lastScanTime)) commandText += string.Format(" AND ( CreateTime >= '{0}' OR UpdateTime >= '{0}')", lastScanTime);
            DataSet ds = SQLiteHelper.ExecuteDataSet(connectionString, commandText, null);
            return ds;
        }
        /// <summary>
        /// 新增发票
        /// </summary>
        /// <param name="invoice"></param>
        public void AddVatInvoice(VatInvoice invoice)
        {
            DataSet ds = GetVatInvoice(invoice.InvoiceCode, invoice.InvoiceNumber, "", "", "", "");
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
                                WHERE  InvoiceCode = @InvoiceCode, InvoiceNumber = @InvoiceNumber";
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
        /// DataSet分页查询
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public DataSet SplitDataSet(DataSet ds, int pageSize, int pageIndex)
        {
            DataSet vds = new DataSet();
            vds = ds.Clone();
            if (pageIndex < 1) pageIndex = 1;//如果小于1，取第一页
            //if ((ds.Tables[0].Rows.Count + pageSize) <= (pageSize * pageIndex)) pageIndex = 1;
            int fromIndex = pageSize * (pageIndex - 1);//开始行
            int toIndex = pageSize * pageIndex - 1; //结束行
            for (int i = fromIndex; i <= toIndex; i++)
            {
                if (i >= (ds.Tables[0].Rows.Count)) //到达这一行，退出
                    break;
                vds.Tables[0].ImportRow(ds.Tables[0].Rows[i]);
            }
            ds.Dispose();
            return vds;
        }
    }
}
