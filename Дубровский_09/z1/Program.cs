class Program
{
    static void Main()
    {
        List<SensorData> data = new List<SensorData>
        {
            new SensorData(DateTime.Now, 25.4),
            new SensorData(DateTime.Now.AddSeconds(15), 26.1),
            new SensorData(DateTime.Now.AddSeconds(30), 24.8)
        };

        SensorDataWriter writer = new SensorDataWriter();
        writer.ClearAndWrite(data);
    }
}