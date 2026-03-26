using System;

namespace CourseWork.Converters
{
    public class BinaryConverter
    {
        public static string ToBinary(int number)
        {
            return Convert.ToString(number, 2);
        }
    }

    public class HexConverter
    {
        public static string ToHex(int number)
        {
            return Convert.ToString(number, 16).ToUpper();
        }
    }
}