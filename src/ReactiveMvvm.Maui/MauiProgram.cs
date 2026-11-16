// Copyright (c) 2019-2026 ReactiveUI and Contributors. All rights reserved.
// ReactiveUI and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using Microsoft.Extensions.Logging;
using ReactiveUI.Reactive.Builder;

namespace ReactiveMvvm.Maui;

/// <summary>Configures the MAUI application's services and resources.</summary>
public static class MauiProgram
{
    /// <summary>Builds the MAUI application and its resources.</summary>
    /// <returns>The configured application.</returns>
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        _ = builder.UseMauiApp<App>().UseReactiveUI(static _ => { }).ConfigureFonts(static fonts =>
        {
            _ = fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular")
                .AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        });
#if DEBUG
        _ = builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}
