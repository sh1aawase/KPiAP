using System;

namespace MusicApp
{
    public class Drum : MusicalInstrument
    {
        public Drum() : base("Барабан") { }

        public override void PlaySound()
        {
            Console.WriteLine($"{Name}: бум-бам");
        }
    }
}