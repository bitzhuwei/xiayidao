using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace bitzhuwei.Xiayidao.Winform
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //var date100 = new DateTime(2014, 6, 11).AddDays(100);
            //MessageBox.Show(date100.ToString(),"");
            //return ;
            //var array = new String(new char[]{'a', 'b', 'c'});
            //var type = array.GetType();
            //MessageBox.Show(type.ToString(), "");
            //return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
