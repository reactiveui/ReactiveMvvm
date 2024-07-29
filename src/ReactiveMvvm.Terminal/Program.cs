using System;
using System.Reactive.Concurrency;
using ReactiveMvvm.Services;
using ReactiveMvvm.Terminal.Services;
using ReactiveMvvm.Terminal.Views;
using ReactiveMvvm.ViewModels;
using ReactiveUI;
using Terminal.Gui;

namespace ReactiveMvvm.Terminal
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Application.Init();
            RxApp.MainThreadScheduler = TerminalScheduler.Default;
            RxApp.TaskpoolScheduler = TaskPoolScheduler.Default;
            Application.Run(
                new FeedbackView(
                    new(
                        new TerminalSender(), 
                        new Clock())));
        }
    }
}