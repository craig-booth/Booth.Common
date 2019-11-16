using System;
using System.Globalization;
using System.Threading;
using NUnit.Framework;

namespace Booth.Common.Tests.DateRangeTests
{
    class ToStringTests
    {
        [TestCase]
        public void ToStringCorrect()
        {
            // For the test ensure that the date format is in Australian format
            var savedCulture = Thread.CurrentThread.CurrentCulture;
            var testCulture = CultureInfo.CreateSpecificCulture("en-AU");
            Thread.CurrentThread.CurrentCulture = testCulture;

            Assert.That(testCulture.DateTimeFormat.ShortDatePattern, Is.EqualTo("d/M/yyy"));

            var dateRange = new DateRange(new DateTime(2000, 01, 01), new DateTime(2000, 01, 31));

            Assert.That(dateRange.ToString(), Is.EqualTo("1/01/2000 - 31/01/2000"));

            Thread.CurrentThread.CurrentCulture = savedCulture;
        }
    }
}
    
