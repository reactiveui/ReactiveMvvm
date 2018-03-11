using ReactiveMvvm.ViewModels;
using Windows.UI.Xaml.Controls;
using ReactiveMvvm.Uwp.Services;

namespace ReactiveMvvm.Uwp.Views
{
    public sealed partial class FeedbackView : Page
    {
        public FeedbackView()
        {
            InitializeComponent();
            DataContext = new FeedbackViewModel(new UwpService());
        }
    }

}
