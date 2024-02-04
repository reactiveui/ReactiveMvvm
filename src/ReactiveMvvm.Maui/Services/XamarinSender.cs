using ReactiveMvvm.Interfaces;

namespace ReactiveMvvm.Maui.Services
{
    public sealed class XamarinSender(Page view) : ISender
    {
        public async Task Send(string title, string message, int section, bool bug)
        {
            var content = $"{message}, Bug: {bug}, Section: {section}";
            await view.DisplayAlert(title, content, "Ok");
        }
    }
}
