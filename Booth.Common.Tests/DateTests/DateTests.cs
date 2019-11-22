using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using NUnit.Framework;

namespace Booth.Common.Tests.DateTests
{
    class DateTests
    {
        [TestCase]
        public void TodayTest()
        {
            Assert.That(Date.Today.DateTime, Is.EqualTo(DateTime.Today));
        }

        [TestCase]
        public void DayTest()
        {
            var date = new Date(2019, 11, 04);
            Assert.That(date.Day, Is.EqualTo(4));
        }

        [TestCase]
        public void MonthTest()
        {
            var date = new Date(2019, 11, 04);
            Assert.That(date.Month, Is.EqualTo(11));
        }

        [TestCase]
        public void YearTest()
        {
            var date = new Date(2019, 11, 04);
            Assert.That(date.Year, Is.EqualTo(2019));
        }

        [TestCase]
        public void DayOfWeekTest()
        {
            var date = new Date(2019, 11, 04);
            Assert.That(date.DayOfWeek, Is.EqualTo(DayOfWeek.Monday));
        }

        [TestCase]
        public void DayOfYearTest()
        {
            var date = new Date(2019, 11, 04);
            Assert.That(date.DayOfYear, Is.EqualTo(308));
        }



        [TestCase]
        public void AddTimeSpanTest()
        {
            var date = new Date(2019, 11, 04);
            var newDate = date.Add(new TimeSpan(0, 26, 3, 0, 0));

            Assert.That(newDate, Is.EqualTo(new Date(2019, 11, 05)));
        }

        [TestCase]
        public void AddDaysTest()
        {
            var date = new Date(2019, 11, 04);
            var newDate = date.AddDays(45);

            Assert.That(newDate, Is.EqualTo(new Date(2019, 12, 19)));
        }

        [TestCase]
        public void AddMonthsTest()
        {
            var date = new Date(2019, 11, 04);
            var newDate = date.AddMonths(4);

            Assert.That(newDate, Is.EqualTo(new Date(2020, 03, 04)));
        }

        [TestCase]
        public void AddYearsTest()
        {
            var date = new Date(2019, 11, 04);
            var newDate = date.AddYears(2);

            Assert.That(newDate, Is.EqualTo(new Date(2021, 11, 04)));
        }


        [TestCase]
        public void SubtractTimeSpanTest()
        {
            var date = new Date(2019, 11, 04);
            var newDate = date.Subtract(new TimeSpan(0, 26, 3, 0, 0));

            Assert.That(newDate, Is.EqualTo(new Date(2019, 11, 02)));
        }

        [TestCase]
        public void SubtractDateTest()
        {
            var date = new Date(2019, 11, 04);
            var newDate = date.Subtract(new Date(2019, 11, 30));

            Assert.That(newDate, Is.EqualTo(new TimeSpan(-26, 0, 0, 0)));
        }            

        [TestCase]
        public void GetObjectDataTest()
        {
            var date = new Date(2019, 11, 19);

            var converter = new FormatterConverter();
            var info = new SerializationInfo(typeof(Date), converter);
            var context = new StreamingContext();
            date.GetObjectData(info, context);

            Assert.Multiple(() =>
            {
                Assert.That(info.GetValue("Day", typeof(int)), Is.EqualTo(19));
                Assert.That(info.GetValue("Month", typeof(int)), Is.EqualTo(11));
                Assert.That(info.GetValue("Year", typeof(int)), Is.EqualTo(2019));

                Assert.That(new Date(info, context), Is.EqualTo(date));
            });
            
        }

    }
}
