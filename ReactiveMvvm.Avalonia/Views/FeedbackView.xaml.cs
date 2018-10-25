using Avalonia;
using Avalonia.Markup.Xaml;
using ReactiveMvvm.ViewModels;
using ReactiveUI;

namespace ReactiveMvvm.Avalonia.Views
{
    public sealed class FeedbackView : ReactiveWindow<FeedbackViewModel>
    {
        public FeedbackView()
        {
            this.WhenActivated(disposables => { /* Handle Interactions etc. */ });
            AvaloniaXamlLoader.Load(this);
        }
    }
}
