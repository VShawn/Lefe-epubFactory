using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using LeFe.Model;

namespace epubFactory
{
    public partial class SetImg : Form
    {
        private BookImage bookImage;
        public SetImg(BookImage _bookImage)
        {
            InitializeComponent();
            bookImage = _bookImage;
            this.DialogResult = DialogResult.Cancel;
        }
        private void EditImg_Load(object sender, EventArgs e)
        {
            pbox.Image = ImgManger.GetBMP(bookImage.path);
            lb_name.Text = bookImage.path;
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, 100);//分别是宽和高
            listView1.SmallImageList = imgList;
            //更改属性
            this.listView1.GridLines = true; //显示表格线
            this.listView1.View = View.Details;//显示表格细节
            this.listView1.FullRowSelect = true;//是否可以选择行
            columnHeader1.TextAlign = HorizontalAlignment.Center;
            foreach (var line in bookImage.lines)
            {
                ListViewItem lvi = new ListViewItem(line.ToString());
                string book = "";
                for (int i = -3; i <= 3; i++)
                {
                    int index = line + i;
                    if (index>=0&&index<Program.newBook.booklines.Count)
                    {
                        book += _subString(Program.newBook.booklines[index]) + "\r\n";
                    }
                }
                lvi.SubItems.Add(book);
                lvi.Checked = true;
                listView1.Items.Add(lvi);
            }

            //添加各项
            //ListViewItem[] p = new ListViewItem[2];
            //p[0] = new ListViewItem(new string[] { "", "aa撒大师大师暗杀暗杀 暗杀打算打算啊是的\r\n sadasdasdasdasdasdasdasdaa", "bbbb" });
            //p[1] = new ListViewItem(new string[] { "", "cccc", "ggggg" });
            ////p[0].SubItems[0].BackColor = Color.Red; //用于设置某行的背景颜色
            //this.listView1.Items.AddRange(p);
            //也可以用this.listView1.Items.Add();不过需要在使用的前后添加Begin... 和End...防止界面自动刷新

        }
        private string _subString(string sub)
        {
            if (sub.Length > 20)
                return sub.Substring(0, 20)+"...";
            else
            {
                return sub;
            }
        }
        private void btn_OK_Click(object sender, EventArgs e)
        {
            List<int> newLines  = new List<int>();
            foreach (ListViewItem Item in listView1.Items)
            {
                if (Item.Checked)
                {
                    newLines.Add(int.Parse(Item.Text));
                }
            }
            bookImage.lines = newLines;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
