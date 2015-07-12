using System;
using System.Collections.Generic;
using System.Text;

namespace LeFe.Model
{
    public class BookFileInfo
    {
        public string chName;//中文
        public string fileName;//带后缀的
        public string clearName;//不带后缀的
        public string fileAllName;//带路径的，生产content.opf用
        public bool inContents;//是否在目录中
        public string media_type;//文件类型image/jpeg   application/x-font-ttf   application/xhtml+xml
    }
}
