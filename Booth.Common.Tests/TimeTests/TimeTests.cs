using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using NUnit.Framework;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Booth.Common.Tests.TimeTests
{
    class TimeTests
    {
        [TestCase]
        public void Now()
        {
            var timeNow = Time.Now;
            var dateTimeNow = DateTime.Now;

            timeNow.Should().BeEquivalentTo(new { Hour = dateTimeNow.Hour, Minute = dateTimeNow.Minute, Second = dateTimeNow.Second });           
        }

        [TestCase]
        public void Second()
        {
            var time = new Time(14, 02, 24);

            time.Second.Should().Be(24);
        }

        [TestCase]
        public void Minute()
        {
            var time = new Time(14, 02, 24);
            
            time.Minute.Should().Be(2);
        }

        [TestCase]
        public void Hour()
        {
            var time = new Time(14, 02, 24);
            
            time.Hour.Should().Be(14);
        }

        [TestCaseSource(nameof(AddTimeSpanData))] 
        public void AddTimeSpan(TimeSpan timeSpanToAdd, Time expectedTime)
        {
            var time = new Time(14, 02, 24);

            var newTime = time.Add(timeSpanToAdd);

            newTime.Should().Be(expectedTime);
        }

        private static IEnumerable<object[]> AddTimeSpanData()
        {
            yield return new object[] { new TimeSpan(0, 0, 0), new Time(14, 02, 24) };
            yield return new object[] { new TimeSpan(0, 0, 30), new Time(14, 02, 54) };
            yield return new object[] { new TimeSpan(0, 0, 120), new Time(14, 04, 24) };
            yield return new object[] { new TimeSpan(0, 24, 0), new Time(14, 26, 24) };
            yield return new object[] { new TimeSpan(0, 64, 0), new Time(15, 06, 24) };
            yield return new object[] { new TimeSpan(2, 0, 0), new Time(16, 02, 24) };
            yield return new object[] { new TimeSpan(-1, -1, -1), new Time(13, 01, 23) };
            yield return new object[] { new TimeSpan(0, -5, 7), new Time(13, 57, 31) };
        }

        [TestCase]
        public void AddTimeSpanGreaterThanOneDay()
        {
            var time = new Time(14, 02, 24);

            Action a = () => { var newTime = time.Add(new TimeSpan(10, 0, 0)); };

            a.Should().ThrowExactly<OverflowException>();
        }


        [TestCase]
        public void AddTimeSpanLessThanOneDay()
        {
            var time = new Time(14, 02, 24);

            Action a = () => { var newTime = time.Add(new TimeSpan(-15, 0, 0)); };

            a.Should().ThrowExactly<OverflowException>();
        }

        [TestCase]
        public void AddSeconds()
        {
            var time = new Time(14, 02, 24);
            var newTime = time.AddSeconds(170);

            newTime.Should().Be(new Time(14, 05, 14));
        }

        [TestCase]
        public void AddMinutes()
        {
            var time = new Time(14, 02, 24);
            var newTime = time.AddMinutes(121);

            newTime.Should().Be(new Time(16, 03, 24));
        }

        [TestCase]
        public void AddHours()
        {
            var time = new Time(14, 02, 24);
            var newTime = time.AddHours(5);

            newTime.Should().Be(new Time(19, 02, 24));
        }


        [TestCase]
        public void SubtractTimeSpan()
        {
            var time = new Time(14, 02, 24);
            var newTime = time.Subtract(new TimeSpan(4, 2, 34));

            newTime.Should().Be(new Time(9, 59, 50));
        }

        [TestCase]
        public void SubtractTime()
        {
            var time = new Time(14, 02, 24);
            var ts = time.Subtract(new Time(08, 22, 03));

            ts.Should().Be(new TimeSpan(5, 40, 21));
        }

        [TestCase]
        public void GetObjectData()
        {
            var time = new Time(14, 02, 24);

            var converter = new FormatterConverter();
            var info = new SerializationInfo(typeof(Date), converter);
            var context = new StreamingContext();
            time.GetObjectData(info, context);

            using (new AssertionScope())
            {
                info.GetValue("Second", typeof(int)).Should().Be(24);
                info.GetValue("Minute", typeof(int)).Should().Be(02);
                info.GetValue("Hour", typeof(int)).Should().Be(14);
            };

        }

        [TestCase]
        public void CreateFromObjectData()
        {
            var converter = new FormatterConverter();
            var info = new SerializationInfo(typeof(Date), converter);
            var context = new StreamingContext();

            info.AddValue("Second", 24);
            info.AddValue("Minute", 02);
            info.AddValue("Hour", 14);
            var time = new Time(info, context);

            time.Should().Be(new Time(14, 02, 24));
        }

    }
}
