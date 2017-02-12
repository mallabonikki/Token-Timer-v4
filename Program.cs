using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TokenTimerV4
{
    static class Program
    {
        //[DllImport("coredll.dll", CharSet = CharSet.Auto)]
        //private static extern int FindWindow(string lpClassName, string lpWindowName);

        //[DllImport("coredll.dll", CharSet = CharSet.Auto)]
        //private static extern bool ShowWindow(int hWnd, int cmdShow);

        //private const int SW_HIDE = 0x0000;
        //private const int SW_SHOW = 0x0001;
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmTTimer());
            //int hTaskBar = FindWindow("HHTaskBar", string.Empty);
           //ShowWindow(hTaskBar, 0);
           TokenTimerV4.SingleApplication.Run(new frmTTimer());
        }
    }
}
