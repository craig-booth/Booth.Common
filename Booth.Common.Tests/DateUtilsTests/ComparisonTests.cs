using System;
using System.Collections;

using NUnit.Framework;

namespace Booth.Common.Tests.DateUtilsTests
{
    class ComparisonTests
    {
        [TestCaseSource(typeof(ComparisonTestsTestData), nameof(ComparisonTestsTestData.WeekDayData))]
        public bool WeekDayTests(Date date)
        {
            return date.WeekDay();
        }

        [TestCase]
        public void EarliestTestFirstDateEarlier()
        {
            var date1 = new Date(2000, 01, 01);
            var date2 = new Date(2002, 01, 01);

            Assert.That(DateUtils.Earlist(date1, date2), Is.EqualTo(date1));
        }

        [TestCase]
        public void EarliestTestLastDateEarlier()
        {
            var date1 = new Date(2000, 01, 01);
            var date2 = new Date(1999, 01, 01);

            Assert.That(DateUtils.Earlist(date1, date2), Is.EqualTo(date2));
        }

        [TestCase]
        public void EarliestTestSame()
        {
            var date1 = new Date(2000, 01, 01);
            var date2 = new Date(2000, 01, 01);

            Assert.That(DateUtils.Earlist(date1, date2), Is.EqualTo(date1));
        }

        [TestCase]
        public void LatestTestFirstDateEarlier()
        {
            var date1 = new Date(2000, 01, 01);
            var date2 = new Date(2002, 01, 01);

            Assert.That(DateUtils.Latest(date1, date2), Is.EqualTo(date2));
        }

        [TestCase]
        public void LatestTestLastDateEarlier()
        {
            var date1 = new Date(2000, 01, 01);
            var date2 = new Date(1999, 01, 01);

            Assert.That(DateUtils.Latest(date1, date2), Is.EqualTo(date1));
        }


        [TestCase]
        public void LatestTestSame()
        {
            var date1 = new Date(2000, 01, 01);
            var date2 = new Date(2000, 01, 01);

            Assert.That(DateUtils.Latest(date1, date2), Is.EqualTo(date1));
        }


        [TestCaseSource(typeof(ComparisonTestsTestData), nameof(ComparisonTestsTestData.EndOfWeekData))]
        public Date TestEndOfWeek(Date date)
        {
            return date.EndOfWeek();
        }

        [TestCaseSource(typeof(ComparisonTestsTestData), nameof(ComparisonTestsTestData.EndOfMonthData))]
        public static Date EndOfMonth(Date date)
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
                yield return new TestCaseData(new Date(2019, 10, 07)).Returns(true).SetArgDisplayNames("Monday");
                yield return new TestCaseData(new Date(2019, 10, 08)).Returns(true).SetArgDisplayNames("Tuesday");
                yield return new TestCaseData(new Date(2019, 10, 09)).Returns(true).SetArgDisplayNames("Wednesday");
                yield return new TestCaseData(new Date(2019, 10, 10)).Returns(true).SetArgDisplayNames("Thursday");
                yield return new TestCaseData(new Date(2019, 10, 11)).Returns(true).SetArgDisplayNames("Friday");
                yield return new TestCaseData(new Date(2019, 10, 12)).Returns(false).SetArgDisplayNames("Saturday");
                yield return new TestCaseData(new Date(2019, 10, 13)).Returns(false).SetArgDisplayNames("Sunday");
            }
        }

        public static IEnumerable EndOfWeekData
        {
            get
            {
                yield return new TestCaseData(new Date(2019, 10, 07)).Returns(new Date(2019, 10, 13)).SetArgDisplayNames("Monday");
                yield return new TestCaseData(new Date(2019, 10, 08)).Returns(new Date(2019, 10, 13)).SetArgDisplayNames("Tuesday");
                yield return new TestCaseData(new Date(2019, 10, 09)).Returns(new Date(2019, 10, 13)).SetArgDisplayNames("Wednesday");
                yield return new TestCaseData(new Date(2019, 10, 10)).Returns(new Date(2019, 10, 13)).SetArgDisplayNames("Thursday");
                yield return new TestCaseData(new Date(2019, 10, 11)).Returns(new Date(2019, 10, 13)).SetArgDisplayNames("Friday");
                yield return new TestCaseData(new Date(2019, 10, 12)).Returns(new Date(2019, 10, 13)).SetArgDisplayNames("Saturday");
                yield return new TestCaseData(new Date(2019, 10, 13)).Returns(new Date(2019, 10, 13)).SetArgDisplayNames("Sunday");
            }
        }

        public static IEnumerable EndOfMonthData
        {
            get
            {
                yield return new TestCaseData(new Date(2000, 01, 01)).Returns(new Date(2000, 01, 31)).SetArgDisplayNames("Jan1");
                yield return new TestCaseData(new Date(2000, 01, 31)).Returns(new Date(2000, 01, 31)).SetArgDisplayNames("Jan31");
                yield return new TestCaseData(new Date(2000, 02, 01)).Returns(new Date(2000, 02, 29)).SetArgDisplayNames("Feb1LeapYear");
                yield return new TestCaseData(new Date(2000, 02, 28)).Returns(new Date(2000, 02, 29)).SetArgDisplayNames("Feb28LeapYear");
                yield return new TestCaseData(new Date(2000, 02, 29)).Returns(new Date(2000, 02, 29)).SetArgDisplayNames("Feb29LeapYear");
                yield return new TestCaseData(new Date(2001, 02, 01)).Returns(new Date(2001, 02, 28)).SetArgDisplayNames("Feb1");
                yield return new TestCaseData(new Date(2000, 10, 13)).Returns(new Date(2000, 10, 31)).SetArgDisplayNames("Oct13");
            }
        }
    } 
}
