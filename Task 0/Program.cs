using System;
using System.Threading;

namespace Task_0
{
    class ThreadPoolDemo
    {
        public void Task1(object obj)
        {
            // Writes text to console 3 times
            for (int i = 0; i <= 2; i++)
            {
                Console.WriteLine("Task 1 is being executed");
            }
        }

        public void Task2(object obj)
        {
            // Writes text to console 3 time
            for (int i = 0; i <= 2; i++)
            {
                Console.WriteLine("Task 2 is being executed");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ThreadPoolDemo tpd = new ThreadPoolDemo();

            // Calls thread the thread methods 4 times
            for (int i = 0; i < 2; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(tpd.Task1));
                ThreadPool.QueueUserWorkItem(new WaitCallback(tpd.Task2));
            }

            Console.Read();
        }
    }
}
