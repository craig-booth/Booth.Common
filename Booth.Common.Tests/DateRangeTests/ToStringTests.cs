using System;
using System.Globalization;
using System.Threading;

using NUnit.Framework;
using FluentAssertions;

namespace Booth.Common.Tests.DateRangeTests
{
    class ToStringTests
    {
        [TestCase]
        public void ToStringCorrect()
        {
            // For the test ensure that the date format is in Australian format
            var savedCulture = Thread.CurrentThread.CurrentCulture;
            var testCulture = new CultureInfo("en-AU");
            testCulture.DateTimeFormat.ShortDatePattern = "d/MM/yyyy";
            Thread.CurrentThread.CurrentCulture = testCulture;

            var dateRange = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var result = dateRange.ToString();

            result.Should().Be("1/01/2000 - 31/01/2000");

            Thread.CurrentThread.CurrentCulture = savedCulture;
        }
    }
}
    
