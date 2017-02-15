using ForDrives.Services.Interfaces;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForDrives.Services.Core
{
    public class DrivesVisibilityService : IDrivesService
    {
        private const string fakeValueName = "ForDrivesTested";
        private const string valueName = "NoDrives";
        private IInterpretationService interpreter;
        private ICustomRegistryService regeditor;

        private bool forLocalMachine;

        public bool ForLocalMachine
        {
            get
            {
                return forLocalMachine;
            }

            set
            {
                forLocalMachine = value;
            }
        }

        public DrivesVisibilityService()
        {
            interpreter = new InterpretationService();
        }

        private string getDrivesString()
        {
            int LM = regeditor.GetValue(StaticValues.LocalMachinePath, valueName);
            int CU = regeditor.GetValue(StaticValues.CurrentUserPath, valueName);
            if (LM >= 0)
                return (interpreter.ToLetters(LM));
            if (CU > 0)
                return (interpreter.ToLetters(CU));
            return "";
        }

        public string GetCurrentSettings()
        {
            return getDrivesString();
        }

        public bool RemoveGlobalSettings()
        {
            try
            {
                RegistryKey registry = Registry.LocalMachine;
                registry = registry.OpenSubKey(StaticValues.PartialPath, true);
                int result = (int)registry.GetValue(valueName, -1);
                if (result != -1)
                    registry.DeleteValue(valueName, false);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SaveNewSettings(string userInput)
        {
            int value = interpreter.ToNumber(userInput);
            string targetPath = forLocalMachine ? StaticValues.LocalMachinePath : StaticValues.CurrentUserPath;
            return regeditor.SetValue(targetPath, valueName, value);
        }

        public bool LocalMachineAccessTest()
        {
            string targetPath = forLocalMachine ? StaticValues.LocalMachinePath : StaticValues.CurrentUserPath;
            return regeditor.SetValue(targetPath, fakeValueName, 1);
        }
    }
}
