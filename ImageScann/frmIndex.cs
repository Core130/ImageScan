using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using NLog;
using Aspose.BarCode.BarCodeRecognition;
using ImageScann.BLL;

namespace ImageScann
{

    public partial class frmIndex : Form
    {

        public string USERID;
        //ScanCtrl scan = new ScanCtrl();
        Bitmap bitMap = null;
        Point mouseDownPoint = new Point(); //记录拖拽过程鼠标位置
        bool isMove = false;                //判断鼠标在picturebox上移动时，是否处于拖拽过程(鼠标左键是否按下)
        int zoomStep = 20;                  //缩放步长
        bool bInitFlag = false;
        int pageCnt = 0;
        //string strScanInf = null;
        //string strCstmInf = null;
        string fileName = string.Empty;
        string filePath = string.Empty;
        string imagePath = string.Empty;
        string savePath = string.Empty;
        TreeNode curNode = null;
        TreeNode replaceNode = null;
        TreeNode viewNode = null;
        string iniPath = string.Empty;
        string logPath = string.Empty;
        Point Position = new Point(0, 0);
        ScanUpload scanUpload = null;
        Dictionary<string, string> paths = new Dictionary<string, string>();
        List<string> datalist = new List<string>(); //记录补充上传单据
        TextLog textlog = new TextLog(AppDomain.CurrentDomain.BaseDirectory + @"/log/Log.txt");
        TextLog scannLog = new TextLog(AppDomain.CurrentDomain.BaseDirectory + @"/log/ScannLog.txt");
        JToken companycach = null;      //获取公司缩写
        JToken prgidcach = null;        //获取Prgid
        JToken prefix = null;           //获取流水前缀
        bool isscann = false;           //是否正常扫描
        bool isreplacescann = false;    //是否替换扫描
        bool issupplementscann = false; //是否补充扫描
        bool isreturnscann = false;     //是否回单补扫
        List<TreeNode> selectNode = new List<TreeNode>();//多选的子节点
        List<string> errDataNbr = new List<string>();//记录重复扫描的单号
        private bool isFirstScan = false;//判断本次扫描的图片的条形码是否第一张
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        OpskyScan opskyScan = new OpskyScan();
        public int PageCnt
        {
            get { return pageCnt; }
            set { pageCnt = value; }
        }

        void GetCachData()
        {
            var result = JObject.Parse(Common.HttpPost(Common.GetApiUrl("GetAllCompany"), ""));
            companycach = (JArray)result["data"];

            result = JObject.Parse(Common.HttpPost(Common.GetApiUrl("GetAllPrograms"), ""));
            prgidcach = (JArray)result["data"];

            result = JObject.Parse(Common.HttpPost(Common.GetApiUrl("GetAllNbrRule"), ""));
            prefix = (JArray)result["data"];
        }

        public frmIndex()
        {
            InitializeComponent();
            paths.Add("DocNode", "");
            paths.Add("UploadDocNode", "uploadimages/");
            paths.Add("SupplementDocNode", "supplementimages/");
            this.pbPicture.MouseWheel += new MouseEventHandler(pbPicture_MouseWheel);
        }

        /// <summary>
        /// 验证是否CES系统单号
        /// </summary>
        /// <param name="datanbr"></param>
        /// <returns></returns>
        public bool CheckCesDataNbr(string datanbr)
        {
            var result = JObject.Parse(Common.HttpPost(Common.GetApiUrl("IsExistDocList"), string.Format("dataNbr={0}", datanbr)));
            if (result["data"] == null)
                return false;
            else
                return (bool)(JValue)result["data"];
        }

        /// <summary>
        /// 滑轮滚动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void pbPicture_MouseWheel(object sender, MouseEventArgs eventArgs)
        {

            if (eventArgs.Delta > 0)
            {
                Zoom(1);
            }
            else
            {
                if (pbPicture.Width < bitMap.Width / 10) return;
                Zoom(2);
            }
        }
        private void frmIndex_Load(object sender, EventArgs e)
        {
            _logger.Info("系统登录");
            AsposeLicense.ConfigKey();
            string msg;

            bInitFlag = opskyScan.InitOpSkyScan(this,out msg);
            if (!bInitFlag)
            {
                MessageBox.Show(msg, "提示");
                tslNormalScan.Enabled = false;
                toolStripLabel6.Enabled = false;
                tslSuppleScann.Enabled = false;
                tslSuppleUp.Enabled = false;
            }
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            imagePath = Path.Combine(basePath, "images");
            if (!Directory.Exists(imagePath)) Directory.CreateDirectory(imagePath);
            InitTreeView();
            panelTip.Location = new Point((panelTip.Parent.ClientSize.Width / 2) - (panelTip.Width / 2),
                (panelTip.Parent.ClientSize.Height / 2) - (panelTip.Height / 2));
            panelTip.Refresh();
            int count = GetNotReadMsgNum();
            if (count > 0)
            {
                Image img = Image.FromFile("icon/msg-active.png");
                var _bitMap = new Bitmap(img);
                tsMessage.Size = new Size(120, 80);
                tsMessage.Text = "我的消息" + "(" + "未读" + count + ")";
                tsMessage.Image = _bitMap;
                img.Dispose();
            }
            // GetCachData();
        }

        /// <summary>
        /// 上一个
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tslPrePage_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode node = null;
                if (treeView1.SelectedNode.PrevNode != null)
                {
                    node = treeView1.SelectedNode.PrevNode;
                }
                else
                {
                    node = treeView1.SelectedNode.Parent.LastNode;
                }
                InitImage(node.Tag.ToString());
                treeView1.SelectedNode = node;
                viewNode = node;
            }
            catch (Exception) { }

        }

        /// <summary>
        /// 下一个
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tslNextPage_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode node = null;
                if (treeView1.SelectedNode.NextNode != null)
                {
                    node = treeView1.SelectedNode.NextNode;
                }
                else
                {
                    node = treeView1.SelectedNode.Parent.FirstNode;
                }
                InitImage(node.Tag.ToString());
                treeView1.SelectedNode = node;
                viewNode = node;
            }
            catch (Exception) { }
        }

        /// <summary>
        /// 左旋转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tslLRotate90_Click(object sender, EventArgs e)
        {
            InitImage();
            // 顺时针旋转90度
            bitMap.RotateFlip(RotateFlipType.Rotate270FlipNone);
            pbPicture.Image = bitMap;
            bitMap.Save(treeView1.SelectedNode.Tag.ToString());
            InitImage();
        }

        /// <summary>
        /// 右旋转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tslRRotate90_Click(object sender, EventArgs e)
        {
            InitImage();
            // 顺时针旋转90度
            bitMap.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pbPicture.Image = bitMap;
            bitMap.Save(treeView1.SelectedNode.Tag.ToString());
            InitImage();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDownPoint.X = Cursor.Position.X;
                mouseDownPoint.Y = Cursor.Position.Y;
                isMove = true;
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMove = false;
            }
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove)
            {
                int x, y;
                int moveX, moveY;
                moveX = Cursor.Position.X - mouseDownPoint.X;
                moveY = Cursor.Position.Y - mouseDownPoint.Y;
                x = pbPicture.Location.X + moveX;
                y = pbPicture.Location.Y + moveY;
                pbPicture.Location = new Point(x, y);
                mouseDownPoint.X = Cursor.Position.X;
                mouseDownPoint.Y = Cursor.Position.Y;
            }
        }

        private void pbPicture_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMove = false;
            }
        }

        private void pbPicture_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDownPoint.X = Cursor.Position.X;
                mouseDownPoint.Y = Cursor.Position.Y;
                isMove = true;
            }
        }

        private void pbPicture_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMove)
            {
                int x, y;
                int moveX, moveY;
                moveX = Cursor.Position.X - mouseDownPoint.X;
                moveY = Cursor.Position.Y - mouseDownPoint.Y;
                x = pbPicture.Location.X + moveX;
                y = pbPicture.Location.Y + moveY;
                pbPicture.Location = new Point(x, y);
                mouseDownPoint.X = Cursor.Position.X;
                mouseDownPoint.Y = Cursor.Position.Y;
            }
        }

        /// <summary>
        /// 放大
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void tslEnlarge_Click(object sender, EventArgs e)
        {
            Zoom(1);
        }

        /// <summary>
        /// 缩小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tslNarrow_Click(object sender, EventArgs e)
        {
            if (pbPicture.Width < bitMap.Width / 10) return;
            Zoom(2);
        }

        /// <summary>
        /// 重新加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void tslRefresh_Click(object sender, EventArgs e)
        {
            InitImage();
        }

        /// <summary>
        /// 新建分组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            frmAddGroup addGroup = new frmAddGroup("AddGroup");
            addGroup.tree = treeView1;
            addGroup.ShowDialog();
        }

        /// <summary>
        /// 分组查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button1_Click(object sender, EventArgs e)
        {
            frmGroupSearch search = new frmGroupSearch();
            search.treeview = treeView1;
            search.ShowDialog();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Node.Checked)
                {
                    if (!selectNode.Contains(e.Node))
                        selectNode.Add(e.Node);
                }
                else
                {
                    if (selectNode.Contains(e.Node))
                        selectNode.Remove(e.Node);
                }

                txtRemark.Text = "";
                treeView1.SelectedNode = e.Node;
                if (e.Node.Nodes.Count == 0 && e.Node.Tag.ToString() != "UploadDocNode" && e.Node.Tag.ToString() != "DocNode" && e.Node.Tag.ToString() != "SupplementDocNode")
                {
                    viewNode = e.Node;
                    InitImage(e.Node.Tag.ToString());
                }
                tslPrePage.Enabled = tslNextPage.Enabled = tslLRotate90.Enabled =
                    tslRRotate90.Enabled = tslRefresh.Enabled = e.Node.Nodes.Count == 0 && e.Node.Tag.ToString() != "UploadDocNode";
            }
            else if (e.Button == MouseButtons.Right)
            {
                //根节点隐藏替换图片和批量删除右键菜单按钮
                if (e.Node.Parent == null)
                {
                    this.cmMenu.Items[0].Visible = true;
                    this.cmMenu.Items[1].Visible = false;
                    this.cmMenu.Items[2].Visible = true;
                    this.cmMenu.Items[3].Visible = false;
                }
                else
                {
                    this.cmMenu.Items[0].Visible = true;
                    this.cmMenu.Items[1].Visible = true;
                    this.cmMenu.Items[2].Visible = true;
                    this.cmMenu.Items[3].Visible = true;
                }
            }


        }

        /// <summary>
        /// 合并影像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tslMergeImage_Click(object sender, EventArgs e)
        {
            List<TreeNode> parentNode = new List<TreeNode>();
            List<TreeNode> checkNode = new List<TreeNode>();
            bool valid = true;
            foreach (TreeNode item in treeView1.Nodes)
            {
                foreach (TreeNode childItem in item.Nodes)
                {
                    if (childItem.Checked)
                    {
                        if (checkNode.Count > 0 && childItem.Parent != checkNode[0].Parent)
                        {
                            MessageBox.Show("只能合并同一单据下的影像!");
                            valid = false;
                            break;
                        }
                        checkNode.Add(childItem);
                    }
                }
                if (!valid)
                {
                    break;
                }
            }
            if (!valid)
            {
                return;
            }
            if (checkNode.Count != 2)
            {
                MessageBox.Show("请在左侧勾选两张影像进行合并!", "提示");
                return;
            }
            //开始合并
            frmMergeName frmCombinImage = new frmMergeName();
            frmCombinImage.checkNode = checkNode;
            frmCombinImage.Callback = MergeCallback;
            frmCombinImage.ShowDialog();
        }

        /// <summary>
        /// 撤销合并
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tslRevoke_Click(object sender, EventArgs e)
        {
            List<TreeNode> list = new List<TreeNode>();
            foreach (TreeNode item in treeView1.Nodes)
            {
                foreach (TreeNode childItem in item.Nodes)
                {
                    if (childItem.Checked)
                    {
                        list.Add(childItem);
                    }
                }
            }
            if (list.Count == 0)
            {
                MessageBox.Show("请在左侧勾选撤销合并的影像!", "提示");
                return;
            }
            if (list.Count > 1)
            {
                MessageBox.Show("只能勾选一个已合并的影像!", "提示");
                return;
            }
            var parentNode = list[0].Parent;
            var dataNbr = parentNode.Text;
            var path = "images/" + paths[parentNode.Tag.ToString()] + dataNbr;
            DirectoryInfo dir = new DirectoryInfo(Path.Combine(path, list[0].Text));
            //开始撤销合并
            if (!dir.Exists)
            {
                MessageBox.Show("选择的影像不是合并影像!", "提示");
                return;
            }
            var files = dir.GetFiles("*.jpg");

            FileInfo file1 = files[0];
            FileInfo file2 = files[1];

            //将合并文件夹的图片移动到单据文件夹下
            string file1Name = file1.Name;
            string file2Name = file2.Name;
            File.Delete(list[0].Tag.ToString());
            var oldTxtPath = list[0].Tag.ToString().Replace(".jpg", ".txt");
            if (File.Exists(oldTxtPath))
            {
                File.Delete(oldTxtPath);
            }

            file1Name = GetFileName(path, file1Name, dataNbr);
            File.Move(file1.FullName, Path.Combine(path, file1Name));
            var txtPath1 = file1.FullName.Replace(".jpg", ".txt");
            if (File.Exists(txtPath1))
            {
                File.Move(txtPath1, Path.Combine(path, file1Name.Replace(".jpg", ".txt")));
            }
            file2Name = GetFileName(path, file2Name, dataNbr);
            File.Move(file2.FullName, Path.Combine(path, file2Name));
            var txtPath2 = file2.FullName.Replace(".jpg", ".txt");
            if (File.Exists(txtPath2))
            {
                File.Move(txtPath2, Path.Combine(path, file2Name.Replace(".jpg", ".txt")));
            }
            //删除文件夹
            dir.Delete(true);
            //添加节点
            TreeNode node1 = new TreeNode();
            node1.Text = file1Name.Split('.')[0];
            node1.Tag = Path.Combine(path, file1Name);
            parentNode.Nodes.Add(node1);
            TreeNode node2 = new TreeNode();
            node2.Text = file2Name.Split('.')[0];
            node2.Tag = Path.Combine(path, file2Name);
            parentNode.Nodes.Add(node2);
            //删除节点
            list[0].Remove();
            var selectNode = treeView1.SelectedNode;
            if (selectNode != null)
            {
                InitImage(selectNode.Tag.ToString());
            }
            MessageBox.Show("撤销合并成功!", "提示");
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlNodeDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("你确定要删除 " + this.treeView1.SelectedNode.Text + " 吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    TreeNode node = treeView1.SelectedNode;
                    _logger.Info("单笔删除:" + node.Text);
                    if (node.Parent == null)
                    {
                        var root = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"images/");
                        if (node.Tag.ToString() == "UploadDocNode")
                        {
                            root += "uploadimages/";
                        }
                        else if (node.Tag.ToString() == "SupplementDocNode")
                        {
                            root += "supplementimages/";
                        }
                        //选中节点下有子节点删除及整个文件夹
                        Directory.Delete(root + node.Text, true);
                    }
                    else
                    {
                        var root = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images/");
                        if (node.Parent.Tag.ToString() == "UploadDocNode")
                        {
                            root += "uploadimages/";
                        }
                        else if (node.Tag.ToString() == "SupplementDocNode")
                        {
                            root += "supplementimages/";
                        }
                        var dirPath = string.Format(@"{0}{1}/{2}", root, node.Parent.Text, node.Text);
                        if (Directory.Exists(dirPath))
                        {
                            Directory.Delete(dirPath, true); //选择的影像为合并影像,删除合并前影像文件
                        }
                        var filePath = node.Tag.ToString();
                        if (File.Exists(filePath))
                            File.Delete(filePath);
                        var parentDir = new FileInfo(filePath).Directory;
                        if (parentDir != null && parentDir.Exists)
                        {
                            var txtPath = parentDir + "/" + node.Text + ".txt";
                            if (File.Exists(txtPath)) File.Delete(txtPath);
                            if (parentDir.GetFiles().Length == 0)
                            {
                                parentDir.Delete(true);
                                node.Parent.Remove();
                            }
                        }
                        pbPicture.Image = null;
                    }
                    node.Remove();
                    selectNode.Remove(node);
                    //foreach (TreeNode nodes in this.treeView1.Nodes)
                    //{
                    //    nodes.Checked = false;
                    //    foreach (TreeNode childNodes in nodes.Nodes)
                    //    {
                    //        childNodes.Checked = false;
                    //    }
                    //}
                    MessageBox.Show("删除成功!", "提示");
                }
            }
            catch (Exception exception)
            {
                _logger.Info("单笔删除异常:" + exception.ToString());
            }
        }



        /// <summary>
        /// 修改名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsAlterName_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            if (node.Nodes.Count == 0 && node.ToString() != "UploadDocNode" && node.Tag.ToString() != "DocNode" &&
                node.Tag.ToString() != "SupplementDocNode")
            {
                treeView1.LabelEdit = true;
                node.BeginEdit();
            }
            else
            {
                MessageBox.Show("单号不允许修改!", "提示");
            }
        }

        /// <summary>
        /// 修改节点名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(e.Label))
                {
                    List<string> fileName = new List<string>();
                    foreach (TreeNode item in e.Node.Parent.Nodes)
                    {
                        fileName.Add(item.Text);
                    }
                    if (!fileName.Contains(e.Label))
                    {
                        var root = "images/" + paths[e.Node.Parent.Tag.ToString()];
                        var imgPath = string.Format(@"{0}{1}/{2}", root, e.Node.Parent.Text, e.Label + ".jpg");
                        File.Move(e.Node.Tag.ToString(), imgPath);
                        var txtPath = e.Node.Tag.ToString().Replace(".jpg", ".txt");
                        if (File.Exists(txtPath))
                        {
                            File.Move(txtPath, imgPath.Replace(".jpg", ".txt"));
                        }

                        //判断是否合并后的影像修改名称
                        DirectoryInfo dir = new DirectoryInfo(Path.GetDirectoryName(imgPath) + "/" + e.Node.Text);
                        if (dir.Exists)
                        {
                            dir.MoveTo(Path.GetDirectoryName(imgPath) + "/" + e.Label);
                        }
                        e.Node.Text = e.Label;
                        e.Node.Tag = imgPath;
                        MessageBox.Show("修改成功!", "提示");
                    }
                    else
                    {
                        e.CancelEdit = true;
                        MessageBox.Show("单据不允许修改!", "提示");
                    }
                }
                else
                {
                    e.CancelEdit = true;
                    MessageBox.Show("请输入新的名称!", "提示");
                }
            }
            catch (Exception exception)
            {
                _logger.Info(string.Format("修改单据号异常:" + exception.ToString()));
            }
        }

        private void tslNormalScan_Click(object sender, EventArgs e)
        {
            _logger.Info(string.Format("正常扫描开始***************************"));
            txtLog.Clear();
            isscann = true;
            isreturnscann = false;
            isreplacescann = false;
            issupplementscann = false;
            button5.Enabled = true;
            datanbr = "";
            tslNormalScan.Enabled = false;
            savePath = "";
            isFirstScan = false;
            if (bInitFlag)
            {
                opskyScan.Scan(this);
                tslNormalScan.Enabled = true;
            }
            _logger.Info(string.Format("正常扫描结束***************************"));            
            //InitImage();
        }

        private void toolStripLabel6_Click(object sender, EventArgs e)
        {
            _logger.Info(string.Format("替换扫描开始***************************"));
            isscann = false;
            button5.Enabled = true;
            isreturnscann = false;
            isreplacescann = true;
            issupplementscann = false;
            datanbr = "";
            var node = treeView1.SelectedNode;
            if (node == null || node.Parent == null)
            {
                MessageBox.Show("请在左侧选中要替换扫描的影像!", "提示");
                _logger.Info(string.Format("请在左侧选中要替换扫描的影像,本次扫描结束***************************"));
                return;
            }
            curNode = node.Parent;
            replaceNode = node;
            savePath = Path.Combine(imagePath, curNode.Text);
            if (bInitFlag)
            {
                opskyScan.Scan(this);
                tslNormalScan.Enabled = true;
            }
            _logger.Info(string.Format("替换扫描结束***************************"));
            //InitImage();
        }

        private void tslSuppleScann_Click(object sender, EventArgs e)
        {
            _logger.Info(string.Format("补充扫描开始***************************"));
            isscann = false;
            button5.Enabled = true;
            isreturnscann = false;
            isreplacescann = false;
            issupplementscann = true;
            datanbr = "";
            var node = treeView1.SelectedNode;
            if (node == null || node.Parent != null)
            {
                MessageBox.Show("请在左侧选中要补充扫描的单据!", "提示");
                _logger.Info(string.Format("请在左侧选中要补充扫描的单据,本次扫描结束***************************"));
                return;
            }
            curNode = node;

            savePath = Path.Combine(imagePath, Path.Combine(paths[node.Tag.ToString()], curNode.Text));
            if (bInitFlag)
            {                
                opskyScan.Scan(this);
                tslNormalScan.Enabled = true;
            }
            _logger.Info(string.Format("补充扫描结束***************************"));
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            frmOpen frm = new frmOpen();
            frm.treeView = treeView1;
            frm.ShowDialog();
        }
        /// <summary>
        /// 实时上传点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                button5.Enabled = false;
                _logger.Info(string.Format("实时上传开始***************************"));
                var newDataNbrs = new List<string>();
                var oldDataNbrs = new List<string>();
                var uploadData = new List<UploadDataNbr>();
                foreach (TreeNode item in treeView1.Nodes)
                {
                    if (item.Nodes.Count == 0 || item.Tag.ToString() == "SupplementDocNode" || item.Text.ToString() == "0000000000") continue;
                    if (item.Tag.ToString() == "DocNode")
                    {
                        newDataNbrs.Add(item.Text);
                        uploadData.Add(new UploadDataNbr
                        {
                            DataNbr = item.Text,
                            Kind = 0
                        });
                    }
                    else
                    {
                        oldDataNbrs.Add(item.Text);
                        uploadData.Add(new UploadDataNbr
                        {
                            DataNbr = item.Text,
                            Kind = 1
                        });
                    }
                }
                if (uploadData.Count == 0)
                {
                    button5.Enabled = true;
                    txtLog.AppendText("没有实时上传数据\r\n");
                    return;
                }

                foreach (var item in uploadData)
                {
                    var path = "images/" + (item.Kind == 1 ? "uploadimages/" : item.Kind == 2 ? "supplementimages/" : "") + item.DataNbr;
                    path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
                    if (!Directory.Exists(path))
                    {
                        button5.Enabled = true;
                        _logger.Info("文件路径不存在:" + path);
                        MessageBox.Show("文件路径不存在:" + path, "异常");
                        return;
                    }
                }
                if (newDataNbrs.Count > 0 || oldDataNbrs.Count > 0)
                {
                    var uploadDataNbrs = CheckUploadImage(string.Join(",", newDataNbrs.ToArray()));
                    if (!string.IsNullOrEmpty(uploadDataNbrs))
                    {
                        _logger.Info(string.Format("以下单据已上传过影像:\n{0}\n请调出影像进行补扫,上传失败!", uploadDataNbrs));
                        MessageBox.Show(string.Format("以下单据已上传过影像:\n{0}\n请调出影像进行补扫,上传失败!", uploadDataNbrs), "提示");
                        this.button5.Enabled = true;
                        return;
                    }
                    var dataNbrIsExist = CheckDataNbrIsExitDocList(string.Join(",", newDataNbrs.ToArray()));
                    if (!string.IsNullOrEmpty(dataNbrIsExist))
                    {
                        _logger.Info(string.Format("以下单据不存在Ces系统中:\n{0}\n,上传失败!", dataNbrIsExist));
                        MessageBox.Show(string.Format("以下单据不存在Ces系统中:\n{0}\n,上传失败!", dataNbrIsExist), "提示");
                        this.button5.Enabled = true;
                        return;
                    }
                    if (oldDataNbrs.Count > 0)
                    {
                        Common.HttpPost(Common.GetApiUrl("DeleteImage"),
                            string.Format("dataNbr={0}&image=&kind=0&isUpload=Y", string.Join(",", oldDataNbrs.ToArray())));
                    }
                    //newDataNbrs.AddRange(oldDataNbrs);
                    //Common.HttpPost(Common.GetApiUrl("AddImageInfo"),
                    //    string.Format("dataNbrs={0}&userID={1}", string.Join(",", newDataNbrs.ToArray()), USERID));
                    panelTip.Visible = true;
                    panelTip.BringToFront();
                    scanUpload = new ScanUpload(uploadCallBack, setProgressBar, initTipInfo, Common.GetApiUrl("NewUploadImage"), USERID,
                        uploadData);
                    new Thread(scanUpload.Upload).Start();
                }
                _logger.Info(string.Format("实时上传结束***************************"));
            }
            catch (Exception exception)
            {
                _logger.Info(string.Format("实时上传异常:{0}", exception.ToString()));
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (scanUpload != null) scanUpload.cancelUpload = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var node = treeView1.SelectedNode;
            if (node == null || node.Parent == null)
            {
                MessageBox.Show("请选择要备注的影像!", "提示");
                return;
            }
            var remark = txtRemark.Text.Trim();
            if (string.IsNullOrEmpty(remark))
            {
                MessageBox.Show("请输入备注信息!", "提示");
                return;
            }
            var filePath = "images/" + paths[node.Parent.Tag.ToString()] + node.Parent.Text + "/" + node.Text + ".txt";
            File.WriteAllText(filePath, remark);
            MessageBox.Show("备注成功!", "提示");
        }

        private void tsMessage_Click(object sender, EventArgs e)
        {

            frmMessage frm = new frmMessage();
            frm.eventrefresh += MessageRefresh;
            frm.userID = USERID;
            frm.teee = treeView1;
            frm.ShowDialog();
        }


        void MessageRefresh()
        {
            int count = GetNotReadMsgNum();
            if (count > 0)
            {
                Image img = Image.FromFile("icon/msg-active.png");
                var _bitMap = new Bitmap(img);
                tsMessage.Size = new Size(120, 80);
                tsMessage.Text = "我的消息" + "(" + "未读" + count + ")";
                tsMessage.Image = _bitMap;
                img.Dispose();
            }
            else
            {
                Image img = Image.FromFile("icon/msg-normal.png");
                var _bitMap = new Bitmap(img);
                tsMessage.Size = new Size(65, 80);
                tsMessage.Text = "我的消息";
                tsMessage.Image = _bitMap;
                img.Dispose();
            }

        }
        /// <summary>
        /// 放大缩小
        /// </summary>
        /// <param name="kind">1：放大 2：缩小</param>
        private void Zoom(int kind)
        {
            if (kind == 1)
            {
                pbPicture.Width += zoomStep;
                pbPicture.Height += zoomStep;
            }
            else
            {
                pbPicture.Width -= zoomStep;
                pbPicture.Height -= zoomStep;
            }

            //PropertyInfo pInfo = pbPicture.GetType().GetProperty("ImageRectangle", BindingFlags.Instance |
            //                                                                       BindingFlags.NonPublic);
            //Rectangle rect = (Rectangle)pInfo.GetValue(pbPicture, null);

            //pbPicture.Width = rect.Width;
            //pbPicture.Height = rect.Height;

            pbPicture.Location = new Point((pbPicture.Parent.ClientSize.Width / 2) - (pbPicture.Width / 2),
                (pbPicture.Parent.ClientSize.Height / 2) - (pbPicture.Height / 2) + 300);
            pbPicture.Refresh();
        }

        /// <summary>
        /// 初始化图片
        /// </summary>
        /// <param name="filePath"></param>
        void InitImage(string filePath = "")
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                if (bitMap != null) bitMap.Dispose();
                Image img = Image.FromFile(filePath);
                bitMap = new Bitmap(img);
                pbPicture.Image = bitMap;
                img.Dispose();
                var txtPath = filePath.Replace(".jpg", ".txt");
                if (File.Exists(txtPath)) txtRemark.Text = File.ReadAllText(txtPath);
            }
            if (bitMap.Width >= panel2.Width)
                pbPicture.Width = Convert.ToInt32(panel2.Width * 0.8);
            else
                pbPicture.Width = bitMap.Width;
            pbPicture.Height = bitMap.Height;
            pbPicture.SizeMode = PictureBoxSizeMode.Zoom;
            int x = (pbPicture.Parent.ClientSize.Width / 2) - (pbPicture.Width / 2);
            int y = (pbPicture.Parent.ClientSize.Height / 2) - (pbPicture.Height / 2) + 300;
            pbPicture.Location = new Point(x, y);
            pbPicture.Refresh();
        }

        /// <summary>
        /// 初始化文件列表
        /// </summary>
        void InitTreeView()
        {
            treeView1.Nodes.Clear();
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\images")) //检查文件夹是否存在
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + @"\images");
            DirectoryInfo dir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + @"\images");
            foreach (DirectoryInfo folder in dir.GetDirectories())
            {
                DirectoryInfo[] dirs = folder.GetDirectories();
                SortAsFolderCreationTime(ref dirs);
                if (folder.Name == "uploadimages")
                {
                    foreach (var childFolder in dirs)
                    {
                        TreeNode node = new TreeNode();
                        node.Tag = "UploadDocNode";
                        node.Text = childFolder.Name;
                        var newfile = childFolder.GetFiles("*.jpg");
                        Array.Sort(newfile, new FileNameSort());

                        foreach (FileInfo file in newfile)
                        {
                            TreeNode childCode = new TreeNode();
                            childCode.Text = file.Name.Split('.')[0];
                            childCode.Tag = file.FullName;
                            node.Nodes.Add(childCode);
                        }
                        treeView1.Nodes.Add(node);
                        TreeViewExtension.HideCheckBox(treeView1, node);
                    }
                }
                else if (folder.Name == "supplementimages")
                {
                    foreach (var childFolder in dirs)
                    {
                        TreeNode node = new TreeNode();
                        node.Tag = "SupplementDocNode";
                        node.Text = childFolder.Name;
                        var newfile = childFolder.GetFiles("*.jpg");
                        Array.Sort(newfile, new FileNameSort());

                        foreach (FileInfo file in newfile)
                        {
                            TreeNode childCode = new TreeNode();
                            childCode.Text = file.Name.Split('.')[0];
                            childCode.Tag = file.FullName;
                            node.Nodes.Add(childCode);
                        }
                        treeView1.Nodes.Add(node);
                        TreeViewExtension.HideCheckBox(treeView1, node);
                    }
                }
                else
                {
                    TreeNode node = new TreeNode();
                    node.Tag = "DocNode";
                    node.Text = folder.Name;
                    var newfile = folder.GetFiles("*.jpg");
                    Array.Sort(newfile, new FileNameSort());

                    foreach (FileInfo file in newfile)
                    {
                        TreeNode childCode = new TreeNode();
                        childCode.Text = file.Name.Split('.')[0];
                        childCode.Tag = file.FullName;
                        node.Nodes.Add(childCode);
                    }
                    treeView1.Nodes.Add(node);
                    TreeViewExtension.HideCheckBox(treeView1, node);
                }
            }
            treeView1.ExpandAll();
        }

        /// <summary>
        /// C#按文件夹夹创建时间排序（顺序）
        /// </summary>
        /// <param name="dirs">待排序文件夹数组</param>
        private void SortAsFolderCreationTime(ref DirectoryInfo[] dirs)
        {
            Array.Sort(dirs, delegate (DirectoryInfo x, DirectoryInfo y)
            {
                return x.CreationTime.CompareTo(y.CreationTime);
            });
        }

        /// <summary>
        /// 文件名排序
        /// </summary>
        public class FileNameSort : IComparer
        {

            //调用DLL
            [DllImport("Shlwapi.dll", CharSet = CharSet.Unicode)]
            private static extern int StrCmpLogicalW(string param1, string param2);


            //前后文件名进行比较。
            public int Compare(object name1, object name2)
            {
                if (null == name1 && null == name2)
                {
                    return 0;
                }
                if (null == name1)
                {
                    return -1;
                }
                if (null == name2)
                {
                    return 1;
                }
                return StrCmpLogicalW(name1.ToString(), name2.ToString());
            }

        }

        /// <summary>
        /// 获取撤销还原后的新文件名称
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <param name="dataNbr"></param>
        /// <returns></returns>

        string GetFileName(string path, string name, string dataNbr)
        {
            if (File.Exists(Path.Combine(path, name)))
            {
                int num = Directory.GetFiles(path, "*.jpg").Length + 1;
                var newName = dataNbr + "_" + num + ".jpg";
                while (File.Exists(Path.Combine(path, newName)))
                {
                    num++;
                    newName = dataNbr + "_" + num + ".jpg";
                }
                name = newName;
            }
            return name;
        }

        #region 扫描仪

        /// <summary>
        /// 初始化飞利浦扫描仪
        /// </summary>
        //void InitScan()
        //{
        //    int err = 0;
        //    int bAlert = 1;
        //    int sts = scan.InitInstance("CES Image Scan", this.Handle, bAlert, out err);
        //    if (sts == 0)
        //    {
        //        bInitFlag = true;
        //        var basePath = AppDomain.CurrentDomain.BaseDirectory;
        //        logPath = Path.Combine(basePath, "log");
        //        imagePath = Path.Combine(basePath, "images");
        //        iniPath = Path.Combine(basePath, "PacsScanInf_ICP_E.ini");
        //        if (!Directory.Exists(logPath)) Directory.CreateDirectory(logPath);
        //        if (!Directory.Exists(imagePath)) Directory.CreateDirectory(imagePath);
        //        logPath = Path.Combine(logPath, "info.log");
        //        strScanInf = iniPath;
        //        new IniHelper(iniPath).IniWriteValue("FILEINFO", "DirBase", imagePath);
        //        sts = scan.CheckIniFile(0, iniPath, logPath, out err);
        //        if (sts != 0) MessageBox.Show("初始化配置文件失败!");
        //    }
        //    else
        //    {
        //        MessageBox.Show("启动扫描仪失败!");
        //    }
        //}        
        //飞利浦扫描
        //void Scan()
        //{
        //    if (bInitFlag)
        //    {

        //        int err = 0;
        //        int sts;
        //        IntPtr lpFunc2 = new IntPtr();
        //        ScanCtrl.PageEndCallBack func = new ScanCtrl.PageEndCallBack(ScanCallback);
        //        sts = scan.EntryEventFunc(func, lpFunc2, out err);
        //        PageCnt = 0;
        //        try
        //        {
        //            sts = scan.ScanExec(strScanInf, strCstmInf, 1, false, out err);
        //            string errMsg = Common.ErrorMsg.ContainsKey(err) ? Common.ErrorMsg[err] : "没有对应的错误信息";
        //            _logger.Info(string.Format("扫描设备提示：代码:{0}|信息:{1}!", err, errMsg));
        //        }
        //        catch (Exception ex)
        //        {
        //            _logger.Info(string.Format("系统异常,{0}!", ex.ToString()));
        //            MessageBox.Show(string.Format("系统异常,请重新扫描,{0}!", ex.ToString()), "提示");
        //        }
        //        finally
        //        {
        //            tslNormalScan.Enabled = true;
        //            if (errDataNbr.Count > 0)
        //            {
        //                _logger.Info("扫描出相同的单号:" + string.Join(",", errDataNbr.ToArray()));
        //                MessageBox.Show("扫描出相同的单号:" + string.Join(",", errDataNbr.ToArray()), "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            }
        //            errDataNbr.Clear();
        //        }
        //    }
        //}       


        /// <summary>
        /// 扫描回调
        /// </summary>
        /// <param name="pPage"></param>
        /// <returns></returns>
        //int ScanCallback(ref ScanPageinfo pPage)
        //{
        //    try
        //    {
        //        int err = 0;
        //        StringBuilder temp = new StringBuilder("", 100000);
        //        scan.GetFileName(temp, out err);
        //        var path = temp.ToString();
        //        ScanBarCode(path);
        //        pageCnt++;
        //        _logger.Info(string.Format("扫描回调:当前扫描第{0}次,返回提示代码:{1},", pageCnt, err));
        //        return 0;
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.Info(string.Format("扫描回调异常,{0}!", e.ToString()));
        //        MessageBox.Show(string.Format("扫描回调异常,{0}!", e.ToString()), "提示");
        //        return 0;
        //    }
        //}

        /// <summary>
        /// 条形码识别
        /// </summary>
        /// <param name="fileName"></param>
        public void ScanBarCode(string fileName)
        {
            _logger.Info("条形码识别开始***************************");
            DateTime now = DateTime.Now;
            //var basePath = AppDomain.CurrentDomain.BaseDirectory;
            //imagePath = Path.Combine(basePath, "images");
            //if (!Directory.Exists(imagePath)) Directory.CreateDirectory(imagePath);
            using (Image primaryImage = Image.FromFile(fileName))
            {
                //判断是否替换扫描(替换扫描只替换一张影像)
                if (replaceNode != null)
                {
                    _logger.Info(string.Format("替换扫描:替换文件路径{0}", replaceNode.Tag.ToString()));
                    var filePath = replaceNode.Tag.ToString();
                    primaryImage.Save(filePath);
                    if (viewNode == replaceNode)
                    {
                        new Thread(() => this.Invoke(new EventHandler(delegate
                        {
                            InitImage(filePath);
                        }))).Start();
                    }
                    replaceNode = null;
                    return;
                }
                var barCode = "";
                if (issupplementscann || isreplacescann || isreturnscann)
                {
                    barCode = "";
                }
                else
                {
                    barCode = AsposeBarCode(fileName);
                    _logger.Info(string.Format("条形码识别:{0}", string.IsNullOrWhiteSpace(barCode) ? "未识别到条形码" : barCode));
                }

                if (!string.IsNullOrEmpty(barCode))
                {
                    // savePath = string.Empty;
                    var dataNbr = barCode;
                    if (CheckCesDataNbr(dataNbr))
                    {
                        _logger.Info(string.Format("条形码识别校验成功{0}", barCode));
                        txtLog.AppendText("单据号:" + dataNbr + "\r\n");
                        isFirstScan = true;
                        savePath = Path.Combine(imagePath, dataNbr);
                        if (!Directory.Exists(savePath))
                        {
                            _logger.Info(string.Format("本地不存在单号{0}的文件夹,正常加入影像列表", barCode));
                            curNode = new TreeNode(dataNbr);
                            curNode.Tag = "DocNode";
                            Directory.CreateDirectory(savePath);
                            treeView1.Nodes.Add(curNode);
                            TreeViewExtension.HideCheckBox(treeView1, curNode);
                        }
                        else
                        {
                            _logger.Info(string.Format("本地已经存在单号{0}的文件夹", barCode));
                            if (isscann)
                            {
                                _logger.Info(string.Format("正常扫描&重复单据号{0}", barCode));
                                //重复单据扫描优化提示
                                errDataNbr.Add(dataNbr);
                                var fileInfo = Directory.GetDirectories(imagePath);
                                var count = 0;
                                foreach (var item in fileInfo)
                                {
                                    if (item.IndexOf(dataNbr) > 0)
                                    {
                                        count++;
                                    }
                                }
                                savePath = Path.Combine(imagePath, dataNbr + "重复" + count);
                                curNode = new TreeNode(dataNbr + "重复" + count);
                                curNode.Tag = "DocNode";
                                Directory.CreateDirectory(savePath);
                                treeView1.Nodes.Add(curNode);
                                TreeViewExtension.HideCheckBox(treeView1, curNode);
                            }
                            else
                            {
                                //根据单据号获取节点
                                foreach (TreeNode item in treeView1.Nodes)
                                {
                                    if (item.Text == dataNbr)
                                    {
                                        curNode = item;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        _logger.Info(string.Format("不符合单据规则的条形码{0}", barCode));
                        txtLog.AppendText("不符合单据规则的条形码:" + dataNbr + "\r\n");
                    }


                    //正常扫描未识别的条形码都放在一个节点下
                    if (!isFirstScan && string.IsNullOrEmpty(savePath))
                    {
                        _logger.Info(string.Format("正常扫描未识别的条形码{0}", barCode));
                        var code = "0000000000";
                        datanbr = "";
                        savePath = Path.Combine(imagePath, code);

                        if (!Directory.Exists(savePath))
                        {
                            curNode = new TreeNode(code);
                            curNode.Tag = "DocNode";
                            Directory.CreateDirectory(savePath);
                            treeView1.Nodes.Add(curNode);
                            TreeViewExtension.HideCheckBox(treeView1, curNode);
                        }
                        else
                        {
                            //根据单据号获取节点
                            foreach (TreeNode item in treeView1.Nodes)
                            {
                                if (item.Text == code)
                                {
                                    curNode = item;
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    _logger.Info("条形码识别校验：未识别到条形码");
                }
                if (!string.IsNullOrEmpty(savePath) && Directory.Exists(savePath))
                {
                    var orderbyno = 0;
                    var fileNum = 0;
                    if (datanbr != "")
                        orderbyno = GetOrderByNo(datanbr);
                    var fileslength = Directory.GetFiles(savePath, "*.jpg").Length;
                    if (orderbyno < 0)
                        fileNum = fileslength + 1;
                    else
                        fileNum = orderbyno + 1;
                    var newName = curNode.Text + "_" + fileNum;
                    while (File.Exists(Path.Combine(savePath, newName + ".jpg")))
                    {
                        fileNum += 1;
                        newName = curNode.Text + "_" + fileNum;
                    }
                    var filePath = Path.Combine(savePath, newName + ".jpg");
                    primaryImage.Save(filePath);
                    var node = new TreeNode(newName);
                    node.Tag = filePath;
                    curNode.Nodes.Add(node);
                    _logger.Info("新增影像:" + node.Text + "到" + curNode.Text + "下");
                }
                else
                {
                    _logger.Info("附件保存失败,文件路径(" + savePath + ")!");
                }
                _logger.Info(string.Format("条形码识别结束***************************"));
            }
        }


        /// <summary>
        /// 处理图片灰度
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        Bitmap MakeGrayscale3(Bitmap original)
        {

            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            System.Drawing.Imaging.ColorMatrix colorMatrix = new System.Drawing.Imaging.ColorMatrix(
               new float[][]
              {
                 new float[] {.3f, .3f, .3f, 0, 0},
                 new float[] {.59f, .59f, .59f, 0, 0},
                 new float[] {.11f, .11f, .11f, 0, 0},
                 new float[] {0, 0, 0, 1, 0},
                 new float[] {0, 0, 0, 0, 1}
              });

            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();
            return newBitmap;
        }

        #endregion

        void initTipInfo(string dataNbr, int len)
        {
            if (this.InvokeRequired)
            {
                InitTipInfo inittipInfo = new InitTipInfo(initTipInfo);
                this.Invoke(inittipInfo, new object[] { dataNbr, len });
            }
            else
            {
                lblNbr.Text = dataNbr;
                lblNum.Text = string.Format("已上传:0/{0}张", len);
                progressBar1.Maximum = len;
                progressBar1.Value = 0;
            }
        }

        void setProgressBar(int ipos, int count)
        {
            if (this.InvokeRequired)
            {
                SetPos setpos = new SetPos(setProgressBar);
                this.Invoke(setpos, new object[] { ipos, count });
            }
            else
            {
                progressBar1.Value = ipos;
                lblNum.Text = "已上传:" + ipos + "/" + count + "张";
            }
        }

        void uploadCallBack(string dataNbr, List<string> paths, List<string> error, int kind, int docType)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    UploadCallBack callBack = new UploadCallBack(uploadCallBack);
                    this.Invoke(callBack, new object[] { dataNbr, paths, error, kind, docType });
                }
                else
                {
                    if (kind == 0)
                    {
                        foreach (var item in paths)
                        {
                            if (File.Exists(item))
                            {
                                File.Delete(item);
                                var txtPath = item.Replace(".jpg", ".txt");
                                if (File.Exists(txtPath))
                                {
                                    File.Delete(txtPath);
                                }
                            }
                        }

                        //var filePath = "images/" + (docType == 1 ? "uploadimages/" : docType == 2 ? "supplementimages/" : "") + dataNbr;

                        var filePath = "images/" + (docType == 1 ? "uploadimages/" : docType == 2 ? "supplementimages/" : "") + dataNbr;
                        filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);

                        if (Directory.Exists(filePath) && Directory.GetFiles(filePath).Length == 0)
                        {
                            Directory.Delete(filePath, true);
                        }
                    }
                    else
                    {
                        //MessageBox.Show(kind == 1 ? "上传完成!" : "取消成功!", "提示");
                        if (paths.Count > 0)
                        {
                            foreach (var item in paths)
                            {
                                if (File.Exists(item))
                                {
                                    File.Delete(item);
                                    var txtPath = item.Replace(".jpg", ".txt");
                                    if (File.Exists(txtPath))
                                    {
                                        File.Delete(txtPath);
                                    }
                                }
                            }

                            var filePath = "images/" + dataNbr;
                            if (Directory.Exists(filePath) && Directory.GetFiles(filePath).Length == 0)
                            {
                                Directory.Delete(filePath, true);
                            }
                            var filePath2 = "images/uploadimages" + dataNbr;
                            if (Directory.Exists(filePath2) && Directory.GetFiles(filePath2).Length == 0)
                            {
                                Directory.Delete(filePath2, true);
                            }
                            var filePath3 = "images/supplementimages" + dataNbr;
                            if (Directory.Exists(filePath3) && Directory.GetFiles(filePath3).Length == 0)
                            {
                                Directory.Delete(filePath3, true);
                            }
                        }

                        if (error.Count > 0)
                            MessageBox.Show(string.Join("\n\r", error.ToArray()), "上传错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.button5.Enabled = true;
                        this.button4.Enabled = true;
                        this.InitTreeView();
                        this.panelTip.Visible = false;
                        this.pbPicture.Image = null;
                    }
                }
            }
            catch (Exception e)
            {
                _logger.Info(string.Format("回调函数异常:" + e.ToString()));
            }
        }

        string CheckUploadImage(string dataNbrs)
        {
            var result = JObject.Parse(Common.HttpPost(Common.GetApiUrl("CheckUploadImage"), string.Format("dataNbrs={0}", dataNbrs)));
            var data = result["data"].ToString();
            return data;
        }
        string CheckDataNbrIsExitDocList(string dataNbrs)
        {
            try
            {
                var result = JObject.Parse(Common.HttpPost(Common.GetApiUrl("CheckDataNbrIsExitDocList"), string.Format("dataNbrs={0}", dataNbrs)));
                var data = result["data"].ToString();
                return data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return "接口异常";
            }

        }

        int GetOrderByNo(string dataNbrs)
        {
            var result = JObject.Parse(Common.HttpPost(Common.GetApiUrl("GetOrderByNo"), string.Format("dataNbrs={0}", dataNbrs)));
            var data = result["data"];
            return (int)data;
        }




        /// <summary>
        /// 合并成功之后的回调方法
        /// </summary>
        /// <param name="node">合并之后的新节点</param>
        void MergeCallback(TreeNode node)
        {
            treeView1.SelectedNode = node;
            InitImage(node.Tag.ToString());
            txtRemark.Text = "";
        }

        /// <summary>
        /// 获取未读消息数量
        /// </summary>
        /// <returns></returns>
        int GetNotReadMsgNum()
        {
            var result = JObject.Parse(Common.HttpPost(Common.GetApiUrl("GetNotReadMessageNum"), string.Format("userID={0}", USERID)));
            return Convert.ToInt32(Convert.ToBoolean(result["success"].ToString()) ? result["data"].ToString() : "0");
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            frmConfig frm = new frmConfig();
            frm.ShowDialog();
        }

        private void frmIndex_FormClosed(object sender, FormClosedEventArgs e)
        {
            _logger.Info("系统退出");
            if (bInitFlag)
            {
                //int err = 0;
                //int sts;
                //sts = scan.ExitInstance(out err);
            }
            Dispose();
            Process process = Process.GetProcessById(Process.GetCurrentProcess().Id);
            process.Kill();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                int count = GetNotReadMsgNum();
                if (count > 0)
                {
                    Image img = Image.FromFile("icon/msg-active.png");
                    var _bitMap = new Bitmap(img);
                    tsMessage.Size = new Size(120, 80);
                    tsMessage.Text = "我的消息" + "(" + "未读" + count + ")";
                    tsMessage.Image = _bitMap;
                    img.Dispose();
                }
                else
                {
                    Image img = Image.FromFile("icon/msg-normal.png");
                    var _bitMap = new Bitmap(img);
                    tsMessage.Size = new Size(65, 80);
                    tsMessage.Text = "我的消息";
                    tsMessage.Image = _bitMap;
                    img.Dispose();

                }
            }
            catch (Exception)
            {

            }

        }

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //只处理左键拖拽操作；
                curNode = null;
                TreeNode _node = (TreeNode)e.Item;
                //只允许拖拽子级节点；
                if (_node.Level > 0)
                {
                    //开始拖拽；
                    DoDragDrop(e.Item, DragDropEffects.Move | DragDropEffects.Copy);
                }
            }

        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            //try
            //{
            //    if (e.Data.GetDataPresent(typeof(TreeNode)))
            //        e.Effect = DragDropEffects.Move;
            //    else
            //        e.Effect = DragDropEffects.None;
            //}
            //catch (Exception e1)
            //{

            //}

        }

        private void treeView1_DragOver(object sender, DragEventArgs e)
        {
            //获取当前拖拽到的目标节点；
            TreeNode _node2 = treeView1.GetNodeAt(treeView1.PointToClient(new Point(e.X, e.Y)));

            //清除前一个目标节点的颜色标识；
            if (_node2 == null || !_node2.Equals(curNode))
            {
                if (curNode != null)
                {
                    curNode.BackColor = Color.Empty;
                }
            }
            curNode = null;

            if (_node2 != null)
            {
                //顶级节点，允许
                curNode = _node2;
                curNode.BackColor = Color.Gray;
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                //禁止；
                e.Effect = DragDropEffects.None;
            }
        }
        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (curNode != null)
                {
                    TreeNode _node = (TreeNode)e.Data.GetData(typeof(TreeNode));
                    if (!curNode.Equals(_node))
                    {

                        if (curNode.Level == _node.Level)
                        {
                            //1. 不同的父节点；
                            //2. 被拖拽的节点不在目标节点的上面（相邻）；
                            if (!_node.Parent.Equals(curNode.Parent) || curNode.Index - 1 != _node.Index)
                            {

                                var destfeilname = "";
                                TreeNode DragNode = null;
                                TreeNode DragNode1 = null;
                                DragNode = _node;
                                DragNode1 = _node.Parent;
                                _node.Remove();
                                if (curNode.Parent.Tag.ToString() == "UploadDocNode")
                                {
                                    destfeilname = Rename(paths[curNode.Parent.Tag.ToString()] + curNode.Parent.Text, "UploadDocNode");
                                }
                                else if (curNode.Parent.Tag.ToString() == "SupplementDocNode")
                                {
                                    destfeilname = Rename(paths[curNode.Parent.Tag.ToString()] + curNode.Parent.Text, "SupplementDocNode");
                                }
                                else
                                {
                                    destfeilname = Rename(curNode.Parent.Text, "");
                                }


                                moveFiles(Path.Combine("images", paths[DragNode1.Tag.ToString()] + DragNode1.Text), Path.Combine("images", paths[curNode.Parent.Tag.ToString()] + curNode.Parent.Text), DragNode.Text + ".jpg", destfeilname + ".jpg");
                                //  DragNode.Text=DropNode.Parent.Text
                                // 在目标节点下增加被拖拽节点
                                DragNode.Text = destfeilname;//节点重命名

                                InitTreeView();//初始化文件列表，刷新改变后的文件路径
                                curNode.Parent.Nodes.Insert(curNode.Index, _node);
                            }
                        }
                        else
                        {
                            //改变阵营；


                            var destfeilname = "";
                            TreeNode DragNode = null;
                            TreeNode DragNode1 = null;
                            DragNode = _node;
                            DragNode1 = _node.Parent;
                            _node.Remove();
                            if (curNode.Tag.ToString() == "UploadDocNode")
                            {
                                destfeilname = Rename(paths[curNode.Tag.ToString()] + curNode.Text, "UploadDocNode");
                            }
                            if (curNode.Tag.ToString() == "SupplementDocNode")
                            {
                                destfeilname = Rename(paths[curNode.Tag.ToString()] + curNode.Text, "SupplementDocNode");
                            }
                            else
                            {
                                destfeilname = Rename(curNode.Text, "");
                            }


                            moveFiles(Path.Combine("images", paths[DragNode1.Tag.ToString()] + DragNode1.Text), Path.Combine("images", paths[curNode.Tag.ToString()] + curNode.Text), DragNode.Text + ".jpg", destfeilname + ".jpg");
                            //  DragNode.Text=DropNode.Parent.Text
                            // 在目标节点下增加被拖拽节点
                            DragNode.Text = destfeilname;//节点重命名

                            InitTreeView();//初始化文件列表，刷新改变后的文件路径
                            curNode.Nodes.Add(_node);
                        }
                    }
                    curNode.BackColor = Color.Empty;
                    curNode = null;
                    _node = null;
                    selectNode.Clear();
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// 给目标文件重新编排名称
        /// </summary>
        /// <param name="destname"></param>
        /// <returns></returns>
        private string Rename(string destname, string tag)
        {
            bool f = true;
            int count = 1;
            string dest = "";
            string newdestname = "";
            while (f)
            {
                if (tag == "UploadDocNode" || tag == "SupplementDocNode")
                    newdestname = destname.Split('/')[1];
                else
                    newdestname = destname;
                dest = Path.GetFullPath(Path.Combine("images", Path.Combine(destname, newdestname + "_" + count + ".jpg")));
                if (File.Exists(dest))
                {
                    count++;
                    f = true;
                }
                else
                {
                    f = false;
                }
            }
            return newdestname + "_" + count;

        }

        /// <summary>
        /// 文件转移
        /// </summary>
        /// <param name="srcFolder"></param>
        /// <param name="destFolder"></param>
        /// <param name="filename"></param>
        /// <param name="newname"></param>
        private void moveFiles(string srcFolder, string destFolder, string filename, string newname)
        {
            var src = Path.GetFullPath(Path.Combine(srcFolder, filename));
            var dest = Path.GetFullPath(Path.Combine(destFolder, newname));
            textlog.log("原文件路径:" + src);
            textlog.log("目标文件路径:" + dest);
            var srcfile = Path.GetFullPath(Path.Combine(srcFolder, filename.Split('.')[0]));
            var destfile = Path.GetFullPath(Path.Combine(destFolder, newname.Split('.')[0]));

            if (Directory.Exists(srcfile) && !Directory.Exists(destfile))
            {
                textlog.log("原文件夹路径:" + srcfile);
                textlog.log("目标文件夹路径:" + destfile);
                Directory.Move(srcfile, destfile);
                DirectoryInfo dir = new DirectoryInfo(destfile);
                foreach (FileInfo file in dir.GetFiles("*.jpg"))
                {
                    bool fla = true;
                    int count = 1;
                    while (fla)
                    {
                        if (File.Exists(Path.GetFullPath(Path.Combine(destfile, newname.Split('.')[0].Split('_')[0] + "_" + count) + ".jpg")))
                        {
                            count++;
                            fla = true;
                        }
                        else
                            fla = false;
                    }
                    string a = Path.GetFullPath(Path.Combine(destfile, newname.Split('.')[0].Split('_')[0] + "_" + count)) + ".jpg";
                    textlog.log("原文件夹2路径:" + file.FullName);
                    textlog.log("目标文件夹2路径:" + a);
                    File.Move(file.FullName, a);
                }
            }
            try
            {
                File.Move(src, dest);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                // throw;
            }
        }

        /// <summary>
        /// 条形码识别
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string AsposeBarCode(string path)
        {
            var reader = new BarCodeReader(path, DecodeType.Code128);
            var barCode = "";
            while (reader.Read())
            {
                barCode = reader.GetCodeText();
                //  textlog2.log(barCode);
                if (!string.IsNullOrEmpty(barCode))
                {
                    break;
                }
            }
            return barCode;
        }
        public void RenameDirectories(string directoryName, string newDirectoryName)
        {

        }


        /// <summary>
        /// 回单补扫
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tslSuppleUp_Click(object sender, EventArgs e)
        {
            _logger.Info(string.Format("回单补扫开始***************************"));
            frmAddGroup addGroup = new frmAddGroup("");
            addGroup.Text = "请输入单据号";
            datanbr = "";
            addGroup.tree = treeView1;
            addGroup.eventgroup += GetGroupName;
            addGroup.ShowDialog();

            if (!string.IsNullOrEmpty(datanbr))
            {
                savePath = Path.Combine(imagePath, Path.Combine(paths[curNode.Tag.ToString()], datanbr));
                isreturnscann = true;
                isreplacescann = false;
                issupplementscann = false;
                isscann = false;
                if (bInitFlag)
                {
                    opskyScan.Scan(this);
                    tslNormalScan.Enabled = true;
                }
            }
            _logger.Info(string.Format("回单补扫结束***************************"));
        }
        public string datanbr = "";
        void GetGroupName(string name, TreeNode node)
        {
            datanbr = name;
            curNode = node;

        }
        /// <summary>
        /// 回单上传点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            _logger.Info(string.Format("回单上传开始***************************"));
            button4.Enabled = false;
            var uploadData = new List<UploadDataNbr>();
            foreach (TreeNode item in treeView1.Nodes)
            {
                if (item.Nodes.Count == 0 || item.Tag.ToString() == "DocNode" || item.Text.ToString() == "0000000000") continue;
                if (item.Tag.ToString() == "SupplementDocNode")
                {
                    uploadData.Add(new UploadDataNbr
                    {
                        DataNbr = item.Text,
                        Kind = 2
                    });
                }
            }
            if (uploadData.Count == 0)
            {
                button4.Enabled = true;
                //txtLog.AppendText("没有回单补扫上传数据\r\n");
                MessageBox.Show("没有回单补扫上传数据");
                _logger.Info(string.Format("没有回单补扫上传数据,补充上传结束"));
                return;
            }
            foreach (var item in uploadData)
            {
                var path = "images/" + (item.Kind == 1 ? "uploadimages/" : item.Kind == 2 ? "supplementimages/" : "") + item.DataNbr;
                if (!Directory.Exists(path))
                {
                    button4.Enabled = true;
                    _logger.Info("文件路径不存在:" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path));
                    MessageBox.Show("文件路径不存在:" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path), "异常");
                    return;
                }
            }
            panelTip.Visible = true;
            panelTip.BringToFront();
            scanUpload = new ScanUpload(uploadCallBack, setProgressBar, initTipInfo, Common.GetApiUrl("NewUploadImage"), USERID, uploadData);
            new Thread(scanUpload.Upload).Start();
            _logger.Info(string.Format("回单上传结束***************************"));
        }
        /// <summary>
        /// 快捷键设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmIndex_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F)
            {
                toolStripLabel1_Click(null, null);
            }
            else if (e.Alt && e.KeyCode == Keys.X)
            {
                tslNormalScan_Click(null, null);
            }
            else if (e.Alt && e.KeyCode == Keys.T)
            {
                toolStripLabel6_Click(null, null);
            }
            else if (e.Alt && e.KeyCode == Keys.B)
            {
                tslSuppleScann_Click(null, null);
            }
            else if (e.Alt && e.KeyCode == Keys.H)
            {
                tslSuppleUp_Click(null, null);
            }
            else if (e.KeyCode == Keys.Up)
            {
                tslPrePage_Click(null, null);
            }
            else if (e.KeyCode == Keys.Down)
            {
                tslNextPage_Click(null, null);
            }
            else if (e.Alt && e.KeyCode == Keys.M)
            {
                tsMessage_Click(null, null);
            }
        }

        /// <summary>
        /// 屏蔽treeView的方向键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// 替换图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsReplaceImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "图片|*.jpg"; //过滤文件格式 
            //fileDialog.FilterIndex = 2;                                    //格式索引
            fileDialog.RestoreDirectory = true;                            //每次打卡文件是否恢复默认路径

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {

                if (!string.IsNullOrEmpty(fileDialog.FileName))
                {
                    string extension = Path.GetExtension(fileDialog.FileName);
                    string[] str = new string[] { ".jpg" };
                    if (!((IList)str).Contains(extension))
                    {
                        MessageBox.Show("仅能上传jpg格式的图片!", "错误");
                        return;
                    }
                    TreeNode node = treeView1.SelectedNode;
                    var destPath = node.Tag.ToString();
                    var destNo = node.Text;
                    if (File.Exists(destPath))
                    {
                        File.Delete(destPath);
                    }
                    File.Copy(fileDialog.FileName, destPath);
                    this.InitImage(node.Tag.ToString());
                }
            }
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBatchRemove_Click(object sender, EventArgs e)
        {
            if (selectNode.Count > 0)
            {
                if (MessageBox.Show("本次选中" + selectNode.Count + "个影像,确定要全部删除吗?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        _logger.Info("批量删除开始****************************");
                        foreach (var itemNode in selectNode)
                        {
                            _logger.Info("删除:" + itemNode.Text);
                            var root = "images/";
                            if (itemNode.Parent.Tag.ToString() == "UploadDocNode")
                            {
                                root += "uploadimages/";
                            }
                            else if (itemNode.Parent.Tag.ToString() == "SupplementDocNode")
                            {
                                root += "supplementimages/";
                            }
                            var dirPath = string.Format(@"{0}{1}/{2}", root, itemNode.Parent.Text, itemNode.Text);
                            if (Directory.Exists(dirPath))
                            {
                                Directory.Delete(dirPath, true); //选择的影像为合并影像,删除合并前影像文件
                            }
                            var filePath = itemNode.Tag.ToString();
                            if (File.Exists(filePath))
                            {
                                File.Delete(filePath);
                            }
                            var parentDir = new FileInfo(filePath).Directory;
                            if (parentDir != null && parentDir.Exists)
                            {
                                var txtPath = parentDir + "/" + itemNode.Text + ".txt";
                                if (File.Exists(txtPath))
                                {
                                    File.Delete(txtPath);
                                }
                                if (parentDir.GetFiles().Length == 0)
                                {
                                    parentDir.Delete(true);
                                    itemNode.Parent.Remove();
                                }
                            }
                            pbPicture.Image = null;
                            // this.selectNode.Remove(itemNode);
                            itemNode.Remove();
                        }
                        selectNode.Clear();
                        _logger.Info("批量删除结束****************************");
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("批量删除异常:" + exception.ToString());
                        _logger.Info("批量删除异常:" + exception.ToString());
                        _logger.Info("批量删除结束****************************");
                    }
                }
            }
            else
            {
                MessageBox.Show("请勾选要删除的记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
    }
    public delegate void SetPos(int ipos, int count);
    public delegate void UploadCallBack(string dataNbr, List<string> paths, List<string> error, int kind, int docType);
    public delegate void SetProgressBar(int num, int len);
    public delegate void InitTipInfo(string dataNbr, int len);
    public class UploadDataNbr
    {
        public string DataNbr { get; set; }
        public int Kind { get; set; }
    }
    public class ScanUpload
    {
        UploadCallBack callback;
        SetProgressBar setProgressBar;
        InitTipInfo initTipInfo;
        List<UploadDataNbr> uploadDataNbr;
        string url;
        string userID;
        public bool cancelUpload = false;
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        // 构造函数
        public ScanUpload(UploadCallBack _callback, SetProgressBar _setProgressBar, InitTipInfo _initTipInfo, string _url, string _userID, List<UploadDataNbr> _uploadDataNbr)
        {
            callback = _callback;
            setProgressBar = _setProgressBar;
            initTipInfo = _initTipInfo;
            uploadDataNbr = _uploadDataNbr;
            url = _url;
            userID = _userID;
        }

        public void Upload()
        {
            var error = new List<string>();
            var paths = new List<string>();
            var dataNbr = "";
            var fileName = "";
            try
            {

                foreach (var item in uploadDataNbr)
                {
                    if (cancelUpload) break;
                    var path = "images/" + (item.Kind == 1 ? "uploadimages/" : item.Kind == 2 ? "supplementimages/" : "") + item.DataNbr;
                    path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
                    var files = Directory.GetFiles(path, "*.jpg");
                    initTipInfo(item.DataNbr, files.Length);
                    var num = 0;
                    var counts = 0;
                    foreach (var fileInfo in files)
                    {
                        if (cancelUpload) break;
                        var txtPath = fileInfo.Replace(".jpg", ".txt");
                        dataNbr = item.DataNbr;
                        fileName = Path.GetFileName(fileInfo);
                        if (Path.GetFileName(fileInfo).Replace(".jpg", "").Split('_').Length == 2)
                        {
                            var count = Path.GetFileName(fileInfo).Replace(".jpg", "").Split('_')[1];

                            if (!int.TryParse(count, out counts))
                            {
                                _logger.Info("上传异常数据:" + "单号:" + item.DataNbr + ",影像:" + Path.GetFileName(fileInfo) + ",影像名称格式错误");
                                error.Add("单号:" + item.DataNbr + ",影像:" + Path.GetFileName(fileInfo) + ",影像名称格式错误");
                                continue;
                            }
                        }
                        else
                        {
                            _logger.Info("上传异常数据:" + "单号:" + item.DataNbr + ",影像:" + Path.GetFileName(fileInfo) + ",影像名称格式错误");
                            error.Add("单号:" + item.DataNbr + ",影像:" + Path.GetFileName(fileInfo) + ",影像名称格式错误");
                            continue;
                        }
                        var nums = counts.ToString();
                        Common common = new Common();
                        var result = common.UploadImage(this.url, item.DataNbr, fileInfo, Path.GetFileName(fileInfo), this.userID, "", nums);
                        var jsonResult = JObject.Parse(result);
                        if (Convert.ToBoolean(jsonResult["success"].ToString()))
                        {
                            num += 1;
                            paths.Add(fileInfo);
                        }
                        else
                        {
                            _logger.Info("上传异常数据:" + "单号:" + item.DataNbr + ",影像:" + Path.GetFileName(fileInfo) + "," + jsonResult["info"].ToString());
                            error.Add("单号:" + item.DataNbr + ",影像:" + Path.GetFileName(fileInfo) + "," + jsonResult["info"].ToString());
                        }
                        setProgressBar(num, files.Length);
                    }
                    if (callback != null) callback(item.DataNbr, paths, new List<string>(), 0, item.Kind);  // 通过委托,将数据回传给回调函数
                    Thread.Sleep(1000);
                }
                if (callback != null) callback("", new List<string>(), error, cancelUpload ? 2 : 1, 0);  // 通过委托,将数据回传给回调函数

            }
            catch (Exception e)
            {
                error.Add("单号:" + dataNbr + ",影像:" + fileName + "," + e.ToString());
                _logger.Info("上传异常:" + "单号:" + dataNbr + ",影像:" + fileName + "," + e.ToString());
                if (callback != null) callback("", paths, error, cancelUpload ? 2 : 1, 0); // 通过委托,将数据回传给回调函数
            }
        }



    }
}
