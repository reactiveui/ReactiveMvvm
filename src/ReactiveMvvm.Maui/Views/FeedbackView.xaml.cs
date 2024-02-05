using ReactiveMvvm.ViewModels;
using ReactiveMvvm.Services;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.Maui;
using ReactiveMvvm.Maui.Services;

namespace ReactiveMvvm.Maui.Views
{
    public partial class FeedbackView : ReactiveContentPage<FeedbackViewModel>
    {
        public FeedbackView()
        {
            InitializeComponent();
            ViewModel = new FeedbackViewModel(new XamarinSender(this), new Clock());
            this.WhenActivated(subscriptions =>
            {
                this.Bind(ViewModel, x => x.Title, x => x.TitleEntry.Text)
                    .DisposeWith(subscriptions);
                this.OneWayBind(ViewModel, x => x.TitleLengthMax, x => x.TitleEntry.MaxLength)
                    .DisposeWith(subscriptions);

                this.WhenAnyValue(x => x.ViewModel.TitleLength, x => x.ViewModel.TitleLengthMax)
                    .Select(values => $"{values.Item1} letters used from {values.Item2}")
                    .BindTo(this, x => x.TitleLengthEntry.Text)
                    .DisposeWith(subscriptions);

                this.Bind(ViewModel, x => x.Message, x => x.MessageEntry.Text)
                    .DisposeWith(subscriptions);
                this.OneWayBind(ViewModel, x => x.MessageLengthMax, x => x.MessageEntry.MaxLength)
                    .DisposeWith(subscriptions);

                this.WhenAnyValue(x => x.ViewModel.MessageLength, x => x.ViewModel.MessageLengthMax)
                    .Select(values => $"{values.Item1} letters used from {values.Item2}")
                    .BindTo(this, x => x.MessageLengthEntry.Text)
                    .DisposeWith(subscriptions);

                this.Bind(ViewModel, x => x.Section, x => x.SectionPicker.SelectedIndex)
                    .DisposeWith(subscriptions);

                this.Bind(ViewModel, x => x.Idea, x => x.IdeaSwitch.IsToggled)
                    .DisposeWith(subscriptions);
                this.Bind(ViewModel, x => x.Issue, x => x.IssueSwitch.IsToggled)
                    .DisposeWith(subscriptions);

                this.OneWayBind(ViewModel, x => x.HasErrors, x => x.HasErrorsLabel.IsVisible)
                    .DisposeWith(subscriptions);
                this.BindCommand(ViewModel, x => x.Submit, x => x.SubmitButton)
                    .DisposeWith(subscriptions);

                this.OneWayBind(ViewModel, x => x.Elapsed, x => x.TimeElapsedLabel.Text, time => $"Time elapsed: {time}")
                    .DisposeWith(subscriptions);
            });
        }
    }
}
