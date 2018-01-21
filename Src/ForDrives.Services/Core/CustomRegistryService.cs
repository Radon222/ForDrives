using ForDrives.Services.Interfaces;
using Microsoft.Win32;
using System;
using System.Threading.Tasks;

namespace ForDrives.Services.Core
{
    public class CustomRegistryService : ICustomRegistryService
    {
        public int GetValue(string keyName, string valueName)
        {
            try
            {
                var result = (int)Registry.GetValue(keyName, valueName, -1);
                return result;
            }
            catch
            {
                return -1;
            }
        }
        
        public bool SetValue(string keyName, string valueName, object value)
        {
            try
            {
                Registry.SetValue(keyName, valueName, value, RegistryValueKind.DWord);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }        
    }
}
