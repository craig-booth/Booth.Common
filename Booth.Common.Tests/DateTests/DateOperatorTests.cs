using System;
using System.Collections.Generic;
using System.Text;

using Xunit;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Booth.Common.Tests.DateTests
{
    public class DateOperatorTests
    {

        [Fact]
        public void AddTimeSpan()
        {
            var date = new Date(2019, 11, 04);

            var newDate = date + new TimeSpan(0, 26, 3, 0, 0);

            newDate.Should().Be(new Date(2019, 11, 05));
        }


        [Fact]
        public void SubtractTimeSpan()
        {
            var date = new Date(2019, 11, 04);

            var newDate = date - new TimeSpan(0, 26, 3, 0, 0);

            newDate.Should().Be(new Date(2019, 11, 02));
        }

        [Fact]
        public void SubtractDate()
        {
            var date = new Date(2019, 11, 04);

            var timeSpan = date - new Date(2019, 11, 30);

            timeSpan.Should().Be(new TimeSpan(-26, 0, 0, 0));
        }

        [Fact]
        public void Equal()
        {
            var date = new Date(2019, 11, 18);

            bool result;
            using (new AssertionScope())
            {
                result = date == new Date(2019, 11, 01);
                result.Should().BeFalse("date being compared is less than given date");

                result = date == new Date(2019, 11, 18);
                result.Should().BeTrue("date being compared is equal to given date");

                result = date == new Date(2019, 11, 22);
                result.Should().BeFalse("date being compared is greater than given date");
            };
        }

        [Fact]
        public void NotEqual()
        {
            var date = new Date(2019, 11, 18);

            bool result;
            using (new AssertionScope())
            {
                result = date != new Date(2019, 11, 01);
                result.Should().BeTrue("date being compared is less than given date");

                result = date != new Date(2019, 11, 18);
                result.Should().BeFalse("date being compared is equal to given date");

                result = date != new Date(2019, 11, 22);
                result.Should().BeTrue("date being compared is greater than given date");
            };
        }

        [Fact]
        public void LessThan()
        {
            var date = new Date(2019, 11, 18);

            bool result;
            using (new AssertionScope())
            {
                result = date < new Date(2019, 11, 01);
                result.Should().BeFalse("date being compared is less than given date");

                result = date < new Date(2019, 11, 18);
                result.Should().BeFalse("date being compared is equal to given date");

                result = date < new Date(2019, 11, 22);
                result.Should().BeTrue("date being compared is greater than given date");
            };
        }

        [Fact]
        public void GreaterThan()
        {
            var date = new Date(2019, 11, 18);

            bool result;
            using (new AssertionScope())
            {
                result = date > new Date(2019, 11, 01);
                result.Should().BeTrue("date being compared is less than given date");

                result = date > new Date(2019, 11, 18);
                result.Should().BeFalse("date being compared is equal to given date");

                result = date > new Date(2019, 11, 22);
                result.Should().BeFalse("date being compared is greater than given date");
            };
        }

        [Fact]
        public void LessThanEqual()
        {
            var date = new Date(2019, 11, 18);

            bool result;
            using (new AssertionScope())
            {
                result = date <= new Date(2019, 11, 01);
                result.Should().BeFalse("date being compared is less than given date");

                result = date <= new Date(2019, 11, 18);
                result.Should().BeTrue("date being compared is equal to given date");

                result = date <= new Date(2019, 11, 22);
                result.Should().BeTrue("date being compared is greater than given date");
            };
        }

        [Fact]
        public void GreaterThanEqual()
        {
            var date = new Date(2019, 11, 18);

            bool result;
            using (new AssertionScope())
            {
                result = (date >= new Date(2019, 11, 01));
                result.Should().BeTrue("date being compared is less than given date");

                result = (date >= new Date(2019, 11, 18));
                result.Should().BeTrue("date being compared is equal to given date");

                result = (date >= new Date(2019, 11, 22));
                result.Should().BeFalse("date being compared is greater than given date");
            };
        }
    }
}
