using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LeFe.Model
{
    public class Book
    {
        public string Path;
        public string ImgsFolder;
        public string Name;
        public string NameOriginal;
        public string Author;
        public string Illustration;


        /// <summary>
        /// 分章节存储每一行
        /// </summary>
        public List<Capater> capaters;
        /// <summary>
        /// 制作信息
        /// </summary>
        public List<string> messages;
        /// <summary>
        /// 简介
        /// </summary>
        public List<string> summarys;
        /// <summary>
        /// 书籍原始行数
        /// </summary>
        public List<string> booklines;
        /// <summary>
        /// epub书籍行数
        /// </summary>
        public List<string> epublines;

        public BookImage imgCover;
        public BookImage imgBackCover;
        public BookImage imgContents;
        public List<BookImage> imgIllustrations;
        public List<BookImage> imgInBook;
        public List<BookImage> imgOthers;

        public List<Note> notes;
        public List<BookFileInfo> filelist;
        /// <summary>
        /// 导入书本基本信息
        /// </summary>
        /// <param name="Name">中文书名</param>
        /// <param name="NameOriginal">原书名</param>
        /// <param name="Path">txt路径</param>
        /// <param name="ImgsFolder">图片文件夹路径</param>
        /// <param name="Author">作者</param>
        /// <param name="Illustration">插画</param>
        /// <returns></returns>
        public bool setBaseInfo(string Name, string NameOriginal, string Path, string ImgsFolder, string Author, string Illustration)
        {
            if (Path == "")
            {
                MessageBox.Show("请选择TXT文件");
                return false;
            }
            else if (ImgsFolder == "")
            {
                MessageBox.Show("请选择图片文件夹");
                return false; ;
            }
            else if (Name.Trim() == "" || NameOriginal.Trim() == "")
            {
                MessageBox.Show("请填写书名");
                return false; ;
            }
            this.Name = Name.Trim();
            this.NameOriginal = NameOriginal.Trim();
            this.Path = Path.Trim();
            this.ImgsFolder = ImgsFolder.Trim();
            this.Author = Author.Trim();
            this.Illustration = Illustration.Trim();
            return true;
        }
    }
}
