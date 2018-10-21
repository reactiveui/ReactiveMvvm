using Avalonia;
using Avalonia.Logging.Serilog;
using Avalonia.Markup.Xaml;
using ReactiveMvvm.Avalonia.Views;
using Serilog;

namespace ReactiveMvvm.Avalonia
{
    internal class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
            base.Initialize();
        }

        private static void Main(string[] args)
        {
            InitializeLogging();
            BuildAvaloniaApp().Start<FeedbackView>();
        }

        public static AppBuilder BuildAvaloniaApp() =>
            AppBuilder.Configure<App>()
                .UseReactiveUI()
                .UsePlatformDetect();

        private static void InitializeLogging()
        {
#if DEBUG
            SerilogLogger.Initialize(new LoggerConfiguration()
                .MinimumLevel.Warning()
                .WriteTo.Trace(outputTemplate: "{Area}: {Message}")
                .CreateLogger());
#endif
        }
    }
}
