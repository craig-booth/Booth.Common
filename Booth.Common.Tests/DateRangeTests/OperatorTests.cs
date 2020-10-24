using System;

using Xunit;
using FluentAssertions;

using Booth.Common;

namespace Booth.Common.Tests.DateRangeTests
{
    public class OperatorTests
    {
        [Fact]
        public void EqualOperatorBothDatesTheSame()
        {
            var dateRange1 = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var dateRange2 = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));

            var result = dateRange1 == dateRange2;

            result.Should().BeTrue();
        }

        [Fact]
        public void EqualOperatorOnlyStartDateTheSame()
        {
            var dateRange1 = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var dateRange2 = new DateRange(new Date(2000, 01, 01), new Date(2002, 01, 31));

            var result = dateRange1 == dateRange2;

            result.Should().BeFalse();
        }

        [Fact]
        public void EqualOperatorOnlyEndDateTheSame()
        {
            var dateRange1 = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var dateRange2 = new DateRange(new Date(2000, 01, 03), new Date(2000, 01, 31));

            var result = dateRange1 == dateRange2;

            result.Should().BeFalse();
        }

        [Fact]
        public void EqualOperatorBothDateDifferent()
        {
            var dateRange1 = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var dateRange2 = new DateRange(new Date(2002, 01, 03), new Date(2002, 01, 31));

            var result = dateRange1 == dateRange2;

            result.Should().BeFalse();
        }

        [Fact]
        public void NotEqualOperatorBothDatesTheSame()
        {
            var dateRange1 = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var dateRange2 = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));

            var result = dateRange1 != dateRange2;

            result.Should().BeFalse();
        }

        [Fact]
        public void NotEqualOperatorOnlyStartDateTheSame()
        {
            var dateRange1 = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var dateRange2 = new DateRange(new Date(2000, 01, 01), new Date(2002, 01, 31));

            var result = dateRange1 != dateRange2;

            result.Should().BeTrue();
        }

        [Fact]
        public void NotEqualOperatorOnlyEndDateTheSame()
        {
            var dateRange1 = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var dateRange2 = new DateRange(new Date(2000, 01, 03), new Date(2000, 01, 31));

            var result = dateRange1 != dateRange2;

            result.Should().BeTrue();
        }

        [Fact]
        public void NotEqualOperatorBothDateDifferent()
        {
            var dateRange1 = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var dateRange2 = new DateRange(new Date(2002, 01, 03), new Date(2002, 01, 31));

            var result = dateRange1 != dateRange2;

            result.Should().BeTrue();
        }
    }
}
