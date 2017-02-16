using ForDrives.Services.Interfaces;
using System;
using System.Linq;
using System.Text;

namespace ForDrives.Services.Core
{
    public class InterpretationService : IInterpretationService
    {
        public string ToLetters(int number)
        {
            string result = "";
            if ((number <= 0) || (number > 67108863))
                return result;

            string binaryString = Convert.ToString(number, 2).PadLeft(26, '0');
            var reversedBinaryStr = binaryString.Reverse().ToList();
            for (int i = 0; i < reversedBinaryStr.Count; i++)            
                result += reversedBinaryStr[i] == '1' ? ((char)(i + 65)).ToString() : "";
            
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
