// Copyright (c) 2019-2026 ReactiveUI and Contributors. All rights reserved.
// ReactiveUI and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

namespace ReactiveMvvm.Maui;

/// <summary>Hosts the platform application's feedback view.</summary>
public partial class App : Application
{
    /// <summary>Initializes a new instance of the App class.</summary>
    public App() => InitializeComponent();

    /// <inheritdoc/>
    protected override Window CreateWindow(IActivationState? activationState) => new(new AppShell());
}
