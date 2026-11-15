using System;
using System.Reactive.Disposables;
using ReactiveUI.Primitives.Reactive.Disposables;

namespace ReactiveMvvm;

/// <summary>Registers subscriptions with the containers used by the sample views.</summary>
public static class DisposableExtensions
{
    /// <summary>Adds a subscription to a System.Reactive container.</summary>
    public static T DisposeWith<T>(this T subscription, CompositeDisposable container)
        where T : IDisposable
    {
        ArgumentNullException.ThrowIfNull(container);
        container.Add(subscription);
        return subscription;
    }

    /// <summary>Adds a subscription to a ReactiveUI activation container.</summary>
    public static T DisposeWith<T>(this T subscription, ContainerDisposable container)
        where T : IDisposable
    {
        ArgumentNullException.ThrowIfNull(container);
        container.Add(subscription);
        return subscription;
    }
}
