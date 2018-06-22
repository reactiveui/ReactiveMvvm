// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global

using System;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveMvvm.Services;
using PropertyChanged;
using ReactiveUI;

namespace ReactiveMvvm.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public sealed class FeedbackViewModel
    {
        public ReactiveCommand<Unit, Unit> Submit { get; }
        public bool HasErrors { get; private set; }

        public string Title { get; set; } = string.Empty;
        public int TitleLength => Title.Length;
        public int TitleLengthMax => 15;

        public string Message { get; set; } = string.Empty;
        public int MessageLength => Message.Length;
        public int MessageLengthMax => 30;

        public int Section { get; set; }
        public bool Issue { get; set; }
        public bool Idea { get; set; }

        public FeedbackViewModel(IService service)
        {
            this.WhenAnyValue(x => x.Idea)
                .Where(selected => selected)
                .Subscribe(x => Issue = false);
            this.WhenAnyValue(x => x.Issue)
                .Where(selected => selected)
                .Subscribe(x => Idea = false);

            var valid = this.WhenAnyValue(
                x => x.Title, x => x.Message,
                x => x.Issue, x => x.Idea,
                x => x.Section, 
                (title, message, issue, idea, section) =>
                    !string.IsNullOrWhiteSpace(message) &&
                    !string.IsNullOrWhiteSpace(title) &&
                    (idea || issue) && section >= 0);

            valid.Subscribe(x => HasErrors = !x);
            Submit = ReactiveCommand.Create(
                () => service.Send(Title, Message), valid);
        } 
    }
}
