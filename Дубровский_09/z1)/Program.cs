using System;
using System.IO;
using z1_;

namespace Task;

public class Program
{
    public static void Main()
    {
        string baseDir = @"C:\Users\MSI\Documents\Tema 9\Task 1\bin\Debug\net8.0";
        string mainFile = Path.Combine(baseDir, "dubrovsky_ruslan.txt");
        string copyPath = Path.Combine(baseDir, "dubrovsky_ruslan_copy.txt");
        string movePath = Path.Combine(baseDir, "dubrovsky_ruslan_moved.txt");
        string renamedFile = Path.Combine(baseDir, "dubrovsky_ruslan.io");

        if (!Directory.Exists(baseDir))
            Directory.CreateDirectory(baseDir);

        FileManager fileMgr = new();
        FileInfoProvider infoProvider = new();

        fileMgr.CreateFile(mainFile, "Hello World!");
        var content = File.ReadAllText(mainFile);

        Console.WriteLine($"Чтение: {content}");
        Console.WriteLine($"Существует: {File.Exists(mainFile)}\n");

        infoProvider.GetInfo(mainFile);
        Console.WriteLine();

        fileMgr.CopyFile(mainFile, copyPath);
        Console.WriteLine($"Копия: {File.Exists(copyPath)}");

        fileMgr.MoveFile(copyPath, movePath);
        Console.WriteLine("Файл перемещен.\n");

        fileMgr.RenameFile(movePath, "dubrovsky_ruslan.io");
        Console.WriteLine();

        fileMgr.DeleteFile(Path.Combine(baseDir, "not_found.txt"));
        Console.WriteLine();

        infoProvider.CompareSize(mainFile, renamedFile);
        Console.WriteLine();

        fileMgr.CreateFile(Path.Combine(baseDir, "dubrovsky_ruslan.ii"), "temp");
        fileMgr.CreateFile(Path.Combine(baseDir, "data.ii"), "buffer");
        fileMgr.CreateFile(Path.Combine(baseDir, "store.txt"), "save");

        fileMgr.DeleteFilesByPattern(baseDir, "*.ii");
        Console.WriteLine();

        var filesList = fileMgr.GetFiles(baseDir);
        Console.WriteLine("Содержимое директории:");
        foreach (var f in filesList)
        {
            Console.WriteLine($" - {Path.GetFileName(f)}");
        }
        Console.WriteLine();

        string readOnlyPath = Path.Combine(baseDir, "dubrovsky_ruslan_readonly.txt");
        fileMgr.CreateFile(readOnlyPath, "original");

        infoProvider.SetReadOnly(readOnlyPath, true);
        infoProvider.TryWriteToReadOnly(readOnlyPath, "new text");

        Console.WriteLine();
        infoProvider.CheckPermissions(readOnlyPath);

        Console.WriteLine("\nОчистка...");
        string[] toDelete = { mainFile, renamedFile, readOnlyPath, Path.Combine(baseDir, "store.txt") };
        foreach (var path in toDelete)
        {
            fileMgr.DeleteFile(path);
        }
    }
}