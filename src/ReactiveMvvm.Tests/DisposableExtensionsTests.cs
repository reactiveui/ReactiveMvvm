// Copyright (c) 2019-2026 ReactiveUI and Contributors. All rights reserved.
// ReactiveUI and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Reactive.Disposables;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ReactiveUI.Primitives.Reactive.Disposables;

namespace ReactiveMvvm.Tests;

/// <summary>Verifies that subscriptions are handed to the container that owns them.</summary>
public sealed class DisposableExtensionsTests
{
    /// <summary>Checks that a System.Reactive container disposes the subscription it was given.</summary>
    /// <returns>A task representing the test.</returns>
    [Test]
    public async Task DisposeWith_CompositeDisposable_DisposesWithTheContainer()
    {
        var disposed = new StrongBox<bool>();
        var subscription = Disposable.Create(disposed, static flag => flag.Value = true);
        var container = new CompositeDisposable();

        var returned = subscription.DisposeWith(container);
        container.Dispose();

        await Assert.That(returned).IsSameReferenceAs(subscription);
        await Assert.That(disposed.Value).IsTrue();
    }

    /// <summary>Checks that a ReactiveUI activation container disposes the subscription it was given.</summary>
    /// <returns>A task representing the test.</returns>
    [Test]
    public async Task DisposeWith_ContainerDisposable_DisposesWithTheContainer()
    {
        var disposed = new StrongBox<bool>();
        var subscription = Disposable.Create(disposed, static flag => flag.Value = true);
        var container = new ContainerDisposable();

        var returned = subscription.DisposeWith(container);
        container.Dispose();

        await Assert.That(returned).IsSameReferenceAs(subscription);
        await Assert.That(disposed.Value).IsTrue();
    }

    /// <summary>Checks that a missing container is rejected.</summary>
    /// <returns>A task representing the test.</returns>
    [Test]
    public async Task DisposeWith_RejectsAMissingContainer()
    {
        var subscription = Disposable.Empty;

        _ = await Assert.That(() => subscription.DisposeWith((CompositeDisposable)null!)).Throws<ArgumentNullException>();
        _ = await Assert.That(() => subscription.DisposeWith((ContainerDisposable)null!)).Throws<ArgumentNullException>();
    }
}
