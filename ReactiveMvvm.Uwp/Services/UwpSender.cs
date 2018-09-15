using ReactiveMvvm.Services;
using Windows.UI.Popups;
using System.Threading.Tasks;
using System;

namespace ReactiveMvvm.Uwp.Services
{
    public sealed class UwpSender : ISender
    {
        public async Task Send(string title, string message, int section, bool bug)
        {
            var content = $"{message}, Bug: {bug}, Section: {section}";
            await new MessageDialog(content, title).ShowAsync();
        }
    }
}
