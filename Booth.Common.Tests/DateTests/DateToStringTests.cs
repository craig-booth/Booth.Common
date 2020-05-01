using System;
using System.Collections.Generic;
using System.Globalization;

using Xunit;
using FluentAssertions;

namespace Booth.Common.Tests.DateTests
{
    public class DateToStringTests
    {

        [Fact]
        public void ToLongDateString()
        {
            var date = new Date(2019, 11, 19);
            var dateTime = new DateTime(2019, 11, 19);

            var result = date.ToLongDateString();

            result.Should().Be(dateTime.ToLongDateString());
        }

        [Fact]
        public void ToShortDateString()
        {
            var date = new Date(2019, 11, 19);
            var dateTime = new DateTime(2019, 11, 19);

            var result = date.ToShortDateString();

            result.Should().Be(dateTime.ToShortDateString());
        }

        [Fact]
        public void ToStringProviderFormat()
        {      
            var date = new Date(2019, 11, 19);
            var dateTime = new DateTime(2019, 11, 19);
            var format = "yyyy-MM-dd";
            var provider = CultureInfo.CurrentCulture;

            var result = date.ToString(format, provider);

            result.Should().Be(dateTime.ToString(format, provider));
        }

        [Fact]
        public void ToStringFormat()
        {
            var date = new Date(2019, 11, 19);
            var dateTime = new DateTime(2019, 11, 19);
            var format = "yyyy-MM-dd";

            var result = date.ToString(format);

            result.Should().Be(dateTime.Date.ToString(format));
        }

        [Fact]
        public void ToStringProvider()
        {
            var date = new Date(2019, 11, 19);
            var dateTime = new DateTime(2019, 11, 19);
            var provider = CultureInfo.CurrentCulture;

            var result = date.ToString(provider);

            result.Should().Be(dateTime.Date.ToString(provider));
        }

        [Fact]
        public void DateToString()
        {
            var date = new Date(2019, 11, 19);
            var dateTime = new DateTime(2019, 11, 19);

            var result = date.ToString();

            result.Should().Be(dateTime.Date.ToString(dateTime.Date.ToShortDateString()));
        }

    }
}
