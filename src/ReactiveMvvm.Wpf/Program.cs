// Copyright (c) 2019-2026 ReactiveUI and Contributors. All rights reserved.
// ReactiveUI and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Runtime.CompilerServices;

namespace ReactiveMvvm.Wpf;

/// <summary>Starts the platform feedback application.</summary>
public static class Program
{
    /// <summary>Starts the platform application.</summary>
    /// <param name="args">The command-line arguments.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [STAThread]
    public static void Main(string[] args) => new App().Run();
}
