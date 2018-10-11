using ReactiveMvvm.ViewModels;
using Windows.UI.Xaml.Controls;
using ReactiveMvvm.Uwp.Services;
using ReactiveUI;

namespace ReactiveMvvm.Uwp.Views
{
    public sealed partial class FeedbackView : Page, IViewFor<FeedbackViewModel>
    {
        public FeedbackView()
        {
            InitializeComponent();
            ViewModel = new FeedbackViewModel(new UwpSender());
            this.WhenActivated(disposables =>
            {
                // Handle interactions and complex scenarios...
            });
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
