using System;
using System.IO;
using System.Text;
using LeFe.Model;

namespace epubFactory
{

    public static class HtmlBuilder
    {
        public static Book newBook;
        /// <summary>
        /// 生成书籍时临时存放文件的文件夹
        /// </summary>
        public static string TopPath;
        #region XHTML
        public static void CoverBuilder()
        {
            string path = _getPath(pathType.Text);
            string filename = path + @"\Cover.xhtml";
            _writeFile(filename, DefaultModel.Read("封面"));
            _addFileList("封面", "Text/Cover.xhtml", "Cover.xhtml", "Cover", true);
        }
        public static void TitleBuilder()
        {
            string path = _getPath(pathType.Text);
            string filename = path + @"\Title.xhtml";
            string titleXhtml = DefaultModel.Read("标题");
            titleXhtml = titleXhtml.Replace("[%书名%]", _fixString(newBook.Name))
                                    .Replace("[%作者名字%]", _fixString(newBook.Author))
                                    .Replace("[%插画名字%]", _fixString(newBook.Illustration));
            _writeFile(filename, titleXhtml);
            _addFileList("标题", "Text/Title.xhtml", "Title.xhtml", "Title", false);
        }
        public static void MessageBuilder()
        {
            string path = _getPath(pathType.Text);
            string filename = path + @"\Message.xhtml";
            string messageXhtml = DefaultModel.Read("制作信息");
            string messages = "";
            foreach (string message in newBook.messages)
            {
                messages += @"
    " + DefaultModel.GetSetting("制作信息行").Replace("[%该行内容%]", _fixString(message));
            }
            _writeFile(filename, messageXhtml.Replace("[%制作信息内容%]", messages));
            _addFileList("制作信息", "Text/Message.xhtml", "Message.xhtml", "Message", true);
        }
        public static void LogoBuilder()
        {
            string path = _getPath(pathType.Text);
            string filename = path + @"\Logo.xhtml";
            string logoXhtml = DefaultModel.Read("LOGO");
            _writeFile(filename, logoXhtml.Replace("[%制作者%]", _fixString(SofeSetting.Get("[MAKER]"))));
            _addFileList("制作者与Logo", "Text/Logo.xhtml", "Logo.xhtml", "Logo", false);
        }
        public static void SummaryBuilder()
        {
            string path = _getPath(pathType.Text);
            string filename = path + @"\Summary.xhtml";
            string summaryXhtml = DefaultModel.Read("简介");
            string summarys = "";
            foreach (string summary in newBook.summarys)
            {
                summarys += @"
    " + DefaultModel.GetSetting("简介行").Replace("[%该行内容%]", _fixString(summary));
            }
            _writeFile(filename, summaryXhtml.Replace("[%简介内容%]", summarys));
            _addFileList("简介", "Text/Summary.xhtml", "Summary.xhtml", "Summary", true);
        }
        public static void ContentsBuilder()
        {
            string path = _getPath(pathType.Text);
            string filename = path + @"\Contents.xhtml";
            //文字目录页
            string contentsXhtml = DefaultModel.Read("目录");
            string contents = "";
            foreach (var capater in newBook.capaters)
            {
                string capaFileName = _getCapaterFileName(capater);
                contents += @"
    " + DefaultModel.GetSetting("目录行").Replace("[%章节文件%]",capaFileName).Replace("[%章节名%]", _fixString(capater.Name));
            }
            _writeFile(filename, contentsXhtml.Replace("[%目录内容%]", contents));

            //如果不存在图片目录
            if (newBook.imgContents == null || newBook.imgContents.name == "")
            {
                _addFileList("目录", "Text/Contents.xhtml", "Contents.xhtml", "Contents", true);
                return;
            }
            //存在图片目录
            filename = path + @"\Contents-Illus.xhtml";
            string contentsImgXhtml = DefaultModel.Read("目录插画");
            _writeFile(filename, contentsImgXhtml);

            _addFileList("目录", "Text/Contents-Illus.xhtml", "Contents-Illus.xhtml", "Contents-Illus", true);
            _addFileList("目录", "Text/Contents.xhtml", "Contents.xhtml", "Contents", false);
        }
        public static void IllusBuilder()
        {
            string path = _getPath(pathType.Text);
            foreach (BookImage bookImage in newBook.imgIllustrations)
            {
                //彩页图片
                string illusXhtml = DefaultModel.Read("彩页");
                illusXhtml = illusXhtml.Replace("[%彩插%]", bookImage.storeName + bookImage.ext);
                string fileClearName = bookImage.storeName;
                string filename = path + @"\" + fileClearName + ".xhtml";
                _writeFile(filename, illusXhtml);
                if (bookImage == newBook.imgIllustrations[0])
                    _addFileList("彩页", "Text/" + fileClearName + ".xhtml", fileClearName + ".xhtml", fileClearName, true);
                else
                    _addFileList("彩页", "Text/" + fileClearName + ".xhtml", fileClearName + ".xhtml", fileClearName, false);
                //彩页文字特效
                string illusTextXhtml = DefaultModel.Read("彩页文字特效");
                fileClearName = fileClearName + "-1";
                filename = path + @"\" + fileClearName + ".xhtml";
                _writeFile(filename, illusTextXhtml);
                _addFileList("彩页", "Text/" + fileClearName + ".xhtml", fileClearName + ".xhtml", fileClearName, false);
            }
        }
        public static void CapatersBuilder()
        {
            string path = _getPath(pathType.Text);
            int capaterCount = newBook.capaters.Count;
            string capatersXhtml = DefaultModel.Read("章节正文");
            for (int i = 0; i < capaterCount; i++)
            {
                string Capters = "";
                for (int j = newBook.capaters[i].SatrtLine; j <= newBook.capaters[i].EndLine; j++)
                {
                    Capters += @"    " + newBook.epublines[j] + "\n";
                }
                string clearname = _getCapaterFileName(newBook.capaters[i], true);
                string name = _getCapaterFileName(newBook.capaters[i]);//带后缀的文件名
                string filename = path + @"\" + name;
                _writeFile(filename, capatersXhtml.Replace("[%章节内容%]", Capters).Replace("[%章节名%]",newBook.capaters[i].Name));
                _addFileList(newBook.capaters[i].Name, "Text/" + name, name, clearname, true);
            }
        }
        public static void BackCoverBuilder()
        {
            string path = _getPath(pathType.Text);
            string filename = path + @"\BackCover.xhtml";
            _writeFile(filename, DefaultModel.Read("封底"));
            _addFileList("封底", "Text/BackCover.xhtml", "BackCover.xhtml", "BackCover", false);
        }
        /// <summary>
        /// 给epublines中添加入注释，应当最先调用
        /// </summary>
        public static void SetNotes()
        {
            int capaterCount = newBook.capaters.Count;
            //逐章查找注释
            for (int i = 0; i < capaterCount; i++)
            {
                string footNote = "";
                int footNoteIndex = 1;
                for (int j = newBook.capaters[i].SatrtLine; j <= newBook.capaters[i].EndLine; j++)
                {
                    foreach (Note note in Program.newBook.notes)
                    {
                        if (newBook.epublines[j].IndexOf(note.word) >= 0)
                        {
                            //最先添加尾注
                            if (note.foot != "")
                            {
                                newBook.epublines[j] = newBook.epublines[j].Replace(note.word, note.word + DefaultModel.GetSetting("尾注1").Replace("[%编号%]", footNoteIndex.ToString()));
                                
                                if (DefaultModel.GetSetting("尾注2位置") == "1")
                                {
                                    //直接在下一行添加
                                    newBook.epublines[j] += DefaultModel.GetSetting("尾注2").Replace("[%编号%]", footNoteIndex.ToString()).Replace("[%尾注%]", note.foot);
                                }
                                else
                                {
                                    //在末尾才添加
                                    footNote += DefaultModel.GetSetting("尾注2").Replace("[%编号%]", footNoteIndex.ToString()).Replace("[%尾注%]", note.foot);
                                }
                                footNoteIndex++;
                            }
                            //添加上注
                            if (note.up != "")
                            {
                                newBook.epublines[j] = newBook.epublines[j].Replace(note.word, DefaultModel.GetSetting("上注").Replace("[%注释词%]", note.word).Replace("[%上注%]", note.up));
                            }
                            //添加下注
                            if (note.down != "")
                            {
                                newBook.epublines[j] = newBook.epublines[j] + DefaultModel.GetSetting("下注").Replace("[%下注%]", note.down);
                            }
                            note.usingTimes++;
                        }
                    }
                    if (DefaultModel.GetSetting("尾注2位置") == "0")
                    {
                        //在章节的最后一行，添加尾注
                        if (j == newBook.capaters[i].EndLine && footNote != "")
                        {
                            newBook.epublines[j] += footNote;
                        }
                    }
                }
            }
            return;
        }
        #endregion
        #region XML+OTHER
        public static void mimetype_META_INF()
        {
            string path = TopPath;
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            var sb = new StringBuilder(@"application/epub+zip");
            _writeFile(path + "mimetype", sb);
            path += @"META-INF\";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            sb = new StringBuilder("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sb.Append("\r\n");
            sb.Append("<container version=\"1.0\" xmlns=\"urn:oasis:names:tc:opendocument:xmlns:container\">");
            sb.Append("\r\n");
            sb.Append(@"    <rootfiles>");
            sb.Append("\r\n");
            sb.Append(@"        "+"<rootfile full-path=\"OEBPS/content.opf\" media-type=\"application/oebps-package+xml\"/>");
            sb.Append("\r\n");
            sb.Append(@"   </rootfiles>");
            sb.Append("\r\n");
            sb.Append("</container>");
            _writeFile(path + "container.xml", sb);
        }
        public static void toc_ncx()
        {
            string head =
                @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no"" ?>
<!DOCTYPE ncx PUBLIC ""-//NISO//DTD ncx 2005-1//EN""
 ""http://www.daisy.org/z3986/2005/ncx-2005-1.dtd"">
<ncx xmlns=""http://www.daisy.org/z3986/2005/ncx/"" version=""2005-1"">
<head>
   <meta content=""urn:uuid:5208e6bb-5d25-45b0-a7fd-b97d79a85fd4"" name=""dtb:uid""/>
   <meta content=""0"" name=""dtb:depth""/>
   <meta content=""0"" name=""dtb:totalPageCount""/>
   <meta content=""0"" name=""dtb:maxPageNumber""/>
</head>
<docTitle>
   <text>[NAME]</text><!--填写书名-->
</docTitle>
<docAuthor>
   <text>[AUTHOR]</text><!--填写书籍作者-->
</docAuthor>
<navMap>
";
            head = head.Replace("[NAME]", _fixString(newBook.Name));
            head = head.Replace("[AUTHOR]", _fixString(newBook.Author));

            string template =
                @"
<navPoint id=""[PAGE]"" playOrder=""[INDEX]"">
	<navLabel>
		<text>[TITLE]</text>
	</navLabel>
	<content src=""Text/[PAGE].xhtml""/>
</navPoint>
";
            StringBuilder sb = new StringBuilder(head);
            int index = 0;
            foreach (BookFileInfo file in newBook.filelist)
            {
                if (file.inContents)
                {
                    sb.Append(template.Replace("[PAGE]", file.clearName).Replace("[TITLE]", file.chName).Replace("[INDEX]", index.ToString()));
                    index++;
                }
            }
            sb.Append(@"</navMap>
</ncx>");
            string path = _getPath(pathType.toc_ncx);
            string filename = path + @"\toc.ncx";
            _writeFile(filename, sb);
        }
        public static void content_opf()
        {
            string head =
                @"<?xml version=""1.0"" encoding=""utf-8"" standalone=""yes""?>
<package xmlns=""http://www.idpf.org/2007/opf"" unique-identifier=""BookId"" version=""2.0"">
	<metadata xmlns:dc=""http://purl.org/dc/elements/1.1/"" xmlns:opf=""http://www.idpf.org/2007/opf"">
		<dc:identifier id=""BookId"" opf:scheme=""UUID"">urn:uuid:[UUID]</dc:identifier>
		<dc:title>[TITLE]</dc:title>
		<dc:creator opf:file-as=""[MAKER]"" opf:role=""aut"">[AUTHOR]</dc:creator>
		<dc:language>zh</dc:language>
		<dc:subject>[SUBJECT]</dc:subject>
		<dc:description>[DESCRIPTION]</dc:description>
		<dc:source>[SOURCE]</dc:source>
		<dc:publisher>[PUBLISHER]</dc:publisher>
		<dc:date opf:event=""modification"">" + DateTime.Now.ToString("yyyy-MM-dd") + @"</dc:date>
        <dc:rights>[RIGHT]</dc:rights>
        <dc:identifier opf:scheme="""">[IDENTIFIER]</dc:identifier>
        <dc:contributor opf:role=""mrk"">[MRK]</dc:contributor>
		<meta Name=""cover"" content=""cover.jpg"" />
	</metadata>
	<manifest>
";
            head = head.Replace("[UUID]", MD5(newBook.Name+DateTime.Now.Millisecond.ToString()));
            head = head.Replace("[TITLE]", _fixString(newBook.Name));               //书名
            head = head.Replace("[MAKER]", _fixString(SofeSetting.Get("[MAKER]"))); //制作者
            head = head.Replace("[AUTHOR]", _fixString(newBook.Author));            //书籍作者
            head = head.Replace("[SUBJECT]", _fixString(SofeSetting.Get("[SUBJECT]")));//主题
            head = head.Replace("[DESCRIPTION]", _fixString(SofeSetting.Get("[DESCRIPTION]")));//说明
            head = head.Replace("[SOURCE]", _fixString(SofeSetting.Get("[SOURCE]")));//来源
            head = head.Replace("[PUBLISHER]", _fixString(SofeSetting.Get("[PUBLISHER]")));//出版
            head = head.Replace("[RIGHT]", _fixString(SofeSetting.Get("[RIGHT]")));//权限
            head = head.Replace("[IDENTIFIER]", _fixString(epubFactory.Version.sofeId));//标识符
            head = head.Replace("[MRK]", _fixString(epubFactory.Version.edition));//制作软件
            string manifestTemplate = @"		<item href=""[FILEALLNAME]"" id=""[PAGE]"" media-type=""[MEDIA_TYPE]"" />
";
            string spineTemplate = @"		<itemref idref=""[FILENAME]"" />
";

            StringBuilder sb = new StringBuilder(head);
            string spine = "";
            //添加manifest
            sb.Append(
@"		<item href=""toc.ncx"" id=""ncx"" media-type=""application/x-dtbncx+xml"" />
");
            foreach (BookFileInfo file in newBook.filelist)
            {
                sb.Append(manifestTemplate.Replace("[PAGE]", file.clearName).Replace("[FILEALLNAME]", file.fileAllName).Replace("[MEDIA_TYPE]", file.media_type));
                if (file.media_type == "application/xhtml+xml")
                {
                    spine += spineTemplate.Replace("[FILENAME]", file.clearName);
                }
            }
            sb.Append(@"    </manifest>
    <spine toc=""ncx"">
");
            //添加<spine toc="ncx">
            sb.Append(spine);
            sb.Append(@"	</spine>
	<guide>
		<reference href=""Text/contents.xhtml"" title=""Table Of Contents"" type=""toc"" />
		<reference href=""Text/cover.xhtml"" title=""Cover"" type=""cover"" />
	</guide>
</package>");

            string path = _getPath(pathType.content_opf);
            string filename = path + @"\content.opf";
            _writeFile(filename, sb);
        }
        #endregion
        #region DefaultCSS
        public static void CssBuilder()
        {
            string path = _getPath(pathType.Styles);
            //复制模板的CSS，若不成功，就是用默认模板
            if (!DefaultModel.CopyCSS(path, Program.newBook))
            {
                string css = DefaultModel.DefaultCSS();
                _writeFile(path + "style.css", css);
            }
        }
        #endregion
        #region private
        private static string MD5(string toCryString)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider hashmd5;
            hashmd5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            return BitConverter.ToString(hashmd5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(toCryString))).Replace("-", "").ToLower();//asp是小写,把所有字符变小写
        }
        /// <summary>
        /// 将文件添加入文件列表中
        /// </summary>
        /// <param name="chName"></param>
        /// <param name="fileAllName">相对于OEBPS文件夹的文件地址 如 Text/ass.XHTML</param>
        /// <param name="fileName">文件名 如 ass.Xhtml</param>
        /// <param name="clearName">不带后缀的文件名</param>
        /// <param name="inContents">是否在目录里</param>
        private static void _addFileList(string chName, string fileAllName, string fileName, string clearName, bool inContents)
        {
            BookFileInfo fileInfo = new BookFileInfo();
            fileInfo.chName = chName;
            fileInfo.fileAllName = fileAllName;
            fileInfo.fileName = fileName;
            fileInfo.clearName = clearName;
            fileInfo.inContents = inContents;
            fileInfo.media_type = "application/xhtml+xml";
            newBook.filelist.Add(fileInfo);
        }
        private static void _writeFile(string filename, StringBuilder sb)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            using (StreamWriter sw = new StreamWriter(filename, true, Encoding.UTF8))
            {
                sw.Write(sb);
                sw.Close();
            }
        }
        private static void _writeFile(string filename, string text)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            using (StreamWriter sw = new StreamWriter(filename, true, Encoding.UTF8))
            {
                sw.Write(text);
                sw.Close();
            }
        }
        private static string _getCapaterFileName(Capater capater)
        {
            return _getCapaterFileName(capater, true) + ".xhtml";
        }
        private static string _getCapaterFileName(Capater capater,bool noExt)
        {
            if (!noExt)
            {
                return _getCapaterFileName(capater);
            }
            int i = capater.CapaterIndex;
            string capaterIndex = i <= 9 ? "00" : (i <= 99 ? "0" : "");
            capaterIndex += i.ToString();
            string filename = "Section" + capaterIndex;
            return filename;
        }
        /// <summary>
        /// 获得文件的存储位置
        /// 返回例如 OEBPS\Text\
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static string _getPath(pathType type)
        {
            string path = TopPath;
            if (type == pathType.Text)
                path += @"OEBPS\Text\";
            else if (type == pathType.Images)
                path += @"OEBPS\Images\";
            else if (type == pathType.Styles)
                path += @"OEBPS\Styles\";
            else if (type == pathType.content_opf || type == pathType.toc_ncx)
                path += @"OEBPS\";
            else if (type == pathType.container_xml)
                path += @"META-INF\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }
        /// <summary>
        /// 修复XHtml中不能识别的特殊字符
        /// </summary>
        /// <returns></returns>
        private static string _fixString(string toFix)
        {
            return toFix.Replace(@"&", "&amp;").Replace("<", "&#60;").Replace(">", "&#62;").Trim();
        }
        #endregion
    }

}
