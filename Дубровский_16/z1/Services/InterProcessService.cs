using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading;
using System.IO.MemoryMappedFiles;

namespace z1.Services
{
    public class InterProcessService
    {
        private const string PipeName = "FinanceChatPipe";
        private const string MmfName = "FinanceReminderMmf";
        private const int MmfSize = 1024;

        public void StartPipeServer(Action<string> onMessageReceived)
        {
            Thread serverThread = new Thread(delegate ()
            {
                while (true)
                {
                    try
                    {
                        using (NamedPipeServerStream pipeServer = new NamedPipeServerStream(PipeName, PipeDirection.In))
                        {
                            pipeServer.WaitForConnection();
                            using (StreamReader reader = new StreamReader(pipeServer))
                            {
                                string message = reader.ReadLine();
                                if (!string.IsNullOrEmpty(message))
                                {
                                    onMessageReceived(message);
                                }
                            }
                        }
                    }
                    catch { /* Игнорируем ошибки подключения */ }
                }
            });
            serverThread.IsBackground = true;
            serverThread.Start();
        }

        public void SendPipeMessage(string message)
        {
            Thread clientThread = new Thread(delegate ()
            {
                try
                {
                    using (NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", PipeName, PipeDirection.Out))
                    {
                        pipeClient.Connect(500); // Ждем максимум 0.5 сек
                        using (StreamWriter writer = new StreamWriter(pipeClient))
                        {
                            writer.WriteLine(message);
                            writer.Flush();
                        }
                    }
                }
                catch { /* Если никто не слушает, сообщение просто сохраняется в JSON через ViewModel */ }
            });
            clientThread.IsBackground = true;
            clientThread.Start();
        }

        public void WriteReminder(string text)
        {
            try
            {
                using (MemoryMappedFile mmf = MemoryMappedFile.CreateOrOpen(MmfName, MmfSize))
                {
                    using (MemoryMappedViewStream stream = mmf.CreateViewStream())
                    {
                        byte[] buffer = Encoding.UTF8.GetBytes(text.PadRight(MmfSize / 4));
                        stream.Write(buffer, 0, buffer.Length);
                    }
                }
            }
            catch { }
        }

        public string ReadReminder()
        {
            try
            {
                using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting(MmfName))
                {
                    using (MemoryMappedViewStream stream = mmf.CreateViewStream())
                    {
                        byte[] buffer = new byte[MmfSize / 4];
                        stream.Read(buffer, 0, buffer.Length);
                        return Encoding.UTF8.GetString(buffer).Trim();
                    }
                }
            }
            catch { return "Нет активных напоминаний"; }
        }
    }
}