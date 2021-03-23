using ImageScann.BLL;
using ImageScann.Models;
using Newtonsoft.Json;
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
using Message = ImageScann.Models.Message;

namespace ImageScann
{
    public partial class frmMessage : Form
    {
        public delegate void EventRefresh();
        public EventRefresh eventrefresh;
        public TreeView teee;
        public string userID;
        public frmMessage()
        {
            InitializeComponent();
        }

        private void frmMessage_Load(object sender, EventArgs e)
        {
            cmbStatus.SelectedIndex = 1;
            dataGridView1.AutoGenerateColumns = false;
            GetMessageList();
        }

        void GetMessageList()
        {
            var result = new List<Message>();
            var status = cmbStatus.SelectedItem.ToString() == "全部" ? 0 : cmbStatus.SelectedItem.ToString() == "未读" ? 1 : 2;
            var data = JObject.Parse(Common.HttpPost(Common.GetApiUrl("GetMessageList"), string.Format("status={0}&filter={1}&userID={2}", status, txtFilter.Text.Trim(), userID)));
            if (Convert.ToBoolean(data["success"]))
            {

                result = JsonConvert.DeserializeObject<List<Message>>(data["data"].ToString());
            }
            dataGridView1.DataSource = result;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                if (e.RowIndex != -1)
                {
                    if (e.ColumnIndex == 4)
                    {
                        var dataItem = (Message)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                        if (dataItem.bRead == false)
                        {

                            //更新消息状态
                            Common.HttpPost(Common.GetApiUrl("UpdateMessageStatus"), string.Format("msgID={0}", dataItem.ID));
                            if (eventrefresh != null)
                            {
                                eventrefresh();
                            }
                        }
                        frmViewMessage frm = new frmViewMessage();
                        frm.message = dataItem;
                        frm.ShowDialog();
                    }
                    if (e.ColumnIndex == 5)
                    {
                        var dataItem = (Message)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                        if (dataItem.bRead == false)
                        {

                            //更新消息状态
                            Common.HttpPost(Common.GetApiUrl("UpdateMessageStatus"), string.Format("msgID={0}", dataItem.ID));
                            if (eventrefresh != null)
                            {
                                eventrefresh();
                            }
                        }
                        var dataNbr = dataItem.DataNbr;
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
                            var img = Image.FromStream(WebRequest.Create(Common.GetApiUrl("Priview") + "/" + item["ImageID"].ToString() + "?datanbr=" + item["DataNbr"].ToString()).GetResponse().GetResponseStream());
                            var filePath = Path.Combine(path, item["ImageName"].ToString());
                            using (var bitMap = new Bitmap(img))
                            {
                                //下载时转换成JPG格式的图片
                                var eps = new EncoderParameters(1);
                                var ep = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 85L);
                                eps.Param[0] = ep;
                                var jpsEncodeer = GetEncoder(ImageFormat.Jpeg);
                                bitMap.Save(filePath, jpsEncodeer, eps);
                                ep.Dispose();
                                eps.Dispose();
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
                        teee.Nodes.Add(node);
                        TreeViewExtension.HideCheckBox(teee, node);
                        this.Close();

                    }
                }

            }
            catch (Exception) {
              
            }
 
        }

        /// <summary>
        /// 获取格式
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                    return codec;
            }
            return null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GetMessageList();
        }
    }
}
