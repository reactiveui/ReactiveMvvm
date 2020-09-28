using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ReactiveMvvm.Blazor.Services;
using ReactiveMvvm.Blazor.Views;
using ReactiveMvvm.Interfaces;
using ReactiveMvvm.Services;
using ReactiveMvvm.ViewModels;

namespace ReactiveMvvm.Blazor
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<IClock, Clock>();
            services.AddSingleton<ISender, LoggingSender>();
            services.AddSingleton<FeedbackViewModel>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/Index");
            });
        }
    }
}
