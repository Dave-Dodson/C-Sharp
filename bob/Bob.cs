using System;
using System.Text.RegularExpressions;

public static class Bob
{
    // String -> String
    // Returns a specific response depending on the type of string passed in.
    public static string Response(string statement)
    {
        statement = statement.Trim();
        if(statement == "")
        {
            return "Fine. Be that way!";
        }
        
        if (statement == statement.ToUpper() && containsALetter(statement) == true)
        {            
            if (statement.EndsWith('?'))
            {
                return "Calm down, I know what I'm doing!";
            }
            return "Whoa, chill out!";
        }
        else if(statement.EndsWith('?'))
        {
            return "Sure.";
        }
        else
        {
            return "Whatever.";   
        }       
    }

    private static bool containsALetter(String str)
    {
        return Regex.IsMatch(str, "[a-zA-z]");
    }
}