using ReactiveMvvm.ViewModels;
using ReactiveMvvm.Interfaces;
using FluentAssertions;
using NSubstitute;
using System;
using Xunit;

namespace ReactiveMvvm.Tests
{
    public sealed class FeedbackViewModelTests
    {
        private readonly ISender sender = Substitute.For<ISender>();
        private readonly IClock clock = Substitute.For<IClock>();

        [Fact] 
        public void ShouldDisableCommandWhenFeedbackIsInvalid()
        {
            var feedback = new FeedbackViewModel(sender, clock);
            feedback.HasErrors.Should().BeTrue();
        }

        [Fact]
        public void ShouldEnableCommandWhenFeedbackIsValid()
        {
            var feedback = new FeedbackViewModel(sender, clock)
            {
                Message = "Message!",
                Title = "Title!",
                Section = 0,
                Idea = true
            };
            feedback.HasErrors.Should().BeFalse();
        }

        [Fact]
        public void ShouldSendFeedbackWhenSubmitIsPressed()
        {
            var feedback = new FeedbackViewModel(sender, clock)
            {
                Message = "Message!",
                Title = "Title!",
                Section = 0,
                Issue = true
            };
            feedback.Submit.Execute().Subscribe();
            sender.Received().Send("Title!", "Message!", 0, true);
        }
    }
}
