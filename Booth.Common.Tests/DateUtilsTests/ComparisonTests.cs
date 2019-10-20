using System;
using System.Collections;

using NUnit.Framework;

namespace Booth.Common.Tests.DateUtilsTests
{
    class ComparisonTests
    {
        [TestCaseSource(typeof(ComparisonTestsTestData), nameof(ComparisonTestsTestData.WeekDayData))]
        public bool WeekDayTests(DateTime date)
        {
            return date.WeekDay();
        }

        [TestCase]
        public void EarliestTestFirstDateEarlier()
        {
            var date1 = new DateTime(2000, 01, 01);
            var date2 = new DateTime(2002, 01, 01);

            Assert.That(DateUtils.Earlist(date1, date2), Is.EqualTo(date1));
        }

        [TestCase]
        public void EarliestTestLastDateEarlier()
        {
            var date1 = new DateTime(2000, 01, 01);
            var date2 = new DateTime(1999, 01, 01);

            Assert.That(DateUtils.Earlist(date1, date2), Is.EqualTo(date2));
        }

        [TestCase]
        public void EarliestTestSame()
        {
            var date1 = new DateTime(2000, 01, 01);
            var date2 = new DateTime(2000, 01, 01);

            Assert.That(DateUtils.Earlist(date1, date2), Is.EqualTo(date1));
        }

        [TestCase]
        public void LatestTestFirstDateEarlier()
        {
            var date1 = new DateTime(2000, 01, 01);
            var date2 = new DateTime(2002, 01, 01);

            Assert.That(DateUtils.Latest(date1, date2), Is.EqualTo(date2));
        }

        [TestCase]
        public void LatestTestLastDateEarlier()
        {
            var date1 = new DateTime(2000, 01, 01);
            var date2 = new DateTime(1999, 01, 01);

            Assert.That(DateUtils.Latest(date1, date2), Is.EqualTo(date1));
        }


        [TestCase]
        public void LatestTestSame()
        {
            var date1 = new DateTime(2000, 01, 01);
            var date2 = new DateTime(2000, 01, 01);

            Assert.That(DateUtils.Latest(date1, date2), Is.EqualTo(date1));
        }


        [TestCaseSource(typeof(ComparisonTestsTestData), nameof(ComparisonTestsTestData.EndOfWeekData))]
        public DateTime TestEndOfWeek(DateTime date)
        {
            return date.EndOfWeek();
        }

        [TestCaseSource(typeof(ComparisonTestsTestData), nameof(ComparisonTestsTestData.EndOfMonthData))]
        public static DateTime EndOfMonth(DateTime date)
        {
            return date.EndOfMonth();
        } 
    }

    class ComparisonTestsTestData
    {
        public static IEnumerable WeekDayData
        {
            get
            {
                yield return new TestCaseData(new DateTime(2019, 10, 07)).Returns(true).SetName("WeekdayMonday");
                yield return new TestCaseData(new DateTime(2019, 10, 08)).Returns(true).SetName("WeekdayTuesday");
                yield return new TestCaseData(new DateTime(2019, 10, 09)).Returns(true).SetName("WeekdayWednesday");
                yield return new TestCaseData(new DateTime(2019, 10, 10)).Returns(true).SetName("WeekdayThursday");
                yield return new TestCaseData(new DateTime(2019, 10, 11)).Returns(true).SetName("WeekdayFriday");
                yield return new TestCaseData(new DateTime(2019, 10, 12)).Returns(false).SetName("WeekdaySaturday");
                yield return new TestCaseData(new DateTime(2019, 10, 13)).Returns(false).SetName("WeekdaySunday");
            }
        }

        public static IEnumerable EndOfWeekData
        {
            get
            {
                yield return new TestCaseData(new DateTime(2019, 10, 07)).Returns(new DateTime(2019, 10, 13)).SetName("EndOfWeekMonday");
                yield return new TestCaseData(new DateTime(2019, 10, 08)).Returns(new DateTime(2019, 10, 13)).SetName("EndOfWeekTuesday");
                yield return new TestCaseData(new DateTime(2019, 10, 09)).Returns(new DateTime(2019, 10, 13)).SetName("EndOfWeekWednesday");
                yield return new TestCaseData(new DateTime(2019, 10, 10)).Returns(new DateTime(2019, 10, 13)).SetName("EndOfWeekThursday");
                yield return new TestCaseData(new DateTime(2019, 10, 11)).Returns(new DateTime(2019, 10, 13)).SetName("EndOfWeekFriday");
                yield return new TestCaseData(new DateTime(2019, 10, 12)).Returns(new DateTime(2019, 10, 13)).SetName("EndOfWeekSaturday");
                yield return new TestCaseData(new DateTime(2019, 10, 13)).Returns(new DateTime(2019, 10, 13)).SetName("EndOfWeekSunday");
            }
        }

        public static IEnumerable EndOfMonthData
        {
            get
            {
                yield return new TestCaseData(new DateTime(2000, 01, 01)).Returns(new DateTime(2000, 01, 31)).SetName("EndOfMonthJan1");
                yield return new TestCaseData(new DateTime(2000, 01, 31)).Returns(new DateTime(2000, 01, 31)).SetName("EndOfMonthJan31");
                yield return new TestCaseData(new DateTime(2000, 02, 01)).Returns(new DateTime(2000, 02, 29)).SetName("EndOfMonthFeb1LeapYear");
                yield return new TestCaseData(new DateTime(2000, 02, 28)).Returns(new DateTime(2000, 02, 29)).SetName("EndOfMonthFeb28LeapYear");
                yield return new TestCaseData(new DateTime(2000, 02, 29)).Returns(new DateTime(2000, 02, 29)).SetName("EndOfMonthFeb29LeapYear");
                yield return new TestCaseData(new DateTime(2001, 02, 01)).Returns(new DateTime(2001, 02, 28)).SetName("EndOfMonthFeb1");
                yield return new TestCaseData(new DateTime(2000, 10, 13)).Returns(new DateTime(2000, 10, 31)).SetName("EndOfMonthOct13");
            }
        }
    } 
}
