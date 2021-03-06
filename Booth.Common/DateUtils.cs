﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Booth.Common
{
    public static class DateUtils
    {

        public static int FinancialYear(this Date date)
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

        public static Date StartOfFinancialYear(int financialYear)
        {
            return  new Date(financialYear - 1, 7, 1);
        }

        public static Date EndOfFinancialYear(int financialYear)
        {
            return new Date(financialYear, 6, 30);
        }

        public static Boolean WeekDay(this Date date)
        {
            return (date.DayOfWeek >= DayOfWeek.Monday) && (date.DayOfWeek <= DayOfWeek.Friday);
        }

        public static Boolean Between(this Date date, Date fromDate, Date toDate)
        {
            return ((date >= fromDate) && (date <= toDate));
        }

        public static Boolean InRange(this Date date, DateRange dateRange)
        {
            return dateRange.Contains(date);
        }

        public static Date EndOfWeek(this Date date)
        {
            if (date.DayOfWeek == DayOfWeek.Sunday)
                return date;
            else
                return date.AddDays(7 - ((int)date.DayOfWeek));
        }

        public static Date EndOfMonth(this Date date)
        {
            return new Date(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
        }

        public static IEnumerable<Date> Days(Date fromDate, Date toDate)
        {
            return Enumerable.Range(0, toDate.Subtract(fromDate).Days + 1)
                             .Select(d => fromDate.AddDays(d));
        }
        public static IEnumerable<Date> Days(DateRange dateRange)
        {
            return Days(dateRange.FromDate, dateRange.ToDate);
        }

        public static IEnumerable<Date> WeekEndingDays(Date fromDate, Date toDate)
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

        public static IEnumerable<Date> WeekEndingDays(DateRange dateRange)
        {
            return WeekEndingDays(dateRange.FromDate, dateRange.ToDate);
        }

        public static IEnumerable<Date> MonthEndingDays(Date fromDate, Date toDate)
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

        public static IEnumerable<Date> MonthEndingDays(DateRange dateRange)
        {
            return MonthEndingDays(dateRange.FromDate, dateRange.ToDate);
        }

        public static Date Earlist(Date date1, Date date2)
        {
            return  date1 <= date2 ? date1 : date2;
        }

        public static Date Latest(Date date1, Date date2)
        {
            return date1 >= date2 ? date1 : date2;
        }

        public static string ToIsoDateString(this Date date)
        {
            return date.ToString("yyyy-MM-dd");
        }

    }
}
