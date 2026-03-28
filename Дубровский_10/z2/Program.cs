using System;

namespace CourseWork
{
    class Program
    {
        static void Main(string[] args)
        {
            EncryptionService service = new EncryptionService(new AESEncryption());
            service.ProcessData("Привет мир");

            service.SetStrategy(new DESEncryption());
            service.ProcessData("Привет мир");

            Console.ReadKey();
        }
    }
}