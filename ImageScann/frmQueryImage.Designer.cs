
namespace ImageScann
{
    partial class frmQueryImage
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
            this.picBoxInvoice = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxInvoice)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxInvoice
            // 
            this.picBoxInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBoxInvoice.Location = new System.Drawing.Point(0, 0);
            this.picBoxInvoice.Name = "picBoxInvoice";
            this.picBoxInvoice.Size = new System.Drawing.Size(1232, 772);
            this.picBoxInvoice.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxInvoice.TabIndex = 0;
            this.picBoxInvoice.TabStop = false;
            // 
            // frmQueryImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1232, 772);
            this.Controls.Add(this.picBoxInvoice);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQueryImage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "发票影像";
            this.Load += new System.EventHandler(this.frmQueryImage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxInvoice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxInvoice;
    }
}