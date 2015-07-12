using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LeFe.Model;

namespace epubFactory
{
    public static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
        public static Book newBook = new Book();
    }
}
