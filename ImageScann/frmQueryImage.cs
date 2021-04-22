using ImageScann.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageScann
{
    public partial class frmQueryImage : Form
    {
        string imgPatch = "";
        public frmQueryImage()
        {
            InitializeComponent();
        }

        public frmQueryImage(string patch)
        {
            InitializeComponent();
            imgPatch = patch;
        }
        private void frmQueryImage_Load(object sender, EventArgs e)
        {
            try
            {
                VatInvoiceBll vatInvoiceBll = new VatInvoiceBll();
                picBoxInvoice.Image = vatInvoiceBll.GetImage(imgPatch);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),"异常提示");
            }
            
        }
        
    }
}
