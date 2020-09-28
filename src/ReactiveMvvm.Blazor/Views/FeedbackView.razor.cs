using Microsoft.AspNetCore.Components;
using ReactiveMvvm.ViewModels;
using ReactiveUI;

namespace ReactiveMvvm.Blazor.Views
{
    public partial class FeedbackView
    {
        public FeedbackView() => this.WhenActivated(disposables => { });

        [Inject]
        public FeedbackViewModel Parameter
        {
            get => ViewModel;
            set => ViewModel = value;
        }
    }
}