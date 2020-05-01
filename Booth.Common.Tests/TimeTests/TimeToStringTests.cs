using System;
using System.Globalization;

using Xunit;
using FluentAssertions;

namespace Booth.Common.Tests.TimeTests
{
    public class TimeToStringTests
    {
        [Fact]
        public void ToStringProviderFormat()
        {
            var time = new Time(14, 02, 24);
            var dateTime = new DateTime(2019, 11, 19, 14, 02, 24);

            var format = @"hh\:mm\:ss";
            var provider = CultureInfo.CurrentCulture;

            var result = time.ToString(format, provider);
            
            result.Should().Be(dateTime.ToString(format, provider));
        }

        [Fact]
        public void ToStringFormat()
        {
            var time = new Time(14, 02, 24);
            var dateTime = new DateTime(2019, 11, 19, 14, 02, 24);

            var format = @"hh\:mm\:ss";
            var result = time.ToString(format);

            result.Should().Be(dateTime.ToString(format));
        }

        [Fact]
        public void TimeToString()
        {
            var time = new Time(14, 02, 24);
            var dateTime = new DateTime(2019, 11, 19, 14, 02, 24);

            var result = time.ToString();

            result.Should().Be("14:02:24");
        }
    }
}
