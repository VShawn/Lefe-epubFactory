using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace epubFactory
{
    public partial class SetBookInfo : Form
    {
        public SetBookInfo()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }
        private void SetBookInfo_Load(object sender, EventArgs e)
        {
            if (Program.newBook.messages != null && Program.newBook.messages.Count != 0)
            {
                rtb_Message.Text = "";
                for (int i = 0; i < Program.newBook.messages.Count; i++)
                {
                    rtb_Message.Text += Program.newBook.messages[i].Trim() + "\r\n";
                }
            }
            if (Program.newBook.summarys != null && Program.newBook.summarys.Count != 0)
            {
                rtb_Summray.Text = "";
                for (int i = 0; i < Program.newBook.summarys.Count; i++)
                {
                    rtb_Summray.Text += Program.newBook.summarys[i].Trim() + "\r\n";
                }
            }
        }
        private void btn_Exit_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            //rtb_Message.Text = rtb_Message.Text.Trim();
            //rtb_Summray.Text = rtb_Summray.Text.Trim();
            //messages summary信息分割
            for (int i = 0; i < rtb_Message.Lines.Length; i++)
            {
                rtb_Message.Lines[i] = rtb_Message.Lines[i].Replace("　", " ").Replace(@"&", "＆").Replace("<", "&#60;").Replace(">", "&#62;").Trim();
            }
            for (int i = 0; i < rtb_Summray.Lines.Length; i++)
            {
                rtb_Summray.Lines[i] = rtb_Summray.Lines[i].Replace("　", " ").Replace(@"&", "＆").Replace("<", "&#60;").Replace(">", "&#62;").Trim();
            }
            Program.newBook.messages = new List<string>(rtb_Message.Lines);
            Program.newBook.summarys = new List<string>(rtb_Summray.Lines);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
            Close();
        }

        private void rtb_Message_TextChanged(object sender, EventArgs e)
        {
            //rtb_Message.Text = rtb_Message.Text.Trim();
        }

        private void rtb_Summray_TextChanged(object sender, EventArgs e)
        {
            //rtb_Summray.Text = rtb_Summray.Text.Trim();
        }
    }
}
