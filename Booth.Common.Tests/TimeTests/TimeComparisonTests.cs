using System;

using NUnit.Framework;
using FluentAssertions;

namespace Booth.Common.Tests.TimeTests
{
    class TimeComparisonTests
    {
        [TestCase]
        public void CompareTime1LessThanTime2()
        {
            var result = Time.Compare(new Time(14, 02, 24), new Time(11, 02, 06));

            result.Should().BePositive();
        }

        [TestCase]
        public void CompareTime1EqualToTime2()
        {
            var result = Time.Compare(new Time(14, 02, 24), new Time(14, 02, 24));

            result.Should().Be(0);
        }

        [TestCase]
        public void CompareTime1GreaterThanTime2()
        {
            var result = Time.Compare(new Time(14, 02, 24), new Time(14, 45, 22));

            result.Should().BeNegative();
        }

        [TestCase]
        public void CompareToTimeLessThanThisTime()
        {
            var time = new Time(14, 02, 24);

            var result = time.CompareTo(new Time(11, 02, 06));

            result.Should().BePositive();
        }

        [TestCase]
        public void CompareToTimeEqualToThisTime()
        {
            var time = new Time(14, 02, 24);

            var result = time.CompareTo(new Time(14, 02, 24));

            result.Should().Be(0);
        }

        [TestCase]
        public void CompareToTimeGreaterThanThisTime()
        {
            var time = new Time(14, 02, 24);

            var result = time.CompareTo(new Time(14, 45, 22));

            result.Should().BeNegative();
        }


        [TestCase]
        public void CompareToNullObject()
        {
            var time = new Time(14, 02, 24);

            var result = time.CompareTo(null);

            result.Should().BePositive();
        }

        [TestCase]
        public void CompareToInteger()
        {
            var time = new Time(14, 02, 24);

            Action a = () => time.CompareTo(5);

            a.Should().ThrowExactly<ArgumentException>();
        }

        [TestCase]
        public void CompareToTimeSpanObject()
        {
            var time = new Time(14, 02, 24);

            var result = time.CompareTo(new TimeSpan(14, 02, 24));

            result.Should().Be(0);
        }


        [TestCase]
        public void EqualsTimeLessThanThisTime()
        {
            var time = new Time(14, 02, 24);

            var result = time.Equals(new Time(11, 02, 06));

            result.Should().BeFalse();
        }

        [TestCase]
        public void EqualsTimeEqualToThisTime()
        {
            var time = new Time(14, 02, 24);

            var result = time.Equals(new Time(14, 02, 24));

            result.Should().BeTrue();
        }

        [TestCase]
        public void EqualsTimeGreaterThanThisTime()
        {
            var time = new Time(14, 02, 24);

            var result = time.Equals(new Time(14, 45, 22));

            result.Should().BeFalse();
        }

        [TestCase]
        public void EqualsObjectString()
        {
            var time = new Time(14, 02, 24);

            Action a = () => time.Equals("Hello");

            a.Should().ThrowExactly<ArgumentException>();
        }

        [TestCase]
        public void StaticEqualsTime1LessThanTime2()
        {
            var result = Time.Equals(new Time(14, 02, 24), new Time(11, 02, 06));

            result.Should().BeFalse();
        }

        [TestCase]
        public void StaticEqualsTime1EqualToTime2()
        {
            var result = Time.Equals(new Time(14, 02, 24), new Time(14, 02, 24));

            result.Should().BeTrue();
        }

        [TestCase]
        public void StaticEqualsTime1GreaterThanTime2()
        {
            var result = Time.Equals(new Time(14, 02, 24), new Time(14, 45, 22));

            result.Should().BeFalse();
        }

        [TestCase]
        public void TimeGetHashCode()
        {
            var time = new Time(14, 02, 24);
            
            var hashCode= time.GetHashCode();

            hashCode.Should().Be(50544);
        }
    }
}
