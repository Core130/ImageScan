using System;
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
    public partial class PageControl : UserControl
    {
        /// <summary>
        /// 委托及事件
        /// </summary>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="pageIndex">页序号</param>
        /// <param name="kind">查询方式 1：查询 2：查询最近扫描</param>
        /// <param name="totalCount">总记录数</param>
        public delegate void BindPage(int pageSize, int pageIndex, int kind, out int totalCount);
        public event BindPage BindPageEvent;
        //属性
        public int PageSize { get; set; } = 25; //每页显示记录数
        public int PageIndex { get; set; }   //页序号
        public int TotalCount { get; set; }   //总记录数
        public int PageCount { get; set; }   //总页数
        public int Kind { get; set; } //查询方式
        public PageControl()
        {
            InitializeComponent();
            //取消下划线
            linkFirst.LinkBehavior = LinkBehavior.NeverUnderline;
            linkPrev.LinkBehavior = LinkBehavior.NeverUnderline;
            linkNext.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLast.LinkBehavior = LinkBehavior.NeverUnderline;
            linkGo.LinkBehavior = LinkBehavior.NeverUnderline;
        }
        /// <summary>
        /// 设置页
        /// </summary>
        public void SetPage()
        {
            //总记录数
            int totalCount = 0;            
            BindPageEvent(PageSize, PageIndex + 1, Kind, out totalCount);
            TotalCount = totalCount;
            //总页数
            if (TotalCount % PageSize == 0)
                PageCount = TotalCount / PageSize;
            else
                PageCount = TotalCount / PageSize + 1;
            //当前页及总页数
            txtCurrentPage.Text = (PageIndex + 1).ToString();
            lblTotalPage.Text = "共 " + PageCount.ToString() + " 页" + " 总记录数 " + TotalCount.ToString();
        }
        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkFirst_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PageIndex = 0;
                SetPage();
            }
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkPrve_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PageIndex--;
                if (PageIndex < 0)
                {
                    PageIndex = 0;
                }
                SetPage();
            }
        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PageIndex++;
                if (PageIndex > PageCount - 1)
                {
                    PageIndex = PageCount - 1;
                }
                SetPage();
            }
        }
        /// <summary>
        /// 末页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLast_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PageIndex = PageCount - 1;
                SetPage();
            }
        }
        /// <summary>
        /// 只能按0-9、Delete、Enter、Backspace键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSetPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 13 || e.KeyChar == 127)
            {
                e.Handled = false;
                if (e.KeyChar == 13)
                {
                    Go();
                }
            }
            else
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// 指定页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkGo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Go();
            }
        }
        private void Go()
        {
            if (string.IsNullOrEmpty(txtCurrentPage.Text))
            {
                MessageBox.Show("指定页不能为空。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCurrentPage.Focus();
                return;
            }
            if (int.Parse(txtCurrentPage.Text) > PageCount)
            {
                MessageBox.Show("指定页已超过总页数。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCurrentPage.Focus();
                return;
            }
            PageIndex = int.Parse(txtCurrentPage.Text) - 1;
            SetPage();
        }
        /// <summary>
        /// linkFirst鼠标移过颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkFirst_MouseMove(object sender, MouseEventArgs e)
        {
            linkFirst.LinkColor = Color.Red;
        }
        /// <summary>
        /// linkFirst鼠标离开颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkFirst_MouseLeave(object sender, EventArgs e)
        {
            linkFirst.LinkColor = Color.Black;
        }
        /// <summary>
        /// linkPrev鼠标移过颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkPrev_MouseMove(object sender, MouseEventArgs e)
        {
            linkPrev.LinkColor = Color.Red;
        }
        /// <summary>
        /// linkPrev鼠标离开颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkPrev_MouseLeave(object sender, EventArgs e)
        {
            linkPrev.LinkColor = Color.Black;
        }
        /// <summary>
        /// linkNext鼠标移过颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkNext_MouseMove(object sender, MouseEventArgs e)
        {
            linkNext.LinkColor = Color.Red;
        }
        /// <summary>
        /// linkNext鼠标离开颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkNext_MouseLeave(object sender, EventArgs e)
        {
            linkNext.LinkColor = Color.Black;
        }
        /// <summary>
        /// linkLast鼠标移过颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLast_MouseMove(object sender, MouseEventArgs e)
        {
            linkLast.LinkColor = Color.Red;
        }
        /// <summary>
        /// linkLast鼠标离开颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLast_MouseLeave(object sender, EventArgs e)
        {
            linkLast.LinkColor = Color.Black;
        }
        /// <summary>
        /// linkGo鼠标移过颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkGo_MouseMove(object sender, MouseEventArgs e)
        {
            linkGo.LinkColor = Color.Red;
        }
        /// <summary>
        /// linkGo鼠标离开颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkGo_MouseLeave(object sender, EventArgs e)
        {
            linkGo.LinkColor = Color.Black;
        }

   
    }
}
