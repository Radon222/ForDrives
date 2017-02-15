using ForDrives.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForDrives.Services.Core
{
    public class DrivesAccessibilityService : DrivesService
    {
        public DrivesAccessibilityService() : base("NoViewOnDrive")
        {
        }
    }
}
