using System;

namespace Concurrency.CookBook
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgressSample ps = new ProgressSample();
            var progressTask = ps.CallMyMethodAsync();
            progressTask.Wait();
        }
    }
}
