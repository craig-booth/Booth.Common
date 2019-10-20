using System;
using NUnit.Framework;

namespace Booth.Common.Tests.DateRangeTests
{
    class EqualsTests
    {
        [TestCase]
        public void IsEqual()
        {
            var dateRange1 = new DateRange(new DateTime(2000, 01, 01), new DateTime(2000, 01, 31));
            var dateRange2 = new DateRange(new DateTime(2000, 01, 01), new DateTime(2000, 01, 31));

            Assert.That(dateRange1.Equals(dateRange2), Is.True);
        }

        [TestCase]
        public void IsNotEqual()
        {
            var dateRange1 = new DateRange(new DateTime(2000, 01, 01), new DateTime(2000, 01, 31));
            var dateRange2 = new DateRange(new DateTime(2002, 01, 01), new DateTime(2002, 01, 31));

            Assert.That(dateRange1.Equals(dateRange2), Is.Not.True);
        }

        [TestCase]
        public void IsDifferentObjectType()
        {
            var dateRange1 = new DateRange(new DateTime(2000, 01, 01), new DateTime(2000, 01, 31));
            var date = new DateTime(2000, 01, 01);

            Assert.That(dateRange1.Equals(date), Is.Not.True);
        }
    }
}
