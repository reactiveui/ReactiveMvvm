// Copyright (c) 2019-2026 ReactiveUI and Contributors. All rights reserved.
// ReactiveUI and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Reactive.Linq;
using ReactiveMvvm.ViewModels;

namespace ReactiveMvvm.Wpf.Views;

/// <summary>Displays and binds the shared feedback form on this platform.</summary>
[System.Diagnostics.DebuggerDisplay("FeedbackView: {ToString(),nq}")]
public partial class FeedbackView : ReactiveWindow<FeedbackViewModel>
{
    /// <summary>Initializes a new instance of the FeedbackView class.</summary>
    public FeedbackView()
    {
        InitializeComponent();
        _ = this.WhenActivated(subscriptions =>
        {
            if (ViewModel is not { } viewModel)
            {
                return;
            }

            _ = this.Bind(viewModel, static x => x.Title, static x => x.TitleTextBox.Text).DisposeWith(subscriptions);
            _ = this.OneWayBind(viewModel, static x => x.TitleLengthMax, static x => x.TitleTextBox.MaxLength).DisposeWith(subscriptions);
            _ = viewModel.WhenAnyValue(static x => x.TitleLength, static x => x.TitleLengthMax).Select(static values => $"{values.Property1} letters used from {values.Property2}")
                .BindTo(this, static x => x.TitleLengthTextBox.Text)
                .DisposeWith(subscriptions);
            _ = this.Bind(viewModel, static x => x.Message, static x => x.MessageTextBox.Text).DisposeWith(subscriptions);
            _ = this.OneWayBind(viewModel, static x => x.MessageLengthMax, static x => x.MessageTextBox.MaxLength).DisposeWith(subscriptions);
            _ = viewModel.WhenAnyValue(static x => x.MessageLength, static x => x.MessageLengthMax).Select(static values => $"{values.Property1} letters used from {values.Property2}")
                .BindTo(this, static x => x.MessageLengthTextBox.Text)
                .DisposeWith(subscriptions);
            _ = this.Bind(viewModel, static x => x.Section, static x => x.SectionComboBox.SelectedIndex).DisposeWith(subscriptions);
            _ = this.Bind(viewModel, static x => x.Idea, static x => x.IdeaCheckBox.IsChecked).DisposeWith(subscriptions);
            _ = this.Bind(viewModel, static x => x.Issue, static x => x.IssueCheckBox.IsChecked).DisposeWith(subscriptions);
            _ = this.OneWayBind(viewModel, static x => x.HasErrors, static x => x.HasErrorsTextBox.Visibility).DisposeWith(subscriptions);
            _ = this.BindCommand(viewModel, static x => x.Submit, static x => x.SubmitButton).DisposeWith(subscriptions);
            _ = this.OneWayBind(viewModel, static x => x.Elapsed, static x => x.TimeTextBlock.Text, static time => $"Time elapsed: {time}")
                .DisposeWith(subscriptions);
        });
    }
}
