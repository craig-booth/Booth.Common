using System;
using NUnit.Framework;

namespace Booth.Common.Tests.DateRangeTests
{
    class GeneralTests
    {
        [TestCase]
        public void CreateTest()
        {
            var fromDate = new Date(2000, 01, 01);
            var toDate = new Date(2000, 01, 31);

            var dateRange = new DateRange(fromDate, toDate);

            Assert.Multiple(() =>
            {
                Assert.That(dateRange.FromDate, Is.EqualTo(fromDate));
                Assert.That(dateRange.ToDate, Is.EqualTo(toDate));
            });
        }

        [TestCase]
        public void FromDateAfterToDate()
        {
            var fromDate = new Date(2000, 01, 01);
            var toDate = new Date(2000, 01, 31);

            Assert.That(() => new DateRange(toDate, fromDate), Throws.ArgumentException);
        }

    }
}
