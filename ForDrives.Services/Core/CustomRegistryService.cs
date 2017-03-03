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

        public Task<int> GetValueAsync(string keyName, string valueName)
        {
            var taskSource = new TaskCompletionSource<int>();
            var query = GetValue(keyName, valueName);
            taskSource.SetResult(query);
            return taskSource.Task;
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

        public Task<bool> SetValueAsync(string keyName, string valueName, object value)
        {
            var taskSource = new TaskCompletionSource<bool>();
            var query = SetValue(keyName, valueName, value);
            taskSource.SetResult(query);
            return taskSource.Task;
        }
    }
}
