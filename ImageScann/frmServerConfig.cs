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
        /// 保存服务器配置地址
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddress_Click(object sender, EventArgs e)
        {
            string addressConfig = this.txtAddress.Text.Trim();
            if (!string.IsNullOrEmpty("addressConfig"))
            {
                SetValue("url", addressConfig);
                Close();
            }
            else
            {
                MessageBox.Show("请输入服务器配置地址!", "提示");
            }
        }
        void SetValue(string AppKey, string AppValue)
        {

            System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();
            xDoc.Load(System.Windows.Forms.Application.ExecutablePath + ".config");

            System.Xml.XmlNode xNode;
            System.Xml.XmlElement xElem1;
            System.Xml.XmlElement xElem2;
            xNode = xDoc.SelectSingleNode("//appSettings");

            xElem1 = (System.Xml.XmlElement)xNode.SelectSingleNode("//add[@key='" + AppKey + "']");
            if (xElem1 != null) xElem1.SetAttribute("value", AppValue);
            else
            {
                xElem2 = xDoc.CreateElement("add");
                xElem2.SetAttribute("key", AppKey);
                xElem2.SetAttribute("value", AppValue);
                xNode.AppendChild(xElem2);
            }
            xDoc.Save(System.Windows.Forms.Application.ExecutablePath + ".config");
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void frmServerConfig_Load(object sender, EventArgs e)
        {
            txtAddress.Text = ConfigurationManager.AppSettings["url"];
        }
    }
}
