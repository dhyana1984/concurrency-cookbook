using System;
using System.Threading.Tasks;

namespace Concurrency.Cookbook
{
    public class DeadLock
    {
        public DeadLock()
        {
  
        }

        async  Task WaitAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
        }

        void Deadlock()
        {
            Task task = WaitAsync();

            //Dead lock
            task.Wait();
        }
    }
}
