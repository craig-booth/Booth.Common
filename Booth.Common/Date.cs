using System;
using System.Globalization;
using System.Runtime.Serialization;


namespace Booth.Common
{
    [Serializable]
    public readonly struct Date : IComparable, IComparable<Date>, IEquatable<Date>, IFormattable, ISerializable
    {
        private readonly DateTime _DateTime;

        public Date(DateTime dateTime)
        {
            _DateTime = DateTime.SpecifyKind(dateTime.Date, DateTimeKind.Utc);
        }

        public Date(int year, int month, int day)
        {
            _DateTime = new DateTime(year, month, day, 0, 0, 0, DateTimeKind.Utc);
        }

        public Date(SerializationInfo info, StreamingContext context)
        {
            _DateTime = new DateTime(info.GetInt32("Year"), info.GetInt32("Month"), info.GetInt32("Day"), 0, 0, 0, DateTimeKind.Utc);
        }

        public static Date MinValue = new Date(0001, 01, 01);
        public static Date MaxValue = new Date(9999, 12, 31);

        public static Date Today 
        { 
            get
            {
                var today = DateTime.Today;
                return new Date(today.Year, today.Month, today.Day);
            } 
        }

        public DateTime DateTime
        {
            get
            {
                return _DateTime;
            }
        }

        public int Day
        {
            get
            {
                return _DateTime.Day;
            }
        }

        public int Month
        {
            get
            {
                return _DateTime.Month;
            }
        }

        public int Year
        {
            get
            {
                return _DateTime.Year;
            }
        }

        public DayOfWeek DayOfWeek
        {
            get
            {
                return _DateTime.DayOfWeek;
            }
        }

        public int DayOfYear
        {
            get
            {
                return _DateTime.DayOfYear;
            }
        }

        public static int Compare(Date d1, Date d2)
        {
            return d1.CompareTo(d2);
        }

        public static bool Equals(Date d1, Date d2)
        {
            return d1.Equals(d2);
        }

        public static Date Parse(string s)
        {
            return new Date(DateTime.Parse(s));
        }

        public static Date ParseExact(string s, string format, IFormatProvider provider, DateTimeStyles style)
        {
            return new Date(DateTime.ParseExact(s, format, provider, style));
        }

        public static bool TryParse(string s, out Date result)
        {
            var successful = DateTime.TryParse(s, out var dateTime);
            
            result = new Date(dateTime);
            return successful;
        }

        public static bool TryParseExact(string s, string format, IFormatProvider provider, DateTimeStyles style, out Date result)
        {
            var successful = DateTime.TryParseExact(s, format, provider, style, out var dateTime);

            result = new Date(dateTime);
            return successful;
        }

        public Date Add(TimeSpan value)
        {
            return new Date(_DateTime.AddDays(value.TotalDays));
        }

        public Date AddDays(int days)
        {
            return new Date(_DateTime.AddDays(days));
        }

        public Date AddMonths(int months)
        {
            return new Date(_DateTime.AddMonths(months));
        }

        public Date AddYears(int years)
        {
            return new Date(_DateTime.AddYears(years));
        }

        public int CompareTo(object value)
        {
            if (value == null)
                return 1;
            else if (value is Date)
                return _DateTime.CompareTo(((Date)(value)).DateTime);
            else if (value is DateTime)
                return _DateTime.CompareTo((DateTime)value);
            else
                throw new ArgumentException("Object must be of type Date or DateTime");
        }

        public int CompareTo(Date value)
        {
            return _DateTime.CompareTo(value.DateTime);
        }

        public bool Equals(Date value)
        {
            return ((Year == value.Year) && (Month == value.Month) && (Day == value.Day));
        }

        public override bool Equals(object value)
        {
            if (value == null)
                return false;
            else if (value is Date)
                return Equals((Date)value);
            else if (value is DateTime)
                return _DateTime.Equals((DateTime)value);
            else
                throw new ArgumentException("Object must be of type Date or DateTime");
        }

        public override int GetHashCode()
        {
            return _DateTime.GetHashCode();
        }

        public Date Subtract(TimeSpan value)
        {
            return new Date(_DateTime.AddDays(-value.TotalDays));
        }

        public TimeSpan Subtract(Date value)
        {
            return _DateTime.Subtract(value.DateTime);
        }

        public string ToLongDateString()
        {
            return _DateTime.ToLongDateString();
        }

        public string ToShortDateString()
        {
            return _DateTime.ToShortDateString();
        }

        public string ToString(string format, IFormatProvider provider)
        {
            return _DateTime.ToString(format, provider);
        }
        public string ToString(string format)
        {
            return _DateTime.ToString(format);
        }

        public string ToString(IFormatProvider provider)
        {
            return _DateTime.ToString(provider);
        }

        public override string ToString()
        {
            return _DateTime.ToShortDateString();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");

            info.AddValue("Year", _DateTime.Year, typeof(int));
            info.AddValue("Month", _DateTime.Month, typeof(int));
            info.AddValue("Day", _DateTime.Day, typeof(int));
        }

        public static Date operator +(Date d, TimeSpan t)
        {
            return d.Add(t);
        }

        public static TimeSpan operator -(Date d1, Date d2)
        {
            return d1.Subtract(d2);
        }

        public static Date operator -(Date d, TimeSpan t)
        {
            return d.Subtract(t);
        }

        public static bool operator ==(Date d1, Date d2)
        {
            return ((d1.Year == d2.Year) && (d1.Month == d2.Month) && (d1.Day == d2.Day));
        }

        public static bool operator !=(Date d1, Date d2)
        {
            return ((d1.Year != d2.Year) || (d1.Month != d2.Month) || (d1.Day != d2.Day));
        }

        public static bool operator <(Date d1, Date d2)
        {
            if (d1.Year < d2.Year)
                return true;
            else if ((d1.Year == d2.Year) && (d1.Month < d2.Month))
                return true;
            else if ((d1.Year == d2.Year) && (d1.Month == d2.Month) && (d1.Day < d2.Day))
                return true;
            else
                return false;
        }

        public static bool operator >(Date d1, Date d2)
        {
            if (d1.Year > d2.Year)
                return true;
            else if ((d1.Year == d2.Year) && (d1.Month > d2.Month))
                return true;
            else if ((d1.Year == d2.Year) && (d1.Month == d2.Month) && (d1.Day > d2.Day))
                return true;
            else
                return false;
        }

        public static bool operator <=(Date d1, Date d2)
        {
            if (d1.Year < d2.Year)
                return true;
            else if ((d1.Year == d2.Year) && (d1.Month < d2.Month))
                return true;
            else if ((d1.Year == d2.Year) && (d1.Month == d2.Month) && (d1.Day < d2.Day))
                return true;
            else if ((d1.Year == d2.Year) && (d1.Month == d2.Month) && (d1.Day == d2.Day))
                return true;
            else
                return false;
        }

        public static bool operator >=(Date d1, Date d2) 
        {
            if (d1.Year > d2.Year)
                return true;
            else if ((d1.Year == d2.Year) && (d1.Month > d2.Month))
                return true;
            else if ((d1.Year == d2.Year) && (d1.Month == d2.Month) && (d1.Day > d2.Day))
                return true;
            else if ((d1.Year == d2.Year) && (d1.Month == d2.Month) && (d1.Day == d2.Day))
                return true;
            else
                return false;
        }

    }
}
