using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ReactiveMvvm.Avalonia.Services;
using ReactiveMvvm.ViewModels;

namespace ReactiveMvvm.Avalonia.Views
{
    public class FeedbackView : Window
    {
        public FeedbackView()
        {
            AvaloniaXamlLoaderPortableXaml.Load(this);
            DataContext = new FeedbackViewModel(new AvaloniaService());
            this.AttachDevTools();
        }
    }
}
