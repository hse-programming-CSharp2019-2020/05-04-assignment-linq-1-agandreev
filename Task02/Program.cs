﻿using System;
using System.Linq;

/* В задаче не использовать циклы for, while. Все действия по обработке данных выполнять с использованием LINQ
 * 
 * На вход подается строка, состоящая из целых чисел типа int, разделенных одним или несколькими пробелами.
 * Необходимо оставить только те элементы коллекции, которые предшествуют нулю, или все, если нуля нет.
 * Дважды вывести среднее арифметическое квадратов элементов новой последовательности.
 * Вывести элементы коллекции через пробел.
 * Остальные указания см. непосредственно в коде.
 * 
 * Пример входных данных:
 * 1 2 0 4 5
 * 
 * Пример выходных:
 * 2,500
 * 2,500
 * 1 2
 * 
 * Обрабатывайте возможные исключения путем вывода на экран типа этого исключения 
 * (не использовать GetType(), пишите тип руками).
 * Например, 
 *          catch (SomeException)
            {
                Console.WriteLine("SomeException");
            }
 * В случае возникновения иных нештатных ситуаций (например, в случае попытки итерирования по пустой коллекции) 
 * выбрасывайте InvalidOperationException!
 */
namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTesk02();
        }

        public static void RunTesk02()
        {
            int[] arr;
            try
            {
                // Попробуйте осуществить считывание целочисленного массива, записав это ОДНИМ ВЫРАЖЕНИЕМ.
                arr = Console.ReadLine().Split(
                    new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(c => int.Parse(c)).ToArray();
                if (arr.Length == 0)
                {
                    throw new InvalidOperationException();
                }
                var filteredCollection = arr.TakeWhile(c => c != 0).ToArray();

                // использовать статическую форму вызова метода подсчета среднего
                double averageUsingStaticForm = filteredCollection.Select(n => n*n).ToArray().Average();
                // использовать объектную форму вызова метода подсчета среднего
                double averageUsingInstanceForm = filteredCollection.Select(n => n * n).ToArray().Average();
                Console.WriteLine($"{averageUsingStaticForm:F3}".Replace('.', ','));
                Console.WriteLine($"{averageUsingInstanceForm:F3}".Replace('.', ','));
                // вывести элементы коллекции в одну строку
                Console.WriteLine(String.Join(" ", filteredCollection.
                    Select(p => p.ToString()).ToArray()));
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("InvalidOperationException");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("ArgumentNullException");
            }
            catch (FormatException)
            {
                Console.WriteLine("FormatException");
            }
            catch (OverflowException)
            {
                Console.WriteLine("OverflowException");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("ArgumentException");
            }
            catch (Exception)
            {
                Console.WriteLine("Exception");
            }
            Console.ReadKey();
        }
        
    }
}
