using ReactiveMvvm.ViewModels;
using ReactiveMvvm.Wpf.Services;
using System.Windows;

namespace ReactiveMvvm.Wpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new FeedbackViewModel(new WpfService());
        }
    }

}
