using System;

namespace RestaurantApp
{
    class Chef
    {
        public string name;

        public Chef(string n)
        {
            name = n;
        }

        public void Cook()
        {
            Console.WriteLine("Повар " + name + " готовит блюдо");
        }
    }

    class Menu
    {
        public string type;

        public Menu(string t)
        {
            type = t;
        }

        public void Show()
        {
            Console.WriteLine("Меню: " + type);
        }
    }

    class Supplier
    {
        public string companyName;

        public Supplier(string c)
        {
            companyName = c;
        }

        public void SendFood()
        {
            Console.WriteLine("Поставщик " + companyName + " привез продукты");
        }
    }

    class Restaurant
    {
        public string name;
        public Chef[] chefs;
        public Menu menu;
        public Supplier supplier;

        public Restaurant(string n, Chef[] c, Supplier s)
        {
            name = n;
            chefs = c;
            supplier = s;
            menu = new Menu("Обычное");
        }

        public void PrepareDishes()
        {
            Console.WriteLine("Ресторан: " + name);
            supplier.SendFood();
            menu.Show();

            for (int i = 0; i < chefs.Length; i++)
            {
                chefs[i].Cook();
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Chef c1 = new Chef("Иван");
            Chef c2 = new Chef("Дмитрий");
            Supplier s1 = new Supplier("Продукты 24");

            Chef[] group1 = new Chef[2];
            group1[0] = c1;
            group1[1] = c2;

            Chef[] group2 = new Chef[1];
            group2[0] = c1;

            Restaurant r1 = new Restaurant("Столовая", group1, s1);
            Restaurant r2 = new Restaurant("Кафе", group2, s1);

            Restaurant[] allRestaurants = new Restaurant[2];
            allRestaurants[0] = r1;
            allRestaurants[1] = r2;

            for (int i = 0; i < allRestaurants.Length; i++)
            {
                allRestaurants[i].PrepareDishes();
            }

            Console.ReadLine();
        }
    }
}