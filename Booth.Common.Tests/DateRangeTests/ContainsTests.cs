﻿using System;

using Xunit;
using FluentAssertions;

using Booth.Common;

namespace Booth.Common.Tests.DateRangeTests
{
    public class ContainsTests
    {
        [Fact]
        public void BeforeRange()
        {
            var dateRange = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));

            var testDate = new Date(1999, 12, 07);
            var result = dateRange.Contains(testDate);

            result.Should().BeFalse();
        }

        [Fact]
        public void FirstDayOfRange()
        {
            var dateRange = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));

            var testDate = new Date(2000, 01, 01);
            var result = dateRange.Contains(testDate);

            result.Should().BeTrue();
        }

        [Fact]
        public void InRange()
        {
            var dateRange = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));

            var testDate = new Date(2000, 01, 15);
            var result = dateRange.Contains(testDate);

            result.Should().BeTrue();
        }

        [Fact]
        public void LastDayOfRange()
        {
            var dateRange = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));

            var testDate = new Date(2000, 01, 31);
            var result = dateRange.Contains(testDate);

            result.Should().BeTrue();
        }

        [Fact]
        public void AfterRange()
        {
            var dateRange = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));

            var testDate = new Date(2002, 03, 01);
            var result = dateRange.Contains(testDate);

            result.Should().BeFalse();
        }
    }
}
