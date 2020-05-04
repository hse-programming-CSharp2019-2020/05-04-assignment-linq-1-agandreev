using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* В задаче не использовать циклы for, while. Все действия по обработке данных выполнять с использованием LINQ
 * 
 * На вход подается строка, состоящая из целых чисел типа int, разделенных одним или несколькими пробелами.
 * Необходимо отфильтровать полученные коллекцию, оставив только отрицательные или четные числа.
 * Дважды вывести коллекцию, разделив элементы специальным символом.
 * Остальные указания см. непосредственно в коде!
 * 
 * Пример входных данных:
 * 1 2 3 4 5
 * 
 * Пример выходных:
 * 2:4
 * 2*4
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
 * 
 */

namespace Task01
{
    class Program
    {
        static void Main()
        {
            RunTesk01();
        }

        public static void RunTesk01()
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
                // использовать синтаксис запросов!
                IEnumerable<int> arrQuery = from num in arr
                                            where ((num % 2 == 0) || (num < 0))
                                            select num;

                // использовать синтаксис методов!
                IEnumerable<int> arrMethod = arr.Where(x => (x % 2 == 0) || (x < 0)).Select(x => x);

                PrintEnumerableCollection<int>(arrQuery, ":");
                PrintEnumerableCollection<int>(arrMethod, "*");
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
            Console.ReadLine();
        }

        // Попробуйте осуществить вывод элементов коллекции с учетом разделителя, записав это ОДНИМ ВЫРАЖЕНИЕМ.
        // P.S. Есть два способа, оставьте тот, в котором применяется LINQ...
        public static void PrintEnumerableCollection<T>(IEnumerable<T> collection, string separator)
        {
            string result = String.Join(separator, collection.Select(p => p.ToString()).ToArray());
            Console.WriteLine(result);           
        }
    }
}
