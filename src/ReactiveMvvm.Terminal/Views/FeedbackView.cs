using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using NStack;
using ReactiveMvvm.ViewModels;
using ReactiveUI;
using Terminal.Gui;

namespace ReactiveMvvm.Terminal.Views
{
    public sealed class FeedbackView : Window, IViewFor<FeedbackViewModel>, IDisposable
    {
        private readonly CompositeDisposable _subscriptions = new CompositeDisposable();
        
        public FeedbackView(FeedbackViewModel viewModel) : base(new Rect(0, 0, 30, 15), "Feedback Form")
        {
            ViewModel = viewModel;
            ViewModel.Activator.Activate();
            this.StackPanel(TimeElapsedLabel())
                .Append(new Label("Issue Title"))
                .Append(TitleDescription())
                .Append(TitleInput())
                .Append(new Label("Issue Description"))
                .Append(MessageDescription())
                .Append(MessageInput())
                .Append(new Label("Feedback Type"))
                .Append(IssueCheckBox())
                .Append(IdeaCheckBox())
                .Append(new Button("Send Feedback"));
        }

        private CheckBox IssueCheckBox()
        {
            var item = new CheckBox("Issue", ViewModel.Issue);
            this.WhenAnyValue(x => x.ViewModel.Issue)
                .BindTo(item, x => x.Checked)
                .DisposeWith(_subscriptions);
            item.Events()
                .Toggled
                .Select(args => item.Checked)
                .BindTo(this, x => x.ViewModel.Issue)
                .DisposeWith(_subscriptions);
            return item;
        }

        private CheckBox IdeaCheckBox()
        {
            var item = new CheckBox("Suggestion", ViewModel.Idea);
            this.WhenAnyValue(x => x.ViewModel.Idea)
                .BindTo(item, x => x.Checked)
                .DisposeWith(_subscriptions);
            item.Events()
                .Toggled
                .Select(old => item.Checked)
                .BindTo(this, x => x.ViewModel.Idea)
                .DisposeWith(_subscriptions);
            return item;
        }

        private Label TimeElapsedLabel()
        {
            var label = new Label("0 seconds passed");
            this.WhenAnyValue(x => x.ViewModel.Elapsed)
                .Select(elapsed => (ustring) $"{elapsed} seconds passed")
                .BindTo(label, x => x.Text)
                .DisposeWith(_subscriptions);
            return label;
        }

        private TextField MessageInput()
        {
            var text = new TextField(ViewModel.Message);
            this.WhenAnyValue(x => x.ViewModel.Message)
                .BindTo(text, x => x.Text)
                .DisposeWith(_subscriptions);
            text.Events()
                .Changed
                .Select(older => text.Text)
                .DistinctUntilChanged()
                .BindTo(ViewModel, x => x.Message)
                .DisposeWith(_subscriptions);
            return text;
        }

        private Label MessageDescription()
        {
            var label = new Label($"0 letters used from {ViewModel.MessageLengthMax}");
            this.WhenAnyValue(x => x.ViewModel.MessageLength, x => x.ViewModel.MessageLengthMax)
                .Select(values => (ustring) $"{values.Item1} letters used from {values.Item2}")
                .BindTo(label, x => x.Text)
                .DisposeWith(_subscriptions);
            return label;
        }
        
        private TextField TitleInput()
        {
            var text = new TextField(ViewModel.Title);
            this.WhenAnyValue(x => x.ViewModel.Title)
                .BindTo(text, x => x.Text)
                .DisposeWith(_subscriptions);
            text.Events()
                .Changed
                .Select(older => text.Text)
                .DistinctUntilChanged()
                .BindTo(ViewModel, x => x.Title)
                .DisposeWith(_subscriptions);
            return text;
        }

        private Label TitleDescription()
        {
            var label = new Label($"0 letters used from {ViewModel.TitleLengthMax}");
            this.WhenAnyValue(x => x.ViewModel.TitleLength, x => x.ViewModel.TitleLengthMax)
                .Select(values => (ustring) $"{values.Item1} letters used from {values.Item2}")
                .BindTo(label, x => x.Text)
                .DisposeWith(_subscriptions);
            return label;
        }
        
        public FeedbackViewModel ViewModel { get; set; }
        
        public void Dispose() => _subscriptions.Dispose();

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (FeedbackViewModel) value;
        }
    }
}