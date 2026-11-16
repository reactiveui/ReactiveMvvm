// Copyright (c) 2019-2026 ReactiveUI and Contributors. All rights reserved.
// ReactiveUI and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using ReactiveMvvm.Blazor.Services;
using ReactiveMvvm.Interfaces;
using ReactiveMvvm.Services;
using ReactiveMvvm.ViewModels;

namespace ReactiveMvvm.Blazor;

/// <summary>Registers shared feedback services for the Blazor hosts.</summary>
public static class AppExtensions
{
    /// <summary>Registers feedback services with a Blazor host.</summary>
    /// <param name="services">The host service collection.</param>
    extension(IServiceCollection services)
    {
        /// <summary>Registers the clock, sender and feedback view model.</summary>
        /// <returns>The service collection.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IServiceCollection AddAppServices() => services.AddSingleton<IClock, Clock>().AddSingleton<ISender, LoggingSender>()
            .AddSingleton<FeedbackViewModel>();
    }
}
