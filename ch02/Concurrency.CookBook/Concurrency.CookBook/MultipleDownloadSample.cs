using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Concurrency.CookBook
{
    public class MultipleDownloadSample
    {
        public MultipleDownloadSample()
        {
        }

        async Task<string> DownloadAllAsync(HttpClient client, IEnumerable<string> urls)
        {
            // Define behavior for each url
            var downloads = urls.Select(url => client.GetStringAsync(url));

            // No task start running until execute ToArray()
            Task<string>[] downloadTasks = downloads.ToArray();

            // Wait for all async task complete 
            string[] htmlPages = await Task.WhenAll(downloadTasks);
            return string.Concat(htmlPages);
        }
    }
}
