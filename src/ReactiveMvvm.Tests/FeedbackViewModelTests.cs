// Copyright (c) 2019-2026 ReactiveUI and Contributors. All rights reserved.
// ReactiveUI and Contributors licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveMvvm.Interfaces;
using ReactiveMvvm.ViewModels;

namespace ReactiveMvvm.Tests;

/// <summary>Verifies feedback validation, submission and activation.</summary>
[NotInParallel]
[TestExecutor<ReactiveMvvmTestExecutor>]
public sealed class FeedbackViewModelTests
{
    /// <summary>Valid feedback message.</summary>
    private const string FeedbackMessage = "Message!";

    /// <summary>Valid feedback title.</summary>
    private const string FeedbackTitle = "Title!";

    /// <summary>Character count of the test message.</summary>
    private const int ExpectedMessageLength = 5;

    /// <summary>Maximum message length exposed to the views.</summary>
    private const int MessageLengthLimit = 30;

    /// <summary>Character count of the test title.</summary>
    private const int ExpectedTitleLength = 11;

    /// <summary>Maximum title length exposed to the views.</summary>
    private const int TitleLengthLimit = 15;

    /// <summary>Checks the form's initial validation state.</summary>
    /// <returns>A task representing the test.</returns>
    [Test]
    public async Task Constructor_InitializesDefaults()
    {
        using var feedback = new FeedbackViewModel(new TestSender(), new TestClock());
        await Assert.That(feedback.HasErrors).IsTrue();
        await Assert.That(feedback.Elapsed).IsEqualTo(string.Empty);
        await Assert.That(feedback.Section).IsEqualTo(0);
    }

    /// <summary>Checks that valid text enables submission.</summary>
    /// <returns>A task representing the test.</returns>
    [Test]
    public async Task Form_EnablesValidFeedback()
    {
        using var feedback = new FeedbackViewModel(new TestSender(), new TestClock());
        feedback.Message = FeedbackMessage;
        feedback.Title = FeedbackTitle;
        feedback.Idea = true;
        await Assert.That(feedback.HasErrors).IsFalse();
    }

    /// <summary>Checks that submission forwards the entered feedback.</summary>
    /// <returns>A task representing the test.</returns>
    [Test]
    public async Task Submit_ForwardsFeedback()
    {
        var sender = new TestSender();
        using var feedback = new FeedbackViewModel(sender, new TestClock());
        feedback.Title = FeedbackTitle;
        feedback.Message = FeedbackMessage;
        using var subscription = feedback.Submit.Execute().Subscribe();
        await Assert.That(sender.Title).IsEqualTo(FeedbackTitle);
        await Assert.That(sender.Message).IsEqualTo(FeedbackMessage);
        await Assert.That(sender.Section).IsEqualTo(0);
        await Assert.That(sender.Bug).IsTrue();
    }

    /// <summary>Checks that activation observes clock ticks.</summary>
    /// <returns>A task representing the test.</returns>
    [Test]
    public async Task Activation_ObservesClock()
    {
        using var feedback = new FeedbackViewModel(new TestSender(), new TestClock());
        using var activation = feedback.Activator.Activate();
        await Assert.That(feedback.Elapsed).IsEqualTo("42s");
    }

    /// <summary>Checks that text lengths and input limits are exposed to views.</summary>
    /// <returns>A task representing the test.</returns>
    [Test]
    public async Task Text_TracksLengths()
    {
        using var feedback = new FeedbackViewModel(new TestSender(), new TestClock());
        feedback.Message = "Words";
        feedback.Title = "Issue Title";
        await Assert.That(feedback.MessageLength).IsEqualTo(ExpectedMessageLength);
        await Assert.That(feedback.MessageLengthMax).IsEqualTo(MessageLengthLimit);
        await Assert.That(feedback.TitleLength).IsEqualTo(ExpectedTitleLength);
        await Assert.That(feedback.TitleLengthMax).IsEqualTo(TitleLengthLimit);
    }

    /// <summary>Checks that issue and idea selections remain mutually exclusive.</summary>
    /// <returns>A task representing the test.</returns>
    [Test]
    public async Task Category_UpdatesDependentSelection()
    {
        using var feedback = new FeedbackViewModel(new TestSender(), new TestClock());
        await Assert.That(feedback.Idea).IsFalse();
        feedback.Idea = true;
        await Assert.That(feedback.Issue).IsFalse();
        feedback.Issue = true;
        await Assert.That(feedback.Idea).IsFalse();
    }

    /// <summary>Records submitted feedback without an external mocking framework.</summary>
    [DebuggerDisplay("{Title}")]
    private sealed class TestSender : ISender
    {
        /// <summary>Gets the last submitted title.</summary>
        public string Title { get; private set; } = string.Empty;

        /// <summary>Gets the last submitted message.</summary>
        public string Message { get; private set; } = string.Empty;

        /// <summary>Gets the last submitted section.</summary>
        public int Section { get; private set; }

        /// <summary>Gets a value indicating whether the last submission was an issue.</summary>
        public bool Bug { get; private set; }

        /// <inheritdoc/>
        public Task Send(string title, string message, int section, bool bug)
        {
            Title = title;
            Message = message;
            Section = section;
            Bug = bug;
            return Task.CompletedTask;
        }
    }

    /// <summary>Provides an immediate deterministic clock tick.</summary>
    [DebuggerDisplay("{Tick}")]
    private sealed class TestClock : IClock
    {
        /// <summary>Deterministic tick emitted by the test clock.</summary>
        private const long ElapsedSeconds = 42L;

        /// <inheritdoc/>
        public IObservable<long> Tick { get; } = Observable.Return(ElapsedSeconds);
    }
}
