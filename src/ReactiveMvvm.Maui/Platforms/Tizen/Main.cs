// Copyright (c) 2019-2026 ReactiveUI and Contributors. All rights reserved.
// ReactiveUI and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using System;

namespace ReactiveMvvm.Maui;

/// <summary>Starts the platform feedback application.</summary>
internal class Program : MauiApplication
{
    /// <inheritdoc/>
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    /// <summary>Starts the platform application.</summary>
    /// <param name="args">The command-line arguments.</param>
    static void Main(string[] args)
    {
        var app = new Program();
        app.Run(args);
    }
}
