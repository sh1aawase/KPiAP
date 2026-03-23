using System;

namespace RestaurantApp
{
    public class Restaurant
    {
        public string Name { get; private set; }

        private Menu _menu;

        private Chef[] _chefs;

        public Restaurant(string name, string menuTitle, Chef[] chefs)
        {
            Name = name;
            _menu = new Menu(menuTitle);
            _chefs = chefs;
        }

        public void PrepareDishes(Supplier supplier)
        {
            Console.WriteLine($"--- Ресторан '{Name}' начинает работу ---");
            supplier.DeliverProducts();
            _menu.ShowMenu();

            foreach (var chef in _chefs)
            {
                chef.Cook();
            }
            Console.WriteLine();
        }
    }
}