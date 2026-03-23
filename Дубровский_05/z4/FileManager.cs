using System;

namespace FileSystemApp
{
    public class FileManager : IReadFile, IWriteFile
    {
        void IReadFile.AccessFile(string fileName)
        {
            Console.WriteLine($"[Чтение]: {fileName}");
        }

        void IWriteFile.AccessFile(string fileName)
        {
            Console.WriteLine($"[Запись]: {fileName}");
        }
    }
}