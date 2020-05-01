using System;
using System.Globalization;

using NUnit.Framework;
using FluentAssertions;

namespace Booth.Common.Tests.TimeTests
{
    class TimeToStringTests
    {
        [TestCase]
        public void ToStringProviderFormat()
        {
            var time = new Time(14, 02, 24);
            var dateTime = new DateTime(2019, 11, 19, 14, 02, 24);

            var format = @"hh\:mm\:ss";
            var provider = CultureInfo.CurrentCulture;

            var result = time.ToString(format, provider);
            
            result.Should().Be(dateTime.ToString(format, provider));
        }

        [TestCase]
        public void ToStringFormat()
        {
            var time = new Time(14, 02, 24);
            var dateTime = new DateTime(2019, 11, 19, 14, 02, 24);

            var format = @"hh\:mm\:ss";
            var result = time.ToString(format);

            result.Should().Be(dateTime.ToString(format));
        }

        [TestCase]
        public void TimeToString()
        {
            var time = new Time(14, 02, 24);
            var dateTime = new DateTime(2019, 11, 19, 14, 02, 24);

            var result = time.ToString();

            result.Should().Be("14:02:24");
        }
    }
}
