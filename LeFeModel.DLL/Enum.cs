using System;
using System.Collections.Generic;
using System.Text;

namespace LeFe.Model
{
        /// <summary>
    /// 图片类型的枚举
    /// </summary>
    public enum ImageType : int
    {
        Cover = 1,
        Contents = 2,
        Illustration = 3,
        InBook = 4,
        BackCover = 5,
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
