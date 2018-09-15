using ReactiveMvvm.ViewModels;
using ReactiveMvvm.Xamarin.Services;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Xamarin.Forms;
using ReactiveUI;

namespace ReactiveMvvm.Xamarin.Views
{
    public partial class FeedbackView : ContentPage, IViewFor<FeedbackViewModel>
    {
        public FeedbackView()
	    {
	        InitializeComponent();
            BindingContext = new FeedbackViewModel(new XamarinSender(this));
            this.WhenActivated(subscriptions =>
            {
                this.Bind(ViewModel,
                    viewModel => viewModel.Title,
                    view => view.TitleEntry.Text)
                    .DisposeWith(subscriptions);

                ViewModel.WhenAnyValue(x => x.TitleLength, x => x.TitleLengthMax)
                    .Select(values => $"{values.Item1} letters used from {values.Item2}")
                    .BindTo(this, view => view.TitleLengthEntry.Text)
                    .DisposeWith(subscriptions);

                this.Bind(ViewModel,
                    viewModel => viewModel.Message,
                    view => view.MessageEntry.Text)
                    .DisposeWith(subscriptions);

                ViewModel.WhenAnyValue(x => x.MessageLength, x => x.MessageLengthMax)
                    .Select(values => $"{values.Item1} letters used from {values.Item2}")
                    .BindTo(this, view => view.MessageLengthEntry.Text)
                    .DisposeWith(subscriptions);

                this.Bind(ViewModel,
                    viewModel => viewModel.Section,
                    view => view.SectionPicker.SelectedIndex)
                    .DisposeWith(subscriptions);

                this.Bind(ViewModel,
                    viewModel => viewModel.Idea,
                    view => view.IdeaSwitch.IsToggled)
                    .DisposeWith(subscriptions);

                this.Bind(ViewModel,
                    viewModel => viewModel.Issue,
                    view => view.IssueSwitch.IsToggled)
                    .DisposeWith(subscriptions);

                this.OneWayBind(ViewModel,
                    viewModel => viewModel.HasErrors,
                    view => view.HasErrorsLabel.IsVisible)
                    .DisposeWith(subscriptions);

                this.BindCommand(ViewModel,
                    viewModel => viewModel.Submit,
                    view => view.SubmitButton)
                    .DisposeWith(subscriptions);
            });
        }

        public FeedbackViewModel ViewModel
        {
            get => (FeedbackViewModel)BindingContext;
            set => BindingContext = value;
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (FeedbackViewModel)value;
        }
    }
}
