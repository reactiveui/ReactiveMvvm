using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Disposables;
using ReactiveMvvm.Interfaces;
using PropertyChanged;
using ReactiveUI;
using Splat;

namespace ReactiveMvvm.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public sealed class FeedbackViewModel : IActivatableViewModel, IEnableLogger
    {
        public ReactiveCommand<Unit, Unit> Submit { get; }
        public ViewModelActivator Activator { get; }
        public bool HasErrors { get; private set; }
        public string Elapsed { get; private set; } = string.Empty;

        public string Title { get; set; } = string.Empty;
        public int TitleLength => Title.Length;
        public int TitleLengthMax => 15;

        public string Message { get; set; } = string.Empty;
        public int MessageLength => Message.Length;
        public int MessageLengthMax => 30;

        public int Section { get; set; }
        public bool Issue { get; set; }
        public bool Idea { get; set; }

        public FeedbackViewModel(ISender sender, IClock clock)
        {
            this.WhenAnyValue(x => x.Idea)
                .Where(selected => selected)
                .Subscribe(x => Issue = false);
            this.WhenAnyValue(x => x.Issue)
                .Where(selected => selected)
                .Subscribe(x => Idea = false);

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

            Activator = new ViewModelActivator();
            this.WhenActivated(disposables => 
            {
                clock.Tick.Select(second => $"{second}s")
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Subscribe(elapsed => Elapsed = elapsed)
                    .DisposeWith(disposables);
            });
        } 
    }
}
