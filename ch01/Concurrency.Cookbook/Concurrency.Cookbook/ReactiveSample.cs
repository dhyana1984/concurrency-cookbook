using System;
using System.Diagnostics;
using System.Reactive.Linq;

namespace Concurrency.Cookbook
{
    public class ReactiveSample
    {
        public ReactiveSample()
        {
        }

        public void SubscribeSample()
        {
            IObservable<DateTimeOffset> timestamps = Observable
                .Interval(TimeSpan.FromSeconds(1))
                .Timestamp()
                .Where(x => x.Value % 2 == 0)
                .Select(x => x.Timestamp);

            timestamps.Subscribe(x => Console.WriteLine(x));
        }
    }
}
