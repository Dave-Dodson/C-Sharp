using System;
using System.Text.RegularExpressions;

public static class Markdown
{
    public static string Parse(string markdown)
    {
        string[] lines = markdown.Split('\n');
        string result = "";

        for (int i = 0; i < lines.Length; i++)
        {
            lines[i] = Bold(lines[i]);
            lines[i] = Italics(lines[i]);
            lines[i] = ListItem(lines[i]);     
            lines[i] = ParagraphOrHeader(lines[i]);
            result += lines[i];
        }

        result = IsList(result);

        return result;
    }

    private static string IsList(string text)
    {
        if (text.Contains("<li>"))
        {
            text = text.ReplaceNext("<li>", "<ul><li>");
            int listEndIndex = text.LastIndexOf("</li>");
            text = text.Insert(listEndIndex + "</li>".Length, "</ul>");
        }
        return text;
    }

    private static string ListItem(string text)
    {
        while (text.Contains("*"))
        {
            text = text.ReplaceNext("* ", "<li>");
            text += "</li>";
        }
        return text;
    }

    private static string Bold(string text)
    {
        while (text.Contains("__"))
        {
            text = text.ReplaceNext("__", "<strong>");
            text = text.ReplaceNext("__", "</strong>");
        }
        return text;
    }

    private static string ParagraphOrHeader(string text)
    {
        int headerCount = 0;
        while (text.Contains("#"))
        {
            text = text.ReplaceNext("#", "");
            headerCount++;
        }

        if(headerCount > 0)
        {
            text = text.ReplaceNext(" ", "<h" + headerCount + ">");
            text += "</h" + headerCount + ">";
        }
        else
        {
            if (!text.Contains("<li>"))
            {
                text = "<p>" + text + "</p>";
            }
        }
        return text;
    }

    private static string Italics(string text)
    {
        while (text.Contains("_"))
        {            
            text = text.ReplaceNext("_", "<em>");
            text = text.ReplaceNext("_", "</em>");
        }
        return text;
    }  

}

public static class StringExtensionMethods
{
    public static string ReplaceNext(this string text, string search, string replace)
    {
        int pos = text.IndexOf(search);
        if (pos < 0)
        {
            return text;
        }
        return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
    }
}