using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ForDrives
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 2) 
                MessageBox.Show("已经有 2 个 " + Application.ProductName + " 在运行！", Application.ProductName + " Tips", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else Application.Run(new MainWindow());
        }
    }
}
