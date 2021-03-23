using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ImageScann
{
    public partial class frmMergeName : Form
    {
        public List<TreeNode> checkNode;
        public delegate void callback(TreeNode node);
        public callback Callback;
        public frmMergeName()
        {
            InitializeComponent();
        }

        public static Image CombinImage(string sourceImg, string destImg)
        {
            Image imgLeft = System.Drawing.Image.FromFile(sourceImg);
            Image imgRight = System.Drawing.Image.FromFile(destImg);
            Bitmap imgTemp = new System.Drawing.Bitmap(imgLeft.Width + imgRight.Width, imgLeft.Height >= imgRight.Height ? imgLeft.Height : imgRight.Height, PixelFormat.Format24bppRgb);
            //从指定的System.Drawing.Image创建新的System.Drawing.Graphics        
            Graphics g = Graphics.FromImage(imgTemp);
            g.DrawImage(imgLeft, 0, 0, imgLeft.Width, imgLeft.Height);      // g.DrawImage(imgBack, 0, 0, 相框宽, 相框高); 
            // g.FillRectangle(System.Drawing.Brushes.Transparent, 16, 16, (int)112 + 2, ((int)73 + 2));//相片四周刷一层黑色边框
            //g.DrawImage(img, 照片与相框的左边距, 照片与相框的上边距, 照片宽, 照片高);
            g.DrawImage(imgRight, imgLeft.Width, 0, imgRight.Width, imgRight.Height);
            GC.Collect();
            imgLeft.Dispose();
            imgRight.Dispose();
            return imgTemp;
        }
        /// <summary>
        /// 合并影像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            var mergeName = this.txtMergeName.Text.Trim();//合并名称

            if (string.IsNullOrEmpty(mergeName))
            {
                MessageBox.Show("请输入影像名称!", "提示");
                return;
            }

            var node = checkNode[0].Parent;
            var root = "images/";
            if (node.Tag.ToString() == "UploadDocNode")
            {
                root += "uploadimages/";
            }
            var dir = root + node.Text;
            var newName = Path.Combine(dir, mergeName + ".jpg");
            if (File.Exists(newName))
            {
                MessageBox.Show("影像名称已存在!", "提示");
                return;
            }

            var images1 = checkNode[0].Tag.ToString();
            var images2 = checkNode[1].Tag.ToString();

            var mergeDic = string.Format(@"{0}/{1}", dir, mergeName);
            if (!Directory.Exists(mergeDic)) //如果不存在文件夹
            {
                Directory.CreateDirectory(mergeDic);
            }
            //合并
            CombinImage(images1, images2).Save(newName);
            //合并前复制到新建“合并名称”文件夹里
            File.Move(images1, Path.Combine(mergeDic, checkNode[0].Text + ".jpg"));
            File.Move(images2, Path.Combine(mergeDic, checkNode[1].Text + ".jpg"));
            var txtPath1 = images1.Replace(".jpg", ".txt");
            var txtPath2 = images2.Replace(".jpg", ".txt");
            if (File.Exists(txtPath1))
            {
                File.Move(txtPath1, Path.Combine(mergeDic, checkNode[0].Text + ".txt"));
            }
            if (File.Exists(txtPath2))
            {
                File.Move(txtPath2, Path.Combine(mergeDic, checkNode[1].Text + ".txt"));
            }

            checkNode[0].Remove();
            checkNode[1].Remove();

            TreeNode mergeNode = new TreeNode();
            mergeNode.Text = mergeName;
            mergeNode.Tag = newName;
            node.Nodes.Add(mergeNode);
            Callback(mergeNode);
            MessageBox.Show("合并成功!", "提示");
            Close();
        }
    }
}
