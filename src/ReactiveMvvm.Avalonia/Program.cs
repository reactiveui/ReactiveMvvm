// Copyright (c) 2019-2026 ReactiveUI and Contributors. All rights reserved.
// ReactiveUI and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Runtime.CompilerServices;
using Avalonia;
using ReactiveUI.Avalonia.Reactive;

namespace ReactiveMvvm.Avalonia;

/// <summary>Starts the platform feedback application.</summary>
public static class Program
{
    /// <summary>Starts the platform application.</summary>
    /// <param name="args">The command-line arguments.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Main(string[] args) => BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);

    /// <summary>Configures Avalonia with ReactiveUI and the current desktop platform.</summary>
    /// <returns>The configured application.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static AppBuilder BuildAvaloniaApp() => AppBuilder.Configure<App>().UseReactiveUI(static _ => { }).UsePlatformDetect();
}
