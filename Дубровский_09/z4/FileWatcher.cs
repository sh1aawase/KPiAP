using System;
using System.IO;
using System.Collections.Generic;

public class FileWatcher
{
    private FileSystemWatcher _watcher;
    private string _targetPath;
    private string _archivePath;

    public FileWatcher(string path)
    {
        _targetPath = path;
        _archivePath = Path.Combine(path, "archive");

        if (!Directory.Exists(_archivePath))
        {
            Directory.CreateDirectory(_archivePath);
        }

        _watcher = new FileSystemWatcher(_targetPath);
        _watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.DirectoryName;

        _watcher.Created += OnCreated;
        _watcher.Deleted += OnDeleted;
        _watcher.Changed += OnChanged;
        _watcher.Renamed += OnRenamed;

        _watcher.EnableRaisingEvents = true;
    }

    private void OnCreated(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"Создан: {e.FullPath}");
    }

    private void OnDeleted(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"Удален: {e.FullPath}");
    }

    private void OnChanged(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"Изменен: {e.FullPath}");
    }

    private void OnRenamed(object sender, RenamedEventArgs e)
    {
        Console.WriteLine($"Переименован: {e.OldFullPath} в {e.FullPath}");
    }

    public void ArchiveOldFiles()
    {
        string[] files = Directory.GetFiles(_targetPath);
        DateTime threshold = DateTime.Now.AddDays(-30);

        foreach (string filePath in files)
        {
            FileInfo fileInfo = new FileInfo(filePath);

            if (fileInfo.LastWriteTime < threshold)
            {
                string destFile = Path.Combine(_archivePath, fileInfo.Name);

                try
                {
                    if (File.Exists(destFile)) File.Delete(destFile);
                    File.Move(filePath, destFile);
                    Console.WriteLine($"Архивирован: {fileInfo.Name}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка архивации {fileInfo.Name}: {ex.Message}");
                }
            }
        }
    }
}