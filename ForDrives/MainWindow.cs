using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Win32;
using ForDrives.Services.Core;

namespace ForDrives
{

    public partial class MainWindow : Form
    {
        private const string LMPath = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer";
        private const string CUPath = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer";
        private const string ND = "NoDrives";
        private const string NV = "NoViewOnDrive";
        private string mboxInfo = Application.ProductName + " Tips";
        public delegate void TBDelegate(TextBox thectrl, string thetxt);

        private AppCore kernel;

        public MainWindow()
        {
            InitializeComponent();
            kernel = new AppCore();
        }

        private void tMainWin_Load(object sender, EventArgs e)
        {
            Text = Application.ProductName + " [Version " + Application.ProductVersion + "]";
            if (!kernel.LocalMachineAccessTest())
            {
                MessageBox.Show("请保证您具有管理员权限后再运行本程序！\n",
                    mboxInfo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            RefreshDrvs();
        }

        private void Settext(TextBox thectrl, string thetxt)
        {
            if (thectrl.InvokeRequired)
            {
                TBDelegate d = new TBDelegate(Settext);
                this.Invoke(d, thectrl, thetxt);
            }
            else thectrl.Text = thetxt;
        }

        private void RefreshDrvs()
        {
            var noDrivesService = new DrivesVisibilityService();
            var noViewDriveService = new DrivesAccessibilityService();
            Settext(ShowCH, noDrivesService.GetCurrentSettings());
            Settext(CUNoView, noViewDriveService.GetCurrentSettings());
        }

        private void SaveDrvSettings(string Path, string TP, string TheS)
        {
            if (kernel.SaveToRegistry(Path, TP, TheS))
            {
                RefreshDrvs();
                ReturnOK();
            }
            else
            {
                MessageBox.Show("写入注册表时发生错误，可能是 " + Application.ProductName + " 被禁止访问注册表。\n",
                    mboxInfo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DelDrvSettings(string TP)
        {
            try
            {
                RegistryKey R = Registry.LocalMachine;
                R = R.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true);
                if (!(Convert.ToInt32(R.GetValue(TP, -414)) == -414)) R.DeleteValue(TP, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除原设置时发生错误，可能是 " + Application.ProductName + " 被禁止访问注册表。\n" + ex.Message,
                    mboxInfo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReturnOK()
        {
            MessageBox.Show("设置完成，新的设置需要（注销并重新登录您的用户）或（重新启动计算机）后才能生效。",
                mboxInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void HideDrv_MouseEnter(object sender, EventArgs e)
        {
            RefreshDrvs();
        }

        private void DisallowView_MouseEnter(object sender, EventArgs e)
        {
            RefreshDrvs();
        }

        private void RunBackGround(string targ)
        {
            BackgroundWorker W = new BackgroundWorker();
            switch (targ)
            {
                case ND:
                    W.DoWork += new DoWorkEventHandler(NoD);
                    break;
                case NV:
                    W.DoWork += new DoWorkEventHandler(NoV);
                    break;
            }
            W.RunWorkerAsync();
            W.Dispose();
        }

        private void NoD(object sender, EventArgs e)
        {
            if (ToLM.Checked)
                SaveDrvSettings(LMPath, ND, NewOrder.Text);
            else
            {
                DelDrvSettings(ND);
                SaveDrvSettings(CUPath, ND, NewOrder.Text);
            }
        }

        private void NoV(object sender, EventArgs e)
        {
            if (ToLM.Checked)
                SaveDrvSettings(LMPath, NV, NewNoView.Text);
            else
            {
                DelDrvSettings(NV);
                SaveDrvSettings(CUPath, NV, NewNoView.Text);
            }
        }

        private void Backerb_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkTo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://github.com/radon222");
                linkTo.LinkVisited = true;
            }
            catch
            {

            }
        }

        private void killExplorers()
        {
            try
            {
                foreach (Process p in Process.GetProcessesByName("Explorer"))
                    p.Kill();
            }
            catch (Exception)
            {

            }
        }

        private void TakeEffects_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("执行此命令后，您的桌面和任务栏会暂时丢失，您确认要执行此命令吗？",
                mboxInfo, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                killExplorers();
                MessageBox.Show("请稍候，您的桌面和任务栏将在数秒后恢复。如果您的桌面和任务栏没有自动恢复，请通过（任务管理器执行新任务“Explorer”）来恢复桌面。",
                    mboxInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("您可以通过（注销并重新登录您的用户）或（重新启动计算机）来使新的设置生效。",
                    mboxInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void WriteItIn_Click(object sender, EventArgs e)
        {
            RunBackGround(ND);
        }

        private void SaveNoView_Click(object sender, EventArgs e)
        {
            RunBackGround(NV);
        }

    }
}
