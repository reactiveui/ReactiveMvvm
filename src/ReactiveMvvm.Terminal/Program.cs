// Copyright (c) 2019-2026 ReactiveUI and Contributors. All rights reserved.
// ReactiveUI and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Reactive.Concurrency;
using ReactiveMvvm.Services;
using ReactiveMvvm.Terminal.Services;
using ReactiveMvvm.Terminal.Views;
using ReactiveMvvm.ViewModels;
using ReactiveUI.Reactive.Builder;

namespace ReactiveMvvm.Terminal;

/// <summary>Starts the platform feedback application.</summary>
public static class Program
{
    /// <summary>Starts the platform application.</summary>
    /// <param name="args">The command-line arguments.</param>
    public static void Main(string[] args)
    {
        using var application = Application.Create();
        _ = application.Init();
        _ = RxAppBuilder.CreateReactiveUIBuilder().WithCoreServices().BuildApp();
        RxSchedulers.MainThreadScheduler = new TerminalScheduler(application);
        RxSchedulers.TaskpoolScheduler = TaskPoolScheduler.Default;
        using var viewModel = new FeedbackViewModel(new TerminalSender(), new Clock());
        using var view = new FeedbackView(viewModel);
        _ = application.Run(view);
    }
}
