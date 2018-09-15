using ReactiveMvvm.ViewModels;
using Windows.UI.Xaml.Controls;
using ReactiveMvvm.Uwp.Services;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveUI;

namespace ReactiveMvvm.Uwp.Views
{
    public sealed partial class FeedbackView : Page, IViewFor<FeedbackViewModel>
    {
        public FeedbackView()
        {
            InitializeComponent();
            DataContext = new FeedbackViewModel(new UwpSender());
            this.WhenActivated(subscriptions => 
            {
                this.Bind(ViewModel,
                    viewModel => viewModel.Title,
                    view => view.TitleTextBox.Text)
                    .DisposeWith(subscriptions);

                this.OneWayBind(ViewModel,
                    viewModel => viewModel.TitleLengthMax,
                    view => view.TitleTextBox.MaxLength)
                    .DisposeWith(subscriptions);

                ViewModel.WhenAnyValue(x => x.TitleLength, x => x.TitleLengthMax)
                    .Select(values => $"{values.Item1} letters used from {values.Item2}")
                    .BindTo(this, view => view.TitleLengthTextBox.Text)
                    .DisposeWith(subscriptions);

                this.Bind(ViewModel,
                    viewModel => viewModel.Message,
                    view => view.MessageTextBox.Text)
                    .DisposeWith(subscriptions);

                this.OneWayBind(ViewModel,
                    viewModel => viewModel.MessageLengthMax,
                    view => view.MessageTextBox.MaxLength)
                    .DisposeWith(subscriptions);

                ViewModel.WhenAnyValue(x => x.MessageLength, x => x.MessageLengthMax)
                    .Select(values => $"{values.Item1} letters used from {values.Item2}")
                    .BindTo(this, view => view.MessageLengthTextBox.Text)
                    .DisposeWith(subscriptions);

                this.Bind(ViewModel,
                    viewModel => viewModel.Section,
                    view => view.SectionComboBox.SelectedIndex)
                    .DisposeWith(subscriptions);

                this.Bind(ViewModel,
                    viewModel => viewModel.Idea,
                    view => view.IdeaCheckBox.IsChecked)
                    .DisposeWith(subscriptions);

                this.Bind(ViewModel,
                    viewModel => viewModel.Issue,
                    view => view.IssueCheckBox.IsChecked)
                    .DisposeWith(subscriptions);

                this.OneWayBind(ViewModel,
                    viewModel => viewModel.HasErrors,
                    view => view.HasErrorsTextBox.Visibility)
                    .DisposeWith(subscriptions);

                this.BindCommand(ViewModel,
                    viewModel => viewModel.Submit,
                    view => view.SubmitButton)
                    .DisposeWith(subscriptions);
            });
        }

        public FeedbackViewModel ViewModel
        {
            get => (FeedbackViewModel)DataContext;
            set => DataContext = value;
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (FeedbackViewModel)value;
        }
    }
}
