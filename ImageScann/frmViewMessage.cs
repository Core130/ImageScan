using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ImageScann.DAL;
using Message = ImageScann.DAL.Message;

namespace ImageScann
{
    public partial class frmViewMessage : Form
    {
        public Message message;
        public frmViewMessage()
        {
            InitializeComponent();
        }

        private void frmViewMessage_Load(object sender, EventArgs e)
        {
            lblSendTime.Text = message.CrtDate;
            lblFromUser.Text = message.FromUser;
            textBox1.Text = message.MsgContent;
        }
    }
}
