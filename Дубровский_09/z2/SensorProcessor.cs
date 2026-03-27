using System.Collections.Generic;
using System.Linq;

public class SensorProcessor
{
    public double CalculateAverageValue(List<SensorData> data)
    {
        if (data == null || data.Count == 0)
        {
            return 0;
        }

        double sum = 0;
        foreach (var item in data)
        {
            sum += item.Value;
        }

        return sum / data.Count;
    }
}