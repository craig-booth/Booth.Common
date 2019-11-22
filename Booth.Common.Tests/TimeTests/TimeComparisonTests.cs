using System;
using NUnit.Framework;

namespace Booth.Common.Tests.TimeTests
{
    class TimeComparisonTests
    {
        [TestCase]
        public void CompareTest()
        {
            Assert.Multiple(() =>
            {
                Assert.That(Time.Compare(new Time(14, 02, 24), new Time(11, 02, 06)), Is.EqualTo(1));
                Assert.That(Time.Compare(new Time(14, 02, 24), new Time(14, 02, 24)), Is.EqualTo(0));
                Assert.That(Time.Compare(new Time(14, 02, 24), new Time(14, 45, 22)), Is.EqualTo(-1));
            });
        }

        [TestCase]
        public void CompareToTest()
        {
            Assert.Multiple(() =>
            {
                Assert.That(new Time(14, 02, 24).CompareTo(new Time(11, 02, 06)), Is.EqualTo(1));
                Assert.That(new Time(14, 02, 24).CompareTo(new Time(14, 02, 24)), Is.EqualTo(0));
                Assert.That(new Time(14, 02, 24).CompareTo(new Time(14, 45, 22)), Is.EqualTo(-1));
            });
        }

        [TestCase]
        public void CompareToObjectTest()
        {
            Assert.Multiple(() =>
            {
                Assert.That(new Time(14, 02, 24).CompareTo(null), Is.EqualTo(1));
                Assert.That(new Time(14, 02, 24).CompareTo(new Time(14, 02, 24)), Is.EqualTo(0));
                Assert.That(new Time(14, 02, 24).CompareTo(new TimeSpan(14, 02, 24)), Is.EqualTo(0));
                Assert.That(() => new Time(14, 02, 24).CompareTo(5), Throws.ArgumentException);
            });
        }

        [TestCase]
        public void EqualsTest()
        {
            Assert.Multiple(() =>
            {
                Assert.That(new Time(14, 02, 24).Equals(new Time(11, 02, 06)), Is.False);
                Assert.That(new Time(14, 02, 24).Equals(new Time(14, 02, 24)), Is.True);
                Assert.That(new Time(14, 02, 24).Equals(new Time(14, 45, 22)), Is.False);
            });
        }

        [TestCase]
        public void StaticEqualsObjectTest()
        {
            Assert.Multiple(() =>
            {
                Assert.That(Time.Equals(new Time(14, 02, 24), new Time(11, 02, 06)), Is.False);
                Assert.That(Time.Equals(new Time(14, 02, 24), new Time(14, 02, 24)), Is.True);
                Assert.That(Time.Equals(new Time(14, 02, 24), new Time(14, 45, 22)), Is.False);
            });
        }

        [TestCase]
        public void GetHashCodeTest()
        {
            Assert.That(new Time(14, 02, 24).GetHashCode(), Is.Not.EqualTo(0));
        }
    }
}
