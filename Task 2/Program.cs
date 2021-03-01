using System;
using System.Diagnostics;
using System.Threading;

namespace Task_2
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
            // It takes much longer time to execute the thread process with these loops

            // * With 1 scope
            // Thread Pool Execution
            // Time consumed by ProcessWithThreadPoolMethod is : 19261 ticks
            // Thread Execution
            // Time consumed by ProcessWithThreadMethod is : 24110 ticks

            // * With 2 scopes
            // Thread Pool Execution
            // Time consumed by ProcessWithThreadPoolMethod is : 20608 ticks
            // Thread Execution
            // Time consumed by ProcessWithThreadMethod is : 8166451 ticks

            for (int i = 0; i < 100000; i++)
            {
                for (int j = 0; j < 100000; j++)
                {

                }
            }
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
