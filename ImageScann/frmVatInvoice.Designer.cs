
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
            this.dataGridView_Invoice = new System.Windows.Forms.DataGridView();
            this.InvoiceTypeOrg = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PushStatus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tsVatInvoiceScan = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip_Invoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Invoice)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip_Invoice
            // 
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
            this.tsVatInvoiceScan});
            this.toolStrip_Invoice.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_Invoice.Name = "toolStrip_Invoice";
            this.toolStrip_Invoice.Size = new System.Drawing.Size(1147, 47);
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
            this.tsTextBox_InvCode.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.tsTextBox_InvCode.Name = "tsTextBox_InvCode";
            this.tsTextBox_InvCode.Size = new System.Drawing.Size(132, 47);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(69, 44);
            this.toolStripLabel2.Text = "发票号码";
            // 
            // tsTextBox_InvNum
            // 
            this.tsTextBox_InvNum.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.tsTextBox_InvNum.Name = "tsTextBox_InvNum";
            this.tsTextBox_InvNum.Size = new System.Drawing.Size(132, 47);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(84, 44);
            this.toolStripLabel3.Text = "销售方名称";
            // 
            // tstripTextBox_SellerName
            // 
            this.tstripTextBox_SellerName.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.tstripTextBox_SellerName.Name = "tstripTextBox_SellerName";
            this.tstripTextBox_SellerName.Size = new System.Drawing.Size(132, 47);
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
            this.tstripButton_query.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // dataGridView_Invoice
            // 
            this.dataGridView_Invoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Invoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvoiceTypeOrg,
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
            this.Remarks,
            this.PushStatus});
            this.dataGridView_Invoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Invoice.Location = new System.Drawing.Point(0, 47);
            this.dataGridView_Invoice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView_Invoice.Name = "dataGridView_Invoice";
            this.dataGridView_Invoice.RowHeadersWidth = 51;
            this.dataGridView_Invoice.RowTemplate.Height = 23;
            this.dataGridView_Invoice.Size = new System.Drawing.Size(1147, 515);
            this.dataGridView_Invoice.TabIndex = 1;
            // 
            // InvoiceTypeOrg
            // 
            this.InvoiceTypeOrg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.InvoiceTypeOrg.DataPropertyName = "InvoiceTypeOrg";
            this.InvoiceTypeOrg.HeaderText = "发票名称";
            this.InvoiceTypeOrg.MinimumWidth = 6;
            this.InvoiceTypeOrg.Name = "InvoiceTypeOrg";
            this.InvoiceTypeOrg.Width = 75;
            // 
            // InvoiceCode
            // 
            this.InvoiceCode.DataPropertyName = "InvoiceCode";
            this.InvoiceCode.HeaderText = "发票代码";
            this.InvoiceCode.MinimumWidth = 6;
            this.InvoiceCode.Name = "InvoiceCode";
            this.InvoiceCode.Width = 125;
            // 
            // InvoiceNumber
            // 
            this.InvoiceNumber.DataPropertyName = "InvoiceNumber";
            this.InvoiceNumber.HeaderText = "发票号码";
            this.InvoiceNumber.MinimumWidth = 6;
            this.InvoiceNumber.Name = "InvoiceNumber";
            this.InvoiceNumber.Width = 125;
            // 
            // InvoiceDate
            // 
            this.InvoiceDate.DataPropertyName = "InvoiceDate";
            this.InvoiceDate.HeaderText = "开票日期";
            this.InvoiceDate.MinimumWidth = 6;
            this.InvoiceDate.Name = "InvoiceDate";
            this.InvoiceDate.Width = 125;
            // 
            // PurchaserName
            // 
            this.PurchaserName.DataPropertyName = "PurchaserName";
            this.PurchaserName.HeaderText = "购买方名称";
            this.PurchaserName.MinimumWidth = 6;
            this.PurchaserName.Name = "PurchaserName";
            this.PurchaserName.Width = 125;
            // 
            // PurchaserRegisterNum
            // 
            this.PurchaserRegisterNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.PurchaserRegisterNum.DataPropertyName = "PurchaserRegisterNum";
            this.PurchaserRegisterNum.HeaderText = "购买方纳税人识别号";
            this.PurchaserRegisterNum.MinimumWidth = 6;
            this.PurchaserRegisterNum.Name = "PurchaserRegisterNum";
            this.PurchaserRegisterNum.Width = 116;
            // 
            // PurchaserAddress
            // 
            this.PurchaserAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.PurchaserAddress.DataPropertyName = "PurchaserAddress";
            this.PurchaserAddress.HeaderText = "购买方地址、电话";
            this.PurchaserAddress.MinimumWidth = 6;
            this.PurchaserAddress.Name = "PurchaserAddress";
            this.PurchaserAddress.Width = 116;
            // 
            // PurchaserBank
            // 
            this.PurchaserBank.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.PurchaserBank.DataPropertyName = "PurchaserBank";
            this.PurchaserBank.HeaderText = "购买方开户行及账号";
            this.PurchaserBank.MinimumWidth = 6;
            this.PurchaserBank.Name = "PurchaserBank";
            this.PurchaserBank.Width = 116;
            // 
            // SellerName
            // 
            this.SellerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.SellerName.DataPropertyName = "SellerName";
            this.SellerName.HeaderText = "销售方名称";
            this.SellerName.MinimumWidth = 6;
            this.SellerName.Name = "SellerName";
            this.SellerName.Width = 89;
            // 
            // SellerRegisterNum
            // 
            this.SellerRegisterNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.SellerRegisterNum.DataPropertyName = "SellerRegisterNum";
            this.SellerRegisterNum.HeaderText = "销售方纳税人识别号";
            this.SellerRegisterNum.MinimumWidth = 6;
            this.SellerRegisterNum.Name = "SellerRegisterNum";
            this.SellerRegisterNum.Width = 116;
            // 
            // SellerAddress
            // 
            this.SellerAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.SellerAddress.DataPropertyName = "SellerAddress";
            this.SellerAddress.HeaderText = "销售方地址、电话";
            this.SellerAddress.MinimumWidth = 6;
            this.SellerAddress.Name = "SellerAddress";
            this.SellerAddress.Width = 116;
            // 
            // SellerBank
            // 
            this.SellerBank.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.SellerBank.DataPropertyName = "SellerBank";
            this.SellerBank.HeaderText = "销售方开户行及账号";
            this.SellerBank.MinimumWidth = 6;
            this.SellerBank.Name = "SellerBank";
            this.SellerBank.Width = 116;
            // 
            // TotalAmount
            // 
            this.TotalAmount.DataPropertyName = "TotalAmount";
            this.TotalAmount.HeaderText = "合计金额";
            this.TotalAmount.MinimumWidth = 6;
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.Width = 125;
            // 
            // TotalTaxAmount
            // 
            this.TotalTaxAmount.DataPropertyName = "TotalTaxAmount";
            this.TotalTaxAmount.HeaderText = "价税合计";
            this.TotalTaxAmount.MinimumWidth = 6;
            this.TotalTaxAmount.Name = "TotalTaxAmount";
            this.TotalTaxAmount.Width = 125;
            // 
            // TotalTax
            // 
            this.TotalTax.DataPropertyName = "TotalTax";
            this.TotalTax.HeaderText = "合计税额";
            this.TotalTax.MinimumWidth = 6;
            this.TotalTax.Name = "TotalTax";
            this.TotalTax.Width = 125;
            // 
            // Remarks
            // 
            this.Remarks.DataPropertyName = "Remarks";
            this.Remarks.HeaderText = "备注";
            this.Remarks.MinimumWidth = 6;
            this.Remarks.Name = "Remarks";
            this.Remarks.Width = 125;
            // 
            // PushStatus
            // 
            this.PushStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.PushStatus.DataPropertyName = "PushStatus";
            this.PushStatus.HeaderText = "推送状态";
            this.PushStatus.MinimumWidth = 6;
            this.PushStatus.Name = "PushStatus";
            this.PushStatus.ReadOnly = true;
            this.PushStatus.Width = 52;
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 47);
            // 
            // frmVatInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 562);
            this.Controls.Add(this.dataGridView_Invoice);
            this.Controls.Add(this.toolStrip_Invoice);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmVatInvoice";
            this.Text = "我的发票列表";
            this.Load += new System.EventHandler(this.frmVatInvoice_Load);
            this.toolStrip_Invoice.ResumeLayout(false);
            this.toolStrip_Invoice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Invoice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip_Invoice;
        private System.Windows.Forms.DataGridView dataGridView_Invoice;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceTypeOrg;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PushStatus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsVatInvoiceScan;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}