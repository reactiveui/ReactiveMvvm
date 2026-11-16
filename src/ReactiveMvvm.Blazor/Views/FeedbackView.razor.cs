// Copyright (c) 2019-2026 ReactiveUI and Contributors. All rights reserved.
// ReactiveUI and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using ReactiveMvvm.ViewModels;
using ReactiveUI.Reactive.Blazor;

namespace ReactiveMvvm.Blazor.Views;

/// <summary>Displays and binds the shared feedback form on this platform.</summary>
public partial class FeedbackView : ReactiveInjectableComponentBase<FeedbackViewModel>
{
    /// <summary>Initializes a new instance of the FeedbackView class.</summary>
    public FeedbackView() => this.WhenActivated();
}
