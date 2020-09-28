using Microsoft.AspNetCore.Components;
using ReactiveMvvm.ViewModels;
using ReactiveUI;
using ReactiveUI.Blazor;

namespace ReactiveMvvm.Blazor.Views
{
    public partial class FeedbackView : ReactiveComponentBase<FeedbackViewModel>
    {
        public FeedbackView() => this.WhenActivated(disposables => { });

        [Inject]
        public FeedbackViewModel FeedbackViewModel
        {
            get => ViewModel;
            set => ViewModel = value;
        }
    }
}