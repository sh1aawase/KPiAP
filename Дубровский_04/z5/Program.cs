using System;

abstract class MusicalInstrument
{
    public abstract void PlaySound();

    public virtual void Tune()
    {
        Console.WriteLine("Инструмент настраивается");
    }
}

class Guitar : MusicalInstrument
{
    public override void PlaySound()
    {
        Console.WriteLine("Гитара играет");
    }

    public override void Tune()
    {
        Console.WriteLine("Настройка струн гитары");
    }
}

class Piano : MusicalInstrument
{
    public override void PlaySound()
    {
        Console.WriteLine("Пианино играет");
    }

    public override void Tune()
    {
        Console.WriteLine("Настройка клавиш пианино");
    }
}

class Program
{
    static void Main()
    {
        MusicalInstrument myGuitar = new Guitar();
        MusicalInstrument myPiano = new Piano();

        myGuitar.PlaySound();
        myGuitar.Tune();

        myPiano.PlaySound();
        myPiano.Tune();
    }
}