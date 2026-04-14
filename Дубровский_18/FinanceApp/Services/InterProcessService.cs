using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.IO.Pipes;
using System.Text;
using System.Threading;

namespace FinanceApp.Services
{
    public class InterProcessService
    {
        private const string PipeName = "FinanceChatPipe";
        private const string MemoryName = "FinanceReminderMmf";
        private const int MemorySize = 1024;

        public void StartPipeServer(Action<string> onMessageReceived)
        {
            var serverThread = new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        using var pipeServer = new NamedPipeServerStream(PipeName, PipeDirection.In);
                        pipeServer.WaitForConnection();

                        using var reader = new StreamReader(pipeServer);
                        var message = reader.ReadLine();
                        if (!string.IsNullOrWhiteSpace(message))
                        {
                            onMessageReceived(message);
                        }
                    }
                    catch
                    {
                        // Игнорируем ошибки подключения, поток продолжает слушать.
                    }
                }
            })
            { IsBackground = true };

            serverThread.Start();
        }

        public void SendPipeMessage(string message)
        {
            var clientThread = new Thread(() =>
            {
                try
                {
                    using var pipeClient = new NamedPipeClientStream(".", PipeName, PipeDirection.Out);
                    pipeClient.Connect(500);

                    using var writer = new StreamWriter(pipeClient);
                    writer.WriteLine(message);
                    writer.Flush();
                }
                catch
                {
                    // Если никто не слушает канал, сообщение останется только в локальном чате.
                }
            })
            { IsBackground = true };

            clientThread.Start();
        }

        public void WriteReminder(string text)
        {
            try
            {
                using var mmf = MemoryMappedFile.CreateOrOpen(MemoryName, MemorySize);
                using var stream = mmf.CreateViewStream();
                var bytes = Encoding.UTF8.GetBytes(text.PadRight(MemorySize / 4));
                stream.Write(bytes, 0, bytes.Length);
            }
            catch
            {
                // Игнорируем ошибки записи напоминания.
            }
        }

        public string ReadReminder()
        {
            try
            {
                using var mmf = MemoryMappedFile.OpenExisting(MemoryName);
                using var stream = mmf.CreateViewStream();
                var bytes = new byte[MemorySize / 4];
                stream.Read(bytes, 0, bytes.Length);
                return Encoding.UTF8.GetString(bytes).Trim();
            }
            catch
            {
                return "Нет активных напоминаний";
            }
        }
    }
}
