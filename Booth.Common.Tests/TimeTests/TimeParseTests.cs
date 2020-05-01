using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

using NUnit.Framework;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Booth.Common.Tests.TimeTests
{
    class TimeParseTests
    {
        [TestCase("6:24")]
        [TestCase("6:24:00")]
        [TestCase("06:24")]
        public void ParseTest(string s)
        {
            var time = Time.Parse(s);

            time.Should().Be(new Time(06, 24, 00));
        }

        [TestCase("6:24", @"h\:mm")]
        [TestCase("6.24.00", @"h\.mm\.ss")]
        [TestCase("06.24", @"hh\.mm")]
        public void ParseExactTest(string s, string format)
        {
            var time = Time.ParseExact(s, format, CultureInfo.CurrentCulture);

            time.Should().Be(new Time(06, 24, 00));
        }

        [TestCase("6:24", true)]
        [TestCase("6:24:00", true)]
        [TestCase("06.24", false)]
        [TestCase("06.99", false)]
        [TestCase("ddd", false)]
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

        [TestCase("6:24", @"h\:mm", true)]
        [TestCase("6.24.00", @"h\.mm\.ss", true)]
        [TestCase("06.24", @"hh\.mm", true)]
        [TestCase("06.99", @"hh\.mm", false)]
        [TestCase("ddd", @"hh\.mm", false)]
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
