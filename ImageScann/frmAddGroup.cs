using ImageScann.BLL;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ImageScann
{
    public partial class frmAddGroup : Form
    {
        public TreeView tree = null;
        public delegate void EventGroup(string name, TreeNode node);
        public EventGroup eventgroup;
        private string _kind = "";
        public frmAddGroup(string kind)
        {
            InitializeComponent();
            this._kind = kind;
            if (_kind == "AddGroup")
                this.label1.Text = "分组名称:";
        }

        /// <summary>
        /// 添加分组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnok_Click(object sender, EventArgs e)
        {
            string name = this.txtGroupName.Text.Trim();
            if (name == "0000000000")
            {
                MessageBox.Show("系统设置'0000000000'无法添加!", "提示");
                return;
            }
            if (string.IsNullOrEmpty(name))
            {
                if (_kind == "AddGroup")
                    MessageBox.Show("请输入分组名称!", "提示");
                else
                    MessageBox.Show("请输入单据号!", "提示");
                return;
            }
            var uploadDataNbrs = CheckUploadImage(string.Join(",", name));
            if (_kind != "AddGroup")
            {

                if (string.IsNullOrEmpty(uploadDataNbrs))
                {
                    MessageBox.Show(string.Format("单据号" + name + "不存在财务系统中!", uploadDataNbrs), "提示");
                    return;
                }
            }

            if (!string.IsNullOrEmpty(name))
            {
                TreeNode node = new TreeNode();
                List<string> groupName = new List<string>();
                foreach (TreeNode n in tree.Nodes)
                {
                    if (n.Tag != null)
                    {
                        groupName.Add(n.Text);
                    }
                }
                if (!groupName.Contains(name))
                {
                    node.Text = name;
                    node.Tag = this._kind == "AddGroup" ? "DocNode" : "SupplementDocNode";
                    tree.Nodes.Add(node);
                    TreeViewExtension.HideCheckBox(tree, node);
                    var dirName= this._kind == "AddGroup" ? "" : "supplementimages";                   
                    string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"images\\" + dirName + "\\"+node.Text);
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    if (eventgroup != null)
                        eventgroup(name, node);
                    this.Close();
                }
                else
                {
                    if (_kind == "AddGroup")
                        MessageBox.Show("该分组名称已存在!", "提示");
                    else
                        MessageBox.Show("该单据号已存在!", "提示");
                }

            }

        }

        private void frmAddGroup_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        string CheckUploadImage(string dataNbrs)
        {
            var result = JObject.Parse(Common.HttpPost(Common.GetApiUrl("CheckUploadImage"), string.Format("dataNbrs={0}", dataNbrs)));
            var data = result["data"].ToString();
            return data;
        }
    }
}
