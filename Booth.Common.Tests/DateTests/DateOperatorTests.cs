using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;

namespace Booth.Common.Tests.DateTests
{
    class DateOperatorTests
    {

        [TestCase]
        public void AddTimeSpanTest()
        {
            var date = new Date(2019, 11, 04);
            var newDate = date + new TimeSpan(0, 26, 3, 0, 0);

            Assert.That(newDate, Is.EqualTo(new Date(2019, 11, 05)));
        }


        [TestCase]
        public void SubtractTimeSpanTest()
        {
            var date = new Date(2019, 11, 04);
            var newDate = date - new TimeSpan(0, 26, 3, 0, 0);

            Assert.That(newDate, Is.EqualTo(new Date(2019, 11, 02)));
        }

        [TestCase]
        public void SubtractDateTest()
        {
            var date = new Date(2019, 11, 04);
            var newDate = date - new Date(2019, 11, 30);

            Assert.That(newDate, Is.EqualTo(new TimeSpan(-26, 0, 0, 0)));
        }

        [TestCase]
        public void EqualTest()
        {
            Assert.Multiple(() =>
            {
                Assert.That(new Date(2019, 11, 18) == (new Date(2019, 11, 01)), Is.False);
                Assert.That(new Date(2019, 11, 18) == (new Date(2019, 11, 18)), Is.True);
                Assert.That(new Date(2019, 11, 18) == (new Date(2019, 11, 22)), Is.False);
            });
        }

        [TestCase]
        public void NotEqualTest()
        {
            Assert.Multiple(() =>
            {
                Assert.That(new Date(2019, 11, 18) != (new Date(2019, 11, 01)), Is.True);
                Assert.That(new Date(2019, 11, 18) != (new Date(2019, 11, 18)), Is.False);
                Assert.That(new Date(2019, 11, 18) != (new Date(2019, 11, 22)), Is.True);
            });
        }

        [TestCase]
        public void LessThanTest()
        {
            Assert.Multiple(() =>
            {
                Assert.That(new Date(2019, 11, 18) < (new Date(2019, 11, 01)), Is.False);
                Assert.That(new Date(2019, 11, 18) < (new Date(2019, 11, 18)), Is.False);
                Assert.That(new Date(2019, 11, 18) < (new Date(2019, 11, 22)), Is.True);
            });
        }

        [TestCase]
        public void GreaterThanTest()
        {
            Assert.Multiple(() =>
            {
                Assert.That(new Date(2019, 11, 18) > (new Date(2019, 11, 01)), Is.True);
                Assert.That(new Date(2019, 11, 18) > (new Date(2019, 11, 18)), Is.False);
                Assert.That(new Date(2019, 11, 18) > (new Date(2019, 11, 22)), Is.False);
            });
        }

        [TestCase]
        public void LessThanEqualTest()
        {
            Assert.Multiple(() =>
            {
                Assert.That(new Date(2019, 11, 18) <= (new Date(2019, 11, 01)), Is.False);
                Assert.That(new Date(2019, 11, 18) <= (new Date(2019, 11, 18)), Is.True);
                Assert.That(new Date(2019, 11, 18) <= (new Date(2019, 11, 22)), Is.True);
            });
        }

        [TestCase]
        public void GreaterThanEqualTest()
        {
            Assert.Multiple(() =>
            {
                Assert.That(new Date(2019, 11, 18) >= (new Date(2019, 11, 01)), Is.True);
                Assert.That(new Date(2019, 11, 18) >= (new Date(2019, 11, 18)), Is.True);
                Assert.That(new Date(2019, 11, 18) >= (new Date(2019, 11, 22)), Is.False);
            });
        }
    }
}
