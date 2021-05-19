
namespace ImageScann
{
    partial class frmVatInvoice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVatInvoice));
            this.toolStrip_Invoice = new System.Windows.Forms.ToolStrip();
            this.tsVatInvoiceScan = new System.Windows.Forms.ToolStripButton();
            this.tstripButton_querylasttime = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tstripButton_save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tstripButton_pdf = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_upload = new System.Windows.Forms.ToolStripButton();
            this.DataGridView_Invoice = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceTypeOrg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.InvoiceCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaserRegisterNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaserAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaserBank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SellerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SellerRegisterNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SellerAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SellerBank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalTaxAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PushStatus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panelMycontrol = new System.Windows.Forms.Panel();
            this.panelData = new System.Windows.Forms.Panel();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.buttonExcel = new System.Windows.Forms.Button();
            this.buttonQuery = new System.Windows.Forms.Button();
            this.textBoxPurchaserName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxSellerName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickerDateTo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerDareFm = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxInvNum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxInvCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar_upload = new System.Windows.Forms.ProgressBar();
            this.toolStrip_Invoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Invoice)).BeginInit();
            this.panelData.SuspendLayout();
            this.panelFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip_Invoice
            // 
            this.toolStrip_Invoice.BackColor = System.Drawing.Color.White;
            this.toolStrip_Invoice.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip_Invoice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsVatInvoiceScan,
            this.tstripButton_querylasttime,
            this.toolStripSeparator3,
            this.tstripButton_save,
            this.toolStripSeparator4,
            this.tstripButton_pdf,
            this.toolStripButton_upload});
            this.toolStrip_Invoice.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_Invoice.Name = "toolStrip_Invoice";
            this.toolStrip_Invoice.Size = new System.Drawing.Size(1413, 47);
            this.toolStrip_Invoice.TabIndex = 0;
            this.toolStrip_Invoice.Text = "toolStrip1";
            // 
            // tsVatInvoiceScan
            // 
            this.tsVatInvoiceScan.Image = ((System.Drawing.Image)(resources.GetObject("tsVatInvoiceScan.Image")));
            this.tsVatInvoiceScan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsVatInvoiceScan.Name = "tsVatInvoiceScan";
            this.tsVatInvoiceScan.Size = new System.Drawing.Size(43, 44);
            this.tsVatInvoiceScan.Text = "扫描";
            this.tsVatInvoiceScan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsVatInvoiceScan.ToolTipText = "扫描";
            this.tsVatInvoiceScan.Click += new System.EventHandler(this.tsVatInvoiceScan_Click);
            // 
            // tstripButton_querylasttime
            // 
            this.tstripButton_querylasttime.Image = ((System.Drawing.Image)(resources.GetObject("tstripButton_querylasttime.Image")));
            this.tstripButton_querylasttime.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tstripButton_querylasttime.Name = "tstripButton_querylasttime";
            this.tstripButton_querylasttime.Size = new System.Drawing.Size(73, 44);
            this.tstripButton_querylasttime.Text = "最近扫描";
            this.tstripButton_querylasttime.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tstripButton_querylasttime.Click += new System.EventHandler(this.tstripButton_querylasttime_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 47);
            // 
            // tstripButton_save
            // 
            this.tstripButton_save.Image = ((System.Drawing.Image)(resources.GetObject("tstripButton_save.Image")));
            this.tstripButton_save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tstripButton_save.Name = "tstripButton_save";
            this.tstripButton_save.Size = new System.Drawing.Size(73, 44);
            this.tstripButton_save.Text = "保存更改";
            this.tstripButton_save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tstripButton_save.Click += new System.EventHandler(this.tstripButton_save_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 47);
            // 
            // tstripButton_pdf
            // 
            this.tstripButton_pdf.Image = ((System.Drawing.Image)(resources.GetObject("tstripButton_pdf.Image")));
            this.tstripButton_pdf.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tstripButton_pdf.Name = "tstripButton_pdf";
            this.tstripButton_pdf.Size = new System.Drawing.Size(73, 44);
            this.tstripButton_pdf.Text = "导出发票";
            this.tstripButton_pdf.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tstripButton_pdf.Click += new System.EventHandler(this.tstripButton_pdf_Click);
            // 
            // toolStripButton_upload
            // 
            this.toolStripButton_upload.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_upload.Image")));
            this.toolStripButton_upload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_upload.Name = "toolStripButton_upload";
            this.toolStripButton_upload.Size = new System.Drawing.Size(73, 44);
            this.toolStripButton_upload.Text = "上传发票";
            this.toolStripButton_upload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton_upload.Click += new System.EventHandler(this.toolStripButton_upload_Click);
            // 
            // DataGridView_Invoice
            // 
            this.DataGridView_Invoice.AllowUserToAddRows = false;
            this.DataGridView_Invoice.AllowUserToDeleteRows = false;
            this.DataGridView_Invoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_Invoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.InvoiceTypeOrg,
            this.InvImage,
            this.InvoiceCode,
            this.InvoiceNumber,
            this.InvoiceDate,
            this.PurchaserName,
            this.PurchaserRegisterNum,
            this.PurchaserAddress,
            this.PurchaserBank,
            this.SellerName,
            this.SellerRegisterNum,
            this.SellerAddress,
            this.SellerBank,
            this.TotalAmount,
            this.TotalTaxAmount,
            this.TotalTax,
            this.PushStatus});
            this.DataGridView_Invoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView_Invoice.Location = new System.Drawing.Point(0, 0);
            this.DataGridView_Invoice.Margin = new System.Windows.Forms.Padding(4);
            this.DataGridView_Invoice.Name = "DataGridView_Invoice";
            this.DataGridView_Invoice.RowHeadersWidth = 51;
            this.DataGridView_Invoice.RowTemplate.Height = 23;
            this.DataGridView_Invoice.Size = new System.Drawing.Size(1413, 551);
            this.DataGridView_Invoice.TabIndex = 1;
            this.DataGridView_Invoice.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_Invoice_CellDoubleClick);
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "序号";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Id.Width = 39;
            // 
            // InvoiceTypeOrg
            // 
            this.InvoiceTypeOrg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.InvoiceTypeOrg.DataPropertyName = "InvoiceTypeOrg";
            this.InvoiceTypeOrg.HeaderText = "发票名称";
            this.InvoiceTypeOrg.MinimumWidth = 6;
            this.InvoiceTypeOrg.Name = "InvoiceTypeOrg";
            this.InvoiceTypeOrg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.InvoiceTypeOrg.Width = 52;
            // 
            // InvImage
            // 
            this.InvImage.HeaderText = "查看影像";
            this.InvImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.InvImage.MinimumWidth = 6;
            this.InvImage.Name = "InvImage";
            this.InvImage.ReadOnly = true;
            this.InvImage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.InvImage.Width = 60;
            // 
            // InvoiceCode
            // 
            this.InvoiceCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.InvoiceCode.DataPropertyName = "InvoiceCode";
            this.InvoiceCode.HeaderText = "发票代码";
            this.InvoiceCode.MinimumWidth = 6;
            this.InvoiceCode.Name = "InvoiceCode";
            this.InvoiceCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.InvoiceCode.Width = 52;
            // 
            // InvoiceNumber
            // 
            this.InvoiceNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.InvoiceNumber.DataPropertyName = "InvoiceNumber";
            this.InvoiceNumber.HeaderText = "发票号码";
            this.InvoiceNumber.MinimumWidth = 6;
            this.InvoiceNumber.Name = "InvoiceNumber";
            this.InvoiceNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.InvoiceNumber.Width = 52;
            // 
            // InvoiceDate
            // 
            this.InvoiceDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.InvoiceDate.DataPropertyName = "InvoiceDate";
            this.InvoiceDate.HeaderText = "开票日期";
            this.InvoiceDate.MinimumWidth = 6;
            this.InvoiceDate.Name = "InvoiceDate";
            this.InvoiceDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.InvoiceDate.Width = 52;
            // 
            // PurchaserName
            // 
            this.PurchaserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PurchaserName.DataPropertyName = "PurchaserName";
            this.PurchaserName.HeaderText = "购买方名称";
            this.PurchaserName.MinimumWidth = 6;
            this.PurchaserName.Name = "PurchaserName";
            this.PurchaserName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PurchaserName.Width = 66;
            // 
            // PurchaserRegisterNum
            // 
            this.PurchaserRegisterNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PurchaserRegisterNum.DataPropertyName = "PurchaserRegisterNum";
            this.PurchaserRegisterNum.HeaderText = "购买方纳税人识别号";
            this.PurchaserRegisterNum.MinimumWidth = 6;
            this.PurchaserRegisterNum.Name = "PurchaserRegisterNum";
            this.PurchaserRegisterNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PurchaserRegisterNum.Width = 93;
            // 
            // PurchaserAddress
            // 
            this.PurchaserAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PurchaserAddress.DataPropertyName = "PurchaserAddress";
            this.PurchaserAddress.HeaderText = "购买方地址、电话";
            this.PurchaserAddress.MinimumWidth = 6;
            this.PurchaserAddress.Name = "PurchaserAddress";
            this.PurchaserAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PurchaserAddress.Width = 93;
            // 
            // PurchaserBank
            // 
            this.PurchaserBank.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PurchaserBank.DataPropertyName = "PurchaserBank";
            this.PurchaserBank.HeaderText = "购买方开户行及账号";
            this.PurchaserBank.MinimumWidth = 6;
            this.PurchaserBank.Name = "PurchaserBank";
            this.PurchaserBank.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PurchaserBank.Width = 93;
            // 
            // SellerName
            // 
            this.SellerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SellerName.DataPropertyName = "SellerName";
            this.SellerName.HeaderText = "销售方名称";
            this.SellerName.MinimumWidth = 6;
            this.SellerName.Name = "SellerName";
            this.SellerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SellerName.Width = 66;
            // 
            // SellerRegisterNum
            // 
            this.SellerRegisterNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SellerRegisterNum.DataPropertyName = "SellerRegisterNum";
            this.SellerRegisterNum.HeaderText = "销售方纳税人识别号";
            this.SellerRegisterNum.MinimumWidth = 6;
            this.SellerRegisterNum.Name = "SellerRegisterNum";
            this.SellerRegisterNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SellerRegisterNum.Width = 93;
            // 
            // SellerAddress
            // 
            this.SellerAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SellerAddress.DataPropertyName = "SellerAddress";
            this.SellerAddress.HeaderText = "销售方地址、电话";
            this.SellerAddress.MinimumWidth = 6;
            this.SellerAddress.Name = "SellerAddress";
            this.SellerAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SellerAddress.Width = 93;
            // 
            // SellerBank
            // 
            this.SellerBank.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SellerBank.DataPropertyName = "SellerBank";
            this.SellerBank.HeaderText = "销售方开户行及账号";
            this.SellerBank.MinimumWidth = 6;
            this.SellerBank.Name = "SellerBank";
            this.SellerBank.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SellerBank.Width = 93;
            // 
            // TotalAmount
            // 
            this.TotalAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TotalAmount.DataPropertyName = "TotalAmount";
            this.TotalAmount.HeaderText = "合计金额";
            this.TotalAmount.MinimumWidth = 6;
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TotalAmount.Width = 52;
            // 
            // TotalTaxAmount
            // 
            this.TotalTaxAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TotalTaxAmount.DataPropertyName = "TotalTaxAmount";
            this.TotalTaxAmount.HeaderText = "价税合计";
            this.TotalTaxAmount.MinimumWidth = 6;
            this.TotalTaxAmount.Name = "TotalTaxAmount";
            this.TotalTaxAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TotalTaxAmount.Width = 52;
            // 
            // TotalTax
            // 
            this.TotalTax.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TotalTax.DataPropertyName = "TotalTax";
            this.TotalTax.HeaderText = "合计税额";
            this.TotalTax.MinimumWidth = 6;
            this.TotalTax.Name = "TotalTax";
            this.TotalTax.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TotalTax.Width = 52;
            // 
            // PushStatus
            // 
            this.PushStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PushStatus.DataPropertyName = "PushStatus";
            this.PushStatus.HeaderText = "推送状态";
            this.PushStatus.MinimumWidth = 6;
            this.PushStatus.Name = "PushStatus";
            this.PushStatus.ReadOnly = true;
            this.PushStatus.Width = 52;
            // 
            // panelMycontrol
            // 
            this.panelMycontrol.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMycontrol.Location = new System.Drawing.Point(0, 707);
            this.panelMycontrol.Margin = new System.Windows.Forms.Padding(4);
            this.panelMycontrol.Name = "panelMycontrol";
            this.panelMycontrol.Size = new System.Drawing.Size(1413, 44);
            this.panelMycontrol.TabIndex = 2;
            // 
            // panelData
            // 
            this.panelData.Controls.Add(this.progressBar_upload);
            this.panelData.Controls.Add(this.DataGridView_Invoice);
            this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelData.Location = new System.Drawing.Point(0, 156);
            this.panelData.Margin = new System.Windows.Forms.Padding(4);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(1413, 551);
            this.panelData.TabIndex = 3;
            // 
            // panelFilter
            // 
            this.panelFilter.BackColor = System.Drawing.Color.White;
            this.panelFilter.Controls.Add(this.buttonExcel);
            this.panelFilter.Controls.Add(this.buttonQuery);
            this.panelFilter.Controls.Add(this.textBoxPurchaserName);
            this.panelFilter.Controls.Add(this.label6);
            this.panelFilter.Controls.Add(this.textBoxSellerName);
            this.panelFilter.Controls.Add(this.label5);
            this.panelFilter.Controls.Add(this.dateTimePickerDateTo);
            this.panelFilter.Controls.Add(this.label4);
            this.panelFilter.Controls.Add(this.dateTimePickerDareFm);
            this.panelFilter.Controls.Add(this.label3);
            this.panelFilter.Controls.Add(this.textBoxInvNum);
            this.panelFilter.Controls.Add(this.label2);
            this.panelFilter.Controls.Add(this.textBoxInvCode);
            this.panelFilter.Controls.Add(this.label1);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(0, 47);
            this.panelFilter.Margin = new System.Windows.Forms.Padding(4);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(1413, 109);
            this.panelFilter.TabIndex = 2;
            // 
            // buttonExcel
            // 
            this.buttonExcel.Location = new System.Drawing.Point(1093, 62);
            this.buttonExcel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonExcel.Name = "buttonExcel";
            this.buttonExcel.Size = new System.Drawing.Size(88, 29);
            this.buttonExcel.TabIndex = 13;
            this.buttonExcel.Text = "输出";
            this.buttonExcel.UseVisualStyleBackColor = true;
            this.buttonExcel.Click += new System.EventHandler(this.buttonExcel_Click);
            // 
            // buttonQuery
            // 
            this.buttonQuery.Location = new System.Drawing.Point(992, 62);
            this.buttonQuery.Margin = new System.Windows.Forms.Padding(4);
            this.buttonQuery.Name = "buttonQuery";
            this.buttonQuery.Size = new System.Drawing.Size(88, 29);
            this.buttonQuery.TabIndex = 12;
            this.buttonQuery.Text = "查询";
            this.buttonQuery.UseVisualStyleBackColor = true;
            this.buttonQuery.Click += new System.EventHandler(this.buttonQuery_Click);
            // 
            // textBoxPurchaserName
            // 
            this.textBoxPurchaserName.Location = new System.Drawing.Point(609, 61);
            this.textBoxPurchaserName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPurchaserName.Name = "textBoxPurchaserName";
            this.textBoxPurchaserName.Size = new System.Drawing.Size(364, 25);
            this.textBoxPurchaserName.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(516, 66);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "购买方名称";
            // 
            // textBoxSellerName
            // 
            this.textBoxSellerName.Location = new System.Drawing.Point(117, 61);
            this.textBoxSellerName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSellerName.Name = "textBoxSellerName";
            this.textBoxSellerName.Size = new System.Drawing.Size(388, 25);
            this.textBoxSellerName.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 66);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "销售方名称";
            // 
            // dateTimePickerDateTo
            // 
            this.dateTimePickerDateTo.Location = new System.Drawing.Point(813, 15);
            this.dateTimePickerDateTo.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerDateTo.Name = "dateTimePickerDateTo";
            this.dateTimePickerDateTo.Size = new System.Drawing.Size(160, 25);
            this.dateTimePickerDateTo.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(781, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "至";
            // 
            // dateTimePickerDareFm
            // 
            this.dateTimePickerDareFm.Location = new System.Drawing.Point(609, 15);
            this.dateTimePickerDareFm.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerDareFm.Name = "dateTimePickerDareFm";
            this.dateTimePickerDareFm.Size = new System.Drawing.Size(160, 25);
            this.dateTimePickerDareFm.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(532, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "开票日期";
            // 
            // textBoxInvNum
            // 
            this.textBoxInvNum.Location = new System.Drawing.Point(352, 15);
            this.textBoxInvNum.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxInvNum.Name = "textBoxInvNum";
            this.textBoxInvNum.Size = new System.Drawing.Size(156, 25);
            this.textBoxInvNum.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(281, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "发票号码";
            // 
            // textBoxInvCode
            // 
            this.textBoxInvCode.Location = new System.Drawing.Point(117, 15);
            this.textBoxInvCode.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxInvCode.Name = "textBoxInvCode";
            this.textBoxInvCode.Size = new System.Drawing.Size(156, 25);
            this.textBoxInvCode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "发票代码";
            // 
            // progressBar_upload
            // 
            this.progressBar_upload.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar_upload.ForeColor = System.Drawing.Color.Gray;
            this.progressBar_upload.Location = new System.Drawing.Point(0, 511);
            this.progressBar_upload.Name = "progressBar_upload";
            this.progressBar_upload.Size = new System.Drawing.Size(1413, 40);
            this.progressBar_upload.TabIndex = 4;
            this.progressBar_upload.Visible = false;
            // 
            // frmVatInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1413, 751);
            this.Controls.Add(this.panelData);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.panelMycontrol);
            this.Controls.Add(this.toolStrip_Invoice);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmVatInvoice";
            this.Text = "我的发票列表";
            this.Load += new System.EventHandler(this.frmVatInvoice_Load);
            this.toolStrip_Invoice.ResumeLayout(false);
            this.toolStrip_Invoice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Invoice)).EndInit();
            this.panelData.ResumeLayout(false);
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip_Invoice;
        private System.Windows.Forms.DataGridView DataGridView_Invoice;
        private System.Windows.Forms.ToolStripButton tsVatInvoiceScan;
        private System.Windows.Forms.ToolStripButton tstripButton_querylasttime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceTypeOrg;
        private System.Windows.Forms.DataGridViewImageColumn InvImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaserRegisterNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaserAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaserBank;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellerRegisterNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellerAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellerBank;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalTaxAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalTax;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PushStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tstripButton_save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tstripButton_pdf;
        private System.Windows.Forms.Panel panelMycontrol;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Button buttonExcel;
        private System.Windows.Forms.Button buttonQuery;
        private System.Windows.Forms.TextBox textBoxPurchaserName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxSellerName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerDareFm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxInvNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxInvCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton toolStripButton_upload;
        private System.Windows.Forms.ProgressBar progressBar_upload;
    }
}