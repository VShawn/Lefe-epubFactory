using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LeFe.Model;

namespace epubFactory
{
    public partial class SetTitle : Form
    {
        public SetTitle()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }
        private void SetBookInfo_Load(object sender, EventArgs e)
        {
            Text2Html.MakeUpRules(new List<string>(rtb_rules.Lines));
            analysis();
        }
        private void analysis()
        {
            rtb_titles.Text = "";
            List<string> titles = Text2Html.GetListTitles(Program.newBook.booklines);
            foreach (var title in titles)
            {
                rtb_titles.Text += title + "\r";
            }
        }
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void btn_OK_Click(object sender, EventArgs e)
        {
            //进行文章分页
            //Program.newBook = Text2Html.Text2Epub(Program.newBook);
            DialogResult = DialogResult.OK;
            Close();
        }
        private void btn_back_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
            Close();
        }
        private void btn_retry_Click(object sender, EventArgs e)
        {
            Text2Html.MakeUpRules(new List<string>(rtb_rules.Lines));
            analysis();
        }
    }
}
