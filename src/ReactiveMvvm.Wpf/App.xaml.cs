using System.Windows;
using ReactiveMvvm.Services;
using ReactiveMvvm.ViewModels;
using ReactiveMvvm.Wpf.Services;
using ReactiveMvvm.Wpf.Views;

namespace ReactiveMvvm.Wpf
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var viewModel = new FeedbackViewModel(new WpfSender(), new Clock());
            var view = new FeedbackView { ViewModel = viewModel };
            view.Show();
            base.OnStartup(e);
        }
    }
}
