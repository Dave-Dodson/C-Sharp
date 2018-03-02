using System;

public struct Clock
{
    private int _hours;
    private int _minutes;

    public Clock(int hours, int minutes)
    {
        _hours = 0;
        _minutes = 0;
        ClockValues(hours, minutes);
    }

    private void ClockValues(int hours, int minutes)
    {
        while (minutes < 0)
        {
            minutes += 60;
            hours -= 1;
        }
        while (hours < 0)
        {
            hours += 24;
        }
        while (minutes >= 60)
        {
            minutes -= 60;
            hours += 1;
        }

        while (hours >= 24)
        {
            hours -= 24;
        }
        _hours = hours;
        _minutes = minutes;
    }

    public int Hours
    {
        get
        {
            throw new NotImplementedException("You need to implement this function.");
        }
    }

    public int Minutes
    {
        get
        {
            throw new NotImplementedException("You need to implement this function.");
        }
    }

    public Clock Add(int minutesToAdd)
    {
        ClockValues(_hours, _minutes + minutesToAdd);
        return this;
    }

    public Clock Subtract(int minutesToSubtract)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public override string ToString()
    {
        return string.Format("{0:D2}:{1:D2}", _hours, _minutes);
    }
}