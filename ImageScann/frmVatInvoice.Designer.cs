
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
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsTextBox_InvCode = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tsTextBox_InvNum = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tstripTextBox_SellerName = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tstripButton_query = new System.Windows.Forms.ToolStripButton();
            this.tstripButton_excel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsVatInvoiceScan = new System.Windows.Forms.ToolStripButton();
            this.tstripButton_querylasttime = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tstripButton_save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tstripButton_pdf = new System.Windows.Forms.ToolStripButton();
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
            this.toolStrip_Invoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Invoice)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip_Invoice
            // 
            this.toolStrip_Invoice.BackColor = System.Drawing.Color.White;
            this.toolStrip_Invoice.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip_Invoice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tsTextBox_InvCode,
            this.toolStripLabel2,
            this.tsTextBox_InvNum,
            this.toolStripLabel3,
            this.tstripTextBox_SellerName,
            this.toolStripLabel4,
            this.toolStripLabel5,
            this.toolStripSeparator1,
            this.tstripButton_query,
            this.tstripButton_excel,
            this.toolStripSeparator2,
            this.tsVatInvoiceScan,
            this.tstripButton_querylasttime,
            this.toolStripSeparator3,
            this.tstripButton_save,
            this.toolStripSeparator4,
            this.tstripButton_pdf});
            this.toolStrip_Invoice.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_Invoice.Name = "toolStrip_Invoice";
            this.toolStrip_Invoice.Size = new System.Drawing.Size(1305, 47);
            this.toolStrip_Invoice.TabIndex = 0;
            this.toolStrip_Invoice.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(69, 44);
            this.toolStripLabel1.Text = "发票代码";
            // 
            // tsTextBox_InvCode
            // 
            this.tsTextBox_InvCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tsTextBox_InvCode.Name = "tsTextBox_InvCode";
            this.tsTextBox_InvCode.Size = new System.Drawing.Size(133, 47);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(69, 44);
            this.toolStripLabel2.Text = "发票号码";
            // 
            // tsTextBox_InvNum
            // 
            this.tsTextBox_InvNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tsTextBox_InvNum.Name = "tsTextBox_InvNum";
            this.tsTextBox_InvNum.Size = new System.Drawing.Size(133, 47);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(84, 44);
            this.toolStripLabel3.Text = "销售方名称";
            // 
            // tstripTextBox_SellerName
            // 
            this.tstripTextBox_SellerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tstripTextBox_SellerName.Name = "tstripTextBox_SellerName";
            this.tstripTextBox_SellerName.Size = new System.Drawing.Size(231, 47);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(69, 44);
            this.toolStripLabel4.Text = "开票日期";
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(24, 44);
            this.toolStripLabel5.Text = "至";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 47);
            // 
            // tstripButton_query
            // 
            this.tstripButton_query.Image = ((System.Drawing.Image)(resources.GetObject("tstripButton_query.Image")));
            this.tstripButton_query.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tstripButton_query.Name = "tstripButton_query";
            this.tstripButton_query.Size = new System.Drawing.Size(43, 44);
            this.tstripButton_query.Text = "查询";
            this.tstripButton_query.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tstripButton_query.Click += new System.EventHandler(this.tstripButton_query_Click);
            // 
            // tstripButton_excel
            // 
            this.tstripButton_excel.Image = ((System.Drawing.Image)(resources.GetObject("tstripButton_excel.Image")));
            this.tstripButton_excel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tstripButton_excel.Name = "tstripButton_excel";
            this.tstripButton_excel.Size = new System.Drawing.Size(43, 44);
            this.tstripButton_excel.Text = "输出";
            this.tstripButton_excel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tstripButton_excel.Click += new System.EventHandler(this.tstripButton_excel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 47);
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
            this.DataGridView_Invoice.Location = new System.Drawing.Point(0, 47);
            this.DataGridView_Invoice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DataGridView_Invoice.Name = "DataGridView_Invoice";
            this.DataGridView_Invoice.RowHeadersWidth = 51;
            this.DataGridView_Invoice.RowTemplate.Height = 23;
            this.DataGridView_Invoice.Size = new System.Drawing.Size(1305, 481);
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
            this.panelMycontrol.Location = new System.Drawing.Point(0, 528);
            this.panelMycontrol.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelMycontrol.Name = "panelMycontrol";
            this.panelMycontrol.Size = new System.Drawing.Size(1305, 44);
            this.panelMycontrol.TabIndex = 2;
            // 
            // panelData
            // 
            this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelData.Location = new System.Drawing.Point(0, 0);
            this.panelData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(1305, 572);
            this.panelData.TabIndex = 3;
            // 
            // frmVatInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1305, 572);
            this.Controls.Add(this.DataGridView_Invoice);
            this.Controls.Add(this.panelMycontrol);
            this.Controls.Add(this.toolStrip_Invoice);
            this.Controls.Add(this.panelData);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmVatInvoice";
            this.Text = "我的发票列表";
            this.Load += new System.EventHandler(this.frmVatInvoice_Load);
            this.toolStrip_Invoice.ResumeLayout(false);
            this.toolStrip_Invoice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Invoice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip_Invoice;
        private System.Windows.Forms.DataGridView DataGridView_Invoice;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tsTextBox_InvCode;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox tsTextBox_InvNum;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox tstripTextBox_SellerName;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripButton tstripButton_query;
        private System.Windows.Forms.ToolStripButton tstripButton_excel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsVatInvoiceScan;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
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
    }
}