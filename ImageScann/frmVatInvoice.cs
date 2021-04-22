using ImageScann.BLL;
using ImageScann.DAL;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
        VatInvoiceBll vatInvoiceBll = new VatInvoiceBll();
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
            dtpTo.Value = DateTime.Now.AddMonths(1).AddDays(-DateTime.Now.Day); //月末
            ToolStripControlHost host2 = new ToolStripControlHost(dtpTo);
            toolStrip_Invoice.Items.Insert(9, host2);

            DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            DataGridView_Invoice.AllowUserToAddRows = false;
            DataGridView_Invoice.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.LightCyan;
            DataGridView_Invoice.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DataGridView_Invoice.BackgroundColor = System.Drawing.Color.White;
            DataGridView_Invoice.BorderStyle = BorderStyle.Fixed3D;
            DataGridView_Invoice.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;//211, 223, 240
            dataGridViewCellStyle2.BackColor = Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(223)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle2.Font = new Font("宋体", 9F, FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = Color.Navy;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            DataGridView_Invoice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DataGridView_Invoice.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView_Invoice.EnableHeadersVisualStyles = false;
            DataGridView_Invoice.GridColor = SystemColors.GradientInactiveCaption;
            //DataGridView_Invoice.ReadOnly = true;
            DataGridView_Invoice.RowHeadersVisible = false;
            DataGridView_Invoice.RowTemplate.Height = 23;
            //DataGridView_Invoice.RowTemplate.ReadOnly = true;
            DataGridView_Invoice.AutoGenerateColumns = false;
            //dataGridView_Invoice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            DataGridView_Invoice.Columns["TotalAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridView_Invoice.Columns["TotalTaxAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridView_Invoice.Columns["TotalTax"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridView_Invoice.Columns["TotalAmount"].DefaultCellStyle.Format = "N2";
            DataGridView_Invoice.Columns["TotalTaxAmount"].DefaultCellStyle.Format = "N2";
            DataGridView_Invoice.Columns["TotalTax"].DefaultCellStyle.Format = "N2";
            DataGridView_Invoice.Columns["InvImage"].DefaultCellStyle.NullValue = null;
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
            try
            {
                
                DataSet ds = new DataSet();
                ds = vatInvoiceBll.GetVatInvoice(tsTextBox_InvCode.Text, tsTextBox_InvNum.Text, tstripTextBox_SellerName.Text, toolStrip_Invoice.Items[7].Text.ToString(), toolStrip_Invoice.Items[9].Text.ToString(), null);
                DataGridView_Invoice.DataSource = ds.Tables[0];
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string invPatch = ds.Tables[0].Rows[i]["InvoicePatch"].ToString();
                    string imgPatch = AppDomain.CurrentDomain.BaseDirectory + @"vatinvoiceimages\" + invPatch;
                    DataGridView_Invoice.Rows[i].Cells["InvImage"].Value = vatInvoiceBll.GetImage(imgPatch);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "异常提示");
            }
        }
        /// <summary>
        /// 输出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tstripButton_excel_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcel exportToExcel = new ExportToExcel();
                exportToExcel.OutputAsExcelFile(DataGridView_Invoice);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "异常提示");
            }

        }
        /// <summary>
        /// 发票扫描
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsVatInvoiceScan_Click(object sender, EventArgs e)
        {
            try
            {
                _logger.Info(string.Format("发票扫描开始***************************"));
                if (bInitFlag)
                {
                    tsVatInvoiceScan.Enabled = false;
                    string lastScanTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    opskyScan.InvoiceScan();
                    tsVatInvoiceScan.Enabled = true;
                    Common common = new Common();
                    common.SetValue("lastScanTime", lastScanTime);
                }
                MessageBox.Show("扫描完成", "提示");
                _logger.Info(string.Format("发票扫描结束***************************"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "异常提示");
            }
        }

        /// <summary>
        /// 联查发票影像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_Invoice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //如果是在发票影像上双击，则联查发票影像
                if (e.ColumnIndex == 2)
                {
                    int  id = int.Parse(DataGridView_Invoice.Rows[e.RowIndex].Cells["Id"].Value.ToString());                 
                    string imgPatch = AppDomain.CurrentDomain.BaseDirectory + @"vatinvoiceimages\" + vatInvoiceBll.GetInvoicePatch(id);
                    frmQueryImage frm = new frmQueryImage(imgPatch);
                    frm.ShowDialog();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "异常提示");
            }
        }
        /// <summary>
        /// 最近扫描结果查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tstripButton_querylasttime_Click(object sender, EventArgs e)
        {
            try
            {
                string lastScanTime = ConfigurationManager.AppSettings["lastScanTime"];                
                DataSet ds = vatInvoiceBll.GetVatInvoice("", "", "", "", "", lastScanTime);
                DataGridView_Invoice.DataSource = ds.Tables[0];
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string invPatch = ds.Tables[0].Rows[i]["InvoicePatch"].ToString();
                    string imgPatch = AppDomain.CurrentDomain.BaseDirectory + @"vatinvoiceimages\" + invPatch;
                    DataGridView_Invoice.Rows[i].Cells["InvImage"].Value = Image.FromFile(imgPatch);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "异常提示");
            }


        }
        /// <summary>
        /// 保存数据更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tstripButton_save_Click(object sender, EventArgs e)
        {
            try
            {                
                int rows = DataGridView_Invoice.Rows.Count;
                for (int i = 0; i < rows; i++)
                {
                    VatInvoice invoice = new VatInvoice
                    {
                        Id = int.Parse(DataGridView_Invoice.Rows[i].Cells["Id"].Value.ToString()),
                        InvoiceTypeOrg = DataGridView_Invoice.Rows[i].Cells["InvoiceTypeOrg"].Value.ToString(),
                        InvoiceCode = DataGridView_Invoice.Rows[i].Cells["InvoiceCode"].Value.ToString(),
                        InvoiceNumber = DataGridView_Invoice.Rows[i].Cells["InvoiceNumber"].Value.ToString(),
                        InvoiceDate = DataGridView_Invoice.Rows[i].Cells["InvoiceDate"].Value.ToString(),
                        PurchaserName = DataGridView_Invoice.Rows[i].Cells["PurchaserName"].Value.ToString(),
                        PurchaserRegisterNum = DataGridView_Invoice.Rows[i].Cells["PurchaserRegisterNum"].Value.ToString(),
                        PurchaserAddress = DataGridView_Invoice.Rows[i].Cells["PurchaserAddress"].Value.ToString(),
                        PurchaserBank = DataGridView_Invoice.Rows[i].Cells["PurchaserBank"].Value.ToString(),
                        SellerName = DataGridView_Invoice.Rows[i].Cells["SellerName"].Value.ToString(),
                        SellerRegisterNum = DataGridView_Invoice.Rows[i].Cells["SellerRegisterNum"].Value.ToString(),
                        SellerAddress = DataGridView_Invoice.Rows[i].Cells["SellerAddress"].Value.ToString(),
                        SellerBank = DataGridView_Invoice.Rows[i].Cells["SellerBank"].Value.ToString(),
                        TotalAmount = decimal.Parse(DataGridView_Invoice.Rows[i].Cells["TotalAmount"].Value.ToString()),
                        TotalTaxAmount = decimal.Parse(DataGridView_Invoice.Rows[i].Cells["TotalTaxAmount"].Value.ToString()),
                        TotalTax = decimal.Parse(DataGridView_Invoice.Rows[i].Cells["TotalTax"].Value.ToString())
                    };
                    vatInvoiceBll.UpdateVatInvoice(invoice);
                }
                MessageBox.Show("保存成功", "提示");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "异常提示");
            }

        }
        /// <summary>
        /// 导出列表中的发票影像为PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tstripButton_pdf_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFile = new SaveFileDialog();  //实例化保存文件对话框对象
                saveFile.Title = "请选择保存文件路径";
                saveFile.Filter = "PDF文档(*.pdf)|";
                saveFile.OverwritePrompt = true;  //是否覆盖当前文件
                saveFile.RestoreDirectory = true;  //还原目录
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    ImageToPdf imageToPdf = new ImageToPdf();
                    List<string> imgFiles = new List<string>();
                    int rows = DataGridView_Invoice.Rows.Count;
                    for (int i = 0; i < rows; i++)
                    {
                        int id = int.Parse(DataGridView_Invoice.Rows[i].Cells["Id"].Value.ToString());
                        string imgPatch = AppDomain.CurrentDomain.BaseDirectory + @"vatinvoiceimages\" + vatInvoiceBll.GetInvoicePatch(id);
                        imgFiles.Add(imgPatch);
                    }
                    imageToPdf.ExportDataIntoPDF(imgFiles, saveFile.FileName + ".pdf");
                    MessageBox.Show("导出成功", "提示");
                }
                else
                {
                    return;
                }
                
            }
            catch (Exception)
            {
                
            }
        }
    }
}
