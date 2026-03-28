using System;

namespace CourseWork
{
    public class EncryptionService
    {
        private IEncryptionStrategy strategy;

        public EncryptionService(IEncryptionStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void SetStrategy(IEncryptionStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void ProcessData(string data)
        {
            string result = strategy.Encrypt(data);
            Console.WriteLine("Результат обработки: " + result);
        }
    }
}