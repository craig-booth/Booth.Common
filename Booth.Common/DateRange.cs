﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Booth.Common
{
    public struct DateRange : IEquatable<DateRange>
    {
        public Date FromDate;
        public Date ToDate;

        public DateRange(Date fromDate, Date toDate)
        {
            if (fromDate > toDate)
                throw new ArgumentException("From Date must be on or before To Date");

            FromDate = fromDate;
            ToDate = toDate;
        }

        public bool Contains(Date date)
        {
            return (FromDate <= date) && (ToDate >= date);
        }

        public bool Overlaps(DateRange dateRange)
        {
            return (FromDate <= dateRange.FromDate && ToDate >= dateRange.FromDate) ||
                   (FromDate > dateRange.FromDate && FromDate <= dateRange.ToDate);
        }

        public static bool operator ==(DateRange a, DateRange b)
        {
            return (a.FromDate == b.FromDate) && (a.ToDate == b.ToDate);
        }

        public static bool operator !=(DateRange a, DateRange b)
        {
            return (a.FromDate != b.FromDate) || (a.ToDate != b.ToDate);
        }

        public override string ToString()
        {
            return String.Format("{0:d} - {1:d}", FromDate, ToDate);
        }

        public override bool Equals(object obj)
        {
            if (obj is DateRange)
                return this == (DateRange)obj;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return (FromDate.GetHashCode() * -1521134295) + ToDate.GetHashCode();
        }

        public bool Equals(DateRange other)
        {
            return this == other;
        }
    }
}