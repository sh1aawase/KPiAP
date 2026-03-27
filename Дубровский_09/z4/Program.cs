class Program
{
    static void Main()
    {
        string pathToWatch = @"D:\!DRIVERS";

        if (!Directory.Exists(pathToWatch))
        {
            Directory.CreateDirectory(pathToWatch);
        }

        FileWatcher watcher = new FileWatcher(pathToWatch);

        Console.WriteLine($"Слежение за папкой: {pathToWatch}");

        watcher.ArchiveOldFiles();

        Console.WriteLine("Нажмите Enter для выхода...");
        Console.ReadLine();
    }
}