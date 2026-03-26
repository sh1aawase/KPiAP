using System;
using System.Collections.Generic;

public class ListProcessor
{
    public int GetElementAt(List<int> list, int index)
    {
        if (index < 0 || index >= list.Count)
        {
            throw new IndexOutOfRangeException("Индекс находится вне границ списка (IndexOutOfRangeException)");
        }

        return list[index];
    }
}