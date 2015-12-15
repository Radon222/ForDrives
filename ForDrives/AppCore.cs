using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForDrives
{
    public class AppCore
    {
        private const string LMPath = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer";
        private const string CUPath = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer";
        private const string ND = "NoDrives";
        private const string NV = "NoViewOnDrive";
        private const string Testvalue = "ForDrivesTested";

        public bool LocalMachineAccessTest()
        {
            try
            {
                Registry.SetValue(LMPath, Testvalue, 1);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string getNoDrives()
        {
            return GetDrvChars(ND);
        }

        public string getNoViewOnDrive()
        {
            return GetDrvChars(NV);
        }

        private string GetDrvChars(string tp)
        {
            int LM = GetRegValue(LMPath, tp);
            int CU = GetRegValue(CUPath, tp);
            if (LM >= 0) return (ToChars(LM));
            if (CU > 0) return (ToChars(CU));
            return "";
        }

        private int GetRegValue(string Path, string Strs)
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
            for (int i = 1; i <= 26; i++)
                if (a[i])
                    functionReturnValue += Convert.ToChar(i + 64);
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
            for (int i = 1; i <= 26; i++)
                if (CHS[i])
                    functionReturnValue += Convert.ToInt32(Math.Pow(Convert.ToDouble(2), Convert.ToDouble(i - 1)));
            return functionReturnValue;
        }

        public bool SaveToRegistry(string Path, string keyName, string keyValue)
        {
            try
            {
                Registry.SetValue(Path, keyName, ToNumbers(keyValue), RegistryValueKind.DWord);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
