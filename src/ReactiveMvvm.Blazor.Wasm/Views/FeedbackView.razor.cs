using Microsoft.AspNetCore.Components;
using ReactiveMvvm.ViewModels;
using ReactiveUI;
using ReactiveUI.Blazor;

namespace ReactiveMvvm.Blazor.Wasm.Views
{
    public partial class FeedbackView : ReactiveComponentBase<FeedbackViewModel>
    {
        public FeedbackView() => this.WhenActivated(disposables => { });

        [Inject]
        public FeedbackViewModel Dependency
        {
            get => ViewModel;
            set => ViewModel = value;
        }
    }
}