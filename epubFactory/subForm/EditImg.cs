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
    public partial class EditImg : Form
    {
        private BookImage bookImage;
        public EditImg(BookImage _bookImage)
        {
            InitializeComponent();
            bookImage = _bookImage;
            this.DialogResult = DialogResult.Cancel;
        }

        private void EditImg_Load(object sender, EventArgs e)
        {
            ddl_ImgType.Items.Add((object) ImgManger.GetImgTypeCh(ImageType.Cover));
            ddl_ImgType.Items.Add((object)ImgManger.GetImgTypeCh(ImageType.Contents));
            ddl_ImgType.Items.Add((object)ImgManger.GetImgTypeCh(ImageType.Illustration));
            ddl_ImgType.Items.Add((object)ImgManger.GetImgTypeCh(ImageType.InBook));
            ddl_ImgType.Items.Add((object)ImgManger.GetImgTypeCh(ImageType.Default));

            ddl_ImgType.SelectedItem = (object)ImgManger.GetImgTypeCh(bookImage.type);
            Image image = ImgManger.GetBMP(bookImage.path);
            pb_Img.Image = image;
            upadataDDL();

        }

        private void ddl_ImgType_SelectedIndexChanged(object sender, EventArgs e)
        {
            upadataDDL();
        }
        private void upadataDDL()
        {
            nud_Illustration.Value = bookImage.index == 0 ? 1 : bookImage.index;
            ImageType it = ImgManger.GetImgTypeByCh(ddl_ImgType.SelectedItem.ToString());
            lb_illu.Visible = lb_in1.Visible =  false;
            rb_a.Visible = rb_b.Visible = tb_inBefore.Visible = lb_in1.Visible = false;
            if (it == ImageType.InBook)
            {
                rb_a.Visible = rb_b.Visible = tb_inBefore.Visible = lb_in1.Visible = true;
                tb_inBefore.Text = bookImage.name.Replace("[in]", "").Replace("[a]", "").Replace("[b]", "").Trim().ToLower();
            }
            else if (it == ImageType.Illustration)
            {
                lb_illu.Visible = nud_Illustration.Visible = true;
            }
        }
        private void btn_OK_Click(object sender, EventArgs e)
        {
            ImageType it = ImgManger.GetImgTypeByCh(ddl_ImgType.SelectedItem.ToString());
            bookImage.index = 0;
            bookImage.type = it;
            string path = bookImage.path.Substring(0,bookImage.path.LastIndexOf(@"\")+1);
            string fileName = "";
            if (it == ImageType.InBook)
            {
                if (rb_a.Checked)
                {
                    fileName = "[a]" + tb_inBefore.Text; 
                }
                else
                {
                    fileName = "[b]" + tb_inBefore.Text; 
                }
            }
            else if (it == ImageType.Illustration)
            {
                bookImage.index = (int)nud_Illustration.Value;
                fileName = bookImage.index.ToString();
            }
            else if (it == ImageType.Contents)
            {
                fileName = "contents";
            }
            else if (it == ImageType.Cover)
            {
                fileName = "cover";
            }
            else
                fileName = bookImage.name;
            path = path + fileName + bookImage.ext;
            if (bookImage.path != path)
            {
                if (File.Exists(path))
                {
                    if (it == ImageType.Contents && MessageBox.Show("目录图片已经存在，确定要替换原来的么？", "提示", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    {
                        return;
                    }
                    if (it == ImageType.Cover && MessageBox.Show("封面图片已经存在，确定要替换原来的么？", "提示", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    {
                        return;
                    }
                    
                    if (it == ImageType.Illustration)
                    {
                        string tmp = path + "1";
                        File.Copy(path, tmp,true);
                        File.Delete(path);
                        File.Copy(bookImage.path, path,true);
                        File.Delete(bookImage.path);
                        File.Move(tmp, bookImage.path);
                    }
                    else
                        File.Delete(path);
                }
                if (it != ImageType.Illustration)
                {
                    File.Move(bookImage.path, path);
                }
                bookImage.path = path;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
