using System;

public class BinarySearch
{
    private int[] _array;

    public BinarySearch(int[] input)
    {   
        _array = input;
    }

    public int Find(int value)
    {
        if (_array.Length == 0)
        {
            return -1; //Array is empty
        }

        int upperSearchLimit = _array.Length -1;
        int lowerSearchLimit = 0;
        int checkIndex = upperSearchLimit / 2;
                
        do
        {
            if(_array[checkIndex] == value)
            {
                return checkIndex;
            }
            if(value > _array[checkIndex])
            {
                lowerSearchLimit = checkIndex;
                checkIndex += checkIndex / 2;
            }
            else
            {
                upperSearchLimit = checkIndex;
                checkIndex /= 2;
            }
            if (upperSearchLimit - lowerSearchLimit == 1 && _array[0] != value)
            {
                return -1; //Element not found.
            }

        } while (upperSearchLimit - lowerSearchLimit > 0);

        return -1; //Element not found.
    }
}