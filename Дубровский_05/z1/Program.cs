using System;

namespace MusicalApp
{
    abstract class MusicalInstrument
    {
        public string Name { get; set; }

        protected MusicalInstrument(string name)
        {
            Name = name;
        }

        public abstract void PlaySound();
    }

    class Guitar : MusicalInstrument
    {
        public Guitar() : base("Гитара") { }

        public override void PlaySound()
        {
            Console.WriteLine($"{Name}: Звучит гитарная струна");
        }
    }

    class Piano : MusicalInstrument
    {
        public Piano() : base("Пианино") { }

        public override void PlaySound()
        {
            Console.WriteLine($"{Name}: Звучит клавиша пианино");
        }
    }

    class Drum : MusicalInstrument
    {
        public Drum() : base("Барабан") { }

        public override void PlaySound()
        {
            Console.WriteLine($"{Name}: Звучит удар барабана");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MusicalInstrument[] instruments = new MusicalInstrument[]
            {
                new Guitar(),
                new Piano(),
                new Drum()
            };

            foreach (var instrument in instruments)
            {
                instrument.PlaySound();
            }
        }
    }
}