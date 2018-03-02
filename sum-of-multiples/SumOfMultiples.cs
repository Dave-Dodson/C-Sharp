using System;
using System.Collections.Generic;
using System.Linq;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        List<int> allMultiples = new List<int>();
        int currentMultiple;

        foreach (int multiple in multiples)
        {
            currentMultiple = multiple;

            while (currentMultiple < max)
            {
                allMultiples.Add(currentMultiple);
                currentMultiple += multiple;
            }
        }
        IEnumerable<int> distinctMultiples = allMultiples.Distinct();
        return distinctMultiples.Sum();
    }
}