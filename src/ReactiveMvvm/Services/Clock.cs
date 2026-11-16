// Copyright (c) 2019-2026 ReactiveUI and Contributors. All rights reserved.
// ReactiveUI and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using ReactiveMvvm.Interfaces;

namespace ReactiveMvvm.Services;

/// <summary>Emits a sequential tick once per second.</summary>
[DebuggerDisplay("{Tick}")]
public sealed class Clock : IClock
{
    /// <summary>Initializes a new instance of the <see cref="Clock"/> class using the application scheduler.</summary>
    public Clock()
        : this(RxSchedulers.TaskpoolScheduler)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="Clock"/> class.</summary>
    /// <param name="scheduler">The scheduler that measures each interval.</param>
    public Clock(IScheduler scheduler)
    {
        ArgumentNullException.ThrowIfNull(scheduler);
        var interval = TimeSpan.FromSeconds(1);
        Tick = Observable.Timer(interval, interval, scheduler);
    }

    /// <inheritdoc/>
    public IObservable<long> Tick { get; }
}
