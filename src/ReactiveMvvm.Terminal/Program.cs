using System;
using System.Reactive.Concurrency;
using ReactiveMvvm.Services;
using ReactiveMvvm.Terminal.Services;
using ReactiveMvvm.Terminal.Views;
using ReactiveMvvm.ViewModels;
using ReactiveUI;
using ReactiveUI.Reactive.Builder;
using Terminal.Gui;

namespace ReactiveMvvm.Terminal
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            using var application = Application.Create();
            application.Init();
            RxAppBuilder.CreateReactiveUIBuilder().WithCoreServices().BuildApp();
            RxSchedulers.MainThreadScheduler = new TerminalScheduler(application);
            RxSchedulers.TaskpoolScheduler = TaskPoolScheduler.Default;
            application.Run(
                new FeedbackView(
                    new(
                        new TerminalSender(), 
                        new Clock())));
        }
    }
}
