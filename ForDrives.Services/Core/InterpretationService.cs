using ForDrives.Services.Interfaces;
using System;

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
                    result += (char)(i + 64);
            return result;
        }

        public int ToNumber(string letters)
        {
            int result = 0;
            bool[] CHS = new bool[27];
            for (int i = 0; i <= letters.Length - 1; i++)
            {
                if (((byte)letters[i] < 65) | ((byte)letters[i] > 90))
                    continue;
                else
                    CHS[(byte)letters[i] - 64] = true;
            }
            for (int i = 1; i <= 26; i++)
                if (CHS[i])
                    result += (int)Math.Pow(2, (i - 1));
            return result;
        }
    }
}
