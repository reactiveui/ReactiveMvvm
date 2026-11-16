// Copyright (c) 2019-2026 ReactiveUI and Contributors. All rights reserved.
// ReactiveUI and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using Android.App;
using Android.Runtime;

namespace ReactiveMvvm.Maui;

/// <summary>Creates the MAUI application for the Android runtime.</summary>
[Application]
public class MainApplication : MauiApplication
{
    /// <summary>Initializes a new instance of the MainApplication class.</summary>
    /// <param name="handle">The native application handle supplied by Android.</param>
    /// <param name="ownership">The runtime's handle ownership policy.</param>
    public MainApplication(IntPtr handle, JniHandleOwnership ownership)
        : base(handle, ownership)
    {
    }

    /// <inheritdoc/>
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
