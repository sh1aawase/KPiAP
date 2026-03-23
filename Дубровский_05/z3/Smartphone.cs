using System;
using System.Reflection;

namespace SmartDevicesApp
{
    public class Smartphone : SmartDevice, ICanPlayMusic, ICanMakeCalls
    {
        public Smartphone(string model) : base(model) { }

        public void PlayMusic()
        {
            Console.WriteLine($"{Model}: Музыка играет.");
        }

        public void MakeCall(string number)
        {
            Console.WriteLine($"{Model}: Звонок на {number}.");
        }
    }
}