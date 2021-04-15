
namespace ImageScann
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ts_Image = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_Invoice = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_index = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_Image,
            this.ts_Invoice});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1067, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ts_Image
            // 
            this.ts_Image.Name = "ts_Image";
            this.ts_Image.Size = new System.Drawing.Size(83, 24);
            this.ts_Image.Text = "影像管理";
            this.ts_Image.Click += new System.EventHandler(this.ts_Image_Click);
            // 
            // ts_Invoice
            // 
            this.ts_Invoice.Name = "ts_Invoice";
            this.ts_Invoice.Size = new System.Drawing.Size(83, 24);
            this.ts_Invoice.Text = "发票管理";
            this.ts_Invoice.Click += new System.EventHandler(this.ts_Invoice_Click);
            // 
            // panel_index
            // 
            this.panel_index.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_index.Location = new System.Drawing.Point(0, 28);
            this.panel_index.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel_index.Name = "panel_index";
            this.panel_index.Size = new System.Drawing.Size(1067, 534);
            this.panel_index.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 562);
            this.Controls.Add(this.panel_index);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMain";
            this.Text = "扫描客户端程序";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel_index;
        private System.Windows.Forms.ToolStripMenuItem ts_Image;
        private System.Windows.Forms.ToolStripMenuItem ts_Invoice;
    }
}