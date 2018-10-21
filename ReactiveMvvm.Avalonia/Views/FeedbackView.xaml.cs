using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ReactiveMvvm.Avalonia.Services;
using ReactiveMvvm.Services;
using ReactiveMvvm.ViewModels;
using ReactiveUI;

namespace ReactiveMvvm.Avalonia.Views
{
    public class FeedbackView : Window, IViewFor<FeedbackViewModel>
    {
        public FeedbackView()
        {
            ViewModel = new FeedbackViewModel(new AvaloniaSender(), new Clock());
            this.WhenActivated(disposables =>
            {
                // Handle interactions and complex scenarios...
            });

            AvaloniaXamlLoader.Load(this);
        }

        public FeedbackViewModel ViewModel
        {
            get => (FeedbackViewModel)DataContext;
            set => DataContext = value;
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (FeedbackViewModel)value;
        }
    }
}
