using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ForDrives
{
    
    public partial class TMainWin : Form
    {
        const string LMPath = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer";
        const string CUPath = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer";
        const string ND = "NoDrives";
        const string NV = "NoViewOnDrive";
        const string Testvalue = "ForDrivesTested";
        public string mboxInfo = Application.ProductName + " Tips";
        public delegate void TBDelegate(TextBox thectrl, string thetxt);
        
        public TMainWin()
        {
            InitializeComponent();
        }
        
        private void tMainWin_Load(object sender, EventArgs e)
        {
            Text = Application.ProductName + " [Version " + Application.ProductVersion + "]";
            try
            {
                Registry.SetValue(LMPath, Testvalue, 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Application.ProductName + " 无法写入注册表，请保证您具有管理员权限后再运行本程序！\n" + ex.Message, mboxInfo, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
             Settext(ShowCH ,GetDrvChars(ND));
             Settext(CUNoView, GetDrvChars(NV));
        }

        private int GettValue(string Path, string Strs)
        {
            try
            {
                return Convert.ToInt32(Registry.GetValue(Path, Strs, -1));
            }
            catch
            {
                return -1;
            }            
        }

        private string GetDrvChars(string tp)
        {
            string functionReturnValue = "";
            int LM = GettValue(LMPath, tp);
            int CU = GettValue(CUPath, tp);
            if (LM >= 0) return (ToChars(LM));
            if (CU > 0) return (ToChars(CU));
            return functionReturnValue;
        }

        private string ToChars(int N)
        {
            string functionReturnValue = null;
            int t = 0;
            int m = N;
            bool[] a = new bool[27];
            if ((N <= 0) | (N > 67108863)) return ("");
            while (m > 0)
            {
                t++;
                if (m % 2 == 1) a[t] = true;
                else a[t] = false;
                m = m / 2;
            }
            for (int i = 1; i <= 26; i++) if (a[i]) functionReturnValue = functionReturnValue + Convert.ToChar(i + 64);
            return functionReturnValue;
        }        
        
        private int ToNumbers(string S)
        {
            int functionReturnValue = 0;            
            bool[] CHS = new bool[27];
            for (int i = 0; i <= S.Length - 1; i++)
            {
                if ((Convert.ToByte(S[i]) < 65) | (Convert.ToByte(S[i]) > 90)) continue;
                else CHS[Convert.ToByte(S[i]) - 64] = true;
            }
            for (int i = 1; i <= 26; i++) if (CHS[i]) functionReturnValue = functionReturnValue + Convert.ToInt32(Math.Pow(Convert.ToDouble(2), Convert.ToDouble(i - 1)));
            return functionReturnValue;
        }
        
        private void SaveDrvSettings(string Path, string TP, string TheS)
        {
            try
            {
                Registry.SetValue(Path, TP, ToNumbers(TheS), RegistryValueKind.DWord);
                RefreshDrvs();
                ReturnOK();
            }
            catch (Exception ex)
            {
                MessageBox.Show("写入注册表时发生错误，可能是 " + Application.ProductName + " 被禁止访问注册表。\n" + ex.Message, mboxInfo, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("删除原设置时发生错误，可能是 " + Application.ProductName + " 被禁止访问注册表。\n" + ex.Message, mboxInfo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReturnOK()
        {
            MessageBox.Show("设置完成，新的设置需要（注销并重新登录您的用户）或（重新启动计算机）后才能生效。", mboxInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void NoD(object sender,EventArgs e)
        {           
            if (ToLM.Checked) SaveDrvSettings(LMPath, ND, NewOrder.Text);
            else
            {
                DelDrvSettings(ND);
                SaveDrvSettings(CUPath, ND, NewOrder.Text);
            }
        }

        private void NoV(object sender, EventArgs e)
        {
            if (ToLM.Checked) SaveDrvSettings(LMPath, NV, NewNoView.Text);
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
                System.Diagnostics.Process.Start("http://blog.163.com/Steven_Radon/");
                linkTo.LinkVisited = true;
            }
            catch
            {
            }
        }

        private void TakeEffects_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("执行此命令后，您的桌面和任务栏会暂时丢失，您确认要执行此命令吗？", mboxInfo, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (Process p in Process.GetProcessesByName("Explorer")) p.Kill();
                MessageBox.Show("请稍候，您的桌面和任务栏将在数秒后恢复。如果您的桌面和任务栏没有自动恢复，请通过（任务管理器执行新任务“Explorer”）来恢复桌面。", mboxInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("您可以通过（注销并重新登录您的用户）或（重新启动计算机）来使新的设置生效。", mboxInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
