using System;
using System.Diagnostics;
using System.Collections.Generic;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        int numLength = number.ToString().Length;

        int digitCount = numLength;

        List<int> digits = new List<int>();

        int largestDigit = number;

        while (digitCount >= 1)
        {
            int multiplier = 1;
            while (largestDigit > 9)
            {
                largestDigit /= 10;
                multiplier *= 10;
            }
            digits.Add(largestDigit);

            int deduct = 0;

            for (var i = 0; i < digits.Count; i++)
            {
                deduct += digits[i] * Convert.ToInt32(Math.Pow(10, (numLength - i - 1)));
            }
            largestDigit = number - deduct;
            digitCount--;

        }

        int total = 0;

        foreach (int digit in digits)
        {
            total += Convert.ToInt32(Math.Pow(digit, numLength));
        }

        return (total == number);
    }
}