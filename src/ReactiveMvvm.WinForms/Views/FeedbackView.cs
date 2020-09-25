using ReactiveMvvm.ViewModels;
using ReactiveMvvm.WinForms.Services;
using ReactiveMvvm.Services;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Forms;
using ReactiveUI;

namespace ReactiveMvvm.WinForms.Views
{
    public partial class FeedbackView : Form, IViewFor<FeedbackViewModel>
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
                    .BindTo(this, x => x.TitleLengthLabel.Text)
                    .DisposeWith(subscriptions);

                this.Bind(ViewModel, x => x.Message, x => x.MessageTextBox.Text)
                    .DisposeWith(subscriptions);
                this.OneWayBind(ViewModel, x => x.MessageLengthMax, x => x.MessageTextBox.MaxLength)
                    .DisposeWith(subscriptions);

                this.WhenAnyValue(x => x.ViewModel.MessageLength, x => x.ViewModel.MessageLengthMax)
                    .Select(values => $"{values.Item1} letters used from {values.Item2}")
                    .BindTo(this, x => x.MessageLengthLabel.Text)
                    .DisposeWith(subscriptions);

                this.Bind(ViewModel, x => x.Section, x => x.SectionComboBox.SelectedIndex)
                    .DisposeWith(subscriptions);

                this.Bind(ViewModel, x => x.Idea, x => x.IdeaCheckBox.Checked)
                    .DisposeWith(subscriptions);
                this.Bind(ViewModel, x => x.Issue, x => x.IssueCheckBox.Checked)
                    .DisposeWith(subscriptions);

                this.OneWayBind(ViewModel, x => x.HasErrors, x => x.HasErrorsTextBox.Visible)
                    .DisposeWith(subscriptions);
                this.BindCommand(ViewModel, x => x.Submit, x => x.SubmitButton)
                    .DisposeWith(subscriptions);

                this.OneWayBind(ViewModel, x => x.Elapsed, x => x.TimeElapsedLabel.Text, time => $"Elapsed: {time}")
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
