using System;
using System.Collections.Generic;
using System.Linq;

public class School
{
    private IDictionary<string, int> _roster = new Dictionary<string, int>();

    public void Add(string student, int grade)
    {
        _roster.Add(student, grade);        
    }

    public IEnumerable<string> Roster()
    {
                       
        var orderedByGrade = _roster.OrderBy(KeyValuePair => KeyValuePair.Value)
            .ToDictionary(KeyValuePair => KeyValuePair.Key, KeyValuePair => KeyValuePair.Value);

        List<int> grades = orderedByGrade.Values.Distinct().ToList();

        IDictionary<string, int> ordered = new Dictionary<string, int>();

        foreach (int uniqueGrade in grades)
        {
            List<string> studentsInGrade = Grade(uniqueGrade).ToList();

            foreach (string student in studentsInGrade)
            {
                ordered.Add(student, uniqueGrade);
            }
        }
              
        return ordered.Keys;
    }

    public IEnumerable<string> Grade(int grade)
    {
        List<string> students = new List<string>();

        foreach(KeyValuePair<string, int> student in _roster)
        {
            if (student.Value == grade)
            {
                students.Add(student.Key);
            }
        }

        students.Sort();

        return students;
    }
}