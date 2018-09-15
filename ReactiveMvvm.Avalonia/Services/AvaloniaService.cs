using System.Threading.Tasks;
using ReactiveMvvm.Services;

namespace ReactiveMvvm.Avalonia.Services
{
    public sealed class AvaloniaSender : ISender
    {
        public Task Send(string title, string message, int section, bool bug)
        {
            // Silently ignore...
            return Task.CompletedTask;
        }
    }
}
