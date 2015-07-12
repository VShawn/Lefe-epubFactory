using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using LeFe.Model;

namespace epubFactory
{
    public partial class ListImgs : Form
    {
        public ListImgs()
        {
            InitializeComponent();
            listViewMain.DoubleClick += listViewMain_doubleClick;
            ShowInTaskbar = false;
        }
        private List<BookImage> images;
        private void listViewMain_doubleClick(object sender, EventArgs e)
        {
            if (listViewMain.SelectedItems.Count == 0)
                return;
            EditImg ei = new EditImg(images[listViewMain.FocusedItem.Index]);
            if (ei.ShowDialog() == DialogResult.OK)
            {
                updataLV();
            }
        }
        private void ListImgs_Load(object sender, EventArgs e)
        {
            updataLV();
        }
        private void updataLV()
        {
            images = ImgManger.SearchFolder(Program.newBook.ImgsFolder);
            listViewMain.Items.Clear();
            ImageList il = new ImageList();
            btn_OK.Visible = true;
            if (images.Count == 0)
            {
                btn_OK.Visible = false;
                MessageBox.Show("所选文件夹内不存在图片！");
                return;
            }
            int imgCount = images.Count;
            for (int i = 0; i < imgCount; i++)
            {
                BookImage bookImage = images[i];
                il.Images.Add(ImgManger.GetBMP(images[i].path));
                ListViewItem lvi = new ListViewItem();
                lvi.ImageIndex = i;
                lvi.SubItems.Add(bookImage.name + bookImage.ext);
                lvi.SubItems.Add(bookImage.path);
                lvi.SubItems.Add(ImgManger.GetImgTypeCh(bookImage.type));
                lvi.SubItems[1].ForeColor = Color.Red;
                listViewMain.Items.Add(lvi);
            }
            il.ImageSize = new System.Drawing.Size(50, 70);   //分别是宽和高
            listViewMain.SmallImageList = il;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            ImgManger.ImportImgs(Program.newBook);
            //对需要插图的行标记，行号记录入图片model，标记后，在导入前遍历每行，插入
            for (int i = 0; i < Program.newBook.epublines.Count; i++)
            {
                int imgI = ImgManger.HasFollowImg(Program.newBook.epublines[i], Program.newBook.imgInBook);
                if (imgI >= 0)
                {
                    Program.newBook.imgInBook[imgI].lines.Add(i);
                }
                int otherI = ImgManger.HasFollowImg(Program.newBook.epublines[i], Program.newBook.imgOthers);
                if (otherI >= 0)
                {
                    Program.newBook.imgOthers[otherI].lines.Add(i);
                }
            }
            //选择去除重复项
            for (int i = 0; i < Program.newBook.imgInBook.Count; i++)
            {
                if (Program.newBook.imgInBook[i].lines.Count > 1)
                {
                    SetImg si = new SetImg(Program.newBook.imgInBook[i]);
                    si.ShowDialog(this);
                }
            }
            for (int i = 0; i < Program.newBook.imgOthers.Count; i++)
            {
                if (Program.newBook.imgOthers[i].lines.Count > 1)
                {
                    SetImg si = new SetImg(Program.newBook.imgOthers[i]);
                    si.ShowDialog(this);
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.None;
            Close();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
            Close();
        }
    }
}
