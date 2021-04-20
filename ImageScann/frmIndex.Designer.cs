namespace ImageScann
{
    partial class frmIndex
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIndex));
            this.tsTools = new System.Windows.Forms.ToolStrip();
            this.tslConfig = new System.Windows.Forms.ToolStripButton();
            this.tslOpenImage = new System.Windows.Forms.ToolStripButton();
            this.tslNormalScan = new System.Windows.Forms.ToolStripButton();
            this.tslSuppleScann = new System.Windows.Forms.ToolStripButton();
            this.tslReplaceScann = new System.Windows.Forms.ToolStripButton();
            this.tslSuppleUp = new System.Windows.Forms.ToolStripButton();
            this.tslPrePage = new System.Windows.Forms.ToolStripButton();
            this.tslNextPage = new System.Windows.Forms.ToolStripButton();
            this.tslLRotate90 = new System.Windows.Forms.ToolStripButton();
            this.tslRRotate90 = new System.Windows.Forms.ToolStripButton();
            this.tslRefresh = new System.Windows.Forms.ToolStripButton();
            this.tslMergeImage = new System.Windows.Forms.ToolStripButton();
            this.tslRevoke = new System.Windows.Forms.ToolStripButton();
            this.tsMessage = new System.Windows.Forms.ToolStripButton();
            this.tslAbout = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tv_Images = new System.Windows.Forms.TreeView();
            this.cmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsAlterName = new System.Windows.Forms.ToolStripMenuItem();
            this.tsReplaceImage = new System.Windows.Forms.ToolStripMenuItem();
            this.tlNodeDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBatchRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbPicture = new System.Windows.Forms.PictureBox();
            this.panelTip = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.lblNum = new System.Windows.Forms.Label();
            this.lblNbr = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bt_NewGroup = new System.Windows.Forms.Button();
            this.bt_UploadReceipt = new System.Windows.Forms.Button();
            this.bt_UploadNow = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tslOpen = new System.Windows.Forms.ToolStripLabel();
            this.tsTools.SuspendLayout();
            this.panel1.SuspendLayout();
            this.cmMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture)).BeginInit();
            this.panelTip.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tsTools
            // 
            this.tsTools.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tsTools.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslConfig,
            this.tslOpenImage,
            this.tslNormalScan,
            this.tslSuppleScann,
            this.tslReplaceScann,
            this.tslSuppleUp,
            this.tslPrePage,
            this.tslNextPage,
            this.tslLRotate90,
            this.tslRRotate90,
            this.tslRefresh,
            this.tslMergeImage,
            this.tslRevoke,
            this.tsMessage,
            this.tslAbout});
            this.tsTools.Location = new System.Drawing.Point(0, 0);
            this.tsTools.Name = "tsTools";
            this.tsTools.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsTools.Size = new System.Drawing.Size(1242, 43);
            this.tsTools.TabIndex = 1;
            // 
            // tslConfig
            // 
            this.tslConfig.BackColor = System.Drawing.SystemColors.Control;
            this.tslConfig.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tslConfig.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tslConfig.Image = ((System.Drawing.Image)(resources.GetObject("tslConfig.Image")));
            this.tslConfig.Name = "tslConfig";
            this.tslConfig.Size = new System.Drawing.Size(71, 40);
            this.tslConfig.Text = "扫描设定";
            this.tslConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tslConfig.Visible = false;
            this.tslConfig.Click += new System.EventHandler(this.toolStripLabel2_Click);
            // 
            // tslOpenImage
            // 
            this.tslOpenImage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tslOpenImage.Image = ((System.Drawing.Image)(resources.GetObject("tslOpenImage.Image")));
            this.tslOpenImage.Name = "tslOpenImage";
            this.tslOpenImage.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.tslOpenImage.Size = new System.Drawing.Size(65, 40);
            this.tslOpenImage.Text = "打开(&F)";
            this.tslOpenImage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tslOpenImage.Click += new System.EventHandler(this.tslOpenImage_Click);
            // 
            // tslNormalScan
            // 
            this.tslNormalScan.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tslNormalScan.Image = ((System.Drawing.Image)(resources.GetObject("tslNormalScan.Image")));
            this.tslNormalScan.Name = "tslNormalScan";
            this.tslNormalScan.Size = new System.Drawing.Size(95, 40);
            this.tslNormalScan.Text = "正常扫描(&X)";
            this.tslNormalScan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tslNormalScan.Click += new System.EventHandler(this.tslNormalScan_Click);
            // 
            // tslSuppleScann
            // 
            this.tslSuppleScann.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tslSuppleScann.Image = ((System.Drawing.Image)(resources.GetObject("tslSuppleScann.Image")));
            this.tslSuppleScann.Name = "tslSuppleScann";
            this.tslSuppleScann.Size = new System.Drawing.Size(95, 40);
            this.tslSuppleScann.Text = "补充扫描(&B)";
            this.tslSuppleScann.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tslSuppleScann.Click += new System.EventHandler(this.tslSuppleScann_Click);
            // 
            // tslReplaceScann
            // 
            this.tslReplaceScann.AutoSize = false;
            this.tslReplaceScann.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tslReplaceScann.Image = ((System.Drawing.Image)(resources.GetObject("tslReplaceScann.Image")));
            this.tslReplaceScann.Name = "tslReplaceScann";
            this.tslReplaceScann.Size = new System.Drawing.Size(80, 40);
            this.tslReplaceScann.Text = "替换扫描(&T)";
            this.tslReplaceScann.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tslReplaceScann.Click += new System.EventHandler(this.tslReplaceScan_Click);
            // 
            // tslSuppleUp
            // 
            this.tslSuppleUp.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tslSuppleUp.Image = ((System.Drawing.Image)(resources.GetObject("tslSuppleUp.Image")));
            this.tslSuppleUp.Name = "tslSuppleUp";
            this.tslSuppleUp.Size = new System.Drawing.Size(95, 40);
            this.tslSuppleUp.Text = "回单补扫(&H)";
            this.tslSuppleUp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tslSuppleUp.Click += new System.EventHandler(this.tslSuppleUp_Click);
            // 
            // tslPrePage
            // 
            this.tslPrePage.Enabled = false;
            this.tslPrePage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tslPrePage.Image = ((System.Drawing.Image)(resources.GetObject("tslPrePage.Image")));
            this.tslPrePage.Name = "tslPrePage";
            this.tslPrePage.Size = new System.Drawing.Size(56, 40);
            this.tslPrePage.Text = "上一个";
            this.tslPrePage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tslPrePage.Click += new System.EventHandler(this.tslPrePage_Click);
            // 
            // tslNextPage
            // 
            this.tslNextPage.Enabled = false;
            this.tslNextPage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tslNextPage.Image = ((System.Drawing.Image)(resources.GetObject("tslNextPage.Image")));
            this.tslNextPage.Name = "tslNextPage";
            this.tslNextPage.Size = new System.Drawing.Size(56, 40);
            this.tslNextPage.Text = "下一个";
            this.tslNextPage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tslNextPage.Click += new System.EventHandler(this.tslNextPage_Click);
            // 
            // tslLRotate90
            // 
            this.tslLRotate90.Enabled = false;
            this.tslLRotate90.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tslLRotate90.Image = ((System.Drawing.Image)(resources.GetObject("tslLRotate90.Image")));
            this.tslLRotate90.Name = "tslLRotate90";
            this.tslLRotate90.Size = new System.Drawing.Size(72, 40);
            this.tslLRotate90.Text = "左旋转90";
            this.tslLRotate90.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tslLRotate90.Click += new System.EventHandler(this.tslLRotate90_Click);
            // 
            // tslRRotate90
            // 
            this.tslRRotate90.Enabled = false;
            this.tslRRotate90.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tslRRotate90.Image = ((System.Drawing.Image)(resources.GetObject("tslRRotate90.Image")));
            this.tslRRotate90.Name = "tslRRotate90";
            this.tslRRotate90.Size = new System.Drawing.Size(72, 40);
            this.tslRRotate90.Text = "右旋转90";
            this.tslRRotate90.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tslRRotate90.Click += new System.EventHandler(this.tslRRotate90_Click);
            // 
            // tslRefresh
            // 
            this.tslRefresh.Enabled = false;
            this.tslRefresh.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tslRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tslRefresh.Image")));
            this.tslRefresh.Name = "tslRefresh";
            this.tslRefresh.Size = new System.Drawing.Size(71, 40);
            this.tslRefresh.Text = "重新加载";
            this.tslRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tslRefresh.Click += new System.EventHandler(this.tslRefresh_Click);
            // 
            // tslMergeImage
            // 
            this.tslMergeImage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tslMergeImage.Image = ((System.Drawing.Image)(resources.GetObject("tslMergeImage.Image")));
            this.tslMergeImage.Name = "tslMergeImage";
            this.tslMergeImage.Size = new System.Drawing.Size(71, 40);
            this.tslMergeImage.Text = "合并影像";
            this.tslMergeImage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tslMergeImage.Click += new System.EventHandler(this.tslMergeImage_Click);
            // 
            // tslRevoke
            // 
            this.tslRevoke.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tslRevoke.Image = ((System.Drawing.Image)(resources.GetObject("tslRevoke.Image")));
            this.tslRevoke.Name = "tslRevoke";
            this.tslRevoke.Size = new System.Drawing.Size(71, 40);
            this.tslRevoke.Text = "撤销合并";
            this.tslRevoke.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tslRevoke.Click += new System.EventHandler(this.tslRevoke_Click);
            // 
            // tsMessage
            // 
            this.tsMessage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsMessage.Image = ((System.Drawing.Image)(resources.GetObject("tsMessage.Image")));
            this.tsMessage.Name = "tsMessage";
            this.tsMessage.RightToLeftAutoMirrorImage = true;
            this.tsMessage.Size = new System.Drawing.Size(95, 40);
            this.tsMessage.Text = "我的消息(&M)";
            this.tsMessage.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.tsMessage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsMessage.Click += new System.EventHandler(this.tsMessage_Click);
            // 
            // tslAbout
            // 
            this.tslAbout.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tslAbout.Image = ((System.Drawing.Image)(resources.GetObject("tslAbout.Image")));
            this.tslAbout.ImageTransparentColor = System.Drawing.Color.White;
            this.tslAbout.Margin = new System.Windows.Forms.Padding(0);
            this.tslAbout.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.tslAbout.Name = "tslAbout";
            this.tslAbout.RightToLeftAutoMirrorImage = true;
            this.tslAbout.Size = new System.Drawing.Size(41, 43);
            this.tslAbout.Text = "关于";
            this.tslAbout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tv_Images);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 474);
            this.panel1.TabIndex = 2;
            // 
            // tv_Images
            // 
            this.tv_Images.AllowDrop = true;
            this.tv_Images.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tv_Images.CheckBoxes = true;
            this.tv_Images.ContextMenuStrip = this.cmMenu;
            this.tv_Images.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_Images.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tv_Images.Location = new System.Drawing.Point(0, 0);
            this.tv_Images.Name = "tv_Images";
            this.tv_Images.Size = new System.Drawing.Size(235, 472);
            this.tv_Images.TabIndex = 0;
            this.tv_Images.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView1_AfterLabelEdit);
            this.tv_Images.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView1_ItemDrag);
            this.tv_Images.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.tv_Images.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView1_DragDrop);
            this.tv_Images.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView1_DragEnter);
            this.tv_Images.DragOver += new System.Windows.Forms.DragEventHandler(this.treeView1_DragOver);
            this.tv_Images.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyDown);
            // 
            // cmMenu
            // 
            this.cmMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAlterName,
            this.tsReplaceImage,
            this.tlNodeDelete,
            this.tsBatchRemove});
            this.cmMenu.Name = "cmMenu";
            this.cmMenu.Size = new System.Drawing.Size(139, 100);
            // 
            // tsAlterName
            // 
            this.tsAlterName.Name = "tsAlterName";
            this.tsAlterName.Size = new System.Drawing.Size(138, 24);
            this.tsAlterName.Text = "修改";
            this.tsAlterName.Click += new System.EventHandler(this.tsAlterName_Click);
            // 
            // tsReplaceImage
            // 
            this.tsReplaceImage.Name = "tsReplaceImage";
            this.tsReplaceImage.Size = new System.Drawing.Size(138, 24);
            this.tsReplaceImage.Text = "替换图片";
            this.tsReplaceImage.Click += new System.EventHandler(this.tsReplaceImage_Click);
            // 
            // tlNodeDelete
            // 
            this.tlNodeDelete.Name = "tlNodeDelete";
            this.tlNodeDelete.Size = new System.Drawing.Size(138, 24);
            this.tlNodeDelete.Text = "删除";
            this.tlNodeDelete.Click += new System.EventHandler(this.tlNodeDelete_Click);
            // 
            // tsBatchRemove
            // 
            this.tsBatchRemove.Name = "tsBatchRemove";
            this.tsBatchRemove.Size = new System.Drawing.Size(138, 24);
            this.tsBatchRemove.Text = "批量删除";
            this.tsBatchRemove.Click += new System.EventHandler(this.tsBatchRemove_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pbPicture);
            this.panel2.Controls.Add(this.panelTip);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(765, 474);
            this.panel2.TabIndex = 3;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // pbPicture
            // 
            this.pbPicture.BackColor = System.Drawing.SystemColors.Control;
            this.pbPicture.Location = new System.Drawing.Point(52, 89);
            this.pbPicture.Name = "pbPicture";
            this.pbPicture.Size = new System.Drawing.Size(589, 372);
            this.pbPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPicture.TabIndex = 0;
            this.pbPicture.TabStop = false;
            this.pbPicture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbPicture_MouseDown);
            this.pbPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbPicture_MouseMove);
            this.pbPicture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbPicture_MouseUp);
            // 
            // panelTip
            // 
            this.panelTip.BackColor = System.Drawing.Color.White;
            this.panelTip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTip.Controls.Add(this.button2);
            this.panelTip.Controls.Add(this.lblNum);
            this.panelTip.Controls.Add(this.lblNbr);
            this.panelTip.Controls.Add(this.label1);
            this.panelTip.Controls.Add(this.progressBar1);
            this.panelTip.Location = new System.Drawing.Point(671, 52);
            this.panelTip.Name = "panelTip";
            this.panelTip.Size = new System.Drawing.Size(390, 127);
            this.panelTip.TabIndex = 2;
            this.panelTip.Visible = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(299, 85);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 30);
            this.button2.TabIndex = 5;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNum.Location = new System.Drawing.Point(299, 36);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(35, 18);
            this.lblNum.TabIndex = 4;
            this.lblNum.Text = "0/0";
            // 
            // lblNbr
            // 
            this.lblNbr.AutoSize = true;
            this.lblNbr.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNbr.Location = new System.Drawing.Point(3, 36);
            this.lblNbr.Name = "lblNbr";
            this.lblNbr.Size = new System.Drawing.Size(44, 18);
            this.lblNbr.TabIndex = 3;
            this.lblNbr.Text = "单号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "正在上传...";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 56);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(377, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.bt_NewGroup);
            this.panel3.Controls.Add(this.bt_UploadReceipt);
            this.panel3.Controls.Add(this.bt_UploadNow);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(237, 114);
            this.panel3.TabIndex = 1;
            // 
            // bt_NewGroup
            // 
            this.bt_NewGroup.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bt_NewGroup.Location = new System.Drawing.Point(11, 44);
            this.bt_NewGroup.Name = "bt_NewGroup";
            this.bt_NewGroup.Size = new System.Drawing.Size(92, 27);
            this.bt_NewGroup.TabIndex = 11;
            this.bt_NewGroup.Text = "新建分组(&N)";
            this.bt_NewGroup.UseVisualStyleBackColor = true;
            this.bt_NewGroup.Click += new System.EventHandler(this.bt_NewGroup_Click);
            // 
            // bt_UploadReceipt
            // 
            this.bt_UploadReceipt.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bt_UploadReceipt.Location = new System.Drawing.Point(114, 12);
            this.bt_UploadReceipt.Name = "bt_UploadReceipt";
            this.bt_UploadReceipt.Size = new System.Drawing.Size(84, 26);
            this.bt_UploadReceipt.TabIndex = 10;
            this.bt_UploadReceipt.Text = "回单上传(&L)";
            this.toolTip1.SetToolTip(this.bt_UploadReceipt, "只上传回单数据");
            this.bt_UploadReceipt.UseVisualStyleBackColor = true;
            this.bt_UploadReceipt.Click += new System.EventHandler(this.bt_UploadReceipt_Click);
            // 
            // bt_UploadNow
            // 
            this.bt_UploadNow.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bt_UploadNow.Location = new System.Drawing.Point(11, 12);
            this.bt_UploadNow.Name = "bt_UploadNow";
            this.bt_UploadNow.Size = new System.Drawing.Size(92, 26);
            this.bt_UploadNow.TabIndex = 9;
            this.bt_UploadNow.Text = "实时上传(&U)";
            this.toolTip1.SetToolTip(this.bt_UploadNow, "可以上传正常扫描，替换扫描，补充扫描生成的数据");
            this.bt_UploadNow.UseVisualStyleBackColor = true;
            this.bt_UploadNow.Click += new System.EventHandler(this.bt_UploadNow_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.button6);
            this.panel4.Controls.Add(this.txtRemark);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1001, 114);
            this.panel4.TabIndex = 4;
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.button6.Location = new System.Drawing.Point(915, 16);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 78);
            this.button6.TabIndex = 2;
            this.button6.Text = "备注";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // txtRemark
            // 
            this.txtRemark.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemark.Location = new System.Drawing.Point(12, 16);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(893, 78);
            this.txtRemark.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 300000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.txtLog);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(232, 474);
            this.panel5.TabIndex = 5;
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(230, 472);
            this.txtLog.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1242, 474);
            this.splitContainer1.SplitterDistance = 237;
            this.splitContainer1.TabIndex = 6;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel5);
            this.splitContainer2.Size = new System.Drawing.Size(1001, 474);
            this.splitContainer2.SplitterDistance = 765;
            this.splitContainer2.TabIndex = 4;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 43);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(1242, 592);
            this.splitContainer3.SplitterDistance = 474;
            this.splitContainer3.TabIndex = 7;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.IsSplitterFixed = true;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.panel4);
            this.splitContainer4.Size = new System.Drawing.Size(1242, 114);
            this.splitContainer4.SplitterDistance = 237;
            this.splitContainer4.TabIndex = 5;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.Tag = "";
            // 
            // tslOpen
            // 
            this.tslOpen.Image = ((System.Drawing.Image)(resources.GetObject("tslOpen.Image")));
            this.tslOpen.Name = "tslOpen";
            this.tslOpen.Size = new System.Drawing.Size(37, 36);
            this.tslOpen.Text = "打开";
            this.tslOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // frmIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 635);
            this.Controls.Add(this.splitContainer3);
            this.Controls.Add(this.tsTools);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmIndex";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "影像管理工具";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmIndex_FormClosed);
            this.Load += new System.EventHandler(this.frmIndex_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmIndex_KeyUp);
            this.tsTools.ResumeLayout(false);
            this.tsTools.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.cmMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture)).EndInit();
            this.panelTip.ResumeLayout(false);
            this.panelTip.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsTools;
        private System.Windows.Forms.ToolStripLabel tslOpen;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ContextMenuStrip cmMenu;
        private System.Windows.Forms.ToolStripMenuItem tlNodeDelete;
        private System.Windows.Forms.ToolStripMenuItem tsAlterName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button bt_NewGroup;
        private System.Windows.Forms.Button bt_UploadReceipt;
        private System.Windows.Forms.Button bt_UploadNow;
        private System.Windows.Forms.PictureBox pbPicture;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panelTip;
        private System.Windows.Forms.Label lblNbr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripButton tslConfig;
        private System.Windows.Forms.ToolStripButton tslOpenImage;
        private System.Windows.Forms.ToolStripButton tslNormalScan;
        private System.Windows.Forms.ToolStripButton tslReplaceScann;
        private System.Windows.Forms.ToolStripButton tslSuppleScann;
        private System.Windows.Forms.ToolStripButton tslSuppleUp;
        private System.Windows.Forms.ToolStripButton tslPrePage;
        private System.Windows.Forms.ToolStripButton tslNextPage;
        private System.Windows.Forms.ToolStripButton tslLRotate90;
        private System.Windows.Forms.ToolStripButton tslRRotate90;
        private System.Windows.Forms.ToolStripButton tslRefresh;
        private System.Windows.Forms.ToolStripButton tslMergeImage;
        private System.Windows.Forms.ToolStripButton tslRevoke;
        private System.Windows.Forms.ToolStripButton tsMessage;
        private System.Windows.Forms.ToolStripButton tslAbout;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolStripMenuItem tsReplaceImage;
        private System.Windows.Forms.ToolStripMenuItem tsBatchRemove;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TreeView tv_Images;
    }
}

