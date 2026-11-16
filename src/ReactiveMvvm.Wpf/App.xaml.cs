// Copyright (c) 2019-2026 ReactiveUI and Contributors. All rights reserved.
// ReactiveUI and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Windows;
using ReactiveMvvm.Services;
using ReactiveMvvm.ViewModels;
using ReactiveMvvm.Wpf.Services;
using ReactiveMvvm.Wpf.Views;
using ReactiveUI.Reactive.Builder;

namespace ReactiveMvvm.Wpf;

/// <summary>Hosts the platform application's feedback view.</summary>
public partial class App : Application
{
    /// <inheritdoc/>
    protected override void OnStartup(StartupEventArgs e)
    {
        _ = RxAppBuilder.CreateReactiveUIBuilder().WithWpf().BuildApp();
        var viewModel = new FeedbackViewModel(new WpfSender(), new Clock());
        var view = new FeedbackView { ViewModel = viewModel };
        view.Closed += (_, _) => viewModel.Dispose();
        view.Show();
        base.OnStartup(e);
    }
}
