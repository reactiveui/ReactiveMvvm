using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
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
