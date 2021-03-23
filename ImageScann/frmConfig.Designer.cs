namespace ImageScann
{
    partial class frmConfig
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
            this.cmbImageType = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbRes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chbCrop = new System.Windows.Forms.CheckBox();
            this.chbDeskew = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chbAutomaticOrientation = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "图像类型:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbImageType
            // 
            this.cmbImageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbImageType.FormattingEnabled = true;
            this.cmbImageType.Location = new System.Drawing.Point(73, 14);
            this.cmbImageType.Name = "cmbImageType";
            this.cmbImageType.Size = new System.Drawing.Size(235, 20);
            this.cmbImageType.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(233, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 2;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbRes
            // 
            this.cmbRes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRes.FormattingEnabled = true;
            this.cmbRes.Location = new System.Drawing.Point(73, 48);
            this.cmbRes.Name = "cmbRes";
            this.cmbRes.Size = new System.Drawing.Size(235, 20);
            this.cmbRes.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "分辨率:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "自动剪切:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chbCrop
            // 
            this.chbCrop.AutoSize = true;
            this.chbCrop.Location = new System.Drawing.Point(73, 86);
            this.chbCrop.Name = "chbCrop";
            this.chbCrop.Size = new System.Drawing.Size(15, 14);
            this.chbCrop.TabIndex = 6;
            this.chbCrop.UseVisualStyleBackColor = true;
            // 
            // chbDeskew
            // 
            this.chbDeskew.AutoSize = true;
            this.chbDeskew.Location = new System.Drawing.Point(73, 113);
            this.chbDeskew.Name = "chbDeskew";
            this.chbDeskew.Size = new System.Drawing.Size(15, 14);
            this.chbDeskew.TabIndex = 8;
            this.chbDeskew.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "纠正歪斜:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chbAutomaticOrientation
            // 
            this.chbAutomaticOrientation.AutoSize = true;
            this.chbAutomaticOrientation.Location = new System.Drawing.Point(257, 89);
            this.chbAutomaticOrientation.Name = "chbAutomaticOrientation";
            this.chbAutomaticOrientation.Size = new System.Drawing.Size(15, 14);
            this.chbAutomaticOrientation.TabIndex = 10;
            this.chbAutomaticOrientation.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(168, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "自动方向校正:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 267);
            this.Controls.Add(this.chbAutomaticOrientation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chbDeskew);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chbCrop);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbRes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbImageType);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "扫描参数设置";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbImageType;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbRes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chbCrop;
        private System.Windows.Forms.CheckBox chbDeskew;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chbAutomaticOrientation;
        private System.Windows.Forms.Label label5;
    }
}