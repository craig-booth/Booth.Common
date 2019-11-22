using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using NUnit.Framework;

namespace Booth.Common.Tests.TimeTests
{
    class TimeTests
    {
        [TestCase]
        public void NowTest()
        {
            var timeNow = Time.Now;
            var dateTimeNow = DateTime.Now;

            Assert.Multiple(() =>
            {
                Assert.That(timeNow.Hour, Is.EqualTo(dateTimeNow.Hour));
                Assert.That(timeNow.Minute, Is.EqualTo(dateTimeNow.Minute));
                Assert.That(timeNow.Second, Is.EqualTo(dateTimeNow.Second));
            });
            
        }

        [TestCase]
        public void SecondTest()
        {
            var time = new Time(14, 02, 24);
            Assert.That(time.Second, Is.EqualTo(24));
        }

        [TestCase]
        public void MinuteTest()
        {
            var time = new Time(14, 02, 24);
            Assert.That(time.Minute, Is.EqualTo(2));
        }

        [TestCase]
        public void HourTest()
        {
            var time = new Time(14, 02, 24);
            Assert.That(time.Hour, Is.EqualTo(14));
        }

        [TestCase]
        public void AddTimeSpanTest()
        {
            var time = new Time(14, 02, 24);

            Assert.Multiple(() =>
            {
                Assert.That(time.Add(new TimeSpan(0, 0, 0)), Is.EqualTo(time));
                Assert.That(() => time.Add(new TimeSpan(1, 0, 0, 0)), Throws.TypeOf(typeof(ArgumentOutOfRangeException)));
                Assert.That(time.Add(new TimeSpan(0, 0, 30)), Is.EqualTo(new Time(14, 02, 54)));
                Assert.That(time.Add(new TimeSpan(0, 0, 120)), Is.EqualTo(new Time(14, 04, 24)));
                Assert.That(time.Add(new TimeSpan(0, 24, 0)), Is.EqualTo(new Time(14, 26, 24)));
                Assert.That(time.Add(new TimeSpan(0, 64, 0)), Is.EqualTo(new Time(15, 06, 24)));
                Assert.That(time.Add(new TimeSpan(2, 0, 0)), Is.EqualTo(new Time(16, 02, 24)));
                Assert.That(() => time.Add(new TimeSpan(10, 0, 0)), Throws.TypeOf(typeof(ArgumentOutOfRangeException)));
                Assert.That(time.Add(new TimeSpan(-1, -1, -1)), Is.EqualTo(new Time(13, 01, 23)));
                Assert.That(time.Add(new TimeSpan(0, -5, 7)), Is.EqualTo(new Time(13, 57, 31)));
                Assert.That(() => time.Add(new TimeSpan(-1, 0, 0, 0)), Throws.TypeOf(typeof(ArgumentOutOfRangeException)));
            });
        }

        [TestCase]
        public void AddSecondsTest()
        {
            var time = new Time(14, 02, 24);
            var newTime = time.AddSeconds(170);

            Assert.That(newTime, Is.EqualTo(new Time(14, 05, 14)));
        }

        [TestCase]
        public void AddMinutesTest()
        {
            var time = new Time(14, 02, 24);
            var newTime = time.AddMinutes(121);

            Assert.That(newTime, Is.EqualTo(new Time(16, 03, 24)));
        }

        [TestCase]
        public void AddHoursTest()
        {
            var time = new Time(14, 02, 24);
            var newTime = time.AddHours(5);

            Assert.That(newTime, Is.EqualTo(new Time(19, 02, 24)));
        }


        [TestCase]
        public void SubtractTimeSpanTest()
        {
            var time = new Time(14, 02, 24);
            var newTime = time.Subtract(new TimeSpan(4, 2, 34));

            Assert.That(newTime, Is.EqualTo(new Time(9, 59, 50)));
        }

        [TestCase]
        public void SubtractTimeTest()
        {
            var time = new Time(14, 02, 24);
            var ts = time.Subtract(new Time(08, 22, 03));

            Assert.That(ts, Is.EqualTo(new TimeSpan(5, 40, 21)));
        }

        [TestCase]
        public void GetObjectDataTest()
        {
            var time = new Time(14, 02, 24);

            var converter = new FormatterConverter();
            var info = new SerializationInfo(typeof(Date), converter);
            var context = new StreamingContext();
            time.GetObjectData(info, context);

            Assert.Multiple(() =>
            {
                Assert.That(info.GetValue("Second", typeof(int)), Is.EqualTo(24));
                Assert.That(info.GetValue("Minute", typeof(int)), Is.EqualTo(02));
                Assert.That(info.GetValue("Hour", typeof(int)), Is.EqualTo(14));

                Assert.That(new Time(info, context), Is.EqualTo(time));
            });

        }

    }
}
