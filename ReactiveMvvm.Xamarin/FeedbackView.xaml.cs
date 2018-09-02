using ReactiveMvvm.Services;
using ReactiveMvvm.ViewModels;
using Xamarin.Forms;

namespace ReactiveMvvm.Xamarin
{
    public partial class FeedbackView : ContentPage, IService
    {
        public FeedbackView()
	{
	    InitializeComponent();
            BindingContext = new FeedbackViewModel(this);
	}

        public void Send(string title, string message) => DisplayAlert(title, message, "Ok");
    }
}
