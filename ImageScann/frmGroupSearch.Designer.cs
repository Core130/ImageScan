namespace ImageScann
{
    partial class frmGroupSearch
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.chGroupName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNodesCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.lImageCount = new System.Windows.Forms.Label();
            this.LGroupCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chGroupName,
            this.chNodesCount,
            this.chFileSize});
            this.listView1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(643, 390);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // chGroupName
            // 
            this.chGroupName.Text = "组名";
            this.chGroupName.Width = 97;
            // 
            // chNodesCount
            // 
            this.chNodesCount.Text = "子个项数";
            this.chNodesCount.Width = 125;
            // 
            // chFileSize
            // 
            this.chFileSize.Text = "组文件大小（K）";
            this.chFileSize.Width = 386;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 418);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "图像数：";
            // 
            // lImageCount
            // 
            this.lImageCount.AutoSize = true;
            this.lImageCount.Location = new System.Drawing.Point(79, 419);
            this.lImageCount.Name = "lImageCount";
            this.lImageCount.Size = new System.Drawing.Size(0, 12);
            this.lImageCount.TabIndex = 2;
            // 
            // LGroupCount
            // 
            this.LGroupCount.AutoSize = true;
            this.LGroupCount.Location = new System.Drawing.Point(218, 419);
            this.LGroupCount.Name = "LGroupCount";
            this.LGroupCount.Size = new System.Drawing.Size(0, 12);
            this.LGroupCount.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(167, 418);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "组数：";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(363, 419);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "确认";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(468, 418);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmGroupSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 468);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.LGroupCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lImageCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Name = "frmGroupSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "分组信息查询";
            this.Load += new System.EventHandler(this.frmGroupSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader chGroupName;
        private System.Windows.Forms.ColumnHeader chNodesCount;
        private System.Windows.Forms.ColumnHeader chFileSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lImageCount;
        private System.Windows.Forms.Label LGroupCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}