using System;

namespace Concurrency.Cookbook
{
    class Program
    {
        static void Main(string[] args)
        {
            //DeadLock deadLock = new DeadLock();
            //deadLock.Deadlock();

            ReactiveSample reactiveSample = new ReactiveSample();
            reactiveSample.SubscribeSample();

            Console.ReadLine();
        }
    }
}
