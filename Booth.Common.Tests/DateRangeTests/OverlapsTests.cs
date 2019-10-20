using System;
using NUnit.Framework;

using Booth.Common;

namespace Booth.Common.Tests.DateRangeTests
{
    class OverlapsTests
    {
        [TestCase]
        public void WhollyBefore()
        {
            var dateRange = new DateRange(new DateTime(2000, 01, 01), new DateTime(2000, 01, 31));

            var testRange = new DateRange(new DateTime(1999, 01, 01), new DateTime(1999, 07, 01));

            Assert.That(testRange.Overlaps(dateRange), Is.Not.True);
        }

        [TestCase]
        public void BeforeWithEndDateMatchingStartDate()
        {
            var dateRange = new DateRange(new DateTime(2000, 01, 01), new DateTime(2000, 01, 31));

            var testRange = new DateRange(new DateTime(1999, 01, 01), new DateTime(2000, 01, 01));

            Assert.That(testRange.Overlaps(dateRange), Is.True);
        }

        [TestCase]
        public void PartiallyBefore()
        {
            var dateRange = new DateRange(new DateTime(2000, 01, 01), new DateTime(2000, 01, 31));

            var testRange = new DateRange(new DateTime(1999, 01, 01), new DateTime(2000, 01, 12));

            Assert.That(testRange.Overlaps(dateRange), Is.True);
        }

        [TestCase]
        public void WithinWithMatchingStartDate()
        {
            var dateRange = new DateRange(new DateTime(2000, 01, 01), new DateTime(2000, 01, 31));

            var testRange = new DateRange(new DateTime(2000, 01, 01), new DateTime(2000, 01, 12));

            Assert.That(testRange.Overlaps(dateRange), Is.True);
        }

        [TestCase]
        public void WhollyWithin()
        {
            var dateRange = new DateRange(new DateTime(2000, 01, 01), new DateTime(2000, 01, 31));

            var testRange = new DateRange(new DateTime(2000, 01, 05), new DateTime(2000, 01, 12));

            Assert.That(testRange.Overlaps(dateRange), Is.True);
        }

        [TestCase]
        public void WithinWithMatchingEndDate()
        {
            var dateRange = new DateRange(new DateTime(2000, 01, 01), new DateTime(2000, 01, 31));

            var testRange = new DateRange(new DateTime(2000, 01, 05), new DateTime(2000, 01, 31));

            Assert.That(testRange.Overlaps(dateRange), Is.True);
        }

        [TestCase]
        public void PartiallyAfter()
        {
            var dateRange = new DateRange(new DateTime(2000, 01, 01), new DateTime(2000, 01, 31));

            var testRange = new DateRange(new DateTime(2000, 01, 05), new DateTime(2000, 03, 01));

            Assert.That(testRange.Overlaps(dateRange), Is.True);
        }

        [TestCase]
        public void AfterWithStartDateMatchingEndDate()
        {
            var dateRange = new DateRange(new DateTime(2000, 01, 01), new DateTime(2000, 01, 31));

            var testRange = new DateRange(new DateTime(2000, 01, 01), new DateTime(2000, 03, 01));

            Assert.That(testRange.Overlaps(dateRange), Is.True);
        }

        [TestCase]
        public void WhollyAfter()
        {
            var dateRange = new DateRange(new DateTime(2000, 01, 01), new DateTime(2000, 01, 31));

            var testRange = new DateRange(new DateTime(2000, 02, 15), new DateTime(2000, 03, 01));

            Assert.That(testRange.Overlaps(dateRange), Is.Not.True);
        }

        [TestCase]
        public void WhollyOverlaps()
        {
            var dateRange = new DateRange(new DateTime(2000, 01, 01), new DateTime(2000, 01, 31));

            var testRange = new DateRange(new DateTime(1999, 07, 30), new DateTime(2000, 03, 01));

            Assert.That(testRange.Overlaps(dateRange), Is.True);
        }

        [TestCase]
        public void Same()
        {
            var dateRange = new DateRange(new DateTime(2000, 01, 01), new DateTime(2000, 01, 31));

            var testRange = new DateRange(new DateTime(2000, 01, 01), new DateTime(2000, 01, 31));

            Assert.That(testRange.Overlaps(dateRange), Is.True);
        }

    }
}
