using System;

namespace MusicApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MusicalInstrument[] orchestra = new MusicalInstrument[]
            {
                new Guitar(),
                new Piano(),
                new Drum()
            };

            Console.WriteLine("Репетиция оркестра");

            foreach (var instrument in orchestra)
            {
                instrument.PlaySound();
            }

            Console.WriteLine("Нажмите любую клавишу для выхода");
            Console.ReadKey();
        }
    }
}