using ReactiveMvvm.Services;
using Windows.UI.Popups;
using System;

namespace ReactiveMvvm.Uwp.Services
{
    public sealed class UwpService : IService
    {
        public async void Send(string h, string m) => await new MessageDialog(h, m).ShowAsync();
    }
}
