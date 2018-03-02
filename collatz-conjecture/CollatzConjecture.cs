using System;

public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        if (number < 1)
        {
            throw new System.ArgumentException("Parameter must be greater than zero.");
        }

        int counter = 0;

        while (number != 1)
        {
            counter++;

            if (number % 2 == 0)
            {
                number /= 2;
            }
            else
            {
                number *= 3;
                number++;
            }

        } 

        return counter;

    }
}