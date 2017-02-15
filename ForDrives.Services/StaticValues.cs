using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForDrives.Services
{
    public static class StaticValues
    {
        public const string LocalMachinePath = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer";
        public const string CurrentUserPath = "HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer";
        public const string PartialPath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer";
        public const string TestValueName = "ForDrivesTested";
    }
}
