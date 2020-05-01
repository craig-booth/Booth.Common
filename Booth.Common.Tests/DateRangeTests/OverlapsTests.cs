using System;

using NUnit.Framework;
using FluentAssertions;

using Booth.Common;

namespace Booth.Common.Tests.DateRangeTests
{
    class OverlapsTests
    {
        [TestCase]
        public void WhollyBefore()
        {
            var dateRange = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var testRange = new DateRange(new Date(1999, 01, 01), new Date(1999, 07, 01));

            var result = testRange.Overlaps(dateRange);

            result.Should().BeFalse();
        }

        [TestCase]
        public void BeforeWithEndDateMatchingStartDate()
        {
            var dateRange = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var testRange = new DateRange(new Date(1999, 01, 01), new Date(2000, 01, 01));

            var result = testRange.Overlaps(dateRange);

            result.Should().BeTrue();
        }

        [TestCase]
        public void PartiallyBefore()
        {
            var dateRange = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var testRange = new DateRange(new Date(1999, 01, 01), new Date(2000, 01, 12));

            var result = testRange.Overlaps(dateRange);

            result.Should().BeTrue();
        }

        [TestCase]
        public void WithinWithMatchingStartDate()
        {
            var dateRange = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var testRange = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 12));

            var result = testRange.Overlaps(dateRange);

            result.Should().BeTrue();
        }

        [TestCase]
        public void WhollyWithin()
        {
            var dateRange = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var testRange = new DateRange(new Date(2000, 01, 05), new Date(2000, 01, 12));

            var result = testRange.Overlaps(dateRange);

            result.Should().BeTrue();
        }

        [TestCase]
        public void WithinWithMatchingEndDate()
        {
            var dateRange = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var testRange = new DateRange(new Date(2000, 01, 05), new Date(2000, 01, 31));

            var result = testRange.Overlaps(dateRange);

            result.Should().BeTrue();
        }

        [TestCase]
        public void PartiallyAfter()
        {
            var dateRange = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var testRange = new DateRange(new Date(2000, 01, 05), new Date(2000, 03, 01));

            var result = testRange.Overlaps(dateRange);

            result.Should().BeTrue();
        }

        [TestCase]
        public void AfterWithStartDateMatchingEndDate()
        {
            var dateRange = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var testRange = new DateRange(new Date(2000, 01, 01), new Date(2000, 03, 01));

            var result = testRange.Overlaps(dateRange);

            result.Should().BeTrue();
        }

        [TestCase]
        public void WhollyAfter()
        {
            var dateRange = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var testRange = new DateRange(new Date(2000, 02, 15), new Date(2000, 03, 01));

            var result = testRange.Overlaps(dateRange);

            result.Should().BeFalse();
        }

        [TestCase]
        public void WhollyOverlaps()
        {
            var dateRange = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var testRange = new DateRange(new Date(1999, 07, 30), new Date(2000, 03, 01));

            var result = testRange.Overlaps(dateRange);

            result.Should().BeTrue();
        }

        [TestCase]
        public void Same()
        {
            var dateRange = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var testRange = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));

            var result = testRange.Overlaps(dateRange);

            result.Should().BeTrue();
        }

    }
}
