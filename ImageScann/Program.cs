using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace ImageScann
{
    static class Program
    {
      
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //string path = AppDomain.CurrentDomain.BaseDirectory + "MAutoUpdate.exe";
            ////同时启动自动更新程序
            //if (File.Exists(path))
            //{
            //    ProcessStartInfo processStartInfo = new ProcessStartInfo()
            //    {
            //        FileName = "MAutoUpdate.exe",
            //        Arguments = " ImageScann 0" //1表示静默更新 0表示弹窗提示更新
            //    };
            //    processStartInfo.UseShellExecute = false;
            //    Process proc = Process.Start(processStartInfo);
            //    if (proc != null)
            //    {
            //        proc.WaitForExit();
            //    }
            //}
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);        
            Application.Run(new frmLogin());

        }


    }
}
