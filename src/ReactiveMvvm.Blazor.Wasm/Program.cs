using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ReactiveMvvm.Blazor.Wasm.Services;
using ReactiveMvvm.Interfaces;
using ReactiveMvvm.Services;
using ReactiveMvvm.ViewModels;

namespace ReactiveMvvm.Blazor.Wasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = WebAssemblyHostBuilder.CreateDefault(args);
            host.RootComponents.Add<App>("app");
            host.Services
                .AddSingleton<IClock, Clock>()
                .AddSingleton<ISender, LoggingSender>()
                .AddSingleton<FeedbackViewModel>();
            await host.Build().RunAsync();
        }
    }
}
