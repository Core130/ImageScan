using ImageScann.BLL;
using ImageScann.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ImageScann
{
    public partial class frmConfig : Form
    {
        string iniPath;
        public frmConfig()
        {
            InitializeComponent();
            iniPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PacsScanInf_ICP_E.ini");
        }

        private void frmConfig_Load(object sender, System.EventArgs e)
        {
            var imageTypes = new List<DropDownItem>();
            imageTypes.Add(new DropDownItem { Text = "自动", Value = "Automatic" });
            imageTypes.Add(new DropDownItem { Text = "彩色", Value = "Color" });
            imageTypes.Add(new DropDownItem { Text = "黑白", Value = "Black&White" });
            cmbImageType.ValueMember = "Value";
            cmbImageType.DisplayMember = "Text";
            cmbImageType.DataSource = imageTypes;

            var resolution = new List<DropDownItem>();
            resolution.Add(new DropDownItem { Text = "100", Value = "100" });
            resolution.Add(new DropDownItem { Text = "150", Value = "150" });
            resolution.Add(new DropDownItem { Text = "200", Value = "200" });
            resolution.Add(new DropDownItem { Text = "300", Value = "300" });
            resolution.Add(new DropDownItem { Text = "400", Value = "400" });
            resolution.Add(new DropDownItem { Text = "500", Value = "500" });
            resolution.Add(new DropDownItem { Text = "600", Value = "600" });
            resolution.Add(new DropDownItem { Text = "1200", Value = "1200" });
            cmbRes.ValueMember = "Value";
            cmbRes.DisplayMember = "Text";
            cmbRes.DataSource = resolution;

            var iniHelper = new IniHelper(iniPath);
            cmbImageType.SelectedValue = iniHelper.IniReadValue("SETTING -100", "ImageType");
            cmbRes.SelectedValue = iniHelper.IniReadValue("SETTING -100", "Resolution");

            chbCrop.Checked = iniHelper.IniReadValue("SETTING -100", "AutoCrop") == "ON";
            chbDeskew.Checked = iniHelper.IniReadValue("SETTING -100", "Deskew") == "ON";
            chbAutomaticOrientation.Checked = iniHelper.IniReadValue("SETTING -100", "AutomaticImageOrientation") == "ON";

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            var iniHelper = new IniHelper(iniPath);
            iniHelper.IniWriteValue("SETTING -100", "ImageType", cmbImageType.SelectedValue.ToString());
            iniHelper.IniWriteValue("SETTING -100", "Resolution", cmbRes.SelectedValue.ToString());
            iniHelper.IniWriteValue("SETTING -100", "AutoCrop", chbCrop.Checked ? "ON" : "OFF");
            iniHelper.IniWriteValue("SETTING -100", "Deskew", chbDeskew.Checked ? "ON" : "OFF");//倾斜校正
            iniHelper.IniWriteValue("SETTING -100", "AutomaticImageOrientation", chbAutomaticOrientation.Checked ? "ON" : "OFF");//自动图像方向校正
            iniHelper.IniWriteValue("SETTING -100", "AutoImageOrintLangID", "1033");//选择语言  1033 英文

            MessageBox.Show("设置成功!");
            this.Close();
        }



    }
}
