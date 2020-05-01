using System;

using NUnit.Framework;
using FluentAssertions;

using Booth.Common;

namespace Booth.Common.Tests.DateRangeTests
{
    class OperatorTests
    {
        [TestCase]
        public void EqualOperatorBothDatesTheSame()
        {
            var dateRange1 = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var dateRange2 = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));

            var result = dateRange1 == dateRange2;

            result.Should().BeTrue();
        }

        [TestCase]
        public void EqualOperatorOnlyStartDateTheSame()
        {
            var dateRange1 = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var dateRange2 = new DateRange(new Date(2000, 01, 01), new Date(2002, 01, 31));

            var result = dateRange1 == dateRange2;

            result.Should().BeFalse();
        }

        [TestCase]
        public void EqualOperatorOnlyEndDateTheSame()
        {
            var dateRange1 = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var dateRange2 = new DateRange(new Date(2000, 01, 03), new Date(2000, 01, 31));

            var result = dateRange1 == dateRange2;

            result.Should().BeFalse();
        }

        [TestCase]
        public void EqualOperatorBothDateDifferent()
        {
            var dateRange1 = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var dateRange2 = new DateRange(new Date(2002, 01, 03), new Date(2002, 01, 31));

            var result = dateRange1 == dateRange2;

            result.Should().BeFalse();
        }

        [TestCase]
        public void NotEqualOperatorBothDatesTheSame()
        {
            var dateRange1 = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var dateRange2 = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));

            var result = dateRange1 != dateRange2;

            result.Should().BeFalse();
        }

        [TestCase]
        public void NotEqualOperatorOnlyStartDateTheSame()
        {
            var dateRange1 = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var dateRange2 = new DateRange(new Date(2000, 01, 01), new Date(2002, 01, 31));

            var result = dateRange1 != dateRange2;

            result.Should().BeTrue();
        }

        [TestCase]
        public void NotEqualOperatorOnlyEndDateTheSame()
        {
            var dateRange1 = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var dateRange2 = new DateRange(new Date(2000, 01, 03), new Date(2000, 01, 31));

            var result = dateRange1 != dateRange2;

            result.Should().BeTrue();
        }

        [TestCase]
        public void NotEqualOperatorBothDateDifferent()
        {
            var dateRange1 = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var dateRange2 = new DateRange(new Date(2002, 01, 03), new Date(2002, 01, 31));

            var result = dateRange1 != dateRange2;

            result.Should().BeTrue();
        }
    }
}
