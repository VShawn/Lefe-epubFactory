using System;
using System.Collections.Generic;
using System.Text;

namespace LeFe.Model
{
    public class BookImage
    {
        public BookImage()
        {
            name =  storeName = "";
            lines = new List<int>();
        }
        /// <summary>
        /// 图片原始名称 不带后缀
        /// </summary>
        public string name;
        /// <summary>
        /// 图片导入后名称 不带后缀
        /// </summary>
        public string storeName;
        /// <summary>
        /// 图片原始路径
        /// </summary>
        public string path;
        /// <summary>
        /// 图片后缀 如 “.jpg”
        /// </summary>
        public string ext;
        /// <summary>
        /// 图片顺序
        /// </summary>
        public int index;//图片顺序
        /// <summary>
        /// 图片要插入的行
        /// </summary>
        public List<int> lines;
        public ImageType type;
    }
}
