using System;

namespace RestaurantApp
{
    public class Chef
    {
        public string Name { get; private set; }

        public Chef(string name)
        {
            Name = name;
        }

        public void Cook()
        {
            Console.WriteLine($"Повар {Name} готовит блюдо.");
        }
    }
}