using System;
using System.Text;

namespace Lab1
{
    internal static class Program
    {
        private const int MaxFigureSize = 30;
        private const int MaxListNumber = 1000;
        private const double MaxFractionInput = 1e15;
        private const string Menu = """
            Лабораторная работа №1. Задачи 1, 3, 5, 7, 9
            1 - Методы
            2 - Условия
            3 - Циклы
            4 - Массивы
            0 - выход
            """;

        private static void Main()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            int taskNumber;
            while (true)
            {
                Console.WriteLine(Menu);
                taskNumber = ConsoleInput.ReadInt32("Номер задания: ", 0, 4);
                if (taskNumber == 0)
                {
                    return;
                }

                RunTask(taskNumber);
            }
        }

        private static void RunTask(int taskNumber)
        {
            Console.WriteLine();
            try
            {
                switch (taskNumber)
                {
                    case 1:
                        ShowMethods();
                        break;
                    case 2:
                        ShowConditions();
                        break;
                    case 3:
                        ShowLoops();
                        break;
                    case 4:
                        ShowArrays();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(taskNumber));
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Результат не помещается в тип int.");
            }

            Console.WriteLine();
        }

        private static void ShowMethods()
        {
            Console.WriteLine("1.1. Дробная часть");
            var number = ConsoleInput.ReadDouble("x = ", MaxFractionInput);
            Console.WriteLine($"Результат: {Tasks.Fraction(number)}");

            Console.WriteLine("1.3. Букву в число");
            var digit = ReadDigitChar("x = ");
            Console.WriteLine($"Результат: {Tasks.CharToNum(digit)}");

            Console.WriteLine("1.5. Двузначное");
            var value = ReadAnyInt32("x = ");
            Console.WriteLine($"Результат: {FormatBool(Tasks.Is2Digits(value))}");

            Console.WriteLine("1.7. Диапазон");
            var a = ReadAnyInt32("a = ");
            var b = ReadAnyInt32("b = ");
            var num = ReadAnyInt32("num = ");
            Console.WriteLine($"Результат: {FormatBool(Tasks.IsInRange(a, b, num))}");

            Console.WriteLine("1.9. Равенство");
            var first = ReadAnyInt32("a = ");
            var second = ReadAnyInt32("b = ");
            var third = ReadAnyInt32("c = ");
            Console.WriteLine($"Результат: {FormatBool(Tasks.IsEqual(first, second, third))}");
        }

        private static void ShowConditions()
        {
            Console.WriteLine("2.1. Модуль числа");
            var number = ConsoleInput.ReadInt32("x = ", -int.MaxValue, int.MaxValue);
            Console.WriteLine($"Результат: {Tasks.Abs(number)}");

            Console.WriteLine("2.3. Тридцать пять");
            var value = ReadAnyInt32("x = ");
            Console.WriteLine($"Результат: {FormatBool(Tasks.Is35(value))}");

            Console.WriteLine("2.5. Тройной максимум");
            var x = ReadAnyInt32("x = ");
            var y = ReadAnyInt32("y = ");
            var z = ReadAnyInt32("z = ");
            Console.WriteLine($"Результат: {Tasks.Max3(x, y, z)}");

            Console.WriteLine("2.7. Двойная сумма");
            var left = ReadAnyInt32("x = ");
            var right = ReadAnyInt32("y = ");
            Console.WriteLine($"Результат: {Tasks.Sum2(left, right)}");

            Console.WriteLine("2.9. День недели");
            var day = ReadAnyInt32("x = ");
            Console.WriteLine($"Результат: \"{Tasks.Day(day)}\"");
        }

        private static void ShowLoops()
        {
            Console.WriteLine("3.1. Числа подряд");
            var last = ConsoleInput.ReadInt32("x = ", 0, MaxListNumber);
            Console.WriteLine($"Результат: \"{Tasks.ListNums(last)}\"");

            Console.WriteLine("3.3. Чётные числа");
            var limit = ConsoleInput.ReadInt32("x = ", 0, MaxListNumber);
            Console.WriteLine($"Результат: \"{Tasks.Chet(limit)}\"");

            Console.WriteLine("3.5. Длина числа");
            var number = ConsoleInput.ReadInt64("x = ");
            Console.WriteLine($"Результат: {Tasks.NumLen(number)}");

            Console.WriteLine("3.7. Квадрат");
            var squareSize = ConsoleInput.ReadInt32("x = ", 0, MaxFigureSize);
            Tasks.Square(squareSize);

            Console.WriteLine("3.9. Правый треугольник");
            var triangleHeight = ConsoleInput.ReadInt32("x = ", 0, MaxFigureSize);
            Tasks.RightTriangle(triangleHeight);
        }

        private static void ShowArrays()
        {
            Console.WriteLine("4.1. Поиск первого значения");
            var numbers = ConsoleInput.ReadIntArray("arr = ", true);
            var wanted = ReadAnyInt32("x = ");
            Console.WriteLine($"Результат: {Tasks.FindFirst(numbers, wanted)}");

            Console.WriteLine("4.3. Поиск максимального по модулю");
            var values = ConsoleInput.ReadIntArray("arr = ", false);
            Console.WriteLine($"Результат: {Tasks.MaxAbs(values)}");

            Console.WriteLine("4.5. Добавление массива в массив");
            var source = ConsoleInput.ReadIntArray("arr = ", true);
            var inserted = ConsoleInput.ReadIntArray("ins = ", true);
            var position = ConsoleInput.ReadInt32("pos = ", 0, source.Length);
            Console.WriteLine($"Результат: {FormatArray(Tasks.Add(source, inserted, position))}");

            Console.WriteLine("4.7. Возвратный реверс");
            var original = ConsoleInput.ReadIntArray("arr = ", true);
            Console.WriteLine($"Результат: {FormatArray(Tasks.ReverseBack(original))}");
            Console.WriteLine($"Исходный массив не изменился: {FormatArray(original)}");

            Console.WriteLine("4.9. Все вхождения");
            var array = ConsoleInput.ReadIntArray("arr = ", true);
            var element = ReadAnyInt32("x = ");
            Console.WriteLine($"Результат: {FormatArray(Tasks.FindAll(array, element))}");
        }

        private static int ReadAnyInt32(string prompt)
        {
            return ConsoleInput.ReadInt32(prompt, int.MinValue, int.MaxValue);
        }

        private static char ReadDigitChar(string prompt)
        {
            char symbol;
            while (true)
            {
                symbol = ConsoleInput.ReadChar(prompt);
                if (symbol >= '0' && symbol <= '9')
                {
                    return symbol;
                }

                Console.WriteLine("Нужна одна цифра от 0 до 9.");
            }
        }

        private static string FormatBool(bool value)
        {
            return value ? "true" : "false";
        }

        private static string FormatArray(int[] array)
        {
            return "[" + string.Join(", ", array) + "]";
        }
    }
}
