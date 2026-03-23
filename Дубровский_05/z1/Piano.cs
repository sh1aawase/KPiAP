using System;

namespace MusicApp
{
    public class Piano : MusicalInstrument
    {
        public Piano() : base("Пианино") { }

        public override void PlaySound()
        {
            Console.WriteLine($"{Name}: до-ре-ми");
        }
    }
}