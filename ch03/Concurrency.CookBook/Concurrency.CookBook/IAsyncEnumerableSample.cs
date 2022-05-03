using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Concurrency.CookBook
{
    public class IAsyncEnumerableSample
    {
        public IAsyncEnumerableSample()
        {

        }

        //Create IAsyncEnumerable
        async IAsyncEnumerable<string> GetValueAsync(HttpClient client)
        {
            int offset = 0;
            const int limit = 10;
            while (true)
            {
                string result = await client.GetStringAsync($"https://exampleurl/api/values?offset={offset}&limit={limit}");
                string[] valueOnThisPage = result.Split('\n');

                //Generate the result of this page
                foreach (var value in valueOnThisPage)
                {
                    yield return value;
                }

                //Break while loop if last page
                if(valueOnThisPage.Length != limit)
                {
                    break;
                }

                //Or next page
                offset += limit;
            }
        }

        //Consume IAsyncEnumerable
        async Task ProcessValueAsync(HttpClient client)
        {
            await foreach (var value in GetValueAsync(client))
            {
                Console.WriteLine(value);
            }
        }
    }
}
