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
            Func<int, int> pow2 = delegate (int x)
            {
                return (int)Math.Pow(2, x);
            };

            int result = 0;
            for (int i = 0; i < letters.Length; i++)
            {
                var invalid = (letters[i] < 65) || (letters[i] > 90);
                result += invalid ? 0 : pow2(letters[i] - 65);                
            }

            return result;
        }
    }
}
