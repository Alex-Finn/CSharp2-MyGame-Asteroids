using System;
using System.Collections.Generic;
using System.Linq;
/*
    2. Дана коллекция List<T>. Требуется подсчитать, сколько раз каждый элемент встречается в
    данной коллекции:
    a. для целых чисел;
    b. * для обобщенной коллекции;
    c. ** используя Linq.
*/
namespace homework_4_2
{
    class Program
    {
        // 4.2.a
        public static int CountInt (List<int> list, int x)
        {
            int count = 0;
            foreach (var item in list)
            {
                if (item == x)
                {
                    count++;
                }
            }
            return count;
        }

        // 4.2.b
        public static int CountGeneric<T>(List<T> list, T x)
        {
            int count = 0;
            foreach (var item in list)
            {
                if (item.Equals(x))
                {
                    count++;
                }
            }
            return count;
        }

        // 4.2.c
        public static int CountLINQ<T>(List<T> list, T x)
        {
            var count = from n
                        in list
                        where n.Equals(x)
                        select n;
            return count.Count();
        }

        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 4, 4, 20, 1, 2, 8, 19, 4, 3 });

            Console.Write("In List: ");
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
                        
            Console.WriteLine("\n\n======================\nMethod for integers:");
            Console.WriteLine($"4 is encounter {CountInt(list, 4)} times");
            Console.WriteLine($"3 is encounter {CountInt(list, 3)} times");
            Console.WriteLine($"1 is encounter {CountInt(list, 1)} times");
            Console.WriteLine($"666 is encounter {CountInt(list, 666)} times");

            Console.WriteLine("\n======================\nMethod for generic types:");
            Console.WriteLine($"4 is encounter {CountGeneric(list, 4)} times");
            Console.WriteLine($"3 is encounter {CountGeneric(list, 3)} times");
            Console.WriteLine($"1 is encounter {CountGeneric(list, 1)} times");
            Console.WriteLine($"666 is encounter {CountGeneric(list, 666)} times");

            Console.WriteLine("\n======================\nMethod with LINQ:");
            Console.WriteLine($"4 is encounter {CountLINQ(list, 4)} times");
            Console.WriteLine($"3 is encounter {CountLINQ(list, 3)} times");
            Console.WriteLine($"1 is encounter {CountLINQ(list, 1)} times");
            Console.WriteLine($"666 is encounter {CountLINQ(list, 666)} times");

            Console.ReadKey();
        }
    }
}
