using System;
using System.Collections.Generic;
using System.Linq;

public class SaddlePoints
{

    private int[,] _values;
    private List<Tuple<int, int>> _saddlePoints;
    private int _matrixSize;

    public SaddlePoints(int[,] values)
    {
        _values = values;
        _matrixSize = _values.GetLength(0);
        _saddlePoints = new List<Tuple<int, int>>();
    }

    public IEnumerable<Tuple<int, int>> Calculate()
    {
        
        for (int column = 0; column < _matrixSize; column++)
        {
            for (int row = 0; row < _matrixSize; row++)
            {
                Tuple<int, int> saddle = new Tuple<int, int>(row, column);
                
                if (GreatestInRow(saddle, row) && LeastInColumn(saddle, column))
                {                    
                   _saddlePoints.Add(saddle);
                }
            }
        }
        return _saddlePoints;
    }

    private bool LeastInColumn(Tuple<int, int> saddle, int column)
    {
        int testValue = _values[saddle.Item1, saddle.Item2];

        for (int a = 0; a < _matrixSize; a++)
        {
            if (_values[a, column] < testValue)
            {
                return false;
            }
        }

        return true;
    }

    private bool GreatestInRow(Tuple<int, int> saddle, int row)
    {

        int testValue = _values[saddle.Item1, saddle.Item2];

        for(int a = 0; a < _matrixSize; a++)
        {
            if(_values[row, a] > testValue)
            {
                return false;
            }
        }

        return true;
    }
}