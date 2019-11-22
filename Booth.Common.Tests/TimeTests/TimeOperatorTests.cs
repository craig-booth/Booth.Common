using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;

namespace Booth.Common.Tests.TimeTests
{
    class TimeOperatorTests
    {

        [TestCase]
        public void AddTimeSpanTest()
        {
            var time = new Time(14, 02, 24);
            var newTime = time + new TimeSpan(2, 4, 24);

            Assert.That(newTime, Is.EqualTo(new Time(16, 06, 48)));
        }


        [TestCase]
        public void SubtractTimeSpanTest()
        {
            var time = new Time(14, 02, 24);
            var newTime = time - new TimeSpan(2, 4, 24);

            Assert.That(newTime, Is.EqualTo(new Time(11, 58, 00)));
        }

        [TestCase]
        public void SubtractTimeTest()
        {
            var time = new Time(14, 02, 24);
            var ts = time - new Time(08, 22, 34);

            Assert.That(ts, Is.EqualTo(new TimeSpan(5, 39, 50)));
        }

        [TestCase]
        public void EqualTest()
        {
            Assert.Multiple(() =>
            {
                Assert.That(new Time(14, 02, 24) == new Time(11, 02, 06), Is.False);
                Assert.That(new Time(14, 02, 24) == new Time(14, 02, 24), Is.True);
                Assert.That(new Time(14, 02, 24) == new Time(14, 45, 22), Is.False);
            });
        }

        [TestCase]
        public void NotEqualTest()
        {
            Assert.Multiple(() =>
            {
                Assert.That(new Time(14, 02, 24) != new Time(11, 02, 06), Is.True);
                Assert.That(new Time(14, 02, 24) != new Time(14, 02, 24), Is.False);
                Assert.That(new Time(14, 02, 24) != new Time(14, 45, 22), Is.True);
            });
        }

        [TestCase]
        public void LessThanTest()
        {
            Assert.Multiple(() =>
            {
                Assert.That(new Time(14, 02, 24) < new Time(11, 02, 06), Is.False);
                Assert.That(new Time(14, 02, 24) < new Time(14, 02, 24), Is.False);
                Assert.That(new Time(14, 02, 24) < new Time(14, 45, 22), Is.True);
            });
        }

        [TestCase]
        public void GreaterThanTest()
        {
            Assert.Multiple(() =>
            {
                Assert.That(new Time(14, 02, 24) > new Time(11, 02, 06), Is.True);
                Assert.That(new Time(14, 02, 24) > new Time(14, 02, 24), Is.False);
                Assert.That(new Time(14, 02, 24) > new Time(14, 45, 22), Is.False);
            });
        }

        [TestCase]
        public void LessThanEqualTest()
        {
            Assert.Multiple(() =>
            {
                Assert.That(new Time(14, 02, 24) <= new Time(11, 02, 06), Is.False);
                Assert.That(new Time(14, 02, 24) <= new Time(14, 02, 24), Is.True);
                Assert.That(new Time(14, 02, 24) <= new Time(14, 45, 22), Is.True);
            });
        }

        [TestCase]
        public void GreaterThanEqualTest()
        {
            Assert.Multiple(() =>
            {
                Assert.That(new Time(14, 02, 24) >= new Time(11, 02, 06), Is.True);
                Assert.That(new Time(14, 02, 24) >= new Time(14, 02, 24), Is.True);
                Assert.That(new Time(14, 02, 24) >= new Time(14, 45, 22), Is.False);
            });
        }
    }
}
