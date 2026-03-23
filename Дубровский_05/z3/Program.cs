using System;

namespace SmartDevicesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SmartDevice[] devices = new SmartDevice[]
            {
                new Smartphone("iPhone 15"),
                new SmartSpeaker("Yandex Station"),
                new Smartphone("Samsung S23"),
                new SmartSpeaker("HomePod")
            };

            Console.WriteLine("--- Поиск устройств с функцией звонка ---");
            foreach (var device in devices)
            {
                if (device is ICanMakeCalls caller)
                {
                    caller.MakeCall("8-800-555-35-35");
                }
            }

            Console.WriteLine("\n--- Поиск музыкальных устройств ---");
            foreach (var device in devices)
            {
                if (device is ICanPlayMusic musicPlayer)
                {
                    musicPlayer.PlayMusic();
                }
            }

            Console.ReadKey();
        }
    }
}