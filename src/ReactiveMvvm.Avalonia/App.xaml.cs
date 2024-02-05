using Avalonia;
using Avalonia.Logging;
using Avalonia.Markup.Xaml;
using ReactiveMvvm.Avalonia.Services;
using ReactiveMvvm.Avalonia.Views;
using ReactiveMvvm.Services;
using ReactiveMvvm.ViewModels;

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
