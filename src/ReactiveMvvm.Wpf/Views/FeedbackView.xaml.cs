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

            _ = this.Bind(viewModel, x => x.Title, x => x.TitleTextBox.Text).DisposeWith(subscriptions);
            _ = this.OneWayBind(viewModel, x => x.TitleLengthMax, x => x.TitleTextBox.MaxLength).DisposeWith(subscriptions);
            _ = viewModel.WhenAnyValue(x => x.TitleLength, x => x.TitleLengthMax).Select(static values => $"{values.Property1} letters used from {values.Property2}")
                .BindTo(this, x => x.TitleLengthTextBox.Text)
                .DisposeWith(subscriptions);
            _ = this.Bind(viewModel, x => x.Message, x => x.MessageTextBox.Text).DisposeWith(subscriptions);
            _ = this.OneWayBind(viewModel, x => x.MessageLengthMax, x => x.MessageTextBox.MaxLength).DisposeWith(subscriptions);
            _ = viewModel.WhenAnyValue(x => x.MessageLength, x => x.MessageLengthMax).Select(static values => $"{values.Property1} letters used from {values.Property2}")
                .BindTo(this, x => x.MessageLengthTextBox.Text)
                .DisposeWith(subscriptions);
            _ = this.Bind(viewModel, x => x.Section, x => x.SectionComboBox.SelectedIndex).DisposeWith(subscriptions);
            _ = this.Bind(viewModel, x => x.Idea, x => x.IdeaCheckBox.IsChecked).DisposeWith(subscriptions);
            _ = this.Bind(viewModel, x => x.Issue, x => x.IssueCheckBox.IsChecked).DisposeWith(subscriptions);
            _ = this.OneWayBind(viewModel, x => x.HasErrors, x => x.HasErrorsTextBox.Visibility).DisposeWith(subscriptions);
            _ = this.BindCommand(viewModel, x => x.Submit, x => x.SubmitButton).DisposeWith(subscriptions);
            _ = this.OneWayBind(viewModel, x => x.Elapsed, x => x.TimeTextBlock.Text, static time => $"Time elapsed: {time}")
                .DisposeWith(subscriptions);
        });
    }
}
