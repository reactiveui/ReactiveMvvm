using ReactiveMvvm.Services;
using System.Windows;

namespace ReactiveMvvm.Wpf.Services
{
    public class WpfService : IService
    {
        public void Send(string title, string message) => MessageBox.Show(message, title);
    }
}
