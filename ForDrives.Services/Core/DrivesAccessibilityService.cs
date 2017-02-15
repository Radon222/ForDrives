using ForDrives.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForDrives.Services.Core
{
    public class DrivesAccessibilityService : IDrivesService
    {
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

        public string GetCurrentSettings()
        {
            throw new NotImplementedException();
        }

        public bool RemoveGlobalSettings()
        {
            throw new NotImplementedException();
        }

        public bool SaveNewSettings(string userInput)
        {
            throw new NotImplementedException();
        }

        public bool TestAccess()
        {
            throw new NotImplementedException();
        }

    }
}
