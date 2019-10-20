using System;
using NUnit.Framework;

using Booth.Common;

namespace Booth.Common.Tests.DateRangeTests
{
    class OperatorTests
    {
        [TestCase]
        public void EqualOperatorBothDatesTheSame()
        {
            var dateRange1 = new DateRange(new DateTime(2000, 01, 01), new DateTime(2000, 01, 31));
            var dateRange2 = new DateRange(new DateTime(2000, 01, 01), new DateTime(2000, 01, 31));

            Assert.That(dateRange1 == dateRange2, Is.True);
        }

        [TestCase]
        public void EqualOperatorOnlyStartDateTheSame()
        {
            var dateRange1 = new DateRange(new DateTime(2000, 01, 01), new DateTime(2000, 01, 31));
            var dateRange2 = new DateRange(new DateTime(2000, 01, 01), new DateTime(2002, 01, 31));

            Assert.That(dateRange1 == dateRange2, Is.Not.True);
        }

        [TestCase]
        public void EqualOperatorOnlyEndDateTheSame()
        {
            var dateRange1 = new DateRange(new DateTime(2000, 01, 01), new DateTime(2000, 01, 31));
            var dateRange2 = new DateRange(new DateTime(2000, 01, 03), new DateTime(2000, 01, 31));

            Assert.That(dateRange1 == dateRange2, Is.Not.True);
        }

        [TestCase]
        public void EqualOperatorBothDateDifferent()
        {
            var dateRange1 = new DateRange(new DateTime(2000, 01, 01), new DateTime(2000, 01, 31));
            var dateRange2 = new DateRange(new DateTime(2002, 01, 03), new DateTime(2002, 01, 31));

            Assert.That(dateRange1 == dateRange2, Is.Not.True);
        }

        [TestCase]
        public void NotEqualOperatorBothDatesTheSame()
        {
            var dateRange1 = new DateRange(new DateTime(2000, 01, 01), new DateTime(2000, 01, 31));
            var dateRange2 = new DateRange(new DateTime(2000, 01, 01), new DateTime(2000, 01, 31));

            Assert.That(dateRange1 != dateRange2, Is.Not.True);
        }

        [TestCase]
        public void NotEqualOperatorOnlyStartDateTheSame()
        {
            var dateRange1 = new DateRange(new DateTime(2000, 01, 01), new DateTime(2000, 01, 31));
            var dateRange2 = new DateRange(new DateTime(2000, 01, 01), new DateTime(2002, 01, 31));

            Assert.That(dateRange1 != dateRange2, Is.True);
        }

        [TestCase]
        public void NotEqualOperatorOnlyEndDateTheSame()
        {
            var dateRange1 = new DateRange(new DateTime(2000, 01, 01), new DateTime(2000, 01, 31));
            var dateRange2 = new DateRange(new DateTime(2000, 01, 03), new DateTime(2000, 01, 31));

            Assert.That(dateRange1 != dateRange2, Is.True);
        }

        [TestCase]
        public void NotEqualOperatorBothDateDifferent()
        {
            var dateRange1 = new DateRange(new DateTime(2000, 01, 01), new DateTime(2000, 01, 31));
            var dateRange2 = new DateRange(new DateTime(2002, 01, 03), new DateTime(2002, 01, 31));

            Assert.That(dateRange1 != dateRange2, Is.True);
        }
    }
}
