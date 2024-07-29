using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using ReactiveMvvm.ViewModels;
using ReactiveUI;
using Terminal.Gui;
using ReactiveMarbles.ObservableEvents;
using NStack;

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

        private RadioGroup SectionRadioGroup()
        {
            var radioGroup = new RadioGroup() { RadioLabels = ["User Interface", "Audio", "Video", "Voice"] };
            this.WhenAnyValue(x => x.ViewModel.Section)
                .BindTo(radioGroup, x => x.SelectedItem)
                .DisposeWith(_subscriptions);

            var selected = new Subject<int>().DisposeWith(_subscriptions);
            radioGroup.SelectedItemChanged += (sender, args) => selected.OnNext(args.SelectedItem);
            selected.AsObservable()
                .BindTo(this, x => x.ViewModel.Section)
                .DisposeWith(_subscriptions);
            return radioGroup;
        }
        
        private CheckBox IssueCheckBox()
        {
            var item = new CheckBox() { Text = "Issue", State = ViewModel.Issue ? CheckState.Checked : CheckState.UnChecked };
            this.WhenAnyValue(x => x.ViewModel.Issue)
                .Select(issue => issue ? CheckState.Checked : CheckState.UnChecked)
                .BindTo(item, x => x.State)
                .DisposeWith(_subscriptions);
            item.Events()
                .Toggle
                .Select(args => args.NewValue == CheckState.Checked)
                .BindTo(this, x => x.ViewModel.Issue)
                .DisposeWith(_subscriptions);
            this.WhenAnyValue(x => x.ViewModel.Idea)
                .Skip(1)
                .Subscribe(args => item.OnDrawContent(item.Frame))
                .DisposeWith(_subscriptions);
            return item;
        }

        private CheckBox IdeaCheckBox()
        {
            var item = new CheckBox() { Text = "Suggestion", State = ViewModel.Idea ? CheckState.Checked : CheckState.UnChecked };
            this.WhenAnyValue(x => x.ViewModel.Idea)
                .Select(issue => issue ? CheckState.Checked : CheckState.UnChecked)
                .BindTo(item, x => x.State)
                .DisposeWith(_subscriptions);
            item.Events()
                .Toggle
                .Select(args => args.NewValue == CheckState.Checked)
                .BindTo(this, x => x.ViewModel.Idea)
                .DisposeWith(_subscriptions);
            this.WhenAnyValue(x => x.ViewModel.Issue)
                .Skip(1)
                .Subscribe(args => item.OnDrawContent(item.Frame))
                .DisposeWith(_subscriptions);
            return item;
        }

        private Label TimeElapsedLabel()
        {
            var label = new Label() { Text = "0 seconds passed" };
            this.WhenAnyValue(x => x.ViewModel.Elapsed)
                .Select(elapsed => (ustring) $"{elapsed} seconds passed")
                .BindTo(label, x => x.Text)
                .DisposeWith(_subscriptions);
            return label;
        }

        private TextField MessageInput()
        {
            var text = new TextField() { Text = ViewModel.Message, Width = 40 };
            this.WhenAnyValue(x => x.ViewModel.Message)
                .BindTo(text, x => x.Text)
                .DisposeWith(_subscriptions);
            text.Events()
                .TextChanged
                .Select(older => text.Text)
                .DistinctUntilChanged()
                .BindTo(ViewModel, x => x.Message)
                .DisposeWith(_subscriptions);
            return text;
        }

        private Label MessageDescription()
        {
            var label = new Label() { Text = $"0 letters used from {ViewModel.MessageLengthMax}" };
            this.WhenAnyValue(x => x.ViewModel.MessageLength, x => x.ViewModel.MessageLengthMax)
                .Select(values => (ustring) $"{values.Item1} letters used from {values.Item2}")
                .BindTo(label, x => x.Text)
                .DisposeWith(_subscriptions);
            return label;
        }
        
        private TextField TitleInput()
        {
            var text = new TextField() { Text = ViewModel.Title, Width = 40 };
            this.WhenAnyValue(x => x.ViewModel.Title)
                .BindTo(text, x => x.Text)
                .DisposeWith(_subscriptions);
            text.Events()
                .TextChanged
                .Select(older => text.Text)
                .DistinctUntilChanged()
                .BindTo(ViewModel, x => x.Title)
                .DisposeWith(_subscriptions);
            return text;
        }

        private Label TitleDescription()
        {
            var label = new Label() { Text = $"0 letters used from {ViewModel.TitleLengthMax}" };
            this.WhenAnyValue(x => x.ViewModel.TitleLength, x => x.ViewModel.TitleLengthMax)
                .Select(values => (ustring) $"{values.Item1} letters used from {values.Item2}")
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