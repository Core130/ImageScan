﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageScann
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
       
        private void frmMain_Load(object sender, EventArgs e)
        {
            frmIndex frmIndex = new frmIndex();
            frmIndex.TopLevel = false;
            frmIndex.FormBorderStyle = FormBorderStyle.None;
            frmIndex.Dock = DockStyle.Fill;
            frmIndex.Parent = this.panel_index;
            frmIndex.Show();

        }

        private void ts_Invoice_Click(object sender, EventArgs e)
        {
            this.panel_index.Controls.Clear();
            frmVatInvoice frmVatInvoice = new frmVatInvoice();
            frmVatInvoice.TopLevel = false;
            frmVatInvoice.FormBorderStyle = FormBorderStyle.None;
            frmVatInvoice.Dock = DockStyle.Fill;
            frmVatInvoice.Parent = this.panel_index;
            frmVatInvoice.Show();

        }

        private void ts_Image_Click(object sender, EventArgs e)
        {
            frmIndex frmIndex = new frmIndex();
            frmIndex.TopLevel = false;
            frmIndex.FormBorderStyle = FormBorderStyle.None;
            frmIndex.Dock = DockStyle.Fill;
            frmIndex.Parent = this.panel_index;
            frmIndex.Show();
        }        
    }
}