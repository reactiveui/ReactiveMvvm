// Copyright (c) 2019-2026 ReactiveUI and Contributors. All rights reserved.
// ReactiveUI and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ReactiveMvvm.Blazor;
using ReactiveMvvm.Blazor.Wasm;
using ReactiveUI.Reactive.Builder;

_ = RxAppBuilder.CreateReactiveUIBuilder().WithBlazorWasm().BuildApp();

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");

builder.RootComponents.Add<HeadOutlet>("head::after");

_ = builder.Services
    .AddScoped(sp => new HttpClient { BaseAddress = new(builder.HostEnvironment.BaseAddress) })
    .AddAppServices();

await builder.Build().RunAsync();
