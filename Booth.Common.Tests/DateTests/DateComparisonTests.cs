using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Booth.Common.Tests.DateTests
{
    class DateComparisonTests
    {
        [TestCase]
        public void CompareDate1LessThanDate2()
        {
            var result = Date.Compare(new Date(2019, 11, 18), new Date(2019, 11, 01));
            result.Should().BePositive();
        }

        [TestCase]
        public void CompareDate1EqualToDate2()
        {
            var result = Date.Compare(new Date(2019, 11, 18), new Date(2019, 11, 18));
            result.Should().Be(0);
        }

        [TestCase]
        public void CompareDate1GreaterThanDate2()
        {
            var result = Date.Compare(new Date(2019, 11, 18), new Date(2019, 11, 22));
            result.Should().BeNegative();
        }

        [TestCase]
        public void CompareToDateLessThanThisDate()
        {
            var date = new Date(2019, 11, 18);

            var result = date.CompareTo(new Date(2019, 11, 01));

            result.Should().BePositive();
        }

        [TestCase]
        public void CompareToDateEqualToThisDate()
        {
            var date = new Date(2019, 11, 18);

            var result = date.CompareTo(new Date(2019, 11, 18));

            result.Should().Be(0);
        }

        [TestCase]
        public void CompareToDateGreaterThanThisDate()
        {
            var date = new Date(2019, 11, 18);

            var result = date.CompareTo(new Date(2019, 11, 22));

            result.Should().BeNegative();
        }


        [TestCase]
        public void CompareToNullObject()
        {
            var date = new Date(2019, 11, 18);

            var result = date.CompareTo(null);

            result.Should().Be(1);
        }

        [TestCase]
        public void CompareToDateObject()
        {
            var date = new Date(2019, 11, 18);

            var result = date.CompareTo(new Date(2019, 11, 18));

            result.Should().Be(0);
        }

        [TestCase]
        public void CompareToDateTimeObject()
        {
            var date = new Date(2019, 11, 18);

            var result = date.CompareTo(new DateTime(2019, 11, 18));

            result.Should().Be(0);
        }

        [TestCase]
        public void CompareToInteger()
        {
            var date = new Date(2019, 11, 18);

            Action a = () => date.CompareTo(5);

            a.Should().ThrowExactly<ArgumentException>();
        }

        [TestCase]
        public void EqualsDateLessThanThisDate()
        {
            var date = new Date(2019, 11, 18);

            var result = date.Equals(new Date(2019, 11, 01));

            result.Should().BeFalse();
        }

        [TestCase]
        public void EqualsDateEqualThisDate()
        {
            var date = new Date(2019, 11, 18);

            var result = date.Equals(new Date(2019, 11, 18));

            result.Should().BeTrue();
        }

        [TestCase]
        public void EqualsDateGreaterThanThisDate()
        {
            var date = new Date(2019, 11, 18);

            var result = date.Equals(new Date(2019, 11, 22));

            result.Should().BeFalse();
        }

        [TestCase]
        public void EqualsObjectNull()
        {
            var date = new Date(2019, 11, 18);

            var result = date.Equals(null);

            result.Should().BeFalse();
        }

        [TestCase]
        public void EqualsObjectDate()
        {
            var date = new Date(2019, 11, 18);
            var date2 = new Date(2019, 11, 18);

            var result = date.Equals((object)date2);

            result.Should().BeTrue();
        }

        [TestCase]
        public void EqualsObjectDateTimeSameDateWithTimeComponent()
        {
            var date = new Date(2019, 11, 18);

            var result = date.Equals(new DateTime(2019, 11, 18, 1, 23, 50));

            result.Should().BeFalse();
        }

        [TestCase]
        public void EqualsObjectDateTimeSameDateWithoutTimeComponent()
        {
            var date = new Date(2019, 11, 18);

            var result = date.Equals(new DateTime(2019, 11, 18));

            result.Should().BeTrue();
        }

        [TestCase]
        public void EqualsObjectDateTimeDifferentDateWithTimeComponent()
        {
            var date = new Date(2019, 11, 18);

            var result = date.Equals(new DateTime(2019, 11, 01, 1, 23, 50));

            result.Should().BeFalse();
        }

        [TestCase]
        public void EqualsObjectDateTimeDifferentDateWithoutTimeComponent()
        {
            var date = new Date(2019, 11, 18);

            var result = date.Equals(new DateTime(2019, 11, 01));

            result.Should().BeFalse();
        }

        [TestCase]
        public void EqualsObjectString()
        {
            var date = new Date(2019, 11, 18);

            Action a = () => date.Equals("Hello");

            a.Should().ThrowExactly<ArgumentException>();
        }

        [TestCase]
        public void StaticEqualsDate1LessThanDate2()
        {
            var result = Date.Equals(new Date(2019, 11, 18), new Date(2019, 11, 01));

            result.Should().BeFalse();
        }

        [TestCase]
        public void StaticEqualsDate1LessEqualDate2()
        {
            var result = Date.Equals(new Date(2019, 11, 18), new Date(2019, 11, 18));

            result.Should().BeTrue();
        }

        [TestCase]
        public void StaticEqualsDate1GreaterThanDate2()
        {
            var result = Date.Equals(new Date(2019, 11, 18), new Date(2019, 11, 22));

            result.Should().BeFalse();
        }

        [TestCase]
        public void DateGetHashCode()
        {
            var date = new Date(2019, 11, 18);

            var hashCode = date.GetHashCode();

            hashCode.Should().Be(new DateTime(2019, 11, 18).GetHashCode());
        }
    }
}
