using System;

namespace ReactiveMvvm.Interfaces
{
    public interface IClock
    {
        IObservable<long> Tick { get; }
    }
}
