using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForDrives.Services.Interfaces
{
    public interface IInterpretationService
    {
        int ToNumber(string letters);
        string ToLetters(int number);
    }
}
