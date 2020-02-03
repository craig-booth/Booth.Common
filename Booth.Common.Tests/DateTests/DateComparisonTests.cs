using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;

namespace Booth.Common.Tests.DateTests
{
    class DateComparisonTests
    {
        [TestCase]
        public void CompareTest()
        {
            Assert.Multiple(() =>
            {
                Assert.That(Date.Compare(new Date(2019, 11, 18), new Date(2019, 11, 01)), Is.EqualTo(1));
                Assert.That(Date.Compare(new Date(2019, 11, 18), new Date(2019, 11, 18)), Is.EqualTo(0));
                Assert.That(Date.Compare(new Date(2019, 11, 18), new Date(2019, 11, 22)), Is.EqualTo(-1));
            });
        }

        [TestCase]
        public void CompareToTest()
        {
            Assert.Multiple(() =>
            {
                Assert.That(new Date(2019, 11, 18).CompareTo(new Date(2019, 11, 01)), Is.EqualTo(1));
                Assert.That(new Date(2019, 11, 18).CompareTo(new Date(2019, 11, 18)), Is.EqualTo(0));
                Assert.That(new Date(2019, 11, 18).CompareTo(new Date(2019, 11, 22)), Is.EqualTo(-1));
            });
        }

        [TestCase]
        public void CompareToObjectTest()
        {
            Assert.Multiple(() =>
            {
                Assert.That(new Date(2019, 11, 18).CompareTo(null), Is.EqualTo(1));
                Assert.That(new Date(2019, 11, 18).CompareTo(new Date(2019, 11, 18)), Is.EqualTo(0));
                Assert.That(new Date(2019, 11, 18).CompareTo(new DateTime(2019, 11, 18)), Is.EqualTo(0));
                Assert.That(() => new Date(2019, 11, 18).CompareTo(5), Throws.ArgumentException);
            });
        }

        [TestCase]
        public void EqualsTest()
        {
            Assert.Multiple(() =>
            {
                Assert.That(new Date(2019, 11, 18).Equals(new Date(2019, 11, 01)), Is.False);
                Assert.That(new Date(2019, 11, 18).Equals(new Date(2019, 11, 18)), Is.True);
                Assert.That(new Date(2019, 11, 18).Equals(new Date(2019, 11, 22)), Is.False);
            });
        }

        [TestCase]
        public void EqualsObjectNullTest()
        {
            Assert.That(new Date(2019, 11, 18).Equals(null), Is.False);
        }

        [TestCase]
        public void EqualsObjectDateTest()
        {
            var date = new Date(2019, 11, 18);

            Assert.That(new Date(2019, 11, 18).Equals((object)date), Is.True);
        }

        [TestCase]
        public void EqualsObjectDateTimeTest()
        {
            Assert.Multiple(() =>
            {
                Assert.That(new Date(2019, 11, 18).Equals(new DateTime(2019, 11, 01)), Is.False);
                Assert.That(new Date(2019, 11, 18).Equals(new DateTime(2019, 11, 18)), Is.True);
                Assert.That(new Date(2019, 11, 18).Equals(new DateTime(2019, 11, 22)), Is.False);
            });
        }

        [TestCase]
        public void EqualsObjectStringTest()
        {
            Assert.That(() => new Date(2019, 11, 18).Equals("Hello"), Throws.ArgumentException);
        }

        [TestCase]
        public void StaticEqualsObjectTest()
        {
            Assert.Multiple(() =>
            {
                Assert.That(Date.Equals(new Date(2019, 11, 18), new Date(2019, 11, 01)), Is.False);
                Assert.That(Date.Equals(new Date(2019, 11, 18), new Date(2019, 11, 18)), Is.True);
                Assert.That(Date.Equals(new Date(2019, 11, 18), new Date(2019, 11, 22)), Is.False);
            });
        }

        [TestCase]
        public void GetHashCodeTest()
        {
            Assert.That(new Date(2019, 11, 18).GetHashCode(), Is.Not.EqualTo(0));
        }
    }
}
