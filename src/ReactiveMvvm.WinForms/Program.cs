// Copyright (c) 2019-2026 ReactiveUI and Contributors. All rights reserved.
// ReactiveUI and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Windows.Forms;
using ReactiveMvvm.Services;
using ReactiveMvvm.ViewModels;
using ReactiveMvvm.WinForms.Services;
using ReactiveMvvm.WinForms.Views;
using ReactiveUI.Reactive.Builder;

namespace ReactiveMvvm.WinForms;

/// <summary>Starts the platform feedback application.</summary>
public static class Program
{
    /// <summary>Starts the platform application.</summary>
    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        _ = RxAppBuilder.CreateReactiveUIBuilder().WithWinForms().BuildApp();
        using var viewModel = new FeedbackViewModel(new WinFormsSender(), new Clock());
        using var view = new FeedbackView { ViewModel = viewModel };
        Application.Run(view);
    }
}
