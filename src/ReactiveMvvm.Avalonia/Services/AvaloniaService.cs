using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Dialogs;
using Avalonia.Media;
using ReactiveMvvm.Interfaces;

namespace ReactiveMvvm.Avalonia.Services
{
    public sealed class AvaloniaSender : ISender
    {
        private readonly Window _window;

        public AvaloniaSender(Window window) => _window = window;

        public async Task Send(string title, string message, int section, bool bug)
        {
            var classification = bug ? "issue" : "idea";
            var dialog = new Window
            {
                Width = 200,
                Height = 200,
                Content = new StackPanel
                {
                    Margin = new Thickness(10),
                    Children =
                    {
                        new TextBlock
                        {
                            Text = $"[{classification}] {title}: {message}",
                            TextWrapping = TextWrapping.Wrap
                        }
                    }
                }
            };
            await dialog.ShowDialog(_window);
        }
    }
}
