using System;
using System.Diagnostics;
using System.Threading;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {

            Stopwatch watch = new Stopwatch();
            Console.WriteLine("Thread Pool Execution");
            watch.Start();
            ProcessWithThreadPoolMethod();
            watch.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadPoolMethod is : " + watch.ElapsedTicks + " ticks");

            watch.Reset();

            Console.WriteLine("Thread Execution");
            watch.Start();
            ProcessWithThreadMethod();
            watch.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadMethod is : " + watch.ElapsedTicks + " ticks");
        }

        static void Process(object obj)
        {
            // Process has to take object as an argument before it's used by QueueUserWorkItem
            // The reason is, if you pass the object in QueueUserWorkItem 
            // you will be able to get it inside of this thread 
        }

        static void ProcessWithThreadMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                Thread obj = new Thread(Process);
                obj.Start();
            }
        }
        static void ProcessWithThreadPoolMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                ThreadPool.QueueUserWorkItem(Process);
            }
        }
    }
}
