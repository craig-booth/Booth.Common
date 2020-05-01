using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Booth.Common.Tests.DateTests
{
    class DateOperatorTests
    {

        [TestCase]
        public void AddTimeSpan()
        {
            var date = new Date(2019, 11, 04);

            var newDate = date + new TimeSpan(0, 26, 3, 0, 0);

            newDate.Should().Be(new Date(2019, 11, 05));
        }


        [TestCase]
        public void SubtractTimeSpan()
        {
            var date = new Date(2019, 11, 04);

            var newDate = date - new TimeSpan(0, 26, 3, 0, 0);

            newDate.Should().Be(new Date(2019, 11, 02));
        }

        [TestCase]
        public void SubtractDate()
        {
            var date = new Date(2019, 11, 04);

            var timeSpan = date - new Date(2019, 11, 30);

            timeSpan.Should().Be(new TimeSpan(-26, 0, 0, 0));
        }

        [TestCase]
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

        [TestCase]
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

        [TestCase]
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

        [TestCase]
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

        [TestCase]
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

        [TestCase]
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
