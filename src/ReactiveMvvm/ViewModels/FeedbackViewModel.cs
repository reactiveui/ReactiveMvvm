using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Disposables;
using ReactiveMvvm.Interfaces;
using ReactiveUI.Fody.Helpers;
using ReactiveUI;

namespace ReactiveMvvm.ViewModels
{
    public sealed class FeedbackViewModel : ReactiveObject, IActivatableViewModel
    {
        public ViewModelActivator Activator { get; } = new ViewModelActivator();
        public ReactiveCommand<Unit, Unit> Submit { get; }
        
        [Reactive] public bool HasErrors { get; private set; }
        [Reactive] public string Elapsed { get; private set; } = string.Empty;

        [Reactive] public string Title { get; set; } = string.Empty;
        [Reactive] public int TitleLength { get; private set; }
        public int TitleLengthMax { get; } = 15;

        [Reactive] public string Message { get; set; } = string.Empty;
        [Reactive] public int MessageLength { get; private set; }
        public int MessageLengthMax { get; } = 30;

        [Reactive] public int Section { get; set; }
        [Reactive] public bool Issue { get; set; } = true;
        [Reactive] public bool Idea { get; set; }
        
        public FeedbackViewModel(ISender sender, IClock clock)
        {
            this.WhenAnyValue(x => x.Idea)
                .Select(selected => !selected)
                .Subscribe(value => Issue = value);
            this.WhenAnyValue(x => x.Issue)
                .Select(selected => !selected)
                .Subscribe(value => Idea = value);

            this.WhenAnyValue(x => x.Title)
                .Select(title => title.Length)
                .Subscribe(length => TitleLength = length);
            this.WhenAnyValue(x => x.Message)
                .Select(message => message.Length)
                .Subscribe(length => MessageLength = length);

            var valid = this
                .WhenAnyValue(
                    x => x.Title, x => x.Message,
                    x => x.Issue, x => x.Idea,
                    x => x.Section, 
                    (title, message, issue, idea, section) =>
                        !string.IsNullOrWhiteSpace(message) &&
                        !string.IsNullOrWhiteSpace(title) &&
                        (idea || issue) && section >= 0)
                .Log(this, "Form validity changed")
                .Publish()
                .RefCount();

            valid.Subscribe(hasErrors => HasErrors = !hasErrors);
            Submit = ReactiveCommand.CreateFromTask(
                () => sender.Send(Title, Message, Section, Issue), 
                valid);

            this.WhenActivated(disposables => 
                clock.Tick.Select(second => $"{second}s")
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Subscribe(elapsed => Elapsed = elapsed)
                    .DisposeWith(disposables));
        }
    }
}
