namespace ImageScann
{
    partial class frmServerConfig
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddress = new System.Windows.Forms.Button();
            this.txt_imgUrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_invoiceUrl = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cBox_ScanMode = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "影像服务器地址:";
            // 
            // btnAddress
            // 
            this.btnAddress.Location = new System.Drawing.Point(296, 146);
            this.btnAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddress.Name = "btnAddress";
            this.btnAddress.Size = new System.Drawing.Size(100, 42);
            this.btnAddress.TabIndex = 1;
            this.btnAddress.Text = "确定";
            this.btnAddress.UseVisualStyleBackColor = true;
            this.btnAddress.Click += new System.EventHandler(this.btnAddress_Click);
            // 
            // txt_imgUrl
            // 
            this.txt_imgUrl.Location = new System.Drawing.Point(151, 22);
            this.txt_imgUrl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_imgUrl.Name = "txt_imgUrl";
            this.txt_imgUrl.Size = new System.Drawing.Size(259, 25);
            this.txt_imgUrl.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "发票服务器地址:";
            // 
            // txt_invoiceUrl
            // 
            this.txt_invoiceUrl.Location = new System.Drawing.Point(151, 64);
            this.txt_invoiceUrl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_invoiceUrl.Name = "txt_invoiceUrl";
            this.txt_invoiceUrl.Size = new System.Drawing.Size(259, 25);
            this.txt_invoiceUrl.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(57, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "扫描模式:";
            // 
            // cBox_ScanMode
            // 
            this.cBox_ScanMode.FormattingEnabled = true;
            this.cBox_ScanMode.Items.AddRange(new object[] {
            "影像模式",
            "识票模式"});
            this.cBox_ScanMode.Location = new System.Drawing.Point(151, 104);
            this.cBox_ScanMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cBox_ScanMode.Name = "cBox_ScanMode";
            this.cBox_ScanMode.Size = new System.Drawing.Size(101, 23);
            this.cBox_ScanMode.TabIndex = 16;
            this.cBox_ScanMode.Text = "影像模式";
            // 
            // frmServerConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 211);
            this.Controls.Add(this.cBox_ScanMode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_invoiceUrl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_imgUrl);
            this.Controls.Add(this.btnAddress);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(453, 258);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(453, 258);
            this.Name = "frmServerConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "基本配置";
            this.Load += new System.EventHandler(this.frmServerConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddress;
        private System.Windows.Forms.TextBox txt_imgUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_invoiceUrl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cBox_ScanMode;
    }
}