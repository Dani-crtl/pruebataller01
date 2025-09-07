using System.Linq.Expressions;

namespace POOConcepts.core;

public class Time
{
    private int _hour;
    private int _minute;
    private int _second;
    private int _millisecond;

    public Time()
    {
        Hour = 0;
        Minute = 0;
        Second = 0;
        Millisecond = 0;
    }
    public Time(int hour)
    {
        Hour = hour;
        Minute = 0;
        Second = 0;
        Millisecond = 0;

    }
    public Time(int hour, int minute)
    {
        Hour = hour;
        Minute = minute;
        Second = 0;
        Millisecond = 0;
    }
    public Time(int hour, int minute, int second)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecond = 0;
    }
    public Time(int hour, int minute, int second, int millisecond)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecond = millisecond;
    }
    public int Hour
    {
        get => _hour;
        set
        {
            _hour = ValidateHour(value);
        }
    }
    public int Minute
    {
        get => _minute;
        set
        {
            _minute = ValidateMinute(value);
        }
    }
    public int Second
    {
        get => _second;
        set
        {
            _second = ValidateSecond(value);
        }
    }
    public int Millisecond
    {
        get => _millisecond;
        set
        {
            _millisecond = ValidateMillisecond(value);
        }
    }
    public override string ToString()
    {
        int displayHour = Hour % 12 == 0 ? 12 : Hour % 12;
        string period = Hour >= 12 ? "PM" : "AM";
        return $"{displayHour:00}:{Minute:00}:{Second:00}.{Millisecond:000} {period}";
    }

    private int ValidateHour(int hour)
    {
        if (hour < 0 || hour > 23)
        {
            throw new Exception($"The Hour: {hour}, Is not valid");
        }
        return hour;
    }
    private int ValidateMinute(int minute)
    {
        if (minute < 0 || minute > 59)
        {
            throw new Exception($"TheMinute: {minute}, Is not valid");
        }
        return minute;
    }
    private int ValidateSecond(int second)
    {
        if (second < 0 || second > 59)
        {
            throw new Exception($"The Second: {second}, Is not valid");
        }
        return second;
    }
    private int ValidateMillisecond(int millisecond)
    {
        if (millisecond < 0 || millisecond > 999)
        {
            throw new Exception($"The Millisecond: {millisecond}, Is not valid");
        }
        return millisecond;
    }
    public int Tomilliseconds()
    {
        if (Hour < 0 || Hour > 23 || Minute < 0 || Minute > 59 ||Second < 0 || Second > 59 ||Millisecond < 0 || Millisecond > 999)
        {
            return 0;
        }
        return (Hour * 60 * 60 * 1000) + (Minute * 60 * 1000) + (Second * 1000) + Millisecond;
    }
    public int ToMinutes()
    {
        if (Hour < 0 || Hour > 23 ||
            Minute < 0 || Minute > 59)
        {
            return 0;
        }
        return (Hour * 60) + Minute;
    }
    public int ToSeconds()
    {
        if (Hour < 0 || Hour > 23 ||
            Minute < 0 || Minute > 59 ||
            Second < 0 || Second > 59)
        {
            return 0;
        }
        return (Hour * 60 * 60) + (Minute * 60) + Second;
    }
    public bool IsOtherDay(Time other)
    {
        int ToMilliseconds = this.Tomilliseconds() + other.Tomilliseconds();
        const int secondsPerDay = 24 * 60 * 60 * 1000;
        return (ToMilliseconds >= secondsPerDay);
    }
    public Time Add(Time other)
    {
        int Tomilliseconds = this.Tomilliseconds() + other.Tomilliseconds();

        const int millisecondsPerDay = 24 * 60 * 60 * 1000;

        
        if (Tomilliseconds >= millisecondsPerDay)
        {
           return new Time(23, 59, 59, 999);
        }

        int hour = Tomilliseconds / (60 * 60 * 1000);
        Tomilliseconds %= (60 * 60 * 1000);

        int minute = Tomilliseconds / (60 * 1000);
        Tomilliseconds %= (60 * 1000);

        int second = Tomilliseconds / 1000;
        int millisecond = Tomilliseconds % 1000;

        return new Time(hour, minute, second, millisecond);

    }


}
