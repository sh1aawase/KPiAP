using System;

class Person
{
    public string Name;
    public string City;

    public Person(string n, string c)
    {
        Name = n;
        City = c;
    }
}

class Program
{
    static void Main()
    {
        Person[] people = new Person[]
        {
            new Person("Иван", "Москва"),
            new Person("Анна", "Питер"),
            new Person("Олег", "Москва"),
            new Person("Мария", "Казань"),
            new Person("Елена", "Москва"),
            new Person("Петр", "Питер")
        };

        for (int i = 0; i < people.Length; i++)
        {
            Console.WriteLine(people[i].Name + " - " + people[i].City);
        }

        string mostPopular = "";
        int maxCount = 0;

        for (int i = 0; i < people.Length; i++)
        {
            string currentCity = people[i].City;
            int count = 0;

            for (int j = 0; j < people.Length; j++)
            {
                if (people[j].City == currentCity)
                {
                    count++;
                }
            }

            if (count > maxCount)
            {
                maxCount = count;
                mostPopular = currentCity;
            }
        }

        Console.WriteLine("\nСамый популярный город: " + mostPopular);
        Console.ReadKey();
    }
}