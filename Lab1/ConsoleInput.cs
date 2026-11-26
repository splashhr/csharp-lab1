using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Lab1
{
    internal static class ConsoleInput
    {
        public static int ReadInt32(string prompt, int minValue, int maxValue)
        {
            bool isNumber;
            int value;
            while (true)
            {
                Console.Write(prompt);
                isNumber = int.TryParse(ReadLine(), CultureInfo.InvariantCulture, out value);
                if (isNumber && value >= minValue && value <= maxValue)
                {
                    return value;
                }

                Console.WriteLine($"Нужно целое число от {minValue} до {maxValue}.");
            }
        }

        public static long ReadInt64(string prompt)
        {
            long value;
            while (true)
            {
                Console.Write(prompt);
                if (long.TryParse(ReadLine(), CultureInfo.InvariantCulture, out value))
                {
                    return value;
                }

                Console.WriteLine($"Нужно целое число от {long.MinValue} до {long.MaxValue}.");
            }
        }

        public static double ReadDouble(string prompt, double maxAbsValue)
        {
            string text;
            bool isNumber;
            double value;
            while (true)
            {
                Console.Write(prompt);
                text = ReadLine().Replace(',', '.');
                isNumber = double.TryParse(text, CultureInfo.InvariantCulture, out value);
                if (isNumber && Math.Abs(value) <= maxAbsValue)
                {
                    return value;
                }

                Console.WriteLine($"Нужно число от -{maxAbsValue} до {maxAbsValue}, например 5.25 или -3,5.");
            }
        }

        public static char ReadChar(string prompt)
        {
            string text;
            while (true)
            {
                Console.Write(prompt);
                text = ReadLine();
                if (text.Length == 1)
                {
                    return text[0];
                }

                Console.WriteLine("Нужно ввести ровно один символ.");
            }
        }

        public static int[] ReadIntArray(string prompt, bool allowEmpty)
        {
            int[] numbers;
            while (true)
            {
                Console.Write(prompt);
                if (TryParseIntArray(ReadLine(), out numbers) && (allowEmpty || numbers.Length > 0))
                {
                    return numbers;
                }

                Console.WriteLine("Нужно ввести целые числа через пробел, например: 1 2 3 4 5.");
            }
        }

        private static bool TryParseIntArray(string text, out int[] numbers)
        {
            var parts = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var parsed = new List<int>();
            int number;
            foreach (var part in parts)
            {
                if (!int.TryParse(part, CultureInfo.InvariantCulture, out number))
                {
                    numbers = Array.Empty<int>();
                    return false;
                }

                parsed.Add(number);
            }

            numbers = parsed.ToArray();
            return true;
        }

        private static string ReadLine()
        {
            return Console.ReadLine() ?? throw new EndOfStreamException("Ввод с клавиатуры закончился.");
        }
    }
}
