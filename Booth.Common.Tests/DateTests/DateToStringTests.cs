using System;
using System.Collections.Generic;
using System.Globalization;

using NUnit.Framework;

namespace Booth.Common.Tests.DateTests
{
    class DateToStringTests
    {

        [TestCase]
        public void ToLongDateStringTest()
        {
            var date = new Date(2019, 11, 19);
            var dateTime = new DateTime(2019, 11, 19);

            Assert.That(date.ToLongDateString(), Is.EqualTo(dateTime.ToLongDateString()));
        }

        [TestCase]
        public void ToShortDateStringTest()
        {
            var date = new Date(2019, 11, 19);
            var dateTime = new DateTime(2019, 11, 19);

            Assert.That(date.ToShortDateString(), Is.EqualTo(dateTime.ToShortDateString()));
        }

        [TestCase]
        public void ToStringProviderFormatTest()
        {
            var date = new Date(2019, 11, 19);
            var dateTime = new DateTime(2019, 11, 19);

            var format = "yyyy-MM-dd";
            var provider = CultureInfo.CurrentCulture;

            Assert.That(date.ToString(format, provider), Is.EqualTo(dateTime.ToString(format, provider)));
        }

        [TestCase]
        public void ToStringFormatTest()
        {
            var date = new Date(2019, 11, 19);
            var dateTime = new DateTime(2019, 11, 19);

            var format = "yyyy-MM-dd";

            Assert.That(date.ToString(format), Is.EqualTo(dateTime.Date.ToString(format)));
        }

        [TestCase]
        public void ToStringProviderTest()
        {
            var date = new Date(2019, 11, 19);
            var dateTime = new DateTime(2019, 11, 19);

            var provider = CultureInfo.CurrentCulture;

            Assert.That(date.ToString(provider), Is.EqualTo(dateTime.Date.ToString(provider)));
        }

        [TestCase]
        public void ToStringTest()
        {
            var date = new Date(2019, 11, 19);
            var dateTime = new DateTime(2019, 11, 19);

            Assert.That(date.ToString(), Is.EqualTo(dateTime.Date.ToShortDateString()));
        }

    }
}
