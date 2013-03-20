using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

//using LdrawData;
using System.Diagnostics;



namespace LdrDat2Obj
{
    static class LdrDat2Obj
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //MPDFileList testfun = new MPDFileList("C:\\Users\\Rolf\\Desktop\\7667.mpd");
            //Debug.WriteLine("Made testfun");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
