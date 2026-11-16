// Copyright (c) 2019-2026 ReactiveUI and Contributors. All rights reserved.
// ReactiveUI and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Threading.Tasks;
using Microsoft.Reactive.Testing;
using ReactiveMvvm.Services;
using ReactiveUI.Testing;

namespace ReactiveMvvm.Tests;

/// <summary>Verifies clock ticks using independently controlled virtual time.</summary>
public sealed class ClockTests
{
    /// <summary>Virtual scheduler milliseconds in one second.</summary>
    private const int MillisecondsPerSecond = 1000;

    /// <summary>Checks that each elapsed second advances the sequential tick.</summary>
    /// <returns>A task representing the test.</returns>
    [Test]
    public async Task Tick_AdvancesOncePerSecond()
    {
        var scheduler = new TestScheduler();
        var clock = new Clock(scheduler);
        long? value = null;
        using var subscription = clock.Tick.Subscribe(next => value = next);
        await Assert.That(value).IsNull();
        scheduler.AdvanceByMs(MillisecondsPerSecond);
        await Assert.That(value).IsEqualTo(0L);
        scheduler.AdvanceByMs(MillisecondsPerSecond);
        await Assert.That(value).IsEqualTo(1L);
    }
}
