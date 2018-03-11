using ReactiveUI;
using System.Reactive.Concurrency;
using System.Windows;

namespace ReactiveMvvm.Wpf
{
    public partial class App : Application
    {
        public App() => RxApp.MainThreadScheduler = new WaitForDispatcherScheduler(
            () => DispatcherScheduler.Current
        );
    }
}
