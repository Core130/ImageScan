using System;
using System.Windows.Forms;

namespace ImageScann
{
    public partial class frmGroupSearch : Form
    {
        public TreeView treeview;
        public frmGroupSearch()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 分组查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmGroupSearch_Load(object sender, EventArgs e)
        {
           ListViewItem item=null;
            foreach (TreeNode n in treeview.Nodes)
            {
                 
                 item= new ListViewItem();
                 item.SubItems.Add(n.Text);
                 item.SubItems.Add(n.Nodes.Count.ToString());
                 listView1.Items.Add(item);
            }
          
        }
    }
}
