using System;
using ReactiveMvvm.Services;
using ReactiveMvvm.Terminal.Services;
using ReactiveMvvm.Terminal.Views;
using ReactiveMvvm.ViewModels;
using Terminal.Gui;

namespace ReactiveMvvm.Terminal
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Application.Init();
            Application.Run(
                new FeedbackView(
                    new(
                        new TerminalSender(), 
                        new Clock())));
        }
    }
}