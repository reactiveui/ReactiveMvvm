// Copyright (c) 2019-2026 ReactiveUI and Contributors. All rights reserved.
// ReactiveUI and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveMvvm.ViewModels;

namespace ReactiveMvvm.Terminal.Views;

/// <summary>Displays and binds the shared feedback form on this platform.</summary>
[System.Diagnostics.DebuggerDisplay("FeedbackView: {ViewModel}")]
public sealed class FeedbackView : Window, IViewFor<FeedbackViewModel>
{
    /// <summary>The width of each text field in terminal columns.</summary>
    private const int TextFieldWidth = 40;

    /// <summary>The number of rows before the submit button.</summary>
    private const int SubmitButtonOffset = 4;

    /// <summary>Owns the terminal view's binding subscriptions.</summary>
    private readonly CompositeDisposable _subscriptions = [];

    /// <summary>Initializes a new instance of the FeedbackView class.</summary>
    /// <param name="viewModel">The feedback state displayed by the view.</param>
    public FeedbackView(FeedbackViewModel viewModel)
    {
        ViewModel = viewModel;
        _subscriptions.Add(ViewModel.Activator.Activate());
        _ = this.StackPanel(TimeElapsedLabel()).Append(new Label { Text = "Issue Title" }).Append(TitleDescription())
            .Append(TitleInput())
            .Append(new Label { Text = "Issue Description" })
            .Append(MessageDescription())
            .Append(MessageInput())
            .Append(new Label { Text = "Feedback Type" })
            .Append(IssueCheckBox())
            .Append(IdeaCheckBox())
            .Append(new Label { Text = "Feedback Category" })
            .Append(SectionRadioGroup())
            .Append(
                new Button { Text = "Send Feedback" },
                SubmitButtonOffset);
    }

    /// <inheritdoc/>
    [System.Diagnostics.CodeAnalysis.AllowNull]
    public FeedbackViewModel ViewModel
    {
        get;
        set
        {
            ArgumentNullException.ThrowIfNull(value);
            field = value;
        }
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        if (!disposing)
        {
            return;
        }

        _subscriptions.Dispose();
    }

    /// <summary>Creates and binds the feedback category selector.</summary>
    /// <returns>The bound terminal control.</returns>
    private OptionSelector SectionRadioGroup()
    {
        var radioGroup = new OptionSelector { Labels = ["User Interface", "Audio", "Video", "Voice"] };
        _ = ViewModel.WhenAnyValue(static x => x.Section).Select(static section => (int?)section).BindTo(radioGroup, static x => x.Value)
            .DisposeWith(_subscriptions);
        _ = Observable.FromEventPattern<ValueChangedEventArgs<int?>>(
            handler => radioGroup.ValueChanged += handler,
            handler => radioGroup.ValueChanged -= handler)
            .Select(static args => args.EventArgs.NewValue ?? -1)
            .BindTo(this, static x => x.ViewModel.Section)
            .DisposeWith(_subscriptions);
        return radioGroup;
    }

    /// <summary>Creates and binds the issue selector.</summary>
    /// <returns>The bound terminal control.</returns>
    private CheckBox IssueCheckBox()
    {
        var item = new CheckBox { Text = "Issue", Value = ViewModel.Issue ? CheckState.Checked : CheckState.UnChecked };
        _ = ViewModel.WhenAnyValue(static x => x.Issue).Select(static issue => issue ? CheckState.Checked : CheckState.UnChecked)
            .BindTo(item, static x => x.Value)
            .DisposeWith(_subscriptions);
        _ = Observable.FromEventPattern<ValueChangedEventArgs<CheckState>>(handler => item.ValueChanged += handler, handler => item.ValueChanged -= handler)
            .Select(static args => args.EventArgs.NewValue == CheckState.Checked)
            .Subscribe(issue => ViewModel.Issue = issue)
            .DisposeWith(_subscriptions);
        _ = ViewModel.WhenAnyValue(static x => x.Idea).Skip(1).Subscribe(args => item.SetNeedsDraw()).DisposeWith(_subscriptions);
        return item;
    }

    /// <summary>Creates and binds the idea selector.</summary>
    /// <returns>The bound terminal control.</returns>
    private CheckBox IdeaCheckBox()
    {
        var item = new CheckBox { Text = "Suggestion", Value = ViewModel.Idea ? CheckState.Checked : CheckState.UnChecked };
        _ = ViewModel.WhenAnyValue(static x => x.Idea).Select(static issue => issue ? CheckState.Checked : CheckState.UnChecked)
            .BindTo(item, static x => x.Value)
            .DisposeWith(_subscriptions);
        _ = Observable.FromEventPattern<ValueChangedEventArgs<CheckState>>(handler => item.ValueChanged += handler, handler => item.ValueChanged -= handler)
            .Select(static args => args.EventArgs.NewValue == CheckState.Checked)
            .Subscribe(idea => ViewModel.Idea = idea)
            .DisposeWith(_subscriptions);
        _ = ViewModel.WhenAnyValue(static x => x.Issue).Skip(1).Subscribe(args => item.SetNeedsDraw()).DisposeWith(_subscriptions);
        return item;
    }

    /// <summary>Creates a label that displays elapsed seconds.</summary>
    /// <returns>The bound terminal control.</returns>
    private Label TimeElapsedLabel()
    {
        var label = new Label { Text = "0 seconds passed" };
        _ = ViewModel.WhenAnyValue(static x => x.Elapsed).Select(static elapsed => $"{elapsed} seconds passed").BindTo(label, static x => x.Text)
            .DisposeWith(_subscriptions);
        return label;
    }

    /// <summary>Creates and binds the feedback message field.</summary>
    /// <returns>The bound terminal control.</returns>
    private TextField MessageInput()
    {
        var text = new TextField { Text = ViewModel.Message, Width = TextFieldWidth };
        _ = ViewModel.WhenAnyValue(static x => x.Message).BindTo(text, static x => x.Text).DisposeWith(_subscriptions);
        _ = Observable.FromEventPattern(handler => text.TextChanged += handler, handler => text.TextChanged -= handler)
            .Select(_ => text.Text)
            .DistinctUntilChanged()
            .Subscribe(message => ViewModel.Message = message)
            .DisposeWith(_subscriptions);
        return text;
    }

    /// <summary>Creates a label that displays message length and its limit.</summary>
    /// <returns>The bound terminal control.</returns>
    private Label MessageDescription()
    {
        var label = new Label { Text = $"0 letters used from {ViewModel.MessageLengthMax}" };
        _ = ViewModel.WhenAnyValue(static x => x.MessageLength, static x => x.MessageLengthMax).Select(static values => $"{values.Property1} letters used from {values.Property2}")
            .BindTo(label, static x => x.Text)
            .DisposeWith(_subscriptions);
        return label;
    }

    /// <summary>Creates and binds the feedback title field.</summary>
    /// <returns>The bound terminal control.</returns>
    private TextField TitleInput()
    {
        var text = new TextField { Text = ViewModel.Title, Width = TextFieldWidth };
        _ = ViewModel.WhenAnyValue(static x => x.Title).BindTo(text, static x => x.Text).DisposeWith(_subscriptions);
        _ = Observable.FromEventPattern(handler => text.TextChanged += handler, handler => text.TextChanged -= handler)
            .Select(_ => text.Text)
            .DistinctUntilChanged()
            .Subscribe(title => ViewModel.Title = title)
            .DisposeWith(_subscriptions);
        return text;
    }

    /// <summary>Creates a label that displays title length and its limit.</summary>
    /// <returns>The bound terminal control.</returns>
    private Label TitleDescription()
    {
        var label = new Label { Text = $"0 letters used from {ViewModel.TitleLengthMax}" };
        _ = ViewModel.WhenAnyValue(static x => x.TitleLength, static x => x.TitleLengthMax).Select(static values => $"{values.Property1} letters used from {values.Property2}")
            .BindTo(label, static x => x.Text)
            .DisposeWith(_subscriptions);
        return label;
    }

    /// <inheritdoc/>
    object? IViewFor.ViewModel
    {
        get => ViewModel;
        set => ViewModel = (FeedbackViewModel?)value;
    }
}
