using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using ForDrives.Services.Core;
using ForDrives.Services.Interfaces;

namespace ForDrives.Classic
{
    public partial class MainWindow : Form
    {
        private delegate void TextBoxDelegate(TextBox thectrl, string thetxt);

        private string mboxInfo;
        private const string NoDriveSignal = "NoDrives";
        private const string NoViewSignal = "NoViewOnDrive";

        public MainWindow()
        {
            InitializeComponent();
            mboxInfo = Application.ProductName + " Tips";
        }

        private void tMainWin_Load(object sender, EventArgs e)
        {
            Text = Application.ProductName + " [Version " + Application.ProductVersion + "]";

            var noDrivesService = new DrivesVisibilityService();
            if (!noDrivesService.LocalMachineAccessTest())
            {
                MessageBox.Show("请保证您具有管理员权限后再运行本程序！\n",
                    mboxInfo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            ReloadSettings();
        }

        private void SetText(TextBox thectrl, string thetxt)
        {
            if (thectrl.InvokeRequired)
            {
                TextBoxDelegate d = new TextBoxDelegate(SetText);
                this.Invoke(d, thectrl, thetxt);
            }
            else thectrl.Text = thetxt;
        }

        private void ReloadSettings()
        {
            var service1 = new DrivesVisibilityService();
            var service2 = new DrivesAccessibilityService();
            SetText(ShowCH, service1.GetCurrentSettings());
            SetText(CUNoView, service2.GetCurrentSettings());
        }

        private void cannotSaveSetting()
        {
            MessageBox.Show("写入注册表时发生错误，可能是 " + Application.ProductName + " 被禁止访问注册表。\n",
                   mboxInfo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cannotChangeOldSetting()
        {
            MessageBox.Show("删除原设置时发生错误，可能是 " + Application.ProductName + " 被禁止访问注册表。\n",
                    mboxInfo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void showOK()
        {
            MessageBox.Show("设置完成，新的设置需要（注销并重新登录您的用户）或（重新启动计算机）后才能生效。",
                mboxInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void HideDrv_MouseEnter(object sender, EventArgs e)
        {
            ReloadSettings();
        }

        private void DisallowView_MouseEnter(object sender, EventArgs e)
        {
            ReloadSettings();
        }

        private void RunBackGround(string targ)
        {
            BackgroundWorker W = new BackgroundWorker();
            switch (targ)
            {
                case NoDriveSignal:
                    W.DoWork += new DoWorkEventHandler(NoD);
                    break;
                case NoViewSignal:
                    W.DoWork += new DoWorkEventHandler(NoV);
                    break;
            }
            W.RunWorkerAsync();
        }

        private void ApplySetting(IDrivesService driveService, string userInput, bool isLocalMachine)
        {
            driveService.ForLocalMachine = isLocalMachine;

            if ((!isLocalMachine) && (!driveService.RemoveGlobalSettings()))
            {
                cannotChangeOldSetting();
                return;
            }

            if (driveService.SaveNewSettings(userInput))
                showOK();
            else
                cannotSaveSetting();

            ReloadSettings();
        }

        private void NoD(object sender, EventArgs e)
        {
            var noDrivesService = new DrivesVisibilityService();
            string userInput = NewOrder.Text;
            bool isLocalMachine = ToLM.Checked;
            ApplySetting(noDrivesService, userInput, isLocalMachine);
        }

        private void NoV(object sender, EventArgs e)
        {
            var noViewDriveService = new DrivesAccessibilityService();
            string userInput = NewNoView.Text;
            bool isLocalMachine = ToLM.Checked;
            ApplySetting(noViewDriveService, userInput, isLocalMachine);
        }

        private void Backerb_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkTo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start("http://github.com/radon222");
                linkTo.LinkVisited = true;
            }
            catch
            {

            }
        }

        private void stopExplorers()
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
                stopExplorers();
                MessageBox.Show("请稍候，您的桌面和任务栏将在数秒后恢复。如果您的桌面和任务栏没有自动恢复，请通过（任务管理器执行新任务“Explorer”）来恢复桌面。",
                    mboxInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("您可以通过（注销并重新登录您的用户）或（重新启动计算机）来使新的设置生效。",
                    mboxInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void WriteItIn_Click(object sender, EventArgs e)
        {
            RunBackGround(NoDriveSignal);
        }

        private void SaveNoView_Click(object sender, EventArgs e)
        {
            RunBackGround(NoViewSignal);
        }

    }
}
