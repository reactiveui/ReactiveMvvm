// Copyright (c) 2019-2026 ReactiveUI and Contributors. All rights reserved.
// ReactiveUI and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Diagnostics;
using System.Reactive.Linq;
using ReactiveMvvm.Maui.Services;
using ReactiveMvvm.Services;
using ReactiveMvvm.ViewModels;
using ReactiveUI.Reactive.Maui;

namespace ReactiveMvvm.Maui.Views;

/// <summary>Displays and binds the shared feedback form on this platform.</summary>
[DebuggerDisplay("{ViewModel}")]
public partial class FeedbackView : ReactiveContentPage<FeedbackViewModel>
{
    /// <summary>Initializes a new instance of the FeedbackView class.</summary>
    public FeedbackView()
    {
        InitializeComponent();
        _ = this.WhenActivated(subscriptions =>
        {
            var viewModel = new FeedbackViewModel(new MauiSender(this), new Clock());
            ViewModel = viewModel;
            subscriptions.Add(viewModel);
            _ = this.Bind(viewModel, static x => x.Title, static x => x.TitleEntry.Text).DisposeWith(subscriptions);
            _ = this.OneWayBind(viewModel, static x => x.TitleLengthMax, static x => x.TitleEntry.MaxLength).DisposeWith(subscriptions);
            _ = viewModel.WhenAnyValue(static x => x.TitleLength, static x => x.TitleLengthMax)
                .Select(static values => $"{values.Property1} letters used from {values.Property2}")
                .BindTo(this, static x => x.TitleLengthEntry.Text)
                .DisposeWith(subscriptions);
            _ = this.Bind(viewModel, static x => x.Message, static x => x.MessageEntry.Text).DisposeWith(subscriptions);
            _ = this.OneWayBind(viewModel, static x => x.MessageLengthMax, static x => x.MessageEntry.MaxLength).DisposeWith(subscriptions);
            _ = viewModel.WhenAnyValue(static x => x.MessageLength, static x => x.MessageLengthMax)
                .Select(static values => $"{values.Property1} letters used from {values.Property2}")
                .BindTo(this, static x => x.MessageLengthEntry.Text)
                .DisposeWith(subscriptions);
            _ = this.Bind(viewModel, static x => x.Section, static x => x.SectionPicker.SelectedIndex).DisposeWith(subscriptions);
            _ = this.Bind(viewModel, static x => x.Idea, static x => x.IdeaSwitch.IsToggled).DisposeWith(subscriptions);
            _ = this.Bind(viewModel, static x => x.Issue, static x => x.IssueSwitch.IsToggled).DisposeWith(subscriptions);
            _ = this.OneWayBind(viewModel, static x => x.HasErrors, static x => x.HasErrorsLabel.IsVisible).DisposeWith(subscriptions);
            _ = this.BindCommand(viewModel, static x => x.Submit, static x => x.SubmitButton).DisposeWith(subscriptions);
            _ = this.OneWayBind(viewModel, static x => x.Elapsed, static x => x.TimeElapsedLabel.Text, static time => $"Time elapsed: {time}")
                .DisposeWith(subscriptions);
        });
    }
}
