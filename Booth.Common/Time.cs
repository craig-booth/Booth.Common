using System;
using System.Runtime.Serialization;

namespace Booth.Common
{
    [Serializable]
    public readonly struct Time : IComparable, IComparable<Time>, IEquatable<Time>, IFormattable, ISerializable
    {
        public int Hour { get; }
        public int Minute { get; }
        public int Second { get; }

        public Time(TimeSpan timeSpan)
        {
            if (timeSpan.Ticks < 0)
                throw new ArgumentOutOfRangeException();
            if (timeSpan.Days >= 1)
                throw new ArgumentOutOfRangeException();

            Hour = timeSpan.Hours;
            Minute = timeSpan.Minutes;
            Second = timeSpan.Seconds;
        }

        public Time(int hours, int minutes, int seconds)
        {
            if ((hours < 0) || (hours >= 24))
                throw new ArgumentOutOfRangeException();
            if ((minutes < 0) || (minutes >= 60))
                throw new ArgumentOutOfRangeException();
            if ((seconds < 0) || (seconds >= 60))
                throw new ArgumentOutOfRangeException();

            Hour = hours;
            Minute = minutes;
            Second = seconds;
        }

        public Time(SerializationInfo info, StreamingContext context)
        {
            Hour = info.GetInt32("Hour");
            Minute = info.GetInt32("Minute");
            Second = info.GetInt32("Second");
        }

        public static Time MinValue = new Time(0, 0, 0);
        public static Time MaxValue = new Time(23, 59, 59);

        public static Time Now
        {
            get
            {
                var now = DateTime.Now;
                return new Time(now.Hour, now.Minute, now.Second);
            }
        }
        public TimeSpan TimeSpan
        {
            get
            {
                return new TimeSpan(Hour, Minute, Second);
            }
        }

        public static int Compare(Time t1, Time t2)
        {
            return t1.CompareTo(t2);
        }

        public static bool Equals(Time t1, Time t2)
        {
            return t1.Equals(t2);
        }

        public static Time Parse(string s)
        {
            return new Time(TimeSpan.Parse(s));
        }

        public static Time ParseExact(string s, string format, IFormatProvider provider)
        {
            return new Time(TimeSpan.ParseExact(s, format, provider));
        }

        public static bool TryParse(string s, out Time result)
        {
            var successful = TimeSpan.TryParse(s, out var timeSpan);

            result = new Time(timeSpan);
            return successful; 
        }

        public static bool TryParseExact(string s, string format, IFormatProvider provider, out Time result)
        {
            var successful = TimeSpan.TryParseExact(s, format, provider, out var timeSpan);

            result = new Time(timeSpan);
            return successful; 
        }

        public Time Add(TimeSpan value)
        {
            var newTime = TimeSpan.Add(value);

            if (newTime.Days >= 1)
                throw new OverflowException();

            return new Time(newTime);
        }

        public Time AddSeconds(int seconds)
        {
            return Add(new TimeSpan(0, 0, seconds));
        }

        public Time AddMinutes(int minutes)
        {
            return Add(new TimeSpan(0, minutes, 0));
        }

        public Time AddHours(int hours)
        {
            return Add(new TimeSpan(hours, 0, 0));
        }

        public int CompareTo(object value)
        {
            if (value == null)
                return 1;
            else if (value is Time)
                return CompareTo((Time)value);
            else if (value is TimeSpan)
            {
                var ts = (TimeSpan)value;
                if (ts.Ticks < 0)
                    return -1;
                else if (ts.Days >= 1)
                    return 1;
                else
                    return CompareTo(new Time((TimeSpan)value));
            }
            else
                throw new ArgumentException("Object must be of type Time or TimeSpan"); 
        }

        public int CompareTo(Time value)
        {
            if (Hour < value.Hour)
                return -1;
            else if (Hour > value.Hour)
                return 1;
            else
            {
                if (Minute < value.Minute)
                    return -1;
                else if (Minute > value.Minute)
                    return 1;
                else
                {
                    if (Second < value.Second)
                        return -1;
                    else if (Second > value.Second)
                        return 1;
                    else
                        return 0;
                }
            }

        }

        public bool Equals(Time value)
        {
            return ((Hour == value.Hour) && (Minute == value.Minute) && (Second == value.Second));
        }

        public override bool Equals(object value)
        {
            if (value == null)
                return false;
            else if (value is Time)
                return Equals((Time)value);
            else if (value is TimeSpan)
            {
                var ts = (TimeSpan)value;
                if (ts.Ticks < 0)
                    return false;
                else if (ts.Days >= 1)
                    return false;
                else
                    return Equals(new Time((TimeSpan)value));
            }
            else
                throw new ArgumentException("Object must be of type Time or TimeSpan"); 
        }

        public override int GetHashCode()
        {
            return Hour * 3600 + Minute * 60 + Second;
        }

        public Time Subtract(TimeSpan value)
        {
            var newTime = TimeSpan.Subtract(value);

            if (newTime.Ticks < 0)
                throw new OverflowException();

            return new Time(newTime);
        }

        public TimeSpan Subtract(Time value)
        {
            return TimeSpan.Subtract(value.TimeSpan);
        }

        public string ToString(string format, IFormatProvider provider)
        {
            var d = new DateTime(0001, 01, 01, Hour, Minute, Second);
            return d.ToString(format, provider);
        }
        public string ToString(string format)
        {
            var d = new DateTime(0001, 01, 01, Hour, Minute, Second);
            return d.ToString(format);
        }

        public override string ToString()
        {
            var d = new DateTime(0001, 01, 01, Hour, Minute, Second);
            return d.ToString(@"HH\:mm\:ss");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");

            info.AddValue("Hour", Hour, typeof(int));
            info.AddValue("Minute", Minute, typeof(int));
            info.AddValue("Second", Second, typeof(int));
        }

        public static Time operator +(Time t, TimeSpan ts)
        {
            return t.Add(ts);
        }

        public static TimeSpan operator -(Time t1, Time t2)
        {
            return t1.Subtract(t2);
        }

        public static Time operator -(Time t, TimeSpan ts)
        {
            return t.Subtract(ts);
        }

        public static bool operator ==(Time t1, Time t2)
        {
            return ((t1.Hour == t2.Hour) && (t1.Minute == t2.Minute) && (t1.Second == t2.Second));
        }

        public static bool operator !=(Time t1, Time t2)
        {
            return ((t1.Hour != t2.Hour) || (t1.Minute != t2.Minute) || (t1.Second != t2.Second));
        }

        public static bool operator <(Time t1, Time t2)
        {
            var result = t1.CompareTo(t2);
            return (result < 0);
        }

        public static bool operator >(Time t1, Time t2)
        {
            var result = t1.CompareTo(t2);
            return (result > 0);
        }

        public static bool operator <=(Time t1, Time t2)
        {
            var result = t1.CompareTo(t2);
            return (result <= 0);
        }

        public static bool operator >=(Time t1, Time t2)
        {
            var result = t1.CompareTo(t2);
            return (result >= 0);
        }
            
    }
}
