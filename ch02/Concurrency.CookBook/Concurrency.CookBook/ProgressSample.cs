using System;
using System.Threading.Tasks;

namespace Concurrency.CookBook
{
    public class ProgressSample
    {
        public ProgressSample()
        {
        }

        async Task MyMethodAsync(IProgress<int> progress = null)
        {
            bool done = false;
            var percentageComplete = 0;
            while (!done)
            {
                percentageComplete += 1;
                // Report is a async method, percentageComplete should be value type or immutable type
                progress?.Report(percentageComplete);
                done = percentageComplete == 100;
                await Task.Delay(TimeSpan.FromSeconds(1));
            }

        }

       public async Task CallMyMethodAsync()
        {
            var progress = new Progress<int>();
            // Callback
            progress.ProgressChanged += (sender, args) =>
            {
                Console.WriteLine(args);
            };

            await MyMethodAsync(progress);
        }
    }
}
