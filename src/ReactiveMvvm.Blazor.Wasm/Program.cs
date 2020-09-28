using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace ReactiveMvvm.Blazor.Wasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = WebAssemblyHostBuilder.CreateDefault(args);
            host.RootComponents.Add<App>("app");
            host.Services.AddAppServices();
            await host.Build().RunAsync();
        }
    }
}
