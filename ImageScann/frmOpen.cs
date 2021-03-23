using ImageScann.BLL;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
namespace ImageScann
{
    public partial class frmOpen : Form
    {
        public TreeView treeView;
        public frmOpen()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var dataNbr = txtDataNbr.Text.Trim();

            if (string.IsNullOrEmpty(dataNbr))
            {
                MessageBox.Show("请输入单号!", "提示");
                return;
            }

            var result = JObject.Parse(Common.HttpPost(Common.GetApiUrl("GetImageListByDataNbr"), string.Format("dataNbr={0}", dataNbr)));
            if (!Convert.ToBoolean(result["success"].ToString()))
            {
                MessageBox.Show(result["info"].ToString(), "提示");
                return;
            }
            var data = JArray.Parse(result["data"].ToString());
            if (data.Count == 0)
            {
                MessageBox.Show("当前单号下没有查到影像!", "提示");
                return;
            }
            var path = "images/uploadimages/" + dataNbr + "/";
            if (Directory.Exists(path))
            {
                MessageBox.Show("当前单号已打开!", "提示");
                return;
            }

            Directory.CreateDirectory(path);
            var node = new TreeNode();
            node.Text = dataNbr;
            node.Tag = "UploadDocNode";
            foreach (JObject item in data)
            {
                var img = Image.FromStream(WebRequest.Create(Common.GetApiUrl("Priview") + "/" + item["ImageID"].ToString()).GetResponse().GetResponseStream());
                var filePath = Path.Combine(path, item["ImageName"].ToString());
                using (var bitMap = new Bitmap(img))
                {
                    bitMap.Save(filePath);
                    img.Dispose();
                }
                var remark = item["Remark"].ToString();
                if (!string.IsNullOrEmpty(remark))
                {
                    File.WriteAllText(filePath.Replace(".jpg", ".txt"), remark);
                }
                var childNode = new TreeNode();
                childNode.Text = item["ImageName"].ToString().Split('.')[0];
                childNode.Tag = filePath;
                node.Nodes.Add(childNode);
            }
            treeView.Nodes.Add(node);
            TreeViewExtension.HideCheckBox(treeView, node);
            this.Close();
        }
    }
}
