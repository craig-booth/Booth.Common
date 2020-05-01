using System;

using Xunit;
using FluentAssertions;

using Booth.Common;

namespace Booth.Common.Tests.DateRangeTests
{
    public class OverlapsTests
    {
        [Fact]
        public void WhollyBefore()
        {
            var dateRange = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var testRange = new DateRange(new Date(1999, 01, 01), new Date(1999, 07, 01));

            var result = testRange.Overlaps(dateRange);

            result.Should().BeFalse();
        }

        [Fact]
        public void BeforeWithEndDateMatchingStartDate()
        {
            var dateRange = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var testRange = new DateRange(new Date(1999, 01, 01), new Date(2000, 01, 01));

            var result = testRange.Overlaps(dateRange);

            result.Should().BeTrue();
        }

        [Fact]
        public void PartiallyBefore()
        {
            var dateRange = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var testRange = new DateRange(new Date(1999, 01, 01), new Date(2000, 01, 12));

            var result = testRange.Overlaps(dateRange);

            result.Should().BeTrue();
        }

        [Fact]
        public void WithinWithMatchingStartDate()
        {
            var dateRange = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var testRange = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 12));

            var result = testRange.Overlaps(dateRange);

            result.Should().BeTrue();
        }

        [Fact]
        public void WhollyWithin()
        {
            var dateRange = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var testRange = new DateRange(new Date(2000, 01, 05), new Date(2000, 01, 12));

            var result = testRange.Overlaps(dateRange);

            result.Should().BeTrue();
        }

        [Fact]
        public void WithinWithMatchingEndDate()
        {
            var dateRange = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var testRange = new DateRange(new Date(2000, 01, 05), new Date(2000, 01, 31));

            var result = testRange.Overlaps(dateRange);

            result.Should().BeTrue();
        }

        [Fact]
        public void PartiallyAfter()
        {
            var dateRange = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var testRange = new DateRange(new Date(2000, 01, 05), new Date(2000, 03, 01));

            var result = testRange.Overlaps(dateRange);

            result.Should().BeTrue();
        }

        [Fact]
        public void AfterWithStartDateMatchingEndDate()
        {
            var dateRange = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var testRange = new DateRange(new Date(2000, 01, 01), new Date(2000, 03, 01));

            var result = testRange.Overlaps(dateRange);

            result.Should().BeTrue();
        }

        [Fact]
        public void WhollyAfter()
        {
            var dateRange = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var testRange = new DateRange(new Date(2000, 02, 15), new Date(2000, 03, 01));

            var result = testRange.Overlaps(dateRange);

            result.Should().BeFalse();
        }

        [Fact]
        public void WhollyOverlaps()
        {
            var dateRange = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var testRange = new DateRange(new Date(1999, 07, 30), new Date(2000, 03, 01));

            var result = testRange.Overlaps(dateRange);

            result.Should().BeTrue();
        }

        [Fact]
        public void Same()
        {
            var dateRange = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var testRange = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));

            var result = testRange.Overlaps(dateRange);

            result.Should().BeTrue();
        }

    }
}
