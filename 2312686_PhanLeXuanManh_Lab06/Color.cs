using System;

namespace _2312686_PhanLeXuanManh_Lab06
{
    public static class Color
    {
        public static void Red(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(s);
            Console.ResetColor();
        }

        public static void Green(string s)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s);
            Console.ResetColor();
        }
    }
}
