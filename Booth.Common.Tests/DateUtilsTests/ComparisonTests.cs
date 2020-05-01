using System;
using System.Collections.Generic;

using Xunit;
using FluentAssertions;

namespace Booth.Common.Tests.DateUtilsTests
{
    public class ComparisonTests
    {
        [Theory]
        [MemberData(nameof(WeekDayData))]
        public void WeekDayTests(Date date, bool expected, string because)
        {
            date.WeekDay().Should().Be(expected, because);
        }

        public static IEnumerable<object[]> WeekDayData()
        {
            yield return new object[] { new Date(2019, 10, 07), true, "day is a Monday" }; 
            yield return new object[] { new Date(2019, 10, 08), true, "day is a Tuesday" };
            yield return new object[] { new Date(2019, 10, 09), true, "day is a Wednesday" }; 
            yield return new object[] { new Date(2019, 10, 10), true, "day is a Thursday" }; 
            yield return new object[] { new Date(2019, 10, 11), true, "day is a Friday" }; 
            yield return new object[] { new Date(2019, 10, 12), false, "day is a Saturday" }; 
            yield return new object[] { new Date(2019, 10, 13), false, "day is a Sunday" }; 
        }

        [Fact]
        public void EarliestTestFirstDateEarlier()
        {
            var date1 = new Date(2000, 01, 01);
            var date2 = new Date(2002, 01, 01);

            var earliest = DateUtils.Earlist(date1, date2);

            earliest.Should().Be(date1);
        }

        [Fact]
        public void EarliestTestLastDateEarlier()
        {
            var date1 = new Date(2000, 01, 01);
            var date2 = new Date(1999, 01, 01);

            var earliest = DateUtils.Earlist(date1, date2);

            earliest.Should().Be(date2);
        }

        [Fact]
        public void EarliestTestSame()
        {
            var date1 = new Date(2000, 01, 01);
            var date2 = new Date(2000, 01, 01);

            var earliest = DateUtils.Earlist(date1, date2);

            earliest.Should().Be(date1);
        }

        [Fact]
        public void LatestTestFirstDateEarlier()
        {
            var date1 = new Date(2000, 01, 01);
            var date2 = new Date(2002, 01, 01);

            var latest = DateUtils.Latest(date1, date2);

            latest.Should().Be(date2);
        }

        [Fact]
        public void LatestTestLastDateEarlier()
        {
            var date1 = new Date(2000, 01, 01);
            var date2 = new Date(1999, 01, 01);

            var latest = DateUtils.Latest(date1, date2);

            latest.Should().Be(date1);
        }


        [Fact]
        public void LatestTestSame()
        {
            var date1 = new Date(2000, 01, 01);
            var date2 = new Date(2000, 01, 01);

            var latest = DateUtils.Latest(date1, date2);

            latest.Should().Be(date1);
        }


        [Theory]
        [MemberData(nameof(EndOfWeekData))]
        public void TestEndOfWeek(Date date, Date expected, string because)
        {
            date.EndOfWeek().Should().Be(expected, because);
        }

        public static IEnumerable<object[]> EndOfWeekData()
        {
            yield return new object[] { new Date(2019, 10, 07), new Date(2019, 10, 13), "day is a Monday" };
            yield return new object[] { new Date(2019, 10, 08), new Date(2019, 10, 13), "day is a Tuesday" }; 
            yield return new object[] { new Date(2019, 10, 09), new Date(2019, 10, 13), "day is a Wednesday" }; 
            yield return new object[] { new Date(2019, 10, 10), new Date(2019, 10, 13), "day is a Thursday" }; 
            yield return new object[] { new Date(2019, 10, 11), new Date(2019, 10, 13), "day is a Friday" }; 
            yield return new object[] { new Date(2019, 10, 12), new Date(2019, 10, 13), "day is a Saturday" }; 
            yield return new object[] { new Date(2019, 10, 13), new Date(2019, 10, 13), "day is a Sunday" }; 
        }


        [Theory]
        [MemberData(nameof(EndOfMonthData))]
        public void EndOfMonth(Date date, Date expected, string because)
        {
            date.EndOfMonth().Should().Be(expected, because);
        }

        public static IEnumerable<object[]> EndOfMonthData()
        {
            yield return new object[] { new Date(2000, 01, 01), new Date(2000, 01, 31), "day is a January 1st" };
            yield return new object[] { new Date(2000, 01, 31), new Date(2000, 01, 31), "day is a January 31st" }; 
            yield return new object[] { new Date(2000, 02, 01), new Date(2000, 02, 29), "day is a February 1st on Leap Year" }; 
            yield return new object[] { new Date(2000, 02, 28), new Date(2000, 02, 29), "day is a February 28th on Leap Year" }; 
            yield return new object[] { new Date(2000, 02, 29), new Date(2000, 02, 29), "day is a February 29th on Leap Year" }; 
            yield return new object[] { new Date(2001, 02, 01), new Date(2001, 02, 28), "day is a February 1st" }; 
            yield return new object[] { new Date(2000, 10, 13), new Date(2000, 10, 31), "day is a October 13th" }; 
        }
    }
}

