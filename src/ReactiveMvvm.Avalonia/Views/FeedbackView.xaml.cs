// Copyright (c) 2019-2026 ReactiveUI and Contributors. All rights reserved.
// ReactiveUI and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Runtime.CompilerServices;
using Avalonia.Markup.Xaml;
using ReactiveMvvm.ViewModels;
using ReactiveUI.Avalonia.Reactive;

namespace ReactiveMvvm.Avalonia.Views;

/// <summary>Displays and binds the shared feedback form on this platform.</summary>
public sealed class FeedbackView : ReactiveWindow<FeedbackViewModel>
{
    /// <summary>Initializes a new instance of the FeedbackView class.</summary>
    public FeedbackView() => InitializeComponent();

    /// <summary>Loads the feedback view's declarative controls.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void InitializeComponent() => AvaloniaXamlLoader.Load(this);
}
