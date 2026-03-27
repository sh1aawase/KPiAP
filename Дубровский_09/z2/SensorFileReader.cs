using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

public class SensorFileReader
{
    private readonly string _filePath = "file.data";

    public List<SensorData> ReadSensorData()
    {
        List<SensorData> dataList = new List<SensorData>();

        if (!File.Exists(_filePath))
        {
            Console.WriteLine("Файл не найден.");
            return dataList;
        }

        using (StreamReader reader = new StreamReader(_filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(';');
                if (parts.Length == 2)
                {
                    DateTime dt = DateTime.Parse(parts[0]);
                    double val = double.Parse(parts[1], CultureInfo.InvariantCulture);
                    dataList.Add(new SensorData(dt, val));
                }
            }
        }
        return dataList;
    }
}