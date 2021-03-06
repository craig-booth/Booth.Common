﻿using System;

using Xunit;
using FluentAssertions;

namespace Booth.Common.Tests.DateRangeTests
{
    public class GeneralTests
    {
        [Fact]
        public void Create()
        {
            var fromDate = new Date(2000, 01, 01);
            var toDate = new Date(2000, 01, 31);

            var dateRange = new DateRange(fromDate, toDate);

            dateRange.Should().BeEquivalentTo(new { FromDate = fromDate, ToDate = toDate });
        }

        [Fact]
        public void FromDateAfterToDate()
        {
            var fromDate = new Date(2000, 01, 01);
            var toDate = new Date(2000, 01, 31);

            Action a = () => new DateRange(toDate, fromDate);

            a.Should().ThrowExactly<ArgumentException>();
        }

    }
}
