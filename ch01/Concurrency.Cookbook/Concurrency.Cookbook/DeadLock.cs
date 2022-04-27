using System;
using System.Threading.Tasks;

namespace Concurrency.Cookbook
{
    //This Dead Lock only happen in ASP.NET Classical but not in .NET Core
    public class DeadLock
    {
        public DeadLock()
        {

        }

        async Task WaitAsync()
        {
            // Dead lock here
            // await try to recover WaitAsync but failed because the thread was blocked in Deadlock()
            await Task.Delay(TimeSpan.FromSeconds(1));
        }

        public void Deadlock()
        {
            Task task = WaitAsync();

            // Deadlock() block thread and wait for sync complete
            task.Wait();
            Console.WriteLine("test");
        }
    }
}
