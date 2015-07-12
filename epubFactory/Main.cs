using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Ionic.Zip;
using LeFe.Model;
namespace epubFactory
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();


            //多线程检查更新
            AsyncCallback cGetUpdate = new AsyncCallback(callBack_GetUpdate);
            DelegateBook2Html dlb = new DelegateBook2Html(GetUpdate);
            dlb.BeginInvoke(cGetUpdate, dlb);

            if (!DefaultModel.CheckModel())
            {
                MessageBox.Show(@"警告，部分外部模板文件找不到，将使用程序内置模板！");
            }
        }
        private void Main_Load(object sender, EventArgs e)
        {
            Program.newBook = new Book();
            btn_output.Enabled = false;
        }
        private List<string> _booklines;//书籍原始行数
        private List<string> _epublines;//epub书籍行数

        #region 多线程
        public delegate List<string> DelegateLoadbook();//创建一个用于读取文本的委托
        private void callBack_loadBook(IAsyncResult result)
        {
            /*由于已经在调用BeginInvoke传递的最后一个参数是回调委托所以可以从操作状态中获取*/
            var lb = (DelegateLoadbook)result.AsyncState;//处理返回的结果
        }
        public delegate void DelegateBook2Html();//创建一个用于处理文本的委托
        private void callBack_book2Html(IAsyncResult result)
        {
            /*由于已经在调用BeginInvoke传递的最后一个参数是回调委托所以可以从操作状态中获取*/
            var bh = (DelegateBook2Html)result.AsyncState;//处理返回的结果
        }
        private void callBack_GetUpdate(IAsyncResult result)
        {
            /*由于已经在调用BeginInvoke传递的最后一个参数是回调委托所以可以从操作状态中获取*/
            var bh = result.AsyncState;//处理返回的结果
        }
        private void GetUpdate()
        {
            try
            {
                WebBrowser webBrowser = new WebBrowser();
                webBrowser.Navigate("http://singlex.sinaapp.com/LeFe/tongji.html");
            }
            catch
            {

            }

            epubFactory.Version.Check(true);
        }
        private List<string> LoadBook2Lines()
        {
            _booklines = new List<string>();
            _epublines = new List<string>();
            Encoding fileEncoding = TxtFileEncoding.GetEncoding(Program.newBook.Path, Encoding.GetEncoding("GB2312"));//取得这txt文件的编码
            using (var sr = new StreamReader(Program.newBook.Path, fileEncoding))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string newline = line.Replace("　", " ").Replace(@"&", "&amp;").Replace("<", "〈").Replace(">", "〉").Trim();
                    if (newline != "")
                    {
                        _booklines.Add(newline);
                        _epublines.Add(newline);
                    }
                }
            }
            Program.newBook.booklines = _booklines;
            Program.newBook.epublines = _epublines;
            return _booklines;
        }
        private void book2Html()
        {
            //进行文章分页
            Program.newBook = Text2Html.Text2Epub(Program.newBook);
        }
        #endregion 

        private void btn_importTXT_Click(object sender, EventArgs e)
        {
            Opacity = 0;
            int step = 1;
            while (true)
            {
                step = AutoStep(step);
                if (step <= 0)
                {
                    break;
                }
            }
            Opacity = 100;
            if (step == 0)
            {
                _epublines = new List<string>();
                //把原书的html存入临时
                for (int i = 0; i < Program.newBook.epublines.Count; i++)
                {
                    _epublines.Add(Program.newBook.epublines[i]);
                }

                btn_output.Enabled = true;
            }
        }
        private int AutoStep(int step)
        {
            DialogResult dialogResult = DialogResult.Yes;
            if (step == 1)//打开从TXT导入窗口
            {
                ImportTXT newimportTXT = new ImportTXT();
                dialogResult = newimportTXT.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    //多线程读取文本
                    AsyncCallback loadBookCB = new AsyncCallback(callBack_loadBook);
                    DelegateLoadbook dlb = new DelegateLoadbook(LoadBook2Lines);
                    dlb.BeginInvoke(loadBookCB, dlb);
                    return (step+1);
                }
                else
                {
                    return -1;
                }
            }
            else if (step == 2)
            {
                SetTitle st = new SetTitle();
                dialogResult = st.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    //多线程处理文本
                    AsyncCallback book2HtmlCB = new AsyncCallback(callBack_book2Html);
                    DelegateBook2Html dlb = new DelegateBook2Html(book2Html);
                    dlb.BeginInvoke(book2HtmlCB, dlb);
                    return (step + 1);
                }
            }
            else if (step == 3)
            {
                ListImgs listImgs = new ListImgs();
                dialogResult = listImgs.ShowDialog();
            }
            else if (step == 4)
            {
                SetBookInfo setBookInfo = new SetBookInfo();
                dialogResult = setBookInfo.ShowDialog(this);
            }
            else if (step == 5)
            {
                SetNote sn = new SetNote();
                dialogResult = sn.ShowDialog(this);
            }

            if (dialogResult == DialogResult.OK)
                return (step + 1);
            else if (dialogResult == DialogResult.Retry)
                return (step - 1);
            else if (dialogResult == DialogResult.Yes)
                return 0;
            else
                return -1;
        }
        private void btn_output_Click(object sender, EventArgs e)
        {
            string epubPath;
            string defaultfilePath = SofeSetting.Get("OutPutPath");
            var fbd = new FolderBrowserDialog();
            if (defaultfilePath != "")
            {
                //设置此次默认目录为上一次选中目录  
                fbd.SelectedPath = defaultfilePath;
            }
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                epubPath = fbd.SelectedPath;
                //记录选中的目录  
                SofeSetting.Set("OutPutPath", fbd.SelectedPath);
            }
            else
                return;
            //先在临时文件夹创建内容
            //string tmpDir = @"C:\tmp\";
            string tmpDir = epubPath + @"\" + Program.newBook.Name + "_" + DateTime.Now.Millisecond + @"\";
            if (Directory.Exists(tmpDir))
            {
                Directory.Delete(tmpDir, true);
            }
            Directory.CreateDirectory(tmpDir);

            #region 插入图片
            //插入书内图片
            for (int i = 0; i < Program.newBook.imgInBook.Count; i++)
            {
                if (Program.newBook.imgInBook[i].lines.Count > 0)
                {
                    foreach (int line in Program.newBook.imgInBook[i].lines)
                    {
                        //获得图片的存储名
                        string imgname = Program.newBook.imgInBook[i].storeName + Program.newBook.imgInBook[i].ext;
                        //在文字之前插入，后面肯定有文字，一定使用模板【插图后不带字】
                        if (Regex.IsMatch(Program.newBook.imgInBook[i].name, @"^(\[before\])") || Regex.IsMatch(Program.newBook.imgInBook[i].name, @"^(\[b\])"))
                        {
                            string imageHtml = DefaultModel.GetSetting("插图后带字");
                            imageHtml = imageHtml.Replace("[%图片名%]", imgname);
                            Program.newBook.epublines[line] = imageHtml + Program.newBook.epublines[line];
                        }
                        //在文字之后插入
                        else
                        {
                            //判断line的下一行是否有文字
                            int flag = 0;
                            for (int j = 0; j < Program.newBook.capaters.Count; j++)
                            {
                                //line为该章的最后一行
                                if ((line + 1) == Program.newBook.capaters[j].SatrtLine || line == Program.newBook.capaters[j].EndLine)
                                {
                                    flag = 1;
                                    break;
                                }
                            }
                            //flag为1时则说明后面没有文字了
                            string imageHtml = flag == 1 ? DefaultModel.GetSetting("插图后不带字") : DefaultModel.GetSetting("插图后带字");
                            imageHtml = imageHtml.Replace("[%图片名%]", imgname);
                            Program.newBook.epublines[line] += imageHtml;
                        }
                    }
                }
            }
            //直接替换某行的图片
            for (int i = 0; i < Program.newBook.imgOthers.Count; i++)
            {
                if (Program.newBook.imgOthers[i].lines.Count > 0)
                {
                    foreach (int line in Program.newBook.imgOthers[i].lines)
                    {
                        string imgname = Program.newBook.imgOthers[i].storeName + Program.newBook.imgOthers[i].ext;
                        //判断line的下一行是否有文字
                        int flag = 0;
                        for (int j = 0; j < Program.newBook.capaters.Count; j++)
                        {
                            //line为该章的最后一行
                            if ((line + 1) == Program.newBook.capaters[j].SatrtLine || line == Program.newBook.capaters[j].EndLine)
                            {
                                flag = 1;
                                break;
                            }
                        }
                        //若下一行没有文字，就不换行
                        //flag为1时则说明后面没有文字了
                        string imageHtml = flag == 1 ? DefaultModel.GetSetting("插图后不带字") : DefaultModel.GetSetting("插图后带字");
                        imageHtml = imageHtml.Replace("[%图片名%]", imgname);
                        Program.newBook.epublines[line] = imageHtml;
                    }
                }
            }
            #endregion
            Program.newBook.filelist = new List<BookFileInfo>();
            HtmlBuilder.newBook = Program.newBook;
            //设置注释
            HtmlBuilder.SetNotes();
            //设置临时目录
            HtmlBuilder.TopPath = tmpDir;
            HtmlBuilder.mimetype_META_INF();
            HtmlBuilder.CssBuilder();
            //创建封面
            HtmlBuilder.CoverBuilder();
            //标题
            HtmlBuilder.TitleBuilder();
            //创建制作信息
            HtmlBuilder.MessageBuilder();
            HtmlBuilder.LogoBuilder();
            //简介
            HtmlBuilder.SummaryBuilder();
            //创建彩图
            HtmlBuilder.IllusBuilder();
            //创建目录
            HtmlBuilder.ContentsBuilder();
            //创建章节
            HtmlBuilder.CapatersBuilder();
            //创建封底
            HtmlBuilder.BackCoverBuilder();
            //移动模板中图片
            DefaultModel.CopyImages(tmpDir + @"OEBPS\Images\", Program.newBook);
            DefaultModel.CopyMisc(tmpDir + @"OEBPS\Misc\", Program.newBook);
            //移动图片
            ImgManger.MoveImage(tmpDir + @"OEBPS\Images\", Program.newBook);
            HtmlBuilder.toc_ncx();
            HtmlBuilder.content_opf();

            epubPath += @"\" + Program.newBook.Name + ".epub";
            string zipFileToCreate = epubPath;
            string directoryToZip = tmpDir;
            try
            {
                using (ZipFile zip = new ZipFile())
                {
                    zip.StatusMessageTextWriter = System.Console.Out;
                    zip.AddDirectory(directoryToZip); // recurses subdirectories
                    zip.Save(zipFileToCreate);
                }
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }
            finally
            {
                Directory.Delete(tmpDir, true);
            }


            //还原原书的html,便于下一次导出
            for (int i = 0; i < Program.newBook.epublines.Count; i++)
            {
                Program.newBook.epublines[i] = _epublines[i];
            }
        }
        private void btn_About_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }
        private void btn_set_Click(object sender, EventArgs e)
        {
            Settings st = new Settings();
            st.ShowDialog();
        }

        private void btn_hekp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(epubFactory.Version.GetDocuments()); 
        }

        private void btn_comm_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(epubFactory.Version.GetDownload()); 
        }
    }
}
