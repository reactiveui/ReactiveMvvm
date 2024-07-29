using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Disposables;
using ReactiveMvvm.Interfaces;
using ReactiveUI.SourceGenerators;
using ReactiveUI;

namespace ReactiveMvvm.ViewModels
{
    public partial class FeedbackViewModel : ReactiveObject, IActivatableViewModel
    {
        [Reactive] 
        private bool _hasErrors;
        [Reactive] 
        private string _elapsed = string.Empty;
        [Reactive] 
        private string _title = string.Empty;
        [Reactive] 
        private int _titleLength;
        [Reactive] 
        private string _message = string.Empty;
        [Reactive] 
        private int _messageLength;
        [Reactive] 
        private int _section;
        [Reactive] 
        private bool _issue = true;
        [Reactive] 
        private bool _idea;

        public ViewModelActivator Activator { get; } = new ViewModelActivator();
        public ReactiveCommand<Unit, Unit> Submit { get; }

        public int TitleLengthMax { get; } = 15;

        public int MessageLengthMax { get; } = 30;
        
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
