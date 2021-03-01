using System;
using System.Diagnostics;
using System.Threading;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Thread t = new Thread(SomeFunction);
            // t.Start()      -  Used to start thread
            // Thread.Sleep() -  Used to delay a thread in a period of time 
            // t.Suspend()    -  Deprecated... But I would guess it was used to pause the thread
            // t.Resume()     -  Deprecated... But I would guess it was used to resume a paused thread
            // t.Join()       -  awaits until the thread is done executing

            Stopwatch watch = new Stopwatch();

            Thread t1 = new Thread(Process);
            t1.Start();
            Console.WriteLine($"Is Alive:{t1.IsAlive} - IsBackground:{t1.IsBackground} - Priority:{t1.Priority}");

            watch.Start();
            Thread t2 = new Thread(Process);
            t2.Priority = ThreadPriority.Lowest;
            t2.Start();
            t2.Join();
            watch.Stop();
            Console.WriteLine($"For the slow thread it took:{watch.Elapsed.Ticks} ticks");
            watch.Reset();

            watch.Start();
            Thread t3 = new Thread(Process);
            t3.Priority = ThreadPriority.Highest;
            t3.Start();
            t3.Join();
            watch.Stop();
            Console.WriteLine($"For the fast thread it took:{watch.Elapsed.Ticks} ticks");
        }

        static void Process()
        {
            for (int i = 0; i < 100000; i++)
            {
      
            }
        }
    }
}
