using System;
using System.Collections.Generic;
using System.Linq;

public static class BookStore
{
    public static double Total(IEnumerable<int> books)
    {
        int[] totalOfEachTitle = new int[5];

        foreach (int book in books)
        {
            totalOfEachTitle[book - 1]++;
        }

        List<int> combinations = No_of_Titles(totalOfEachTitle);

        double largestComboTotal = DiscountedTotal(combinations);

        for (int i = 0; i < combinations.Count - 1; i++)
        {
            while(combinations.Contains(combinations[i] - 2))
            {                
                combinations[combinations.IndexOf(combinations[i] - 2)]++;
                combinations[i]--;
            }
        }

        double EvenComboTotal = DiscountedTotal(combinations);

        return Math.Min(largestComboTotal, EvenComboTotal);
    }

    private static double DiscountedTotal(List<int> combinations)
    {
        double total = 0;
        foreach (int quantity in combinations)
        {
            double discount = 0;
            switch (quantity)
            {
                case 0:
                    discount = 1;
                    break;
                case 1:
                    discount = 1;
                    break;
                case 2:
                    discount = 0.95;
                    break;
                case 3:
                    discount = 0.90;
                    break;
                case 4:
                    discount = 0.80;
                    break;
                case 5:
                    discount = 0.75;
                    break;
            }
            total += discount * quantity * 8;

        }

        return total;
    }

    private static List<int> No_of_Titles(int[] bookTotals)
    {
        List<int> combinations = new List<int>();
        
        foreach(int title in bookTotals)
        {
            for (int i = 0; i < title; i++)
            {
                if (combinations.Count <= i)
                {
                    combinations.Add(0);
                }
                combinations[i]++;
            }
        }
        return combinations;
    }

}