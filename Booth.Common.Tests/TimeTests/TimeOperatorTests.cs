using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Booth.Common.Tests.TimeTests
{
    class TimeOperatorTests
    {

        [TestCase]
        public void AddTimeSpan()
        {
            var time = new Time(14, 02, 24);
            var newTime = time + new TimeSpan(2, 4, 24);

            newTime.Should().Be(new Time(16, 06, 48));
        }

        [TestCase]
        public void AddTimeSpanOverflow()
        {
            var time = new Time(14, 02, 24);

            Action a = () => {var newTime = time + new TimeSpan(10, 4, 24); };

            a.Should().ThrowExactly<OverflowException>();
        }

        [TestCase]
        public void SubtractTimeSpan()
        {
            var time = new Time(14, 02, 24);

            var newTime = time - new TimeSpan(2, 4, 24);

            newTime.Should().Be(new Time(11, 58, 00));
        }

        [TestCase]
        public void SubtractTimeSpanOverflow()
        {
            var time = new Time(14, 02, 24);

            Action a = () => { var newTime = time - new TimeSpan(22, 4, 24); };

            a.Should().ThrowExactly<OverflowException>();
        }

        [TestCase]
        public void SubtractTime()
        {
            var time = new Time(14, 02, 24);

            var ts = time - new Time(08, 22, 34);

            ts.Should().Be(new TimeSpan(5, 39, 50));
        }

        [TestCase]
        public void Equal()
        {
            var time = new Time(14, 02, 24);

            bool result;
            using (new AssertionScope())
            {
                result = time == new Time(11, 02, 06);
                result.Should().BeFalse("time being compared is less than given time");

                result = time == new Time(14, 02, 24);
                result.Should().BeTrue("time being compared is equal to given time");

                result = time == new Time(14, 45, 22);
                result.Should().BeFalse("time being compared is greater than given time");
            };
        }

        [TestCase]
        public void NotEqual()
        {
            var time = new Time(14, 02, 24);

            bool result;
            using (new AssertionScope())
            {
                result = time != new Time(11, 02, 06);
                result.Should().BeTrue("time being compared is less than given time");

                result = time != new Time(14, 02, 24);
                result.Should().BeFalse("time being compared is equal to given time");

                result = time != new Time(14, 45, 22);
                result.Should().BeTrue("time being compared is greater than given time");
            };
        }

        [TestCase]
        public void LessThan()
        {
            var time = new Time(14, 02, 24);

            bool result;
            using (new AssertionScope())
            {
                result = time < new Time(11, 02, 06);
                result.Should().BeFalse("time being compared is less than given time");

                result = time < new Time(14, 02, 24);
                result.Should().BeFalse("time being compared is equal to given time");

                result = time < new Time(14, 45, 22);
                result.Should().BeTrue("time being compared is greater than given time");
            };
        }

        [TestCase]
        public void GreaterThan()
        {
            var time = new Time(14, 02, 24);

            bool result;
            using (new AssertionScope())
            {
                result = time > new Time(11, 02, 06);
                result.Should().BeTrue("time being compared is less than given time");

                result = time > new Time(14, 02, 24);
                result.Should().BeFalse("time being compared is equal to given time");

                result = time > new Time(14, 45, 22);
                result.Should().BeFalse("time being compared is greater than given time");
            };
        }

        [TestCase]
        public void LessThanEqual()
        {
            var time = new Time(14, 02, 24);

            bool result;
            using (new AssertionScope())
            {
                result = time <= new Time(11, 02, 06);
                result.Should().BeFalse("time being compared is less than given time");

                result = time <= new Time(14, 02, 24);
                result.Should().BeTrue("time being compared is equal to given time");

                result = time <= new Time(14, 45, 22);
                result.Should().BeTrue("time being compared is greater than given time");
            };
        }

        [TestCase]
        public void GreaterThanEqual()
        {
            var time = new Time(14, 02, 24);

            bool result;
            using (new AssertionScope())
            {
                result = time >= new Time(11, 02, 06);
                result.Should().BeTrue("time being compared is less than given time");

                result = time >= new Time(14, 02, 24);
                result.Should().BeTrue("time being compared is equal to given time");

                result = time >= new Time(14, 45, 22);
                result.Should().BeFalse("time being compared is greater than given time");
            };
        }
    }
}
