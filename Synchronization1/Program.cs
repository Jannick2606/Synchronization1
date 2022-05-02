using System;
using System.Threading;

namespace Synchronization1
{
    class Program
    {
        static int num = 0;
        static readonly object lock1 = new object();
        static void Main(string[] args)
        {
            Thread t1 = new Thread(Add);
            Thread t2 = new Thread(Subtract);
            t1.Start();
            t2.Start();
        }
        static void Add()
        {
            while (true)
            {
                Monitor.Enter(lock1);
                try
                {
                    num += 2;
                    Console.WriteLine(num);
                    Thread.Sleep(500);
                }
                finally
                {
                    Monitor.Exit(lock1);
                }
            }
        }
        static void Subtract()
        {
            while (true)
            {
                Monitor.Enter(lock1);
                try
                {
                    num -= 1;
                    Console.WriteLine(num);
                    Thread.Sleep(500);
                }
                finally
                {
                    Monitor.Exit(lock1);
                }
            }
        }
    }
}
