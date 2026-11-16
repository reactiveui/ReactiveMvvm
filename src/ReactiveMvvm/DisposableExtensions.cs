// Copyright (c) 2019-2026 ReactiveUI and Contributors. All rights reserved.
// ReactiveUI and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Reactive.Disposables;
using ReactiveUI.Primitives.Reactive.Disposables;

namespace ReactiveMvvm;

/// <summary>Registers subscriptions with the containers used by the sample views.</summary>
public static class DisposableExtensions
{
    /// <summary>Registers a subscription with its lifetime owner.</summary>
    /// <typeparam name="T">The disposable subscription type.</typeparam>
    /// <param name="subscription">The subscription to register.</param>
    extension<T>(T subscription)
        where T : IDisposable
    {
        /// <summary>Adds a subscription to a System.Reactive container.</summary>
        /// <param name="container">The container that owns the subscription.</param>
        /// <returns>The registered subscription.</returns>
        public T DisposeWith(CompositeDisposable container)
        {
            ArgumentNullException.ThrowIfNull(container);
            container.Add(subscription);
            return subscription;
        }

        /// <summary>Adds a subscription to a ReactiveUI activation container.</summary>
        /// <param name="container">The container that owns the subscription.</param>
        /// <returns>The registered subscription.</returns>
        public T DisposeWith(ContainerDisposable container)
        {
            ArgumentNullException.ThrowIfNull(container);
            container.Add(subscription);
            return subscription;
        }
    }
}
