using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageScann.DAL
{
    /// <summary>
    /// 增值税发票
    /// </summary>
    public class VatInvoice
    {
        public int Id { get; set; }
        /// <summary>
        /// 发票种类
        /// </summary>
        public string InvoiceType { get; set; }
        /// <summary>
        /// 发票名称
        /// </summary>
        public string InvoiceTypeOrg { get; set; }
        /// <summary>
        /// 发票代码
        /// </summary>
        public string InvoiceCode { get; set; }
        /// <summary>
        /// 发票号码
        /// </summary>
        public string InvoiceNumber { get; set; }
        /// <summary>
        /// 开票日期
        /// </summary>
        public string InvoiceDate { get; set; }
        /// <summary>
        /// 购买方名称
        /// </summary>
        public string PurchaserName { get; set; }
        /// <summary>
        /// 购买方纳税人识别号
        /// </summary>
        public string PurchaserRegisterNum { get; set; }
        /// <summary>
        /// 购买方地址、电话
        /// </summary>
        public string PurchaserAddress { get; set; }
        /// <summary>
        /// 购买方开户行及账号
        /// </summary>
        public string PurchaserBank { get; set; }
        /// <summary>
        /// 销售方名称
        /// </summary>
        public string SellerName { get; set; }
        /// <summary>
        /// 销售方纳税人识别号
        /// </summary>
        public string SellerRegisterNum { get; set; }
        /// <summary>
        /// 销售方地址、电话
        /// </summary>
        public string SellerAddress { get; set; }
        /// <summary>
        /// 销售方开户行及账号
        /// </summary>
        public string SellerBank { get; set; }
        /// <summary>
        /// 合计金额
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// 价税合计
        /// </summary>
        public decimal TotalTaxAmount { get; set; }
        /// <summary>
        /// 合计税额
        /// </summary>
        public decimal TotalTax { get; set; }
        /// <summary>
        /// 收款人
        /// </summary>
        public string Payee { get; set; }
        /// <summary>
        /// 复核
        /// </summary>
        public string Checker { get; set; }
        /// <summary>
        /// 开票人
        /// </summary>
        public string NoteDrawer { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 推送标识 1:已推送
        /// </summary>
        public int PushStatus { get; set; }
        /// <summary>
        /// 推送时间
        /// </summary>
        public DateTime PushTime { get; set; }

    }
}
