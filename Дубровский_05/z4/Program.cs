using System;

namespace FileSystemApp
{
    class Program
    {
        static void Main(string[] args)
        {
            FileManager fileManager = new FileManager();

            IReadFile reader = (IReadFile)fileManager;
            reader.AccessFile("kpiap.bin");

            IWriteFile writer = (IWriteFile)fileManager;
            writer.AccessFile("kpiap.bin");

            Console.ReadKey();
        }
    }
}