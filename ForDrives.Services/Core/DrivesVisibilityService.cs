using ForDrives.Services.Interfaces;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForDrives.Services.Core
{
    public class DrivesVisibilityService : DrivesService
    {
        public DrivesVisibilityService() : base("NoDrives")
        {
        }
    }
}
