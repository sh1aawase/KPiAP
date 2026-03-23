using System;

namespace SmartDeviceApp
{
    interface ICanPlayMusic
    {
        void PlayMusic();
    }

    interface ICanMakeCalls
    {
        void MakeCall(string number);
    }

    class SmartDevice
    {
        public string model;

        public SmartDevice(string m)
        {
            model = m;
        }

        public void ShowInfo()
        {
            Console.WriteLine("Устройство: " + model);
        }
    }

    class SmartSpeaker : SmartDevice, ICanPlayMusic
    {
        public SmartSpeaker(string m) : base(m) { }

        public void PlayMusic()
        {
            Console.WriteLine(model + " играет музыку");
        }
    }

    class Smartphone : SmartDevice, ICanPlayMusic, ICanMakeCalls
    {
        public Smartphone(string m) : base(m) { }

        public void PlayMusic()
        {
            Console.WriteLine(model + " играет музыку через наушники");
        }

        public void MakeCall(string number)
        {
            Console.WriteLine(model + " звонит на номер: " + number);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SmartDevice[] devices = new SmartDevice[3];
            devices[0] = new SmartSpeaker("Яндекс Станция");
            devices[1] = new Smartphone("iPhone 15");
            devices[2] = new Smartphone("Samsung S23");

            Console.WriteLine("--- Поиск устройств, которые могут звонить ---");

            for (int i = 0; i < devices.Length; i++)
            {
                if (devices[i] is ICanMakeCalls)
                {
                    ICanMakeCalls phone = (ICanMakeCalls)devices[i];
                    devices[i].ShowInfo();
                    phone.MakeCall("8-800-555-35-35");
                }
            }

            Console.ReadLine();
        }
    }
}