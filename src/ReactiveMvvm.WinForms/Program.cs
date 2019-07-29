using System;
using System.Windows.Forms;
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
            Application.Run(new FeedbackView());
        }
    }
}
