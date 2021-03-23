using Newtonsoft.Json.Linq;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ImageScann
{
    public partial class frmLogin : Form
    {
        Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        public frmLogin()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string name = this.txtName.Text.Trim();
            string passWord = this.txtPassword.Text.Trim();
            string strPath = ConfigurationManager.AppSettings["url"];
            if (string.IsNullOrEmpty(strPath))
            {
                MessageBox.Show("请配置服务器地址!", "提示");
                return;
            }
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("用户名不能为空!", "提示");
                return;
            }
            if (string.IsNullOrEmpty(passWord))
            {
                MessageBox.Show("密码不能为空!", "提示");
                return;
            }

            try
            {
                string json = HttpPost(strPath + "/ImageApi/Login?UserID=" + name + "&passWord=" + passWord, "");
                JObject result = JObject.Parse(json);
                if (Convert.ToBoolean(result["success"]))
                {
                    SetValue("LoginName",txtName.Text);
                    System.Configuration.ConfigurationManager.RefreshSection("appSettings");
                    frmIndex frmIndex = new frmIndex();
                    frmIndex.USERID = name;
                    frmIndex.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show(result["info"].ToString(), "提示");
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
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

        /// <summary>
        /// 服务器配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfig_Click(object sender, EventArgs e)
        {
            frmServerConfig frmServerCongfig = new frmServerConfig();
            frmServerCongfig.ShowDialog();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postDataStr"></param>
        /// <returns></returns>
        string HttpPost(string url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            var postBytes = Encoding.UTF8.GetBytes(postDataStr);
            request.Method = "POST";
            request.Accept = "*/*";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
            var myRequestStream = request.GetRequestStream();
            myRequestStream.Write(postBytes, 0, postBytes.Length);
            myRequestStream.Close();
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                response = (HttpWebResponse)ex.Response;
            }
            var myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtName.Text = config.AppSettings.Settings["LoginName"].Value;
        }
    }
}
