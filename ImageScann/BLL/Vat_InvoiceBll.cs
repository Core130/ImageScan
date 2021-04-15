using ImageScann.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageScann.BLL
{
    public class Vat_InvoiceBll
    {        
        readonly string connectionString = @"Data Source=" + AppDomain.CurrentDomain.BaseDirectory + @"\LocalImageData\InvoicePool.db;Initial Catalog=sqlite;Integrated Security=True;Max Pool Size=10";
        /// <summary>
        /// 查询发票
        /// </summary>
        /// <returns></returns>
        public DataSet GetVatInvoice()
        {
            string sql = @"SELECT  InvoiceTypeOrg, InvoiceCode, InvoiceNumber, InvoiceDate, PurchaserName,
                            PurchaserRegisterNum, PurchaserAddress, PurchaserBank, SellerName, SellerRegisterNum, SellerAddress, SellerBank, 
                            TotalAmount, TotalTaxAmount, TotalTax,  Remarks, 
                             PushStatus FROM Vat_Invoice";
            DataSet ds = SQLiteHelper.ExecuteDataSet(connectionString, sql, null);
            return ds;
        }
        /// <summary>
        /// 新增发票
        /// </summary>
        /// <param name="invoice"></param>
        public void AddVatInvoice(Vat_Invoice invoice)
        {
            string commandStr = @"INSERT INTO Vat_Invoice(InvoiceType,InvoiceTypeOrg, InvoiceCode, InvoiceNumber, 
                            InvoiceDate, PurchaserName, PurchaserRegisterNum, PurchaserAddress, PurchaserBank, 
                            SellerName, SellerRegisterNum, SellerAddress, SellerBank, 
                            TotalAmount, TotalTaxAmount, TotalTax,  Remarks,
                            Payee,Checker,NoteDrawer,CreateTime,PushStatus) 
                            VALUES(@InvoiceType,@InvoiceTypeOrg, @InvoiceCode, @InvoiceNumber,
                            @InvoiceDate, @PurchaserName, @PurchaserRegisterNum, @PurchaserAddress, @PurchaserBank,
                            @SellerName, @SellerRegisterNum, @SellerAddress, @SellerBank, 
                            @TotalAmount, @TotalTaxAmount, @TotalTax,  @Remarks,
                            @Payee,@Checker,@NoteDrawer,@CreateTime,@PushStatus)";
            var parameters = new object[] { invoice.InvoiceType, invoice.InvoiceTypeOrg ,invoice.InvoiceCode, invoice.InvoiceNumber, 
                                        invoice.InvoiceDate,invoice.PurchaserName, invoice.PurchaserRegisterNum,invoice.PurchaserAddress,invoice.PurchaserBank,
                                        invoice.SellerName,invoice.SellerRegisterNum,invoice.SellerAddress,invoice.SellerBank,
                                        invoice.TotalAmount,invoice.TotalTaxAmount,invoice.TotalTax,invoice.Remarks,
                                        invoice.Payee,invoice.Checker,invoice.NoteDrawer,invoice.CreateTime,invoice.PushStatus};
            SQLiteHelper.ExecuteNonQuery(connectionString, commandStr, parameters);
        }
    }
}
