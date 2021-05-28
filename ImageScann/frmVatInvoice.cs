using ImageScann.BLL;
using ImageScann.DAL;
using Newtonsoft.Json;
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
        string invCode = "";
        string invNum = "";
        string sellerName = "";
        string purchaserName = "";
        string invDateFr = "";
        string invDateTo = "";
        public frmVatInvoice()
        {
            InitializeComponent();
        }

        private void frmVatInvoice_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            dateTimePickerDareFm.Format = DateTimePickerFormat.Custom;
            dateTimePickerDareFm.CustomFormat = "yyyy-MM-dd";
            dateTimePickerDareFm.Value = DateTime.Now.AddDays(1 - DateTime.Now.Day); //月初  
            dateTimePickerDateTo.Format = DateTimePickerFormat.Custom;
            dateTimePickerDateTo.CustomFormat = "yyyy-MM-dd";
            dateTimePickerDateTo.Value = DateTime.Now.AddMonths(1).AddDays(-DateTime.Now.Day); //月末


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
            //绑定自定义控件
            panelMycontrol.Controls.Clear();
            PageControl pageControl = new PageControl();
            //pageControl.PageSize = (panelData.Height - 50) / 23;
            pageControl.Parent = panelMycontrol;
            pageControl.Dock = DockStyle.Left;
            pageControl.Kind = 0;
            pageControl.PageIndex = 0;
            pageControl.BindPageEvent += BindPage;
            pageControl.SetPage();
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
                    int id = int.Parse(DataGridView_Invoice.Rows[e.RowIndex].Cells["Id"].Value.ToString());
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
                panelMycontrol.Controls.Clear();
                PageControl pageControl = new PageControl();
                //pageControl.PageSize = (panelData.Height - 50) / 23;
                pageControl.Parent = panelMycontrol;
                pageControl.Dock = DockStyle.Left;
                pageControl.Kind = 2;
                pageControl.PageIndex = 0;
                pageControl.BindPageEvent += BindPage;
                pageControl.SetPage();
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
                if (DataGridView_Invoice.IsCurrentCellInEditMode)
                {
                    DataGridView_Invoice.CurrentCell = null;
                }
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
                    DataSet ds = GetAllData();
                    int rows = ds.Tables[0].Rows.Count;
                    for (int i = 0; i < rows; i++)
                    {
                        int id = int.Parse(ds.Tables[0].Rows[i]["Id"].ToString());
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
        /// <summary>
        /// 获取查询所有结果（分页后要输出全部数据时使用）
        /// </summary>
        /// <returns></returns>
        private DataSet GetAllData()
        {
            return vatInvoiceBll.GetVatInvoice(invCode, invNum, sellerName, purchaserName, invDateFr, invDateTo, null, false);
        }
        /// <summary>
        /// 查询绑定页
        /// </summary>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="kind">查询方式 1：查询 2：查询最近扫描</param>
        /// <param name="totalCount">总记录数</param>
        private void BindPage(int pageSize, int pageIndex, int kind, out int totalCount)
        {
            _ = new DataSet();
            invCode = textBoxInvCode.Text;
            invNum = textBoxInvNum.Text;
            sellerName = textBoxSellerName.Text;
            purchaserName = textBoxPurchaserName.Text;
            invDateFr = dateTimePickerDareFm.Text.ToString();
            invDateTo = dateTimePickerDateTo.Text.ToString();
            DataSet ds;
            if (kind == 1)   //正常查询
            {
                ds = vatInvoiceBll.GetVatInvoice(invCode, invNum, sellerName, purchaserName, invDateFr, invDateTo, null,false, pageSize, pageIndex);
                totalCount = GetAllData().Tables[0].Rows.Count;
            }
            else if (kind == 2)  //最近上传记录
            {
                string lastScanTime = ConfigurationManager.AppSettings["lastScanTime"];
                ds = vatInvoiceBll.GetVatInvoice(invCode, invNum, sellerName, "", "", "", lastScanTime,false, pageSize, pageIndex);
                totalCount = vatInvoiceBll.GetVatInvoice(invCode, invNum, sellerName, "", "", "", lastScanTime,false, 0, 0).Tables[0].Rows.Count;
            }
            else if (kind == 3)   //查待上传的记录
            {                
                ds = vatInvoiceBll.GetVatInvoice("", "", "", "", "", "", "",true, pageSize, pageIndex);
                totalCount = vatInvoiceBll.GetVatInvoice("", "", "", "", "", "", "",true, 0, 0).Tables[0].Rows.Count;
            }
            else
            {
                totalCount = 0;
                ds = null;
            }

            if (ds != null)
            {
                DataGridView_Invoice.DataSource = ds.Tables[0];
                Image invIco = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"icon\invoice.jpg");
                for (int i = 0; i < DataGridView_Invoice.Rows.Count; i++)
                {
                    DataGridView_Invoice.Rows[i].Cells["InvImage"].Value = invIco;
                }
            }
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonQuery_Click(object sender, EventArgs e)
        {
            try
            {
                panelMycontrol.Controls.Clear();
                PageControl pageControl = new PageControl();
                pageControl.Parent = panelMycontrol;
                pageControl.Dock = DockStyle.Left;
                pageControl.Kind = 1;
                pageControl.PageIndex = 0;
                pageControl.BindPageEvent += BindPage;
                pageControl.SetPage();
                //DataSet ds = new DataSet();
                //ds = vatInvoiceBll.GetVatInvoice(tsTextBox_InvCode.Text, tsTextBox_InvNum.Text, tstripTextBox_SellerName.Text, toolStrip_Invoice.Items[7].Text.ToString(), toolStrip_Invoice.Items[9].Text.ToString(), null);
                //DataGridView_Invoice.DataSource = ds.Tables[0];
                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                //    string invPatch = ds.Tables[0].Rows[i]["InvoicePatch"].ToString();
                //    string imgPatch = AppDomain.CurrentDomain.BaseDirectory + @"vatinvoiceimages\" + invPatch;
                //    DataGridView_Invoice.Rows[i].Cells["InvImage"].Value = vatInvoiceBll.GetImage(imgPatch);
                //}
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "异常提示");
            }
        }
        /// <summary>
        /// 输出excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonExcel_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcel exportToExcel = new ExportToExcel();
                exportToExcel.OutputAsExcelFile(GetAllData(), DataGridView_Invoice);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "异常提示");
            }
        }
        /// <summary>
        /// 上传发票
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_upload_Click(object sender, EventArgs e)
        {
            DataSet ds = GetAllData();
            DataTable dataTable = ds.Tables[0];
            DataView dataView = new DataView(dataTable);
            dataView.RowFilter = "PushStatus = 0";
            string result = "1";
            int num = dataView.Count;
            if (num > 0)
            {
                progressBar_upload.Visible = true;
                progressBar_upload.Maximum = num;
                progressBar_upload.Value = 1;
                progressBar_upload.Step = 1;
                string det = "[]";
                for (int i = 0; i < num; i++)
                {
                    DataRowView dr = dataView[i];
                    string invType = dr["InvoiceTypeOrg"].ToString() == "增值税专用发票" ? "01" : "02";
                    int id = int.Parse(dr["Id"].ToString());
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic.Add("DepartID", "0201");
                    dic.Add("ChannelID", "90");
                    dic.Add("DocDate", DateTime.Now.ToString("yyyy-MM-dd"));
                    dic.Add("InvoiceCode", dr["InvoiceCode"]);
                    dic.Add("InvoiceNumber", dr["InvoiceNumber"]);
                    dic.Add("InvoiceDate", dr["InvoiceDate"]);
                    dic.Add("PurchaserName", dr["PurchaserName"]);
                    dic.Add("PurchaserRegisterNum", dr["PurchaserRegisterNum"]);
                    dic.Add("PurchaserAddress", dr["PurchaserAddress"]);
                    dic.Add("PurchaserBank", dr["PurchaserBank"]);
                    dic.Add("SellerName", dr["SellerName"]);
                    dic.Add("SellerRegisterNum", dr["SellerRegisterNum"]);
                    dic.Add("SellerAddress", dr["SellerAddress"]);
                    dic.Add("SellerBank", dr["SellerBank"]);
                    dic.Add("TotalAmount", dr["TotalAmount"]);
                    dic.Add("TotalTax", dr["TotalTax"]);
                    dic.Add("TotalTaxAmount", dr["TotalTaxAmount"]);
                    dic.Add("IsInvalid", false);
                    string doc = JsonConvert.SerializeObject(dic);
                    string fileName = dr["InvoiceCode"] + "_" + dr["InvoiceNumber"] + ".jpg";
                    string filePatch = AppDomain.CurrentDomain.BaseDirectory + @"vatinvoiceimages\" + vatInvoiceBll.GetInvoicePatch(id);
                    result = vatInvoiceBll.InvoiceAdd(invType, doc, det, fileName, filePatch);
                    if (result == "1")
                        vatInvoiceBll.UpdatePushStatus(id);
                    else
                    {
                        break;
                    }
                    progressBar_upload.PerformStep();
                }
                progressBar_upload.Visible = false;
                MessageBox.Show(result == "1" ? "上传完成" : result, "提示");
            }
            else
            {
                MessageBox.Show("无待上传发票", "提示");
            }


        }

        private void toolStripButton_queryBeUploaded_Click(object sender, EventArgs e)
        {
            try
            {
                panelMycontrol.Controls.Clear();
                PageControl pageControl = new PageControl();
                pageControl.Parent = panelMycontrol;
                pageControl.Dock = DockStyle.Left;
                pageControl.Kind = 3;
                pageControl.PageIndex = 0;
                pageControl.BindPageEvent += BindPage;
                pageControl.SetPage();
                //DataSet ds = new DataSet();
                //ds = vatInvoiceBll.GetVatInvoice(tsTextBox_InvCode.Text, tsTextBox_InvNum.Text, tstripTextBox_SellerName.Text, toolStrip_Invoice.Items[7].Text.ToString(), toolStrip_Invoice.Items[9].Text.ToString(), null);
                //DataGridView_Invoice.DataSource = ds.Tables[0];
                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                //    string invPatch = ds.Tables[0].Rows[i]["InvoicePatch"].ToString();
                //    string imgPatch = AppDomain.CurrentDomain.BaseDirectory + @"vatinvoiceimages\" + invPatch;
                //    DataGridView_Invoice.Rows[i].Cells["InvImage"].Value = vatInvoiceBll.GetImage(imgPatch);
                //}
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString(), "异常提示");
            }
        }
    }
}
