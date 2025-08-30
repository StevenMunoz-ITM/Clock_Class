using Clock;

try
{
    var t1 = new Time();
    var t2 = new Time(14);
    var t3 = new Time(9, 34);
    var t4 = new Time(19, 45, 56);
    var t5 = new Time(23, 678, 3, 45);
    //86.4000.000
    var times = new List<Time> { t1, t2, t3, t4, t5 };

    foreach (Time time in times)
    {
        Console.WriteLine($"Time: {time}");
        Console.WriteLine($"\tMilliseconds: {time.ToMillisecond(),15:N0}");
        Console.WriteLine($"\tSeconds     : {time.ToSecond(),15:N0}");
        Console.WriteLine($"\tMinutes     : {time.ToMinutes(),15:N0}");
        Console.WriteLine($"\tAdd         : {time.Add(t3)}");
        Console.WriteLine($"\tIs Other day: {time.IsOtherDay(t4)}");
        Console.WriteLine();
    }

    var t6 = new Time(45, -7, 90, -87);
}
catch (Exception exception)
{
    Console.WriteLine(exception.Message);
}

