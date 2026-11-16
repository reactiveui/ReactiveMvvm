// Copyright (c) 2019-2026 ReactiveUI and Contributors. All rights reserved.
// ReactiveUI and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;

namespace ReactiveMvvm;

/// <summary>Schedules reactive work on the terminal application's event loop.</summary>
/// <param name="application">The application that dispatches scheduled work.</param>
public sealed class TerminalScheduler(IApplication application) : LocalScheduler
{
    /// <inheritdoc/>
    public override IDisposable Schedule<TState>(TState state, TimeSpan dueTime, Func<IScheduler, TState, IDisposable> action)
    {
        ArgumentNullException.ThrowIfNull(action);
        var composite = new CompositeDisposable();
        var cancellation = new CancellationDisposable();
        composite.Add(cancellation);

        void Invoke()
        {
            if (!cancellation.Token.IsCancellationRequested)
            {
                composite.Add(action(this, state));
            }
        }

        if (dueTime <= TimeSpan.Zero)
        {
            application.Invoke(Invoke);
        }
        else
        {
            var timeout = application.AddTimeout(dueTime, () =>
            {
                Invoke();
                return false;
            });
            if (timeout is not null)
            {
                composite.Add(Disposable.Create(timeout, value => application.RemoveTimeout(value)));
            }
        }

        return composite;
    }
}
