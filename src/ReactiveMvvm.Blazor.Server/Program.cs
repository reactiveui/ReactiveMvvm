// Copyright (c) 2019-2026 ReactiveUI and Contributors. All rights reserved.
// ReactiveUI and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ReactiveMvvm.Blazor.Server;

/// <summary>Starts the platform feedback application.</summary>
public static class Program
{
    /// <summary>Starts the platform application.</summary>
    /// <param name="args">The command-line arguments.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Main(string[] args) => Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(static web => web.UseStartup<Startup>())
        .Build()
        .Run();
}
