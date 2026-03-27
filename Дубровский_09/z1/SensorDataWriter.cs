using System;
using System.Collections.Generic;
using System.IO;

public class SensorDataWriter
{
    private readonly string _filePath = "file.data.txt";

    public void ClearAndWrite(List<SensorData> data)
    {
        using (StreamWriter writer = new StreamWriter(new FileStream(_filePath, FileMode.Create, FileAccess.Write)))
        {
            foreach (var item in data)
            {
                writer.WriteLine(item.ToString());
                Console.WriteLine($"Записана строка: {item}");
            }
        }
        Console.WriteLine($"Все данные успешно сохранены в файл: {_filePath}");
    }
}