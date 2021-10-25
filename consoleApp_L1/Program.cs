using System;
using System.Collections.Generic;
using System.Threading;

namespace consoleApp_L1
{
    //4. Создайте класс-обертку над List<T>, что бы можно было добавлять и удалять элементы из разных потоков без ошибок.
    class Program
    {
        private static object lockObject = new object();
        private static List<int> _list = new List<int>();
        static void Main(string[] args)
        {
            Console.WriteLine("Добавление"); 
            for (int i = 0; i < 9; i++)
            {
                Thread thread_1 = new Thread(new ThreadStart(() => AddInList(_list, i)));
                
                thread_1.Start();
                Thread.Sleep(100);
                Thread thread_2 = new Thread(new ThreadStart(() => AddInList(_list, 10+i)));

                thread_2.Start();
                Thread.Sleep(100);
            }


            PrintList(_list);

            Thread.Sleep(2000);

            
            Thread thread_3 = new Thread(new ThreadStart(() => RemoveElem(_list, 4)));

            thread_3.Start();

            Thread thread_4 = new Thread(new ThreadStart(() => RemoveElem(_list, 12)));

            thread_4.Start();

            Thread.Sleep(2000);

            PrintList(_list);

            Console.ReadKey();
        }

        
        

        private static void AddInList(List<int> list, int addNumber)
        {
            lock (lockObject)
            {
                list.Add(addNumber);

            }

        }

        private static void RemoveElem(List<int> list, int addNumber)
        {
            lock (lockObject)
            {
                Console.WriteLine($"Удаление - {addNumber}");
                list.Remove(addNumber);
            }

        }

        private static void PrintList(List<int> list)
        {
            lock (lockObject)
            {
                foreach (var i in list)
                {
                    Console.WriteLine(i);
                }
            }
            
        }
    }
}
