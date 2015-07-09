using FluentAssertions;
using Xunit;

namespace Tests
{
    public class IntroductionTests
    {
        [Fact]
        public void demo_xunit_and_fluentassertions()
        {
            var i = 45;

            // fluentassertions
            i.Should()
                .BeGreaterThan(20)
                .And.BeLessThan(100);
        }
    }
}