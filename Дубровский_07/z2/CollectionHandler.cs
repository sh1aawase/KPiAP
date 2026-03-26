using System;
using System.Collections.Generic;

public class CollectionHandler
{
    private ListProcessor processor = new ListProcessor();

    public void ProcessCollection(List<int> list, int index)
    {
        try
        {
            processor.GetElementAt(list, index);
        }
        catch (IndexOutOfRangeException ex)
        {
            throw new CollectionException("Произошла ошибка в CollectionHandler (CollectionException)", ex);
        }
    }
}