using System;
using System.Linq;

using Xunit;
using FluentAssertions;

namespace Booth.Common.Tests.DateUtilsTests
{
    public class EnumerableTests
    {
        [Fact]
        public void DaysBetweenDates()
        {
            var startDate = new Date(2000, 02, 25);
            var endDate = new Date(2000, 03, 15);

            var days = DateUtils.Days(startDate, endDate).ToList();

            days.Should().Equal(new Date[]
            {
                new Date(2000, 02, 25),
                new Date(2000, 02, 26),
                new Date(2000, 02, 27),
                new Date(2000, 02, 28),
                new Date(2000, 02, 29),
                new Date(2000, 03, 01),
                new Date(2000, 03, 02),
                new Date(2000, 03, 03),
                new Date(2000, 03, 04),
                new Date(2000, 03, 05),
                new Date(2000, 03, 06),
                new Date(2000, 03, 07),
                new Date(2000, 03, 08),
                new Date(2000, 03, 09),
                new Date(2000, 03, 10),
                new Date(2000, 03, 11),
                new Date(2000, 03, 12),
                new Date(2000, 03, 13),
                new Date(2000, 03, 14),
                new Date(2000, 03, 15)
            });
        }

        [Fact]
        public void DaysInRange()
        {
            var startDate = new Date(2000, 02, 25);
            var endDate = new Date(2000, 03, 15);

            var days = DateUtils.Days(new DateRange(startDate, endDate)).ToList();

            days.Should().Equal(new Date[]
            {
                new Date(2000, 02, 25),
                new Date(2000, 02, 26),
                new Date(2000, 02, 27),
                new Date(2000, 02, 28),
                new Date(2000, 02, 29),
                new Date(2000, 03, 01),
                new Date(2000, 03, 02),
                new Date(2000, 03, 03),
                new Date(2000, 03, 04),
                new Date(2000, 03, 05),
                new Date(2000, 03, 06),
                new Date(2000, 03, 07),
                new Date(2000, 03, 08),
                new Date(2000, 03, 09),
                new Date(2000, 03, 10),
                new Date(2000, 03, 11),
                new Date(2000, 03, 12),
                new Date(2000, 03, 13),
                new Date(2000, 03, 14),
                new Date(2000, 03, 15)
             });

        }

        [Fact]
        public void WeekEndingDaysBetweenDates()
        {
            var startDate = new Date(2000, 01, 01);
            var endDate = new Date(2000, 03, 31);

            var days = DateUtils.WeekEndingDays(startDate, endDate).ToList();

            days.Should().Equal(new Date[]
            {
                new Date(2000, 01, 02),
                new Date(2000, 01, 09),
                new Date(2000, 01, 16),
                new Date(2000, 01, 23),
                new Date(2000, 01, 30),
                new Date(2000, 02, 06),
                new Date(2000, 02, 13),
                new Date(2000, 02, 20),
                new Date(2000, 02, 27),
                new Date(2000, 03, 05),
                new Date(2000, 03, 12),
                new Date(2000, 03, 19),
                new Date(2000, 03, 26)
            });
        }

        [Fact]
        public void WeekEndingDaysBetweenDatesFirstDaySunday()
        {
            var startDate = new Date(2000, 01, 02);
            var endDate = new Date(2000, 03, 31);

            var days = DateUtils.WeekEndingDays(startDate, endDate).ToList();

            days.Should().Equal(new Date[]
                        {
                new Date(2000, 01, 02),
                new Date(2000, 01, 09),
                new Date(2000, 01, 16),
                new Date(2000, 01, 23),
                new Date(2000, 01, 30),
                new Date(2000, 02, 06),
                new Date(2000, 02, 13),
                new Date(2000, 02, 20),
                new Date(2000, 02, 27),
                new Date(2000, 03, 05),
                new Date(2000, 03, 12),
                new Date(2000, 03, 19),
                new Date(2000, 03, 26)
                        });
        }

        [Fact]
        public void WeekEndingDaysBetweenDatesLastDaySunday()
        {
            var startDate = new Date(2000, 01, 01);
            var endDate = new Date(2000, 03, 26);

            var days = DateUtils.WeekEndingDays(startDate, endDate).ToList();

            days.Should().Equal(new Date[]
                        {
                new Date(2000, 01, 02),
                new Date(2000, 01, 09),
                new Date(2000, 01, 16),
                new Date(2000, 01, 23),
                new Date(2000, 01, 30),
                new Date(2000, 02, 06),
                new Date(2000, 02, 13),
                new Date(2000, 02, 20),
                new Date(2000, 02, 27),
                new Date(2000, 03, 05),
                new Date(2000, 03, 12),
                new Date(2000, 03, 19),
                new Date(2000, 03, 26)
                        });
        }

        [Fact]
        public void MonthEndingDaysBetweenDates()
        {
            var startDate = new Date(2000, 01, 01);
            var endDate = new Date(2000, 12, 01);

            var days = DateUtils.MonthEndingDays(startDate, endDate).ToList();

            days.Should().Equal(new Date[]
                        {
                    new Date(2000, 01, 31),
                    new Date(2000, 02, 29),
                    new Date(2000, 03, 31),
                    new Date(2000, 04, 30),
                    new Date(2000, 05, 31),
                    new Date(2000, 06, 30),
                    new Date(2000, 07, 31),
                    new Date(2000, 08, 31),
                    new Date(2000, 09, 30),
                    new Date(2000, 10, 31),
                    new Date(2000, 11, 30)
                        });
        }

        [Fact]
        public void MonthEndingDaysBetweenDatesFirstDateAtEndOfMonth()
        {
            var startDate = new Date(2000, 01, 31);
            var endDate = new Date(2000, 12, 01);

            var days = DateUtils.MonthEndingDays(startDate, endDate).ToList();

            days.Should().Equal(new Date[]
                        {
                    new Date(2000, 01, 31),
                    new Date(2000, 02, 29),
                    new Date(2000, 03, 31),
                    new Date(2000, 04, 30),
                    new Date(2000, 05, 31),
                    new Date(2000, 06, 30),
                    new Date(2000, 07, 31),
                    new Date(2000, 08, 31),
                    new Date(2000, 09, 30),
                    new Date(2000, 10, 31),
                    new Date(2000, 11, 30)
                });
        }

        [Fact]
        public void MonthEndingDaysBetweenDatesLastDateAtEndOfMonth()
        {
            var startDate = new Date(2000, 01, 01);
            var endDate = new Date(2000, 12, 31);

            var days = DateUtils.MonthEndingDays(startDate, endDate).ToList();

            days.Should().Equal(new Date[]
                        {
                    new Date(2000, 01, 31),
                    new Date(2000, 02, 29),
                    new Date(2000, 03, 31),
                    new Date(2000, 04, 30),
                    new Date(2000, 05, 31),
                    new Date(2000, 06, 30),
                    new Date(2000, 07, 31),
                    new Date(2000, 08, 31),
                    new Date(2000, 09, 30),
                    new Date(2000, 10, 31),
                    new Date(2000, 11, 30),
                    new Date(2000, 12, 31)
                });
        }
    }
}
