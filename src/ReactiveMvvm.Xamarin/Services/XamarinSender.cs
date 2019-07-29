using ReactiveMvvm.Interfaces;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ReactiveMvvm.Xamarin.Services
{
    public sealed class XamarinSender : ISender
    {
        private readonly Page view;

        public XamarinSender(Page view) => this.view = view;

        public async Task Send(string title, string message, int section, bool bug)
        {
            var content = $"{message}, Bug: {bug}, Section: {section}";
            await view.DisplayAlert(title, content, "Ok");
        }
    }
}
