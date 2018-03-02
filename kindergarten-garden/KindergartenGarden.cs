using System;
using System.Collections.Generic;
using System.Linq;

public enum Plant
{
    Violets,
    Radishes,
    Clover,
    Grass
}

public class KindergartenGarden
{
    private List<string> _students;
    private string[] _rows;

    public KindergartenGarden(string diagram)
        : this(diagram,
        new List<string>() { "Alice", "Bob", "Charlie", "David",
            "Eve", "Fred", "Ginny", "Harriet", "Ileana", "Joseph", "Kincaid", "Larry" })
    { }

    public KindergartenGarden(string diagram, IEnumerable<string> students)
    {
        _rows = diagram.Split(new[] { '\n' }, StringSplitOptions.None);

        List<string> sortedStudents = students.ToList();
        sortedStudents.Sort();
        _students = sortedStudents;

    }

    public IEnumerable<Plant> Plants(string student)
    {
        int studentNo = _students.IndexOf(student) * 2;
        Plant[] plants = new Plant[4];

        for (int i = 0; i < 2; i++)
        {
            char currentPlant = _rows[0][studentNo + i];
            plants[i] = (PlantName(currentPlant));
        }

        for (int i = 0; i < 2; i++)
        {
            char currentPlant = _rows[1][studentNo + i];
            plants[i + 2] = (PlantName(currentPlant));
        }

        return plants;
    }

    private Plant PlantName(char plantType)
    {
        Plant plant = Plant.Clover;

        if (char.ToUpper(plantType) == 'V')
        {
            plant = Plant.Violets;
        }
        if (char.ToUpper(plantType) == 'R')
        {
            plant = Plant.Radishes;
        }
        if (char.ToUpper(plantType) == 'G')
        {
            plant = Plant.Grass;
        }

        return plant;
    }
}