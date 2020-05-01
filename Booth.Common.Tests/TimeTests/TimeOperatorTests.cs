using System;
using System.Collections.Generic;
using System.Text;

using Xunit;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Booth.Common.Tests.TimeTests
{
    public class TimeOperatorTests
    {

        [Fact]
        public void AddTimeSpan()
        {
            var time = new Time(14, 02, 24);
            var newTime = time + new TimeSpan(2, 4, 24);

            newTime.Should().Be(new Time(16, 06, 48));
        }

        [Fact]
        public void AddTimeSpanOverflow()
        {
            var time = new Time(14, 02, 24);

            Action a = () => {var newTime = time + new TimeSpan(10, 4, 24); };

            a.Should().ThrowExactly<OverflowException>();
        }

        [Fact]
        public void SubtractTimeSpan()
        {
            var time = new Time(14, 02, 24);

            var newTime = time - new TimeSpan(2, 4, 24);

            newTime.Should().Be(new Time(11, 58, 00));
        }

        [Fact]
        public void SubtractTimeSpanOverflow()
        {
            var time = new Time(14, 02, 24);

            Action a = () => { var newTime = time - new TimeSpan(22, 4, 24); };

            a.Should().ThrowExactly<OverflowException>();
        }

        [Fact]
        public void SubtractTime()
        {
            var time = new Time(14, 02, 24);

            var ts = time - new Time(08, 22, 34);

            ts.Should().Be(new TimeSpan(5, 39, 50));
        }

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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
