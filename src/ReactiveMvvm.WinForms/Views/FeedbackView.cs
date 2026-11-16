// Copyright (c) 2019-2026 ReactiveUI and Contributors. All rights reserved.
// ReactiveUI and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.Reactive.Linq;
using System.Windows.Forms;
using ReactiveMvvm.ViewModels;

namespace ReactiveMvvm.WinForms.Views;

/// <summary>Displays and binds the shared feedback form on this platform.</summary>
[System.Diagnostics.DebuggerDisplay("FeedbackView: {ViewModel}")]
public partial class FeedbackView : Form, IViewFor<FeedbackViewModel>
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
                .BindTo(this, x => x.TitleLengthLabel.Text)
                .DisposeWith(subscriptions);
            _ = this.Bind(viewModel, x => x.Message, x => x.MessageTextBox.Text).DisposeWith(subscriptions);
            _ = this.OneWayBind(viewModel, x => x.MessageLengthMax, x => x.MessageTextBox.MaxLength).DisposeWith(subscriptions);
            _ = viewModel.WhenAnyValue(x => x.MessageLength, x => x.MessageLengthMax).Select(static values => $"{values.Property1} letters used from {values.Property2}")
                .BindTo(this, x => x.MessageLengthLabel.Text)
                .DisposeWith(subscriptions);
            _ = this.Bind(viewModel, x => x.Section, x => x.SectionComboBox.SelectedIndex).DisposeWith(subscriptions);
            _ = this.Bind(viewModel, x => x.Idea, x => x.IdeaCheckBox.Checked).DisposeWith(subscriptions);
            _ = this.Bind(viewModel, x => x.Issue, x => x.IssueCheckBox.Checked).DisposeWith(subscriptions);
            _ = this.OneWayBind(viewModel, x => x.HasErrors, x => x.HasErrorsTextBox.Visible).DisposeWith(subscriptions);
            _ = this.BindCommand(viewModel, x => x.Submit, x => x.SubmitButton).DisposeWith(subscriptions);
            _ = this.OneWayBind(viewModel, x => x.Elapsed, x => x.TimeElapsedLabel.Text, static time => $"Elapsed: {time}")
                .DisposeWith(subscriptions);
        });
    }

    /// <inheritdoc/>
    [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
    public FeedbackViewModel? ViewModel { get; set; }

    /// <inheritdoc/>
    object? IViewFor.ViewModel { get => ViewModel; set => ViewModel = (FeedbackViewModel?)value; }
}
