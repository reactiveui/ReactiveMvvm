using ReactiveMvvm.ViewModels;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveUI;

namespace ReactiveMvvm.Wpf.Views
{
    public partial class FeedbackView : ReactiveWindow<FeedbackViewModel>
    {
        public FeedbackView()
        {
            InitializeComponent();
            this.WhenActivated(subscriptions =>
            {
                this.Bind(ViewModel, x => x.Title, x => x.TitleTextBox.Text)
                    .DisposeWith(subscriptions);
                this.OneWayBind(ViewModel, x => x.TitleLengthMax, x => x.TitleTextBox.MaxLength)
                    .DisposeWith(subscriptions);

                this.WhenAnyValue(x => x.ViewModel.TitleLength, x => x.ViewModel.TitleLengthMax)
                    .Select(values => $"{values.Item1} letters used from {values.Item2}")
                    .BindTo(this, x => x.TitleLengthTextBox.Text)
                    .DisposeWith(subscriptions);

                this.Bind(ViewModel, x => x.Message, x => x.MessageTextBox.Text)
                    .DisposeWith(subscriptions);
                this.OneWayBind(ViewModel, x => x.MessageLengthMax, x => x.MessageTextBox.MaxLength)
                    .DisposeWith(subscriptions);

                this.WhenAnyValue(x => x.ViewModel.MessageLength, x => x.ViewModel.MessageLengthMax)
                    .Select(values => $"{values.Item1} letters used from {values.Item2}")
                    .BindTo(this, x => x.MessageLengthTextBox.Text)
                    .DisposeWith(subscriptions);

                this.Bind(ViewModel, x => x.Section, x => x.SectionComboBox.SelectedIndex)
                    .DisposeWith(subscriptions);

                this.Bind(ViewModel, x => x.Idea, x => x.IdeaCheckBox.IsChecked)
                    .DisposeWith(subscriptions);
                this.Bind(ViewModel, x => x.Issue, x => x.IssueCheckBox.IsChecked)
                    .DisposeWith(subscriptions);

                this.OneWayBind(ViewModel, x => x.HasErrors, x => x.HasErrorsTextBox.Visibility)
                    .DisposeWith(subscriptions);
                this.BindCommand(ViewModel, x => x.Submit, x => x.SubmitButton)
                    .DisposeWith(subscriptions);

                this.OneWayBind(ViewModel, x => x.Elapsed, x => x.TimeTextBlock.Text, time => $"Time elapsed: {time}")
                    .DisposeWith(subscriptions);
            });
        }
    }
}
