using ReactiveMvvm.ViewModels;
using ReactiveUI;
using ReactiveUI.Reactive.Blazor;

namespace ReactiveMvvm.Blazor.Views
{
    public partial class FeedbackView : ReactiveInjectableComponentBase<FeedbackViewModel>
    {
        public FeedbackView() => this.WhenActivated();
    }
}
