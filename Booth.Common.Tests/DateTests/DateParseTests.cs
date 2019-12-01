using System;
using System.Collections.Generic;
using System.Globalization;
using NUnit.Framework;

namespace Booth.Common.Tests.DateTests
{
    class DateParseTests
    {

        [TestCase("2018-08-18")]
        [TestCase("Sat, 18 Aug 2018 07:22:16 GMT")]
        public void ParseTest(string s)
        {
            Assert.That(Date.Parse(s), Is.EqualTo(new Date(2018, 08, 18)));
        }

        [TestCase("2018-08-18", "yyyy-MM-dd")]
        [TestCase("18/8/2018", "dd/M/yyyy")]
        [TestCase("18/8/18", "dd/M/yy")]
        [TestCase("18/08/2018 07:22:16", "dd/MM/yyyy hh:mm:ss")]
        public void ParseExactTest(string s, string format)
        {
            Assert.That(Date.ParseExact(s, format, CultureInfo.CurrentCulture, DateTimeStyles.None), Is.EqualTo(new Date(2018, 08, 18)));
        }

        [TestCase("2018-08-18", true)]
        [TestCase("Sat, 18 Aug 2018 07:22:16 GMT", true)]
        public void TryParseTest(string s, bool successful)
        {
            var result = Date.TryParse(s, out var resultDate);
            Assert.That(result, Is.EqualTo(successful));
            if (successful)
                Assert.That(resultDate, Is.EqualTo(new Date(2018, 08, 18)));
        }

        [TestCase("2018-08-18", "yyyy-MM-dd", true)]
        [TestCase("18/8/2018", "dd/M/yyyy", true)]
        [TestCase("18/8/18", "dd/M/yy", true)]
        [TestCase("18/08/2018 07:22:16", "dd/MM/yyyy hh:mm:ss", true)]
        public void TryParseExactTest(string s, string format, bool successful)
        {
            var result = Date.TryParseExact(s, format, CultureInfo.CurrentCulture, DateTimeStyles.None, out var resultDate);
            Assert.That(result, Is.EqualTo(successful));
            if (successful)
                Assert.That(resultDate, Is.EqualTo(new Date(2018, 08, 18)));
        }

    }
}
