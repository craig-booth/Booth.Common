using System;
using System.Collections.Generic;
using System.Globalization;

using Xunit;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Booth.Common.Tests.DateTests
{
    public class DateParseTests
    {

        [Theory]
        [InlineData("2018-08-18")]
        [InlineData("Sat, 18 Aug 2018 07:22:16 GMT")]
        public void Parse(string s)
        {
            var date = Date.Parse(s);

            date.Should().Be(new Date(2018, 08, 18));
        }

        [Theory]
        [InlineData("2018-08-18", "yyyy-MM-dd")]
        [InlineData("18/8/2018", "dd/M/yyyy")]
        [InlineData("18/8/18", "dd/M/yy")]
        [InlineData("18/08/2018 07:22:16", "dd/MM/yyyy hh:mm:ss")]
        public void ParseExact(string s, string format)
        {
            var date = Date.ParseExact(s, format, CultureInfo.CurrentCulture, DateTimeStyles.None);

            date.Should().Be(new Date(2018, 08, 18));
        }

        [Theory]
        [InlineData("2018-08-18", true)]
        [InlineData("Sat, 18 Aug 2018 07:22:16 GMT", true)]
        public void TryParse(string s, bool expectedResult)
        {
            var result = Date.TryParse(s, out var resultDate);

            using (new AssertionScope())
            {
                result.Should().Be(expectedResult);
                resultDate.Should().Be(new Date(2018, 08, 18));
            }
        }

        [Theory]
        [InlineData("2018-08-18", "yyyy-MM-dd", true)]
        [InlineData("18/8/2018", "dd/M/yyyy", true)]
        [InlineData("18/8/18", "dd/M/yy", true)]
        [InlineData("18/08/2018 07:22:16", "dd/MM/yyyy hh:mm:ss", true)]
        public void TryParseExact(string s, string format, bool expectedResult)
        {
            var result = Date.TryParseExact(s, format, CultureInfo.CurrentCulture, DateTimeStyles.None, out var resultDate);

            using (new AssertionScope())
            {
                result.Should().Be(expectedResult);
                resultDate.Should().Be(new Date(2018, 08, 18));
            }
        }

    }
}
