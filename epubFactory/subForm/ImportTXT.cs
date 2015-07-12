using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace epubFactory
{
    public partial class ImportTXT : Form
    {
        public ImportTXT()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        private void btn_EXIT_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            //this.TopMost = true;
            this.DialogResult = DialogResult.Cancel;  
            this.Close();
        }

        private void btn_SelectTXT_Click(object sender, EventArgs e)
        {
            string defaultfilePath = SofeSetting.Get("TxtPath");
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "文本文件|*.txt|所有文件|*.*";
            if (defaultfilePath != "")
            {
                //设置此次默认目录为上一次选中目录  
                fd.InitialDirectory = defaultfilePath;
            }
            
            if (fd.ShowDialog() == DialogResult.OK)
            {
                string fileClearName = fd.FileName.Substring(fd.FileName.LastIndexOf(@"\") + 1);
                fileClearName = fileClearName.Substring(0, fileClearName.LastIndexOf('.'));
                tb_TXTPath.Text = fd.FileName;
                SofeSetting.Set("TxtPath", fd.FileName);
                if (tb_bookNameCH.Text == "")
                    tb_bookNameCH.Text = fileClearName;
                if (tb_bookNameOR.Text == "")
                    tb_bookNameOR.Text = fileClearName;
            }
        }

        private void btn_SelectImgs_Click(object sender, EventArgs e)
        {
            string defaultfilePath = SofeSetting.Get("ImgPath");
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (defaultfilePath != "")
            {
                //设置此次默认目录为上一次选中目录  
                fbd.SelectedPath = defaultfilePath;
            }
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                //记录选中的目录  
                defaultfilePath = fbd.SelectedPath;
                SofeSetting.Set("ImgPath", defaultfilePath);
                tb_ImgsFolder.Text = fbd.SelectedPath;
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (Program.newBook.setBaseInfo(tb_bookNameCH.Text, tb_bookNameOR.Text, tb_TXTPath.Text, tb_ImgsFolder.Text, tb_author.Text, tb_illustration.Text))
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void ImportTXT_Load(object sender, EventArgs e)
        {
            if (Program.newBook.Path != null && Program.newBook.Path != "")
            {
                tb_TXTPath.Text = Program.newBook.Path;
            }
            if (Program.newBook.Author != null && Program.newBook.Author != "")
            {
                tb_author.Text = Program.newBook.Author;
            }
            if (Program.newBook.Illustration != null && Program.newBook.Illustration != "")
            {
                tb_illustration.Text = Program.newBook.Illustration;
            }
            if (Program.newBook.ImgsFolder != null && Program.newBook.ImgsFolder != "")
            {
                tb_ImgsFolder.Text = Program.newBook.ImgsFolder;
            }
            if (Program.newBook.Name != null && Program.newBook.Name != "")
            {
                tb_bookNameCH.Text = Program.newBook.Name;
            }
            if (Program.newBook.NameOriginal != null && Program.newBook.NameOriginal != "")
            {
                tb_bookNameOR.Text = Program.newBook.NameOriginal;
            }
        }
    }
}
