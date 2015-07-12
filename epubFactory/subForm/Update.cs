using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace epubFactory
{
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();
        }
        public Update(bool check)
        {
            InitializeComponent();
            btn_ignor.Visible = check;
        }
        private void lb_download_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(epubFactory.Version.GetDownload()); 
        }

        private void Update_Load(object sender, EventArgs e)
        {
            lb_info.Text = epubFactory.Version.GetInfo();
            lb_date.Text = "更新时间：" + epubFactory.Version.GetDate();
            lb_version.Text = "版本号：" + epubFactory.Version.GetVersion();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btn_ignor_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.Close();
        }
    }
}
