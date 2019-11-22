using System;
using System.Linq;

using NUnit.Framework;

namespace Booth.Common.Tests.DateUtilsTests
{
    class EnumerableTests
    {
        [TestCase]
        public void DaysBetweenDatesTest()
        {
            var startDate = new Date(2000, 02, 25);
            var endDate = new Date(2000, 03, 15);

            var days = DateUtils.Days(startDate, endDate).ToList();

            Assert.That(days.First(), Is.EqualTo(startDate));
            Assert.That(days, Has.Count.EqualTo(20).And.Unique.And.Ordered);
        }

        [TestCase]
        public void DaysInRangeTest()
        {
            var startDate = new Date(2000, 02, 25);
            var endDate = new Date(2000, 03, 15);

            var days = DateUtils.Days(new DateRange(startDate, endDate)).ToList();

            Assert.That(days.First(), Is.EqualTo(startDate));
            Assert.That(days, Has.Count.EqualTo(20).And.Unique.And.Ordered);
        }

        [TestCase]
        public void WeekEndingDaysBetweenDatesTest()
        {
            var startDate = new Date(2000, 01, 01);
            var endDate = new Date(2000, 03, 31);

            var days = DateUtils.WeekEndingDays(startDate, endDate).ToList();

            Assert.That(days.First(), Is.EqualTo(new Date(2000, 01, 02)));
            Assert.That(days.Select(x => x.DayOfWeek), Has.All.EqualTo(DayOfWeek.Sunday));
            Assert.That(days, Has.Count.EqualTo(13).And.Unique.And.Ordered);
        }

        [TestCase]
        public void WeekEndingDaysBetweenDatesFirstDaySundayTest()
        {
            var startDate = new Date(2000, 01, 02);
            var endDate = new Date(2000, 03, 31);

            var days = DateUtils.WeekEndingDays(startDate, endDate).ToList();

            Assert.That(days.First(), Is.EqualTo(new Date(2000, 01, 02)));
            Assert.That(days.Select(x => x.DayOfWeek), Has.All.EqualTo(DayOfWeek.Sunday));
            Assert.That(days, Has.Count.EqualTo(13).And.Unique.And.Ordered);
        }

        [TestCase]
        public void WeekEndingDaysBetweenDatesLastDaySundayTest()
        {
            var startDate = new Date(2000, 01, 01);
            var endDate = new Date(2000, 03, 26);

            var days = DateUtils.WeekEndingDays(startDate, endDate).ToList();

            Assert.That(days.First(), Is.EqualTo(new Date(2000, 01, 02)));
            Assert.That(days.Select(x => x.DayOfWeek), Has.All.EqualTo(DayOfWeek.Sunday));
            Assert.That(days, Has.Count.EqualTo(13).And.Unique.And.Ordered);
        }

        [TestCase]
        public void MonthEndingDaysBetweenDatesTest()
        {
            var startDate = new Date(2000, 01, 01);
            var endDate = new Date(2000, 12, 01);

            var days = DateUtils.MonthEndingDays(startDate, endDate).ToList();

            var expected = new Date[]
                {
                    new Date(2000, 01, 31),
                    new Date(2000, 02, 29),
                    new Date(2000, 03, 31),
                    new Date(2000, 04, 30),
                    new Date(2000, 05, 31),
                    new Date(2000, 06, 30),
                    new Date(2000, 07, 31),
                    new Date(2000, 08, 31),
                    new Date(2000, 09, 30),
                    new Date(2000, 10, 31),
                    new Date(2000, 11, 30)
                };

            Assert.That(days, Is.EqualTo(expected));
        }

        [TestCase]
        public void MonthEndingDaysBetweenDatesFirstDateAtEndOfMonthTest()
        {
            var startDate = new Date(2000, 01, 31);
            var endDate = new Date(2000, 12, 01);

            var days = DateUtils.MonthEndingDays(startDate, endDate).ToList();

            var expected = new Date[]
                {
                    new Date(2000, 01, 31),
                    new Date(2000, 02, 29),
                    new Date(2000, 03, 31),
                    new Date(2000, 04, 30),
                    new Date(2000, 05, 31),
                    new Date(2000, 06, 30),
                    new Date(2000, 07, 31),
                    new Date(2000, 08, 31),
                    new Date(2000, 09, 30),
                    new Date(2000, 10, 31),
                    new Date(2000, 11, 30)
                };

            Assert.That(days, Is.EqualTo(expected));
        }

        [TestCase]
        public void MonthEndingDaysBetweenDatesLastDateAtEndOfMonthTest()
        {
            var startDate = new Date(2000, 01, 01);
            var endDate = new Date(2000, 12, 31);

            var days = DateUtils.MonthEndingDays(startDate, endDate).ToList();

            var expected = new Date[]
                {
                    new Date(2000, 01, 31),
                    new Date(2000, 02, 29),
                    new Date(2000, 03, 31),
                    new Date(2000, 04, 30),
                    new Date(2000, 05, 31),
                    new Date(2000, 06, 30),
                    new Date(2000, 07, 31),
                    new Date(2000, 08, 31),
                    new Date(2000, 09, 30),
                    new Date(2000, 10, 31),
                    new Date(2000, 11, 30),
                    new Date(2000, 12, 31)
                };

            Assert.That(days, Is.EqualTo(expected));
        }
    }
}
