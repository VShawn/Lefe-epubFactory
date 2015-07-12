using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using LeFe.Model;
namespace epubFactory
{
    public static class ImgManger
    {
        /// <summary>
        /// 导入图片
        /// </summary>
        /// <param name="newBook"></param>
        public static void ImportImgs(Book newBook)
        {
            newBook.imgIllustrations = new List<BookImage>();
            newBook.imgInBook = new List<BookImage>();
            newBook.imgOthers = new List<BookImage>();
            List<BookImage> images = SearchFolder(newBook.ImgsFolder);
            int inIndex = 0;//文内插图序号
            int otherIndex = 0;//文内插图序号
            foreach (BookImage bookImage in images)
            {
                //图像书籍整理
                bookImage.type = getImgType(bookImage.name);
                if (bookImage.type == ImageType.InBook)
                {
                    bookImage.index = inIndex;
                    inIndex++;
                    //bookImage.name = bookImage.name.Replace("[in]", "").Trim().ToLower();
                }
                if (bookImage.type == ImageType.Default)
                {
                    bookImage.index = otherIndex;
                    otherIndex++;
                }
                else if (bookImage.type == ImageType.Illustration)
                    bookImage.index = int.Parse(bookImage.name);
                bookImage.storeName = _getStoreName(bookImage).ToLower();

                //图片编入书籍模型
                if (bookImage.type == ImageType.Cover)
                {
                    newBook.imgCover = bookImage;
                }
                if (bookImage.type == ImageType.BackCover)
                {
                    newBook.imgBackCover = bookImage;
                }
                else if (bookImage.type == ImageType.Contents)
                {
                    newBook.imgContents = bookImage;
                }
                else if (bookImage.type == ImageType.Illustration)
                {
                    newBook.imgIllustrations.Add(bookImage);
                }
                else if (bookImage.type == ImageType.InBook)
                {
                    newBook.imgInBook.Add(bookImage);
                }
                else
                {
                    newBook.imgOthers.Add(bookImage);
                }
            }
        }
        /// <summary>
        /// 以解除占用的方式获取图片
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static Bitmap GetBMP(string filename)
        {
            Bitmap bmp = new Bitmap(filename);
            //新建第二个bitmap类型的bmp2变量，。
            //Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height, PixelFormat.Format16bppRgb555);
            ////将第一个bmp拷贝到bmp2中
            //Graphics draw = Graphics.FromImage(bmp2);
            //draw.DrawImage(bmp, 0, 0);
            //draw.Dispose();
            //bmp.Dispose();//释放bmp文件资源

            Bitmap bmp3 = new Bitmap(bmp);
            bmp.Dispose();
            return bmp3;
        }
        /// <summary>
        /// 获取原始的图片信息
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns></returns>
        public static List<BookImage> SearchFolder(string folderPath)
        {
            List<BookImage> images = _searchFolder(folderPath);
            int imgCount = images.Count;
            for (int i = 0; i < imgCount; i++)
            {
                BookImage bookImage = images[i];
                bookImage.type = getImgType(bookImage.name);
                if (bookImage.type == ImageType.InBook)
                {
                    bookImage.name = bookImage.name.Trim().ToLower();
                }
                //else if (bookImage.type == ImageType.Illustration)
                //    bookImage.index = int.Parse(bookImage.name);
                //bookImage.storeName = _getStoreName(bookImage).ToLower();
                images[i] = bookImage;
            }
            return images;
        }
        /// <summary>
        /// 判断是否有插图，返回图片序号
        /// </summary>
        /// <param name="row"></param>
        /// <param name="bookImages"></param>
        /// <returns></returns>
        public static int HasFollowImg(string row, List<BookImage> imgInBooks)
        {
            for (int i = 0; i < imgInBooks.Count; i++)
            {
                if (row.ToLower().IndexOf(imgInBooks[i].name.Trim().ToLower().Replace("[in]", "").Replace("[a]", "").Replace("[b]", "")) >= 0)
                {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// 判断是否有替换的插图，返回图片序号
        /// </summary>
        /// <param name="row"></param>
        /// <param name="bookImages"></param>
        /// <returns></returns>
        public static int IsReplaceImg(string row, List<BookImage> imgOthers)
        {
            for (int i = 0; i < imgOthers.Count; i++)
            {
                if (row.Trim() == imgOthers[i].name.Trim())
                {
                    return i;
                }
            }
            return -1;
        }
        public static ImageType getImgType(string name)
        {
            ImageType type;
            name = name.ToLower();
            switch (name)
            {
                case "cover":
                    type = ImageType.Cover;
                    break;
                case "backcover":
                    type = ImageType.BackCover;
                    break;
                case "contents":
                    type = ImageType.Contents;
                    break;
                default:
                    type = ImageType.Default;
                    break;
            }
            //继续判断是彩页还是插图
            //插图格式 [in]+在哪句话的后面。若为[in][before]则是在那句话前面
            if (Regex.IsMatch(name, @"^(\[in\])"))
            {
                type = ImageType.InBook;
            }
            //插图格式 [a]+在哪句话的后面。a = after
            if (Regex.IsMatch(name, @"^(\[a\])"))
            {
                type = ImageType.InBook;
            }
            //插图格式 [b]+在哪句话的后面。b = before
            if (Regex.IsMatch(name, @"^(\[b\])"))
            {
                type = ImageType.InBook;
            }

            //彩页格式 纯数字.JPG 数字为编号
            else if (Regex.IsMatch(name, @"^\d*$"))
            {
                type = ImageType.Illustration;
            }
            return type;
        }
        public static ImageType GetImgTypeByCh(string name)
        {
            switch (name)
            {
                case "书内插图": return ImageType.InBook;
                case "封面图": return ImageType.Cover;
                case "目录图": return ImageType.Contents;
                case "彩页插画": return ImageType.Illustration;
                default:
                    return ImageType.Default;
            }
        }
        public static string GetImgTypeCh(ImageType type)
        {
            switch (type)
            {
                case ImageType.InBook: return "书内插图";
                case ImageType.Cover: return "封面图";
                case ImageType.BackCover: return "封底图";
                case ImageType.Contents: return "目录图";
                case ImageType.Illustration: return "彩页插画";
                default:
                    return "其他，将匹配文中对应的文字并替换";
            }
        }
        /// <summary>
        /// 移动图片，在生成epub时调用
        /// </summary>
        /// <param name="path">目标路径</param>
        /// <param name="newBook"></param>
        public static void MoveImage(string path, Book newBook)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (newBook.imgCover != null && newBook.imgCover.name != "")
            {
                File.Copy(newBook.imgCover.path, path + newBook.imgCover.storeName + newBook.imgCover.ext, true);
                AddImgFileList("封面", newBook.imgCover, newBook);
            }
            if (newBook.imgBackCover != null && newBook.imgBackCover.name != "")
            {
                File.Copy(newBook.imgBackCover.path, path + newBook.imgBackCover.storeName + newBook.imgBackCover.ext, true);
                AddImgFileList("封底", newBook.imgBackCover, newBook);
            }
            if (newBook.imgContents != null && newBook.imgContents.name != "")
            {
                File.Copy(newBook.imgContents.path, path + newBook.imgContents.storeName + newBook.imgContents.ext, true);
                AddImgFileList("目录", newBook.imgContents, newBook);
            }
            foreach (BookImage bookImage in newBook.imgIllustrations)
            {
                File.Copy(bookImage.path, path + bookImage.storeName + bookImage.ext, true);
                AddImgFileList("插画", bookImage, newBook);
            }
            foreach (BookImage bookImage in newBook.imgInBook)
            {
                if (bookImage.lines.Count > 0)
                {
                    File.Copy(bookImage.path, path + bookImage.storeName + bookImage.ext, true);
                    AddImgFileList("插图", bookImage, newBook);
                }
            }

            foreach (BookImage bookImage in newBook.imgOthers)
            {
                if (bookImage.lines.Count > 0)
                {
                    File.Copy(bookImage.path, path + bookImage.storeName + bookImage.ext, true);
                    AddImgFileList("插图", bookImage, newBook);
                }
            }
        }
        /// <summary>
        /// 添加到opf
        /// </summary>
        /// <param name="chName"></param>
        /// <param name="img"></param>
        /// <param name="newBook"></param>
        public static void AddImgFileList(string chName, BookImage img,Book newBook)
        {
            var fileInfo = new BookFileInfo
            {
                chName = chName,
                fileAllName = "Images/" + img.storeName + img.ext,
                fileName = img.storeName + img.ext,
                clearName = img.storeName + img.ext,
                inContents = false,
                media_type = "image/" + img.ext.Replace(".", "").Replace("jpg", "jpeg")
            };
            newBook.filelist.Add(fileInfo);
        }
        public static List<BookImage> _searchFolder(string folderPath)
        {
            List<BookImage> lbi = new List<BookImage>();
            DirectoryInfo theFolder = new DirectoryInfo(folderPath);
            DirectoryInfo[] subFolders = theFolder.GetDirectories();
            if (subFolders.Length > 0)
            {
                foreach (DirectoryInfo subFolder in subFolders)
                {
                    lbi.AddRange(SearchFolder(subFolder.FullName));
                }
            }
            lbi.AddRange(_searchImg(folderPath));
            return lbi;
        }
        public static List<BookImage> _searchImg(string folderPath,string addext = "")
        {
            List<BookImage> nlbi = new List<BookImage>();
            DirectoryInfo theFolder = new DirectoryInfo(folderPath);
            FileInfo[] fi = theFolder.GetFiles("*.*");
            foreach (FileInfo tmpfi in fi)
            {
                string extension = tmpfi.Extension.ToLower();
                if (extension == ".jpg" || extension == ".gif" || extension == ".png" || extension == ".bmp" || addext.IndexOf(extension) >= 0)
                //if (extension == ".jpg" || extension == ".jpeg")
                {
                    string imgpath = tmpfi.FullName;
                    string filename = imgpath.Substring(imgpath.LastIndexOf(@"\") + 1);
                    string ext = filename.Substring(filename.LastIndexOf('.'));
                    filename = filename.Substring(0, filename.LastIndexOf('.'));
                    BookImage bi = new BookImage();
                    {
                        bi.name = filename;
                        bi.storeName = filename;
                        bi.ext = ext;
                        bi.path = imgpath;
                        bi.type = ImageType.Default;
                    }
                    nlbi.Add(bi);
                }
            }
            return nlbi;
        }
        private static string _getStoreName(BookImage bookImage)
        {
            if (bookImage.type == ImageType.Cover)
                return "cover";
            else if (bookImage.type == ImageType.Contents)
                return "contents";
            if (bookImage.type == ImageType.BackCover)
                return "backcover";
            else
            {
                int i = bookImage.index;
                string nameIndex = i <= 9 ? "00" : (i <= 99 ? "0" : "");
                if (bookImage.type == ImageType.InBook)
                {
                    return "inBook" + nameIndex + i.ToString();
                }
                if (bookImage.type == ImageType.Default)
                {
                    return "other" + nameIndex + i.ToString();
                }
                else if (bookImage.type == ImageType.Illustration)
                {
                    return "Illus" + nameIndex + i.ToString();
                }
                else
                {
                    return DateTime.Now.Millisecond.ToString();
                }
            }
        }
    }
}

