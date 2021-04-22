using ImageScann.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ImageScann
{
    public partial class frmServerConfig : Form
    {
        public frmServerConfig()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 保存配置信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddress_Click(object sender, EventArgs e)
        {
            Common common = new Common();
            string imgUrl = this.txt_imgUrl.Text.Trim();
            if (!string.IsNullOrEmpty(imgUrl))
            {
                common.SetValue("url", imgUrl);
            }

            string invoiceUrl = this.txt_invoiceUrl.Text.Trim();
            if (!string.IsNullOrEmpty(invoiceUrl))
            {
                common.SetValue("invoiceUrl", invoiceUrl);
            }
            
            string scanMode = this.cBox_ScanMode.Text.Trim();
            if (!string.IsNullOrEmpty(scanMode))
            {
                common.SetValue("scanMode", scanMode == "影像模式" ? "image" : "invoice");
            }
            Close();            
        }


        private void frmServerConfig_Load(object sender, EventArgs e)
        {
            txt_imgUrl.Text = ConfigurationManager.AppSettings["url"];
            txt_invoiceUrl.Text = ConfigurationManager.AppSettings["invoiceUrl"];
            cBox_ScanMode.Text = ConfigurationManager.AppSettings["scanMode"] == "image" ? "影像模式" : "识票模式";            
        }
    }
}
