using ReactiveMvvm.Interfaces;
using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using ReactiveUI;

namespace ReactiveMvvm.Services
{
    public sealed class Clock : IClock
    {
        public IObservable<long> Tick { get; }

        public Clock()
        {
            var interval = TimeSpan.FromSeconds(1);
            Tick = Observable.Timer(interval, interval, RxApp.TaskpoolScheduler);
        }
    }
}
