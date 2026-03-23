using System;

namespace RestaurantApp
{
    public class Supplier
    {
        public string Name { get; private set; }

        public Supplier(string name)
        {
            Name = name;
        }

        public void DeliverProducts()
        {
            Console.WriteLine($"Поставщик '{Name}' доставил свежие продукты.");
        }
    }
}