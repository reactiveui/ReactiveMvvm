using ReactiveMvvm.ViewModels;
using ReactiveMvvm.WinForms.Services;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows.Forms;
using ReactiveUI;

namespace ReactiveMvvm.WinForms
{
    public partial class FeedbackView : Form, IViewFor<FeedbackViewModel>
    {
        public FeedbackView()
        {
            InitializeComponent();
            SectionComboBox.Items.Add("User Interface");
            SectionComboBox.Items.Add("Audio");
            SectionComboBox.Items.Add("Video");

            ViewModel = new FeedbackViewModel(new WinFormsSender());
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
                    .BindTo(this, view => view.TitleLengthLabel.Text)
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
                    .BindTo(this, view => view.MessageLengthLabel.Text)
                    .DisposeWith(subscriptions);

                this.Bind(ViewModel,
                    viewModel => viewModel.Section,
                    view => view.SectionComboBox.SelectedIndex)
                    .DisposeWith(subscriptions);

                this.Bind(ViewModel,
                    viewModel => viewModel.Idea,
                    view => view.IdeaCheckBox.Checked)
                    .DisposeWith(subscriptions);

                this.Bind(ViewModel,
                    viewModel => viewModel.Issue,
                    view => view.IssueCheckBox.Checked)
                    .DisposeWith(subscriptions);

                this.OneWayBind(ViewModel,
                    viewModel => viewModel.HasErrors,
                    view => view.HasErrorsTextBox.Visible)
                    .DisposeWith(subscriptions);

                this.BindCommand(ViewModel,
                    viewModel => viewModel.Submit,
                    view => view.SubmitButton)
                    .DisposeWith(subscriptions);
            });
        }

        public FeedbackViewModel ViewModel { get; set; }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (FeedbackViewModel)value;
        }
    }
}
