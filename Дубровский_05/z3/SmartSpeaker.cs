using System;
using System.Reflection;

namespace SmartDevicesApp
{
    public class SmartSpeaker : SmartDevice, ICanPlayMusic
    {
        public SmartSpeaker(string model) : base(model) { }

        public void PlayMusic()
        {
            Console.WriteLine($"{Model}: Воспроизведение музыки через динамик.");
        }
    }
}