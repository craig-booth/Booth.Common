using System;
using NUnit.Framework;

using Booth.Common;

namespace Booth.Common.Tests.DateRangeTests
{
    class ContainsTests
    {
            [TestCase]
            public void BeforeRange()
            {
                var dateRange = new DateRange(new DateTime(2000, 01, 01), new DateTime(2000, 01, 31));

                var testDate = new DateTime(1999, 12, 07);

                Assert.That(dateRange.Contains(testDate), Is.Not.True);
            }

            [TestCase]
            public void FirstDayOfRange()
            {
                var dateRange = new DateRange(new DateTime(2000, 01, 01), new DateTime(2000, 01, 31));

                var testDate = new DateTime(2000, 01, 01);

                Assert.That(dateRange.Contains(testDate), Is.True);
            }

            [TestCase]
            public void InRange()
            {
                var dateRange = new DateRange(new DateTime(2000, 01, 01), new DateTime(2000, 01, 31));

                var testDate = new DateTime(2000, 01, 15);

                Assert.That(dateRange.Contains(testDate), Is.True);
            }

            [TestCase]
            public void LastDayOfRange()
            {
                var dateRange = new DateRange(new DateTime(2000, 01, 01), new DateTime(2000, 01, 31));

                var testDate = new DateTime(2000, 01, 31);

                Assert.That(dateRange.Contains(testDate), Is.True);
            }

            [TestCase]
            public void AfterRange()
            {
                var dateRange = new DateRange(new DateTime(2000, 01, 01), new DateTime(2000, 01, 31));

                var testDate = new DateTime(2002, 03, 01);

                Assert.That(dateRange.Contains(testDate), Is.Not.True);
            }
    }
}
