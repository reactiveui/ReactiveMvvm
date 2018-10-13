using ReactiveMvvm.Services;
using FluentAssertions;
using System.Threading.Tasks;
using System;
using Xunit;

namespace ReactiveMvvm.Tests
{
    public sealed class ClockTests
    {
        [Fact]
        public async Task ShouldAdvanceNextValueByOne()
        {
            var value = 0L;
            var clock = new Clock();
            clock.Tick.Subscribe(next => value = next);

            await Task.Delay(1000);
            value.Should().Be(0L);

            await Task.Delay(1000);
            value.Should().Be(1L);
        }
    }
}
