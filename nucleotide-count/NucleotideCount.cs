using System;
using System.Collections.Generic;

public class NucleotideCount
{
    private IDictionary<char, int> _nucleotideCounts = new Dictionary<char, int>();

    public NucleotideCount(string sequence)
    {
        int aCount = 0;
        int cCount = 0;
        int gCount = 0;
        int tCount = 0;
        
        foreach (char c in sequence)
        {
            if (char.ToUpper(c) == 'A')
            {
                aCount += 1;
            }
            else if (char.ToUpper(c) == 'C')
            {
                cCount += 1;
            }
            else if (char.ToUpper(c) == 'G')
            {
                gCount += 1;
            }
            else if (char.ToUpper(c) == 'T')
            {
                tCount += 1;
            }
            else
            {
                throw new InvalidNucleotideException();
            }
        }

        _nucleotideCounts.Add('A', aCount);
        _nucleotideCounts.Add('C', cCount);
        _nucleotideCounts.Add('G', gCount);
        _nucleotideCounts.Add('T', tCount);
    }

    public IDictionary<char, int> NucleotideCounts
    {
        get
        {
            return _nucleotideCounts;
        }
    }
}

public class InvalidNucleotideException : Exception { }
