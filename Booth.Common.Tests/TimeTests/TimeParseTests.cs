using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

using Xunit;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Booth.Common.Tests.TimeTests
{
    public class TimeParseTests
    {
        [Theory]
        [InlineData("6:24")]
        [InlineData("6:24:00")]
        [InlineData("06:24")]
        public void ParseTest(string s)
        {
            var time = Time.Parse(s);

            time.Should().Be(new Time(06, 24, 00));
        }

        [Theory]
        [InlineData("6:24", @"h\:mm")]
        [InlineData("6.24.00", @"h\.mm\.ss")]
        [InlineData("06.24", @"hh\.mm")]
        public void ParseExactTest(string s, string format)
        {
            var time = Time.ParseExact(s, format, CultureInfo.CurrentCulture);

            time.Should().Be(new Time(06, 24, 00));
        }

        [Theory]
        [InlineData("6:24", true)]
        [InlineData("6:24:00", true)]
        [InlineData("06.24", false)]
        [InlineData("06.99", false)]
        [InlineData("ddd", false)]
        public void TryParseTest(string s, bool expectedResult)
        {
            var result = Time.TryParse(s, out var resultTime);

            using (new AssertionScope())
            {
                result.Should().Be(expectedResult);
                if (result == true)
                    resultTime.Should().Be(new Time(06, 24, 00));
            }
        }

        [Theory]
        [InlineData("6:24", @"h\:mm", true)]
        [InlineData("6.24.00", @"h\.mm\.ss", true)]
        [InlineData("06.24", @"hh\.mm", true)]
        [InlineData("06.99", @"hh\.mm", false)]
        [InlineData("ddd", @"hh\.mm", false)]
        public void TryParseExactTest(string s, string format, bool expectedResult)
        {
            var result = Time.TryParseExact(s, format, CultureInfo.CurrentCulture, out var resultTime);

            using (new AssertionScope())
            {
                result.Should().Be(expectedResult);
                if (result == true)
                    resultTime.Should().Be(new Time(06, 24, 00));
            }
        }

    }
}
