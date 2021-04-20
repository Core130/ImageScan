using ImageScann.BLL;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageScann
{
    public partial class frmVatInvoice : Form
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        bool bInitFlag = false;
        string msg = "";        
        OpskyScan opskyScan = new OpskyScan();
        public frmVatInvoice()
        {
            InitializeComponent();
        }

        private void frmVatInvoice_Load(object sender, EventArgs e)
        {            
            //绑定开票日期控件
            DateTimePicker dtpFr = new DateTimePicker();
            dtpFr.Width = 110;
            dtpFr.Format = DateTimePickerFormat.Custom;
            dtpFr.Value = DateTime.Now.AddDays(1 - DateTime.Now.Day); //月初
            ToolStripControlHost host1 = new ToolStripControlHost(dtpFr);
            toolStrip_Invoice.Items.Insert(7, host1);

            DateTimePicker dtpTo = new DateTimePicker();
            dtpTo.Width = 110;
            dtpTo.Format = DateTimePickerFormat.Custom;
            dtpTo.Value = DateTime.Now.AddMonths(1).AddDays(- DateTime.Now.Day); //月末
            ToolStripControlHost host2 = new ToolStripControlHost(dtpTo);
            toolStrip_Invoice.Items.Insert(9, host2);

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
            //this.dataGridView_Invoice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            bInitFlag = opskyScan.InitOpSkyScan(out msg); //初始化扫描仪
            if (!bInitFlag)
            {
                MessageBox.Show(msg, "提示");
                tsVatInvoiceScan.Enabled = false;               
            }
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tstripButton_query_Click(object sender, EventArgs e)
        {
            VatInvoiceBll vat_InvoiceBll = new VatInvoiceBll();
            DataSet ds = new DataSet();
            ds = vat_InvoiceBll.GetVatInvoice(tsTextBox_InvCode.Text,tsTextBox_InvNum.Text,tstripTextBox_SellerName.Text, toolStrip_Invoice.Items[7].Text.ToString(), toolStrip_Invoice.Items[9].Text.ToString());
            dataGridView_Invoice.DataSource = ds.Tables[0];
        }
        /// <summary>
        /// 输出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tstripButton_excel_Click(object sender, EventArgs e)
        {
            ExportToExcel exportToExcel = new ExportToExcel();
            exportToExcel.OutputAsExcelFile(dataGridView_Invoice);
        }

        private void tsVatInvoiceScan_Click(object sender, EventArgs e)
        {
            _logger.Info(string.Format("发票扫描开始***************************"));                       
            if (bInitFlag)
            {
                tsVatInvoiceScan.Enabled = false;
                opskyScan.InvoiceScan();
                tsVatInvoiceScan.Enabled = true;
            }
            _logger.Info(string.Format("发票扫描结束***************************"));
        }
    }
}
