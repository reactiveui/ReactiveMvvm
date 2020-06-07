using ReactiveMvvm.ViewModels;
using ReactiveMvvm.Interfaces;
using FluentAssertions;
using NSubstitute;
using System;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using Microsoft.Reactive.Testing;
using ReactiveUI;
using ReactiveUI.Testing;
using Xunit;

namespace ReactiveMvvm.Tests
{
    public sealed class FeedbackViewModelTests
    {
        private readonly ISender _sender = Substitute.For<ISender>();
        private readonly IClock _clock = Substitute.For<IClock>();
        private readonly FeedbackViewModel _feedback;

        // For every test, a new instance of FeedbackViewModelTests is created by xUnit.
        // This allows us to extract the commonly used mocks and tested objects into
        // fields, in order to avoid duplicating the initialization code.
        public FeedbackViewModelTests()
        {
            // We replace the default schedulers with the immediate scheduler. This is
            // required to avoid concurrency and Task.Delays in unit test harness. There
            // is a TestScheduler in the ReactiveUI.Testing package as well, where you can
            // control time-dependent scenarios, by using .AdvanceBy() or .AdvanceByMs().  
            RxApp.MainThreadScheduler = Scheduler.Immediate;
            RxApp.TaskpoolScheduler = Scheduler.Immediate;
            _feedback = new FeedbackViewModel(_sender, _clock);
        }

        [Fact]
        public void ShouldInitializeDefaultsProperly()
        {
            _feedback.HasErrors.Should().BeTrue();
            _feedback.Elapsed.Should().BeEmpty();
            _feedback.Section.Should().Be(0);
        }

        [Fact]
        public void ShouldEnableCommandWhenFeedbackIsValid()
        {
            _feedback.Message = "Message!";
            _feedback.Title = "Title!";
            _feedback.Section = 0;
            _feedback.Idea = true;
            _feedback.HasErrors.Should().BeFalse();
        }

        [Fact]
        public void ShouldSendFeedbackWhenSubmitIsPressed()
        {
            _feedback.Message = "Message!";
            _feedback.Title = "Title!";
            _feedback.Section = 0;
            _feedback.Issue = true;
            _feedback.Submit.Execute().Subscribe();
            _sender.Received().Send("Title!", "Message!", 0, true);
        }

        [Fact]
        public void ShouldStartTheClockWhenActivated()
        {
            _clock.Tick.ReturnsForAnyArgs(call => Observable.Return<long>(42, Scheduler.Immediate));
            using (_feedback.Activator.Activate())
                _feedback.Elapsed.Should().Be("42s");
        }

        [Fact]
        public void ShouldCorrectlyInitializeLengthRelatedProperties()
        {
            _feedback.Message = "Words";
            _feedback.MessageLength.Should().Be(5);
            _feedback.MessageLengthMax.Should().Be(30);

            _feedback.Title = "Issue Title";
            _feedback.TitleLength.Should().Be(11);
            _feedback.TitleLengthMax.Should().Be(15);
        }

        [Fact]
        public void ShouldAutomaticallySwitchDependentProperties()
        {
            _feedback.Issue = true;
            _feedback.Idea.Should().BeFalse();
            _feedback.Idea = true;
            _feedback.Issue.Should().BeFalse();
            _feedback.Issue = true;
            _feedback.Idea.Should().BeFalse();
        }
    }
}
