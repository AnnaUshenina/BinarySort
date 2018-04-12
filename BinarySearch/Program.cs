using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    class Program
    {
        public static int BinarySearch(int[] array, int value)
        {

            // Проверить, имеет ли смыл вообще выполнять поиск:
            // - если длина массива равна нулю - искать нечего;
            // - если искомый элемент меньше первого элемента массива, значит, его в массиве нет;
            // - если искомый элемент больше последнего элемента массива, значит, его в массиве нет.
            if ((array.Length == 0) || (value < array[0]) || (value > array[array.Length - 1]))
                return -1;

            // Приступить к поиску.
            // Номер первого элемента в массиве.
            int first = 0;
            // Номер элемента массива, СЛЕДУЮЩЕГО за последним
            int last = array.Length;

            // Если просматриваемый участок не пуст, first < last
            while (first < last)
            {
                int mid = first + (last - first) / 2;

                if (value <= array[mid])
                    last = mid;
                else
                    first = mid + 1;
            }

            // Теперь last может указывать на искомый элемент массива.
            if (array[last] == value)
                return last;
            else
                return -1;

        }

        static void Main(string[] args)
        {
            TestNegativeNumbers();
            TestNonExistentElement();
            TestBigArray();
            TestNullArray();
            TestRepetingElement();
            Console.ReadKey();
        }

        private static void TestNegativeNumbers()
        {
            //Тестирование поиска в отрицательных числах
            int[] negativeNumbers = new[] { -5, -4, -3, -2 };
            if (BinarySearch(negativeNumbers, -3) != 2)
                Console.WriteLine("! Поиск не нашёл число -3 среди чисел {-5, -4, -3, -2}");
            else
                Console.WriteLine("Поиск среди отрицательных чисел работает корректно");
        }
        private static void TestNonExistentElement()
        {
            //Тестирование поиска отсутствующего элемента
            int[] negativeNumbers = new[] { -5, -4, -3, -2 };
            if (BinarySearch(negativeNumbers, -1) >= 0)
                Console.WriteLine("! Поиск нашёл число -1 среди чисел {-5, -4, -3, -2}");
            else
                Console.WriteLine("Поиск отсутствующего элемента вернул корректный результат работает корректно");
        }
        private static void TestRepetingElement()
        {
            int[] randomNumbers = new[] { 1, 2, 3, 3, 4, 5 };
            if (BinarySearch(randomNumbers, 3) != 2)
                Console.WriteLine("Поиск не нашёл число, что число 3 среди чисел {1, 2, 3, 3, 4, 5 } повторяется несколько раз");
            else
                Console.WriteLine("Поиск повторяющегося элемента вернул корректный результат, работает корректно");
        }
        private static void TestNullArray()
        {
            int[] unexistentArray = { };
            if (BinarySearch(unexistentArray, 6) != -1)
                Console.WriteLine("Поиск нашел число в пустом массиве");
            else
                Console.WriteLine("Поиск в пустом массиве вернул корректный результат, работает корректно");
        }

        private static void TestBigArray()
        {
            int[] bigArray = new int[100001];
            for (int i = 0; i < 100001; i++)
                bigArray[i] = i;

            if (BinarySearch(bigArray, 5678) == 5678)
                Console.WriteLine("Поиск нашел нужный элемент в массиве из 100001го элемента, работает корректно");
            else
                Console.WriteLine("Поиск не смог найти элемент в массиве из 100001го элемента");
        }
    }
}
