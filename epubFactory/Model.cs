using System;
using System.Collections.Generic;
using System.Text;

namespace epubFactory
{
    class Model
    {
    }
    public class Book
    {
        public string path;
        public string ImgsFolder;
        public string Name;
        public string NameOriginal;
        public string Author;
        public string Illustration;
        public List<Capater> capaters;
        public List<string> messages;
        public List<string> summarys;
        public List<List<string>> article;
        public List<string> booklines;//书籍原始行数
        public List<string> epublines;//epub书籍行数

        public BookImage imgCover;
        public BookImage imgContents;
        public List<BookImage> imgIllustrations;
        public List<BookImage> imgInBook;
        public List<BookImage> imgOthers;

        public List<Note> notes;
        public List<BookFileInfo> filelist;
    }
    public class BookFileInfo
    {
        public string chName;//中文
        public string fileName;//带后缀的
        public string clearName;//不带后缀的
        public string fileAllName;//带路径的，生产content.opf用
        public bool inContents;//是否在目录中
        public string media_type;//文件类型image/jpeg   application/x-font-ttf   application/xhtml+xml
    }
    public class Capater
    {
        public int capaterIndex;
        public string name;
        public int lineIndex;
    }
    public class BookImage
    {
        public BookImage()
        {
            name = "";
        }
        public string name;
        public string storeName;
        public string path;
        public string ext;
        public int index;//图片顺序
        public ImageType type;
    }
    public class Note
    {
        public Note()
        {
            word = up = down = "";
            usingTimes = 0;
        }
        public string word;
        public string up;
        public string down;
        public int usingTimes;
        public bool upRepeat = false;
        public bool downRepeat = false;
    }
    /// <summary>
    /// 图片类型的枚举
    /// </summary>
    public enum ImageType : int
    {
        Cover = 1,
        Contents = 2,
        Illustration = 3,
        InBook = 4,
        Default = 0
    }
    public enum pathType : int
    {
        Fonts = 0,
        Text = 1,
        Images = 2,
        Styles = 3,
        content_opf=4,
        toc_ncx =5,
        container_xml = 6
    }
}
