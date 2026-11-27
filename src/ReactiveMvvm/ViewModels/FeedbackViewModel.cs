// Copyright (c) 2019-2026 ReactiveUI and Contributors. All rights reserved.
// ReactiveUI and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveMvvm.Interfaces;
using ReactiveUI.SourceGenerators;

namespace ReactiveMvvm.ViewModels;

/// <summary>Collects, validates and submits feedback across the sample views.</summary>
[DebuggerDisplay("{Title}")]
public sealed partial class FeedbackViewModel : ReactiveObject, IActivatableViewModel, IDisposable
{
    /// <summary>Owns validation subscriptions and the submit command.</summary>
    private readonly CompositeDisposable _subscriptions = [];

    /// <summary>Whether the entered feedback is invalid.</summary>
    [Reactive]
    private bool _hasErrors;

    /// <summary>The elapsed time displayed by the views.</summary>
    [Reactive]
    private string _elapsed = string.Empty;

    /// <summary>The entered feedback title.</summary>
    [Reactive]
    private string _title = string.Empty;

    /// <summary>The number of characters in the title.</summary>
    [Reactive]
    private int _titleLength;

    /// <summary>The entered feedback message.</summary>
    [Reactive]
    private string _message = string.Empty;

    /// <summary>The number of characters in the message.</summary>
    [Reactive]
    private int _messageLength;

    /// <summary>The selected feedback category.</summary>
    [Reactive]
    private int _section;

    /// <summary>Whether the feedback describes an issue.</summary>
    [Reactive]
    private bool _issue = true;

    /// <summary>Whether the feedback describes an idea.</summary>
    [Reactive]
    private bool _idea;

    /// <summary>Initializes a new instance of the <see cref="FeedbackViewModel"/> class.</summary>
    /// <param name="sender">The service that submits feedback.</param>
    /// <param name="clock">The clock observed while the view is active.</param>
    public FeedbackViewModel(ISender sender, IClock clock)
    {
        ArgumentNullException.ThrowIfNull(sender);
        ArgumentNullException.ThrowIfNull(clock);

        _ = this.WhenAnyValue(static x => x.Idea)
            .Select(static selected => !selected)
            .Subscribe(value => Issue = value)
            .DisposeWith(_subscriptions);
        _ = this.WhenAnyValue(static x => x.Issue)
            .Select(static selected => !selected)
            .Subscribe(value => Idea = value)
            .DisposeWith(_subscriptions);
        _ = this.WhenAnyValue(static x => x.Title)
            .Select(static title => title.Length)
            .Subscribe(length => TitleLength = length)
            .DisposeWith(_subscriptions);
        _ = this.WhenAnyValue(static x => x.Message)
            .Select(static message => message.Length)
            .Subscribe(length => MessageLength = length)
            .DisposeWith(_subscriptions);

        var valid = this.WhenAnyValue(
            static x => x.Title,
            static x => x.Message,
            static x => x.Issue,
            static x => x.Idea,
            static x => x.Section,
            static (title, message, issue, idea, section) =>
                !string.IsNullOrWhiteSpace(message)
                && !string.IsNullOrWhiteSpace(title)
                && (idea || issue)
                && section >= 0)
            .Publish()
            .RefCount();

        _ = valid.Subscribe(hasErrors => HasErrors = !hasErrors).DisposeWith(_subscriptions);
        Submit = ReactiveCommand.CreateFromTask(() => sender.Send(Title, Message, Section, Issue), valid);
        _subscriptions.Add(Submit);

        this.WhenActivated(dispose => dispose(
            clock.Tick.Select(static second => $"{second}s")
                .ObserveOn(RxSchedulers.MainThreadScheduler)
                .Subscribe(elapsed => Elapsed = elapsed)));
    }

    /// <inheritdoc/>
    public ViewModelActivator Activator { get; } = new();

    /// <summary>Gets the command that sends valid feedback.</summary>
    public ReactiveCommand<Unit, Unit> Submit { get; }

    /// <summary>Gets the maximum title length accepted by the sample views.</summary>
    public int TitleLengthMax { get; } = 15;

    /// <summary>Gets the maximum message length accepted by the sample views.</summary>
    public int MessageLengthMax { get; } = 30;

    /// <inheritdoc/>
    public void Dispose()
    {
        Activator.Dispose();
        _subscriptions.Dispose();
    }
}
