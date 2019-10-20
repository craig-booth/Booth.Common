using System;
using System.Collections.Generic;
using System.Linq;

namespace Booth.Common
{
    public static class DateUtils
    {
        private readonly static DateTime _NoStartDate = new DateTime(0001, 01, 01);
        private readonly static DateTime _NoEndDate = new DateTime(9999, 12, 31);

        public static DateTime NoDate
        {
            get { return _NoStartDate; }
        }

        public static DateTime NoStartDate 
        {
            get { return _NoStartDate; }
        }

        public static DateTime NoEndDate
        {
            get { return _NoEndDate; }
        }

        public static int FinancialYear(this DateTime date)
        {
            if (date.Month <= 6)
                return date.Year;
            else
                return  date.Year + 1;
        }

        public static DateRange FinancialYear(int financialYear)
        {
            return new DateRange(StartOfFinancialYear(financialYear), EndOfFinancialYear(financialYear));
        }

        public static DateTime StartOfFinancialYear(int financialYear)
        {
            return  new DateTime(financialYear - 1, 7, 1);
        }

        public static DateTime EndOfFinancialYear(int financialYear)
        {
            return new DateTime(financialYear, 6, 30);
        }

        public static Boolean WeekDay(this DateTime date)
        {
            return (date.DayOfWeek >= DayOfWeek.Monday) && (date.DayOfWeek <= DayOfWeek.Friday);
        }

        public static Boolean Between(this DateTime date, DateTime fromDate, DateTime toDate)
        {
            return ((date >= fromDate) && (date <= toDate));
        }

        public static Boolean InRange(this DateTime date, DateRange dateRange)
        {
            return dateRange.Contains(date);
        }

        public static DateTime EndOfWeek(this DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Sunday)
                return date;
            else
                return date.AddDays(7 - ((int)date.DayOfWeek));
        }

        public static DateTime EndOfMonth(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
        }

        public static IEnumerable<DateTime> Days(DateTime fromDate, DateTime toDate)
        {
            return Enumerable.Range(0, toDate.Subtract(fromDate).Days + 1)
                             .Select(d => fromDate.AddDays(d));
        }
        public static IEnumerable<DateTime> Days(DateRange dateRange)
        {
            return Days(dateRange.FromDate, dateRange.ToDate);
        }

        public static IEnumerable<DateTime> WeekEndingDays(DateTime fromDate, DateTime toDate)
        {
            var startDate = fromDate.EndOfWeek();
            var days = 0;
            while (true)
            {
                var date = startDate.AddDays(days);
                if (date > toDate)
                    break;

                yield return date;

                days += 7;
            }
        }

        public static IEnumerable<DateTime> WeekEndingDays(DateRange dateRange)
        {
            return WeekEndingDays(dateRange.FromDate, dateRange.ToDate);
        }

        public static IEnumerable<DateTime> MonthEndingDays(DateTime fromDate, DateTime toDate)
        {
            var date = fromDate.EndOfMonth();
            while (true)
            {
                if (date > toDate)
                    break;

                yield return date;

                int days;
                if (date.Month < 12)
                    days = DateTime.DaysInMonth(date.Year, date.Month + 1);
                else
                    days = DateTime.DaysInMonth(date.Year + 1, date.Month);
                date = date.AddDays(days);
            }
        }

        public static IEnumerable<DateTime> MonthEndingDays(DateRange dateRange)
        {
            return MonthEndingDays(dateRange.FromDate, dateRange.ToDate);
        }

        public static DateTime Earlist(DateTime date1, DateTime date2)
        {
            return  date1 <= date2 ? date1 : date2;
        }

        public static DateTime Latest(DateTime date1, DateTime date2)
        {
            return date1 >= date2 ? date1 : date2;
        }

        public static string ToIsoDateString(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

    }
}
