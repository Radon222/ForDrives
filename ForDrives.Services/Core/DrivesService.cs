using ForDrives.Services.Interfaces;
using Microsoft.Win32;
using System;

namespace ForDrives.Services.Core
{
    public class DrivesService : IDrivesService
    {
        private string valueName;
        private IInterpretationService interpreter;
        private ICustomRegistryService regeditor;

        public DrivesService(string ServiceType)
        {
            valueName = ServiceType;
            interpreter = new InterpretationService();
            regeditor = new CustomRegistryService();
        }

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
            return regeditor.SetValue(targetPath, StaticValues.TestValueName, 1);
        }
    }
}
