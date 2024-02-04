using Avalonia;
using Avalonia.ReactiveUI;

namespace ReactiveMvvm.Avalonia
{
    public sealed class Program
    {
        public static void Main(string[] args) => BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);

        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UseReactiveUI()
                .UsePlatformDetect();
    }
}
