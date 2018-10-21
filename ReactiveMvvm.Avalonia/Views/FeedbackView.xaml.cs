using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ReactiveMvvm.ViewModels;
using ReactiveUI;

namespace ReactiveMvvm.Avalonia.Views
{
    public class FeedbackView : Window, IViewFor<FeedbackViewModel>
    {
        public static readonly AvaloniaProperty<FeedbackViewModel> ViewModelProperty =
            AvaloniaProperty.Register<FeedbackView, FeedbackViewModel>(nameof(ViewModel));

        public FeedbackView()
        {
            DataContextChanged += (sender, args) => ViewModel = DataContext as FeedbackViewModel;
            this.WhenActivated(disposables =>
            {
                // Handle interactions and complex scenarios...
            });

            AvaloniaXamlLoader.Load(this);
        }

        public FeedbackViewModel ViewModel
        {
            get => GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (FeedbackViewModel)value;
        }
    }
}
