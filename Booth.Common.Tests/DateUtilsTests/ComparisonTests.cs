using System;
using System.Collections;

using NUnit.Framework;
using FluentAssertions;

namespace Booth.Common.Tests.DateUtilsTests
{
    class ComparisonTests
    {
        [TestCaseSource(typeof(ComparisonTestsTestData), nameof(ComparisonTestsTestData.WeekDayData))]
        public void WeekDayTests(Date date, bool expected)
        {
            date.WeekDay().Should().Be(expected);
        }

        [TestCase]
        public void EarliestTestFirstDateEarlier()
        {
            var date1 = new Date(2000, 01, 01);
            var date2 = new Date(2002, 01, 01);

            var earliest = DateUtils.Earlist(date1, date2);

            earliest.Should().Be(date1);
        }

        [TestCase]
        public void EarliestTestLastDateEarlier()
        {
            var date1 = new Date(2000, 01, 01);
            var date2 = new Date(1999, 01, 01);

            var earliest = DateUtils.Earlist(date1, date2);

            earliest.Should().Be(date2);
        }

        [TestCase]
        public void EarliestTestSame()
        {
            var date1 = new Date(2000, 01, 01);
            var date2 = new Date(2000, 01, 01);

            var earliest = DateUtils.Earlist(date1, date2);

            earliest.Should().Be(date1);
        }

        [TestCase]
        public void LatestTestFirstDateEarlier()
        {
            var date1 = new Date(2000, 01, 01);
            var date2 = new Date(2002, 01, 01);

            var latest = DateUtils.Latest(date1, date2);

            latest.Should().Be(date2);
        }

        [TestCase]
        public void LatestTestLastDateEarlier()
        {
            var date1 = new Date(2000, 01, 01);
            var date2 = new Date(1999, 01, 01);

            var latest = DateUtils.Latest(date1, date2);

            latest.Should().Be(date1);
        }


        [TestCase]
        public void LatestTestSame()
        {
            var date1 = new Date(2000, 01, 01);
            var date2 = new Date(2000, 01, 01);

            var latest = DateUtils.Latest(date1, date2);

            latest.Should().Be(date1);
        }


        [TestCaseSource(typeof(ComparisonTestsTestData), nameof(ComparisonTestsTestData.EndOfWeekData))]
        public void TestEndOfWeek(Date date, Date expected)
        {
            date.EndOfWeek().Should().Be(expected);
        }

        [TestCaseSource(typeof(ComparisonTestsTestData), nameof(ComparisonTestsTestData.EndOfMonthData))]
        public void EndOfMonth(Date date, Date expected)
        {
            date.EndOfMonth().Should().Be(expected);
        } 
    }

    class ComparisonTestsTestData
    {
        public static IEnumerable WeekDayData
        {
            get
            {
                yield return new TestCaseData(new Date(2019, 10, 07), true).SetArgDisplayNames("Monday");
                yield return new TestCaseData(new Date(2019, 10, 08), true).SetArgDisplayNames("Tuesday");
                yield return new TestCaseData(new Date(2019, 10, 09), true).SetArgDisplayNames("Wednesday");
                yield return new TestCaseData(new Date(2019, 10, 10), true).SetArgDisplayNames("Thursday");
                yield return new TestCaseData(new Date(2019, 10, 11), true).SetArgDisplayNames("Friday");
                yield return new TestCaseData(new Date(2019, 10, 12), false).SetArgDisplayNames("Saturday");
                yield return new TestCaseData(new Date(2019, 10, 13), false).SetArgDisplayNames("Sunday");
            }
        }

        public static IEnumerable EndOfWeekData
        {
            get
            {
                yield return new TestCaseData(new Date(2019, 10, 07), new Date(2019, 10, 13)).SetArgDisplayNames("Monday");
                yield return new TestCaseData(new Date(2019, 10, 08), new Date(2019, 10, 13)).SetArgDisplayNames("Tuesday");
                yield return new TestCaseData(new Date(2019, 10, 09), new Date(2019, 10, 13)).SetArgDisplayNames("Wednesday");
                yield return new TestCaseData(new Date(2019, 10, 10), new Date(2019, 10, 13)).SetArgDisplayNames("Thursday");
                yield return new TestCaseData(new Date(2019, 10, 11), new Date(2019, 10, 13)).SetArgDisplayNames("Friday");
                yield return new TestCaseData(new Date(2019, 10, 12), new Date(2019, 10, 13)).SetArgDisplayNames("Saturday");
                yield return new TestCaseData(new Date(2019, 10, 13), new Date(2019, 10, 13)).SetArgDisplayNames("Sunday");
            }
        }

        public static IEnumerable EndOfMonthData
        {
            get
            {
                yield return new TestCaseData(new Date(2000, 01, 01), new Date(2000, 01, 31)).SetArgDisplayNames("Jan1");
                yield return new TestCaseData(new Date(2000, 01, 31), new Date(2000, 01, 31)).SetArgDisplayNames("Jan31");
                yield return new TestCaseData(new Date(2000, 02, 01), new Date(2000, 02, 29)).SetArgDisplayNames("Feb1LeapYear");
                yield return new TestCaseData(new Date(2000, 02, 28), new Date(2000, 02, 29)).SetArgDisplayNames("Feb28LeapYear");
                yield return new TestCaseData(new Date(2000, 02, 29), new Date(2000, 02, 29)).SetArgDisplayNames("Feb29LeapYear");
                yield return new TestCaseData(new Date(2001, 02, 01), new Date(2001, 02, 28)).SetArgDisplayNames("Feb1");
                yield return new TestCaseData(new Date(2000, 10, 13), new Date(2000, 10, 31)).SetArgDisplayNames("Oct13");
            }
        }
    } 
}
