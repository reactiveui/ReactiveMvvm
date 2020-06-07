using ReactiveMvvm.Services;
using FluentAssertions;
using System;
using Microsoft.Reactive.Testing;
using ReactiveMvvm.Interfaces;
using ReactiveUI.Testing;
using Xunit;

namespace ReactiveMvvm.Tests
{
    public sealed class ClockTests
    {
        private readonly TestScheduler _scheduler = new TestScheduler();
        private readonly IClock _clock;
        
        public ClockTests() => _clock = new Clock(_scheduler);

        [Fact]
        public void ShouldAdvanceNextValueByOne()
        {
            var value = (long?) null;
            _clock.Tick.Subscribe(next => value = next);
            value.Should().BeNull();
            
            _scheduler.AdvanceByMs(1000);
            value.Should().Be(0L);
            
            _scheduler.AdvanceByMs(1000);
            value.Should().Be(1L);
        }
    }
}
