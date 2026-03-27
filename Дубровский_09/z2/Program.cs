

class Program
{
    static void Main()
    {
        SensorFileReader reader = new SensorFileReader();
        List<SensorData> loadedData = reader.ReadSensorData();

        SensorProcessor processor = new SensorProcessor();
        double average = processor.CalculateAverageValue(loadedData);

        Console.WriteLine($"Количество записей: {loadedData.Count}");
        Console.WriteLine($"Среднее значение показателей: {average:F2}");
    }
}