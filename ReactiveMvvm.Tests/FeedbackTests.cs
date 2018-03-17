using ReactiveMvvm.Services;
using ReactiveMvvm.ViewModels;
using FluentAssertions;
using NSubstitute;
using System;
using Xunit;

namespace ReactiveMvvm.Tests
{
    public sealed class FeedbackTests
    {
        [Fact] 
        public void ShouldDisableCommandWhenFeedbackIsInvalid()
        {
            var service = Substitute.For<IService>();
            var feedback = new FeedbackViewModel(service);
            feedback.HasErrors.Should().BeTrue();
        }

        [Fact]
        public void ShouldEnableCommandWhenFeedbackIsValid()
        {
            var service = Substitute.For<IService>();
            var feedback = new FeedbackViewModel(service)
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
            var service = Substitute.For<IService>();
            var feedback = new FeedbackViewModel(service)
            {
                Message = "Message!",
                Title = "Title!",
                Section = 0,
                Idea = true
            };
            feedback.Submit.Execute().Subscribe();
            service.Received().Send("Title!", "Message!");
        }
    }
}
