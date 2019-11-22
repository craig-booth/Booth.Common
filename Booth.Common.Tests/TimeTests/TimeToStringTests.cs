using System;
using System.Globalization;

using NUnit.Framework;

namespace Booth.Common.Tests.TimeTests
{
    class TimeToStringTests
    {
        [TestCase]
        public void ToStringProviderFormatTest()
        {
            var time = new Time(14, 02, 24);
            var dateTime = new DateTime(2019, 11, 19, 14, 02, 24);

            var format = @"hh\:mm\:ss";
            var provider = CultureInfo.CurrentCulture;

            Assert.That(time.ToString(format, provider), Is.EqualTo(dateTime.ToString(format, provider)));
        }

        [TestCase]
        public void ToStringFormatTest()
        {
            var time = new Time(14, 02, 24);
            var dateTime = new DateTime(2019, 11, 19, 14, 02, 24);

            var format = @"hh\:mm\:ss";

            Assert.That(time.ToString(format), Is.EqualTo(dateTime.ToString(format)));
        }

        [TestCase]
        public void ToStringTest()
        {
            var time = new Time(14, 02, 24);
            var dateTime = new DateTime(2019, 11, 19, 14, 02, 24);

            Assert.That(time.ToString(), Is.EqualTo("14:02:24"));
        }
    }
}
