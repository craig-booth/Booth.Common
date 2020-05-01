using System;
using System.Collections.Generic;
using System.Globalization;

using NUnit.Framework;
using FluentAssertions;

namespace Booth.Common.Tests.DateTests
{
    class DateToStringTests
    {

        [TestCase]
        public void ToLongDateString()
        {
            var date = new Date(2019, 11, 19);
            var dateTime = new DateTime(2019, 11, 19);

            var result = date.ToLongDateString();

            result.Should().Be(dateTime.ToLongDateString());
        }

        [TestCase]
        public void ToShortDateString()
        {
            var date = new Date(2019, 11, 19);
            var dateTime = new DateTime(2019, 11, 19);

            var result = date.ToShortDateString();

            result.Should().Be(dateTime.ToShortDateString());
        }

        [TestCase]
        public void ToStringProviderFormat()
        {      
            var date = new Date(2019, 11, 19);
            var dateTime = new DateTime(2019, 11, 19);
            var format = "yyyy-MM-dd";
            var provider = CultureInfo.CurrentCulture;

            var result = date.ToString(format, provider);

            result.Should().Be(dateTime.ToString(format, provider));
        }

        [TestCase]
        public void ToStringFormat()
        {
            var date = new Date(2019, 11, 19);
            var dateTime = new DateTime(2019, 11, 19);
            var format = "yyyy-MM-dd";

            var result = date.ToString(format);

            result.Should().Be(dateTime.Date.ToString(format));
        }

        [TestCase]
        public void ToStringProvider()
        {
            var date = new Date(2019, 11, 19);
            var dateTime = new DateTime(2019, 11, 19);
            var provider = CultureInfo.CurrentCulture;

            var result = date.ToString(provider);

            result.Should().Be(dateTime.Date.ToString(provider));
        }

        [TestCase]
        public void DateToString()
        {
            var date = new Date(2019, 11, 19);
            var dateTime = new DateTime(2019, 11, 19);

            var result = date.ToString();

            result.Should().Be(dateTime.Date.ToString(dateTime.Date.ToShortDateString()));
        }

    }
}
