// Copyright (c) 2019-2026 ReactiveUI and Contributors. All rights reserved.
// ReactiveUI and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReactiveUI.Reactive.Builder;

namespace ReactiveMvvm.Blazor.Server;

/// <summary>Configures the Blazor server's services and request pipeline.</summary>
public class Startup
{
    /// <summary>Registers Blazor and shared feedback services.</summary>
    /// <param name="services">The host service collection.</param>
    public void ConfigureServices(IServiceCollection services)
    {
        _ = RxAppBuilder.CreateReactiveUIBuilder().WithBlazor().BuildApp();
        _ = services.AddRazorPages();
        _ = services.AddServerSideBlazor();
        _ = services.AddAppServices();
    }

    /// <summary>Configures static files and the Blazor server endpoints.</summary>
    /// <param name="app">The application request pipeline.</param>
    /// <param name="env">The hosting environment.</param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            _ = app.UseDeveloperExceptionPage();
        }
        else
        {
            _ = app.UseExceptionHandler("/Error");
            _ = app.UseHsts();
        }

        _ = app.UseStaticFiles();
        _ = app.UseRouting();
        _ = app.UseEndpoints(static endpoints =>
        {
            _ = endpoints.MapBlazorHub();
            _ = endpoints.MapFallbackToPage("/Index");
        });
    }
}
