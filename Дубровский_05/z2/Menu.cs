using System;

namespace RestaurantApp
{
    public class Menu
    {
        public string Title { get; private set; }

        public Menu(string title)
        {
            Title = title;
        }

        public void ShowMenu()
        {
            Console.WriteLine($"Меню: {Title}");
        }
    }
}