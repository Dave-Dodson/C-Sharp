using System;
using System.Diagnostics;

public static class Leap
{
    // int -> bool
    // Returns true if the given year is a leap year
    public static bool IsLeapYear(int year)
    {
        if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0 ) 
        //if the remainder of year divided by 4 is 0 and the remainder of the year divded by 100 is not 0, or the remainder of the year divided by 400 is 0.
        {            
            return true;
        }
        else
        {
            return false;
        }
    }
}