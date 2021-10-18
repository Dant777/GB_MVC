using System;
using System.Threading;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (var pool = new Pool(5))
            {
                Action<int> action = (index =>
                {

                    Console.WriteLine($"Start: ThreadId - {Thread.CurrentThread.ManagedThreadId} - number {index}");
                    Thread.Sleep(200);
                    Console.WriteLine($"End: ThreadId - {Thread.CurrentThread.ManagedThreadId} - number {index}");
                });

                for (int i = 0; i < 10; i++)
                {
                    
                    pool.QueueTask(() => action(i));
                    
                }
            }

            Console.ReadKey();
        }
        
    }
}
