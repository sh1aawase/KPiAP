using System;

namespace MusicApp
{
    public abstract class MusicalInstrument
    {
        public string Name { get; protected set; }

        protected MusicalInstrument(string name)
        {
            Name = name;
        }

        public abstract void PlaySound();
    }
}