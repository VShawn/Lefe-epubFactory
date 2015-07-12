using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using LeFe.Model;

namespace epubFactory
{
    class Text2Html
    {
        //标题
        public static string titleMark = "h4";
        public static string titleClass = "";
        //分隔符
        public static string delimiterMark = "h4";
        public static string delimiterClass = "";
        //普通行
        public static string lineMark = "p";
        public static string lineClass = "";
        /// <summary>
        /// 自己添加的正则格式 格式如 开始章 第?节
        /// </summary>
        public static List<string> addRegex;
        /// <summary>
        /// 判断传入的字符串是否为标题
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static bool IsTitle(string row)
        {
            row = row.Trim();
            string[] rows = { row };
            if (row.IndexOf(" ") > 0)
            {
                rows = row.Split(' ');//分割以应付："第一卷 一章 故事的开始"这样的情况
            }
            foreach (var s in rows)
            {
                if (addRegex != null && addRegex.Count > 0)
                {
                    foreach (string rule in addRegex)
                    {
                        if (Regex.IsMatch(s, rule))
                        {
                            return true;
                        }
                    }
                }
                else //若没有设置识别规则
                {
                    //以这三个开头并结束
                    if (Regex.IsMatch(s, "^(序|序章|终|终章|后记|最终章)$"))
                    {
                        return true;
                    }
                    //以第或没有第开头+汉字数字+章或不加结束的
                    if (Regex.IsMatch(s, "^(第|)[一二三四五十六七八九十百千壹贰叁肆伍拾陆柒捌玖拾佰仟]*(章|)$"))
                    {
                        return true;
                    }
                    //存在纯数字则一定要以章结束
                    if (Regex.IsMatch(s, "^(第|)[1234567890]*(章)$"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 判断是否为分隔符
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static bool IsDelimiter(string row)
        {
            row = row.Trim();
            if (Regex.IsMatch(row, "^◇.*◇$") || Regex.IsMatch(row, "^◆.*◆$") || Regex.IsMatch(row, "^※.*※$"))//※
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 获取识别出的文章标题
        /// </summary>
        /// <param name="booklines"></param>
        /// <returns></returns>
        public static List<string> GetListTitles(List<string> booklines)
        {
            List<string> titles = new List<string>();
            for (int i = 0; i < booklines.Count; i++)
            {
                if (IsTitle(booklines[i]))
                {
                    titles.Add(booklines[i]);
                }
            }
            return titles;
        }
        /// <summary>
        /// 将原始的TXT行转换为EPUB行
        /// </summary>
        /// <param name="newBook"></param>
        /// <returns></returns>
        public static Book Text2Epub(Book newBook)
        {
            string _delimiterClass = delimiterClass == "" ? "" : " class='" + delimiterClass.Trim() + "'";
            newBook.capaters = new List<Capater>();
            int capaterIndex = 0; //章节序号
            for (int i = 0; i < newBook.booklines.Count; i++)
            {
                if (IsTitle(newBook.booklines[i]))
                {
                    newBook.epublines[i] = DefaultModel.GetSetting("正文标题").Replace("[%标题%]", newBook.booklines[i]);
                    Capater cm = new Capater();
                    cm.Name = newBook.booklines[i];
                    cm.SatrtLine = i;
                    cm.CapaterIndex = capaterIndex;
                    cm.EndLine = newBook.booklines.Count - 1;
                    if (capaterIndex > 0)
                    {
                        newBook.capaters[capaterIndex - 1].EndLine = i - 1;
                    }
                    newBook.capaters.Add(cm);
                    capaterIndex++;
                }
                else
                {
                    if (IsDelimiter(newBook.booklines[i]))
                        newBook.epublines[i] = "<" + delimiterMark + _delimiterClass + ">" + newBook.booklines[i] + "</" + delimiterMark + ">";//若为分界符
                    else
                    {
                        newBook.epublines[i] = DefaultModel.GetSetting("正文行").Replace("[%该行内容%]", newBook.booklines[i]);
                    }
                }
            }
            return newBook;
        }
        /// <summary>
        /// 添加自定义正则规则
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public static void MakeUpRules(List<string> original)
        {
            addRegex = new List<string>();
            foreach (var one in original)
            {
                addRegex.Add(_MakeUp(one.Trim()));
            }
        }
        private static string _MakeUp(string original)
        {
            string re = "^(";
            if (original.IndexOf("?") >= 0)
            {
                re += original.Replace("?", "[一二三四五十六七八九十百千壹贰叁肆伍拾陆柒捌玖拾佰仟1234567890]");
            }
            else
            {
                re += original;
            }
            re += ")$";
            return re;
        }
    }
}
