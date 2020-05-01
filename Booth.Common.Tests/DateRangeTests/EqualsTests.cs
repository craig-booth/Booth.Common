using System;

using NUnit.Framework;
using FluentAssertions;

namespace Booth.Common.Tests.DateRangeTests
{
    class EqualsTests
    {
        [TestCase]
        public void IsEqual()
        {
            var dateRange1 = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var dateRange2 = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));

            var result = dateRange1.Equals(dateRange2);

            result.Should().BeTrue();
        }

        [TestCase]
        public void IsNotEqual()
        {
            var dateRange1 = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var dateRange2 = new DateRange(new Date(2002, 01, 01), new Date(2002, 01, 31));

            var result = dateRange1.Equals(dateRange2);

            result.Should().BeFalse();
        }

        [TestCase]
        public void IsDifferentObjectType()
        {
            var dateRange1 = new DateRange(new Date(2000, 01, 01), new Date(2000, 01, 31));
            var date = new DateTime(2000, 01, 01);

            var result = dateRange1.Equals(date);

            result.Should().BeFalse();
        }
    }
}
