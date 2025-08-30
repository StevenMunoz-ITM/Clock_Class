namespace Clock;


public class Time
{
    private int _hour;
    private int _millisecond;
    private int _minute;
    private int _second;

    // Constructors
    //1
    public Time()
    {
        Hour = 0;
        Millisecond = 0;
        Minute = 0;
        Second = 0;
    }
   
  
    //2
    public Time(int hour)
    {
        Hour = hour;
    }
    //3
    public Time(int hour, int minute)
    {
        Hour = hour;
        Minute = minute;
    }
    //4
    public Time(int hour, int minute, int second)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
    }
    //5
    public Time(int hour, int millisecond, int minute, int second)
    {
        Hour = hour;
        Millisecond = millisecond;
        Minute = minute;
        Second = second;
    }

    //properties
    public int Hour 
    {
        get => _hour; //aca hay un return implícito 

        set
        {
            _hour = ValidateHour(value);
        }
        //1
    }
    public int Millisecond
    {
        get => _millisecond;

        set
        {
            _millisecond = ValidateMillisecond(value);
        }
        //2
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


    //Methods
    public override string ToString()
    {
        try
        {
            int h = ValidateHour(Hour);
            int m = ValidateMinute(Minute);
            int s = ValidateSecond(Second);
            int ms = ValidateMillisecond(Millisecond);

            string period = h < 12 ? "AM" : "PM"; 
            int hour12 = h % 12;
           
            string hourStr;
            if (h == 0 && period == "AM")
                hourStr = "00";
            else
                hourStr = (hour12 == 0 ? 12 : hour12).ToString("D2");

            return $"{hourStr}:{m:D2}:{s:D2}.{ms:D3} {period}";
        }
        catch (Exception ex)
        {
            throw new Exception($"The hour: {Hour}, is not valid.");
        }
    }

    private int ValidateHour(int hour)
    {
        if (hour < 0 || hour > 23)
        {
            throw new Exception($"the hour: {hour},is not valid.");
        }
        return hour;
    }

    private int ValidateMinute(int minute)
    {
        if (minute < 0 || minute > 59)
        {
            throw new Exception($"the hour: {minute},is not valid.");
        }
        return minute;
    }

    private int ValidateSecond(int second)
    {
        if (second < 0 || second > 59)
        {
            throw new Exception($"the hour: {second},is not valid.");
        }
        return second;
    }

    private int ValidateMillisecond(int milliseconds)
    {
        if (milliseconds < 0 || milliseconds > 999)
        {
            throw new Exception($"the hour: {milliseconds},is not valid.");
        }
        return milliseconds;
    }

    public Time Add(Time t3)
    {
        
        int milliseconds = this.Millisecond + t3.Millisecond;
        int seconds = this.Second + t3.Second; 
        int minutes = this.Minute + t3.Minute;
        int hours = this.Hour + t3.Hour;

        if (milliseconds > 999)
        {
            int extraMilliseconds = milliseconds / 1000; 
            seconds = seconds + extraMilliseconds; 
            milliseconds = milliseconds % 1000; 
        }
           
        if (seconds > 59)
        {
            int extraMinutes = seconds / 60;
            minutes = minutes + extraMinutes;
            seconds = seconds % 60;
        }
        if (minutes > 59)
        {
            int extraHours = minutes / 60;
            hours = hours + extraHours;
            minutes = minutes % 60;
        }
        if (hours > 23)
        {
            hours = hours % 24; 
        }

        
        return new Time(hours, milliseconds, minutes, seconds);
    }

    public bool IsOtherDay(Time t4)
    {
        
        int millisecondsInADay = 24 * 60 * 60 * 1000;

       
        int totalMilliseconds = this.ToMillisecond() + t4.ToMillisecond();

        if (totalMilliseconds >= millisecondsInADay)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int ToMillisecond()
    {
        try
        {
           
            int h = ValidateHour(Hour);
            int m = ValidateMinute(Minute);
            int s = ValidateSecond(Second);
            int ms = ValidateMillisecond(Millisecond);

          
            return h * 60 * 60 * 1000 + m * 60 * 1000 + s * 1000 + ms;
        }
        catch
        {
            return 0;
        }
    }

    public int ToSecond()
    {
        try
        {
            int h = ValidateHour(Hour);
            int m = ValidateMinute(Minute);
            int s = ValidateSecond(Second);

            
            return h * 60 * 60 + m * 60 + s;
        }
        catch
        {
            return 0;
        }
    }

    public int ToMinutes()
    {
        try
        {
            int h = ValidateHour(Hour);
            int m = ValidateMinute(Minute);

            
            return h * 60 + m;
        }
        catch
        {
            return 0;
        }
    }
}