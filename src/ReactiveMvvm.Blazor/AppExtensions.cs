using Microsoft.Extensions.DependencyInjection;
using ReactiveMvvm.Blazor.Services;
using ReactiveMvvm.Interfaces;
using ReactiveMvvm.Services;
using ReactiveMvvm.ViewModels;

namespace ReactiveMvvm.Blazor
{
    public static class AppExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services) => 
            services.AddSingleton<IClock, Clock>()
                .AddSingleton<ISender, LoggingSender>()
                .AddSingleton<FeedbackViewModel>();
    }
}