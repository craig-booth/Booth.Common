using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

using Xunit;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Booth.Common.Tests.DateTests
{
    public class DateTests
    {
        [Fact]
        public void Today()
        {
            var today = Date.Today;

            today.Should().BeEquivalentTo(DateTime.Today.Date);
        }

        [Fact]
        public void Day()
        {
            var date = new Date(2019, 11, 04);

            date.Day.Should().Be(4);
        }

        [Fact]
        public void Month()
        {
            var date = new Date(2019, 11, 04);

            date.Month.Should().Be(11);
        }

        [Fact]
        public void Year()
        {
            var date = new Date(2019, 11, 04);

            date.Year.Should().Be(2019);
        }

        [Fact]
        public void DateDayOfWeek()
        {
            var date = new Date(2019, 11, 04);

            date.DayOfWeek.Should().Be(DayOfWeek.Monday);
        }

        [Fact]
        public void DayOfYear()
        {
            var date = new Date(2019, 11, 04);

            date.DayOfYear.Should().Be(308);
        }



        [Fact]
        public void AddTimeSpan()
        {
            var date = new Date(2019, 11, 04);
            var newDate = date.Add(new TimeSpan(0, 26, 3, 0, 0));

            newDate.Should().Be(new Date(2019, 11, 05));
        }

        [Fact]
        public void AddDays()
        {
            var date = new Date(2019, 11, 04);
            var newDate = date.AddDays(45);

            newDate.Should().Be(new Date(2019, 12, 19));
        }

        [Fact]
        public void AddMonths()
        {
            var date = new Date(2019, 11, 04);
            var newDate = date.AddMonths(4);

            newDate.Should().Be(new Date(2020, 03, 04));
        }

        [Fact]
        public void AddYears()
        {
            var date = new Date(2019, 11, 04);
            var newDate = date.AddYears(2);

            newDate.Should().Be(new Date(2021, 11, 04));
        }


        [Fact]
        public void SubtractTimeSpan()
        {
            var date = new Date(2019, 11, 04);
            var newDate = date.Subtract(new TimeSpan(0, 26, 3, 0, 0));

            newDate.Should().Be(new Date(2019, 11, 02));
        }

        [Fact]
        public void SubtractDate()
        {
            var date = new Date(2019, 11, 04);
            var timeSpan = date.Subtract(new Date(2019, 11, 30));

            timeSpan.Should().Be(new TimeSpan(-26, 0, 0, 0));
        }            

        [Fact]
        public void GetObjectData()
        {
            var date = new Date(2019, 11, 19);

            var converter = new FormatterConverter();
            var info = new SerializationInfo(typeof(Date), converter);
            var context = new StreamingContext();
            date.GetObjectData(info, context);

            {
                info.GetValue("Day", typeof(int)).Should().Be(19);
                info.GetValue("Month", typeof(int)).Should().Be(11);
                info.GetValue("Year", typeof(int)).Should().Be(2019);
            }                    
        }

        [Fact]
        public void CreateFromObjectData()
        {
            var converter = new FormatterConverter();
            var info = new SerializationInfo(typeof(Date), converter);
            var context = new StreamingContext();

            info.AddValue("Day", 19);
            info.AddValue("Month", 11);
            info.AddValue("Year", 2019);
            var date = new Date(info, context);

            date.Should().Be(new Date(2019, 11, 19));
        }

    }
}
