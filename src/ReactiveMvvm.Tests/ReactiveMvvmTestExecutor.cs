// Copyright (c) 2019-2026 ReactiveUI and Contributors. All rights reserved.
// ReactiveUI and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Reactive.Concurrency;
using System.Threading.Tasks;
using ReactiveUI.Reactive.Builder;
using Splat;

namespace ReactiveMvvm.Tests;

/// <summary>Installs fresh services and restores schedulers after each feedback test.</summary>
public sealed class ReactiveMvvmTestExecutor : ITestExecutor
{
    /// <inheritdoc/>
    public async ValueTask ExecuteTest(TestContext context, Func<ValueTask> action)
    {
        ArgumentNullException.ThrowIfNull(action);
        var previousResolver = AppLocator.GetLocator();
        var previousMain = RxSchedulers.MainThreadScheduler;
        var previousPool = RxSchedulers.TaskpoolScheduler;
        using var resolver = new ModernDependencyResolver();
        AppLocator.SetLocator(resolver);
        _ = RxAppBuilder.CreateReactiveUIBuilder().WithCoreServices().BuildApp();
        RxSchedulers.MainThreadScheduler = Scheduler.Immediate;
        RxSchedulers.TaskpoolScheduler = Scheduler.Immediate;
        try
        {
            await action();
        }
        finally
        {
            RxSchedulers.MainThreadScheduler = previousMain;
            RxSchedulers.TaskpoolScheduler = previousPool;
            AppLocator.SetLocator(previousResolver);
        }
    }
}
