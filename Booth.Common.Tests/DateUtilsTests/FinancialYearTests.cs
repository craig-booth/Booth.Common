using System;

using NUnit.Framework;
using FluentAssertions;

namespace Booth.Common.Tests.DateUtilsTests
{
    class FinancialYearTests
    {
        [TestCase]
        public void Before30June()
        {
            var date = new Date(2000, 04, 01);

            date.FinancialYear().Should().Be(2000);
        }

        [TestCase]
        public void On30June()
        {
            var date = new Date(2000, 06, 30);

            date.FinancialYear().Should().Be(2000);
        }

        [TestCase]
        public void After30June()
        {
            var date = new Date(2000, 09, 01);

            date.FinancialYear().Should().Be(2001);
        }

        [TestCase]
        public void DateRangeForFinancialYear()
        {
            var dateRange = new DateRange(new Date(1999, 07, 01), new Date(2000, 06, 30));

            DateUtils.FinancialYear(2000).Should().Be(dateRange);
        }

        [TestCase]
        public void FirstDayOfFinancialYear()
        {
            var date = new Date(1999, 07, 01);

            DateUtils.StartOfFinancialYear(2000).Should().Be(date);
        }

        [TestCase]
        public void LastDayOfFinancialYear()
        {
            var date = new Date(2000, 06, 30);

            DateUtils.EndOfFinancialYear(2000).Should().Be(date);
        }
    }
}
