using System.Threading.Tasks;

namespace ForDrives.Services.Interfaces
{
    public interface ICustomRegistryService
    {
        int GetValue(string keyName, string valueName);
        bool SetValue(string keyName, string valueName, object value);
    }
}
