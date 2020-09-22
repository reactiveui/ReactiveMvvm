﻿using Avalonia;
using Avalonia.Logging.Serilog;
using Avalonia.Markup.Xaml;
using ReactiveMvvm.Avalonia.Services;
using ReactiveMvvm.Avalonia.Views;
using ReactiveMvvm.Services;
using ReactiveMvvm.ViewModels;
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

        public override void OnFrameworkInitializationCompleted()
        {
#if DEBUG
            SerilogLogger.Initialize(new LoggerConfiguration()
                .MinimumLevel.Warning()
                .WriteTo.Trace(outputTemplate: "{Area}: {Message}")
                .CreateLogger());
#endif
            var view = new FeedbackView();
            var context = new FeedbackViewModel(
                new AvaloniaSender(view),
                new Clock());

            view.DataContext = context;
            view.Show();

            base.OnFrameworkInitializationCompleted();
        }
    }
}
