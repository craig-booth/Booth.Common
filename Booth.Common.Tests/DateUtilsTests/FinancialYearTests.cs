using System;
using NUnit.Framework;

namespace Booth.Common.Tests.DateUtilsTests
{
    class FinancialYearTests
    {
        [TestCase]
        public void Before30June()
        {
            var date = new DateTime(2000, 04, 01);

            Assert.That(date.FinancialYear(), Is.EqualTo(2000));
        }

        [TestCase]
        public void On30June()
        {
            var date = new DateTime(2000, 06, 30);

            Assert.That(date.FinancialYear(), Is.EqualTo(2000));
        }

        [TestCase]
        public void After30June()
        {
            var date = new DateTime(2000, 09, 01);

            Assert.That(date.FinancialYear(), Is.EqualTo(2001));
        }

        [TestCase]
        public void DateRangeForFinancialYear()
        {
            var dateRange = new DateRange(new DateTime(1999, 07, 01), new DateTime(2000, 06, 30));

            Assert.That(DateUtils.FinancialYear(2000), Is.EqualTo(dateRange));
        }

        [TestCase]
        public void FirstDayOfFinancialYear()
        {
            var date = new DateTime(1999, 07, 01);

            Assert.That(DateUtils.StartOfFinancialYear(2000), Is.EqualTo(date));
        }

        [TestCase]
        public void LastDayOfFinancialYear()
        {
            var date = new DateTime(2000, 06, 30);

            Assert.That(DateUtils.EndOfFinancialYear(2000), Is.EqualTo(date));
        }
    }
}
