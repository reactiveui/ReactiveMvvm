using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using ReactiveMvvm.ViewModels;
using ReactiveUI;
using Terminal.Gui;
using ReactiveMarbles.ObservableEvents;

namespace ReactiveMvvm.Terminal.Views
{
    public sealed class FeedbackView : Window, IViewFor<FeedbackViewModel>, IDisposable
    {
        private readonly CompositeDisposable _subscriptions = [];
        
        public FeedbackView(FeedbackViewModel viewModel)
        {
            ViewModel = viewModel;
            ViewModel.Activator.Activate();
            this.StackPanel(TimeElapsedLabel())
                .Append(new Label() { Text = "Issue Title" })
                .Append(TitleDescription())
                .Append(TitleInput())
                .Append(new Label() { Text = "Issue Description" })
                .Append(MessageDescription())
                .Append(MessageInput())
                .Append(new Label() { Text = "Feedback Type" })
                .Append(IssueCheckBox())
                .Append(IdeaCheckBox())
                .Append(new Label() { Text = "Feedback Category" })
                .Append(SectionRadioGroup())
                .Append(new Button() { Text = "Send Feedback" }, 4);
        }

        private OptionSelector SectionRadioGroup()
        {
            var radioGroup = new OptionSelector() { Labels = ["User Interface", "Audio", "Video", "Voice"] };
ViewModel.WhenAnyValue(x => x.Section)
                .Select(section => (int?)section)
                .BindTo(radioGroup, x => x.Value)
                .DisposeWith(_subscriptions);

            var selected = new Subject<int>().DisposeWith(_subscriptions);
            radioGroup.ValueChanged += (sender, args) => selected.OnNext(args.NewValue ?? -1);
            selected.AsObservable()
                .BindTo(this, x => x.ViewModel.Section)
                .DisposeWith(_subscriptions);
            return radioGroup;
        }
        
        private CheckBox IssueCheckBox()
        {
            var item = new CheckBox() { Text = "Issue", Value = ViewModel.Issue ? CheckState.Checked : CheckState.UnChecked };
ViewModel.WhenAnyValue(x => x.Issue)
                .Select(issue => issue ? CheckState.Checked : CheckState.UnChecked)
                .BindTo(item, x => x.Value)
                .DisposeWith(_subscriptions);
            item.Events()
                .ValueChanged
                .Select(args => args.NewValue == CheckState.Checked)
                .Subscribe(issue => ViewModel.Issue = issue)
                .DisposeWith(_subscriptions);
ViewModel.WhenAnyValue(x => x.Idea)
                .Skip(1)
                .Subscribe(args => item.SetNeedsDraw())
                .DisposeWith(_subscriptions);
            return item;
        }

        private CheckBox IdeaCheckBox()
        {
            var item = new CheckBox() { Text = "Suggestion", Value = ViewModel.Idea ? CheckState.Checked : CheckState.UnChecked };
ViewModel.WhenAnyValue(x => x.Idea)
                .Select(issue => issue ? CheckState.Checked : CheckState.UnChecked)
                .BindTo(item, x => x.Value)
                .DisposeWith(_subscriptions);
            item.Events()
                .ValueChanged
                .Select(args => args.NewValue == CheckState.Checked)
                .Subscribe(idea => ViewModel.Idea = idea)
                .DisposeWith(_subscriptions);
ViewModel.WhenAnyValue(x => x.Issue)
                .Skip(1)
                .Subscribe(args => item.SetNeedsDraw())
                .DisposeWith(_subscriptions);
            return item;
        }

        private Label TimeElapsedLabel()
        {
            var label = new Label() { Text = "0 seconds passed" };
ViewModel.WhenAnyValue(x => x.Elapsed)
                .Select(elapsed => $"{elapsed} seconds passed")
                .BindTo(label, x => x.Text)
                .DisposeWith(_subscriptions);
            return label;
        }

        private TextField MessageInput()
        {
            var text = new TextField() { Text = ViewModel.Message, Width = 40 };
ViewModel.WhenAnyValue(x => x.Message)
                .BindTo(text, x => x.Text)
                .DisposeWith(_subscriptions);
            Observable.FromEventPattern(text, nameof(text.TextChanged))
                .Select(_ => text.Text)
                .DistinctUntilChanged()
                .Subscribe(message => ViewModel.Message = message)
                .DisposeWith(_subscriptions);
            return text;
        }

        private Label MessageDescription()
        {
            var label = new Label() { Text = $"0 letters used from {ViewModel.MessageLengthMax}" };
ViewModel.WhenAnyValue(x => x.MessageLength, x => x.MessageLengthMax)
                .Select(values => $"{values.Property1} letters used from {values.Property2}")
                .BindTo(label, x => x.Text)
                .DisposeWith(_subscriptions);
            return label;
        }
        
        private TextField TitleInput()
        {
            var text = new TextField() { Text = ViewModel.Title, Width = 40 };
ViewModel.WhenAnyValue(x => x.Title)
                .BindTo(text, x => x.Text)
                .DisposeWith(_subscriptions);
            Observable.FromEventPattern(text, nameof(text.TextChanged))
                .Select(_ => text.Text)
                .DistinctUntilChanged()
                .Subscribe(title => ViewModel.Title = title)
                .DisposeWith(_subscriptions);
            return text;
        }

        private Label TitleDescription()
        {
            var label = new Label() { Text = $"0 letters used from {ViewModel.TitleLengthMax}" };
ViewModel.WhenAnyValue(x => x.TitleLength, x => x.TitleLengthMax)
                .Select(values => $"{values.Property1} letters used from {values.Property2}")
                .BindTo(label, x => x.Text)
                .DisposeWith(_subscriptions);
            return label;
        }
        
        public FeedbackViewModel ViewModel { get; set; }
        
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                _subscriptions.Dispose();
                ViewModel.Activator.Deactivate();
            }
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (FeedbackViewModel) value;
        }
    }
}
