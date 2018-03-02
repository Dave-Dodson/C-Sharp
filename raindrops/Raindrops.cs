using System;
using System.Collections.Generic;

public static class Raindrops
{
    //int -> sting
    //output a string of raindrop sounds based on the factors of the given number
    public static string Convert(int number)
    {
        string result = "";
        List<int> factors = new List<int>();

        for(int i = 1; i <= number; i++)
            if(number % i == 0)
            {
                factors.Add(i);
            }

        if (!factors.Contains(3) && !factors.Contains(5) && !factors.Contains(7))
        {
            return number.ToString();
        }

        if (factors.Contains(3))
        {
            result = "Pling";
        }

        if (factors.Contains(5))
        {
           result += "Plang";           
        }

        if (factors.Contains(7))
        {
            result += "Plong";                  
        } 
        
        return result;
    }
}