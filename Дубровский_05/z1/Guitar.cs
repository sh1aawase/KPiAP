using System;

namespace MusicApp
{
    public class Guitar : MusicalInstrument
    {
        public Guitar() : base("Гитара") { }

        public override void PlaySound()
        {
            Console.WriteLine($"{Name}: брынь-брынь");
        }
    }
}