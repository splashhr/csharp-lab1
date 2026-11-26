using System;
using System.Text;

namespace Lab1
{
    public static class Tasks
    {
        public static double Fraction(double x)
        {
            return x - (long)x;
        }

        public static int CharToNum(char x)
        {
            if (x < '0' || x > '9')
            {
                throw new ArgumentOutOfRangeException(nameof(x), "Символ должен быть цифрой от 0 до 9.");
            }

            return x - '0';
        }

        public static bool Is2Digits(int x)
        {
            return (x >= 10 && x <= 99) || (x >= -99 && x <= -10);
        }

        public static bool IsInRange(int a, int b, int num)
        {
            var left = Math.Min(a, b);
            var right = Math.Max(a, b);
            return num >= left && num <= right;
        }

        public static bool IsEqual(int a, int b, int c)
        {
            return a == b && b == c;
        }

        public static int Abs(int x)
        {
            if (x < 0)
            {
                return checked(-x);
            }

            return x;
        }

        public static bool Is35(int x)
        {
            var divisibleBy3 = x % 3 == 0;
            var divisibleBy5 = x % 5 == 0;
            return divisibleBy3 != divisibleBy5;
        }

        public static int Max3(int x, int y, int z)
        {
            var max = x;
            if (y > max)
            {
                max = y;
            }

            if (z > max)
            {
                max = z;
            }

            return max;
        }

        public static int Sum2(int x, int y)
        {
            var sum = checked(x + y);
            if (sum >= 10 && sum <= 19)
            {
                return 20;
            }

            return sum;
        }

        public static string Day(int x)
        {
            switch (x)
            {
                case 1:
                    return "понедельник";
                case 2:
                    return "вторник";
                case 3:
                    return "среда";
                case 4:
                    return "четверг";
                case 5:
                    return "пятница";
                case 6:
                    return "суббота";
                case 7:
                    return "воскресенье";
                default:
                    return "это не день недели";
            }
        }

        public static string ListNums(int x)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(x);

            var result = new StringBuilder();
            result.Append(0);
            for (var number = 1; number <= x; number++)
            {
                result.Append(' ').Append(number);
            }

            return result.ToString();
        }

        public static string Chet(int x)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(x);

            var result = new StringBuilder();
            result.Append(0);
            for (var number = 2; number <= x; number += 2)
            {
                result.Append(' ').Append(number);
            }

            return result.ToString();
        }

        public static int NumLen(long x)
        {
            var length = 0;
            do
            {
                length++;
                x /= 10;
            }
            while (x != 0);

            return length;
        }

        public static void Square(int x)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(x);

            for (var row = 0; row < x; row++)
            {
                Console.WriteLine(new string('*', x));
            }
        }

        public static void RightTriangle(int x)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(x);

            for (var row = 1; row <= x; row++)
            {
                Console.WriteLine(new string(' ', x - row) + new string('*', row));
            }
        }

        public static int FindFirst(int[] arr, int x)
        {
            ArgumentNullException.ThrowIfNull(arr);

            for (var index = 0; index < arr.Length; index++)
            {
                if (arr[index] == x)
                {
                    return index;
                }
            }

            return -1;
        }

        public static int MaxAbs(int[] arr)
        {
            ArgumentNullException.ThrowIfNull(arr);
            if (arr.Length == 0)
            {
                throw new ArgumentException("Массив не должен быть пустым.", nameof(arr));
            }

            var result = arr[0];
            for (var index = 1; index < arr.Length; index++)
            {
                if (Math.Abs((long)arr[index]) > Math.Abs((long)result))
                {
                    result = arr[index];
                }
            }

            return result;
        }

        public static int[] Add(int[] arr, int[] ins, int pos)
        {
            ArgumentNullException.ThrowIfNull(arr);
            ArgumentNullException.ThrowIfNull(ins);
            if (pos < 0 || pos > arr.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(pos), $"Позиция должна быть от 0 до {arr.Length}.");
            }

            var result = new int[arr.Length + ins.Length];
            for (var index = 0; index < pos; index++)
            {
                result[index] = arr[index];
            }

            for (var index = 0; index < ins.Length; index++)
            {
                result[pos + index] = ins[index];
            }

            for (var index = pos; index < arr.Length; index++)
            {
                result[ins.Length + index] = arr[index];
            }

            return result;
        }

        public static int[] ReverseBack(int[] arr)
        {
            ArgumentNullException.ThrowIfNull(arr);

            var result = new int[arr.Length];
            for (var index = 0; index < arr.Length; index++)
            {
                result[index] = arr[arr.Length - 1 - index];
            }

            return result;
        }

        public static int[] FindAll(int[] arr, int x)
        {
            ArgumentNullException.ThrowIfNull(arr);

            var count = 0;
            foreach (var element in arr)
            {
                if (element == x)
                {
                    count++;
                }
            }

            var result = new int[count];
            var position = 0;
            for (var index = 0; index < arr.Length; index++)
            {
                if (arr[index] == x)
                {
                    result[position] = index;
                    position++;
                }
            }

            return result;
        }
    }
}
