using System;
using NUnit.Framework;

namespace Booth.Common.Tests.DateRangeTests
{
    class ToStringTests
    {
        [TestCase]
        public void ToStringCorrect()
        {
            var dateRange = new DateRange(new DateTime(2000, 01, 01), new DateTime(2000, 01, 31));

            Assert.That(dateRange.ToString(), Is.EqualTo("1/01/2000 - 31/01/2000"));
        }
    }
}
    
