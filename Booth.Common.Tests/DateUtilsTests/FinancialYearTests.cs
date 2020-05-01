using System;

using Xunit;
using FluentAssertions;

namespace Booth.Common.Tests.DateUtilsTests
{
    public class FinancialYearTests
    {
        [Fact]
        public void Before30June()
        {
            var date = new Date(2000, 04, 01);

            date.FinancialYear().Should().Be(2000);
        }

        [Fact]
        public void On30June()
        {
            var date = new Date(2000, 06, 30);

            date.FinancialYear().Should().Be(2000);
        }

        [Fact]
        public void After30June()
        {
            var date = new Date(2000, 09, 01);

            date.FinancialYear().Should().Be(2001);
        }

        [Fact]
        public void DateRangeForFinancialYear()
        {
            var dateRange = new DateRange(new Date(1999, 07, 01), new Date(2000, 06, 30));

            DateUtils.FinancialYear(2000).Should().Be(dateRange);
        }

        [Fact]
        public void FirstDayOfFinancialYear()
        {
            var date = new Date(1999, 07, 01);

            DateUtils.StartOfFinancialYear(2000).Should().Be(date);
        }

        [Fact]
        public void LastDayOfFinancialYear()
        {
            var date = new Date(2000, 06, 30);

            DateUtils.EndOfFinancialYear(2000).Should().Be(date);
        }
    }
}
