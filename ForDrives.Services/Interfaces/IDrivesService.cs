using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForDrives.Services.Interfaces
{
    public interface IDrivesService
    {
        bool ForLocalMachine { get; set; }
        bool LocalMachineAccessTest();
        string GetCurrentSettings();
        bool SaveNewSettings(string userInput);
        bool RemoveGlobalSettings();
    }
}
