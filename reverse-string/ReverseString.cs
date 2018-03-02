using System;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        string newString = "";

        for (var i = input.Length - 1; i>= 0; i--)
        {
            newString += input[i];
        }
        return newString;
        //throw new NotImplementedException("You need to implement this function.");
    }
}