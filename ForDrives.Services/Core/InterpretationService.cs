using ForDrives.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForDrives.Services.Core
{
    public class InterpretationService : IInterpretationService
    {
        public string ToLetters(int number)
        {
            string result = null;
            int t = 0;
            int m = number;
            bool[] a = new bool[27];
            if ((number <= 0) | (number > 67108863))
                return ("");
            while (m > 0)
            {
                t++;
                if (m % 2 == 1)
                    a[t] = true;
                else
                    a[t] = false;
                m = m / 2;
            }
            for (int i = 1; i <= 26; i++)
                if (a[i])
                    result += Convert.ToChar(i + 64);
            return result;
        }

        public int ToNumber(string letters)
        {
            int result = 0;
            bool[] CHS = new bool[27];
            for (int i = 0; i <= letters.Length - 1; i++)
            {
                if ((Convert.ToByte(letters[i]) < 65) | (Convert.ToByte(letters[i]) > 90))
                    continue;
                else
                    CHS[Convert.ToByte(letters[i]) - 64] = true;
            }
            for (int i = 1; i <= 26; i++)
                if (CHS[i])
                    result += Convert.ToInt32(Math.Pow(Convert.ToDouble(2), Convert.ToDouble(i - 1)));
            return result;
        }
    }
}
