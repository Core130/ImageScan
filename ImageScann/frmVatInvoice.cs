using ImageScann.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageScann
{
    public partial class frmVatInvoice : Form
    {
        public frmVatInvoice()
        {
            InitializeComponent();
        }

        private void frmVatInvoice_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView_Invoice.AllowUserToAddRows = false;
            this.dataGridView_Invoice.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.dataGridView_Invoice.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Invoice.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_Invoice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_Invoice.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;//211, 223, 240
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(223)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView_Invoice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_Invoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Invoice.EnableHeadersVisualStyles = false;
            this.dataGridView_Invoice.GridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridView_Invoice.ReadOnly = true;
            this.dataGridView_Invoice.RowHeadersVisible = false;
            this.dataGridView_Invoice.RowTemplate.Height = 23;
            this.dataGridView_Invoice.RowTemplate.ReadOnly = true;
        }

        private void tstripButton_query_Click(object sender, EventArgs e)
        {
            Vat_InvoiceBll vat_InvoiceBll = new Vat_InvoiceBll();
            DataSet ds = new DataSet();
            ds = vat_InvoiceBll.GetVatInvoice();
            dataGridView_Invoice.DataSource = ds.Tables[0];
        }

        private void tstripButton_excel_Click(object sender, EventArgs e)
        {
            ExportToExcel exportToExcel = new ExportToExcel();
            exportToExcel.OutputAsExcelFile(dataGridView_Invoice);
        }
    }
}
