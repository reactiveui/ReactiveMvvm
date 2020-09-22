using System.Threading.Tasks;
using ReactiveMvvm.Interfaces;

namespace ReactiveMvvm.Terminal.Services
{
    public sealed class TerminalSender : ISender
    {
        public Task Send(string title, string message, int section, bool bug) => Task.CompletedTask;
    }
}
