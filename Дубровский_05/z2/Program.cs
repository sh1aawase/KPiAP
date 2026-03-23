using System;

namespace RestaurantApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Supplier globalSupplier = new Supplier("FoodExpress");

            Chef chef1 = new Chef("Олег");
            Chef chef2 = new Chef("Руслан");
            Chef chef3 = new Chef("Мирослав");

            Restaurant[] restaurants = new Restaurant[]
            {
                new Restaurant("Звезда", "Европейская кухня", new Chef[] { chef1, chef2 }),
                new Restaurant("Океан", "Морепродукты", new Chef[] { chef3 })
            };

            foreach (var restaurant in restaurants)
            {
                restaurant.PrepareDishes(globalSupplier);
            }

            Console.ReadKey();
        }
    }
}