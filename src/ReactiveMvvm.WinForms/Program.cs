using System;
using System.Windows.Forms;
using ReactiveMvvm.Services;
using ReactiveMvvm.ViewModels;
using ReactiveMvvm.WinForms.Services;
using ReactiveMvvm.WinForms.Views;

namespace ReactiveMvvm.WinForms
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FeedbackView
            {
                ViewModel = new FeedbackViewModel(new WinFormsSender(), new Clock())
            });
        }
    }
}
