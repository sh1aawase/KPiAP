using System;

namespace FileApp
{
    interface IReadFile
    {
        void AccessFile(string fileName);
    }

    interface IWriteFile
    {
        void AccessFile(string fileName);
    }

    class FileManager : IReadFile, IWriteFile
    {
        void IReadFile.AccessFile(string fileName)
        {
            Console.WriteLine("Чтение данных из файла: " + fileName);
        }

        void IWriteFile.AccessFile(string fileName)
        {
            Console.WriteLine("Запись новых данных в файл: " + fileName);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FileManager myManager = new FileManager();

            IReadFile reader = (IReadFile)myManager;
            reader.AccessFile("kpiap.txt");

            IWriteFile writer = (IWriteFile)myManager;
            writer.AccessFile("kpiap.txt");

            Console.ReadLine();
        }
    }
}