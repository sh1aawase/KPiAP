using System;

abstract class Person
{
    public string FullName;
    public int Age;
    public int HealthStatus;

    public Person(string name, int age, int health)
    {
        FullName = name;
        Age = age;
        HealthStatus = health;
    }
}

sealed class Patient : Person
{
    public Patient(string name, int age, int health) : base(name, age, health)
    {
    }
}

sealed class Doctor : Person
{
    public string Specialty;

    public Doctor(string name, int age, string spec) : base(name, age, 0)
    {
        Specialty = spec;
    }
}

class Hospital
{
    public Person[] People;

    public Hospital(Person[] p)
    {
        People = p;
    }

    public Patient GetMostCriticalPatient()
    {
        Patient critical = null;
        int maxStatus = -1;

        for (int i = 0; i < People.Length; i++)
        {
            if (People[i] is Patient)
            {
                Patient p = (Patient)People[i];
                if (p.HealthStatus > maxStatus)
                {
                    maxStatus = p.HealthStatus;
                    critical = p;
                }
            }
        }
        return critical;
    }

    public void GetDoctorsBySpecialty(string spec)
    {
        for (int i = 0; i < People.Length; i++)
        {
            if (People[i] is Doctor)
            {
                Doctor d = (Doctor)People[i];
                if (d.Specialty == spec)
                {
                    Console.WriteLine(d.FullName);
                }
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Person[] list = new Person[3];
        list[0] = new Doctor("Иванов", 40, "Хирург");
        list[1] = new Patient("Петров", 20, 10);
        list[2] = new Patient("Сидоров", 30, 80);

        Hospital hospital = new Hospital(list);

        Patient critical = hospital.GetMostCriticalPatient();
        Console.WriteLine("Самый больной: " + critical.FullName);

        Console.WriteLine("Врачи хирурги:");
        hospital.GetDoctorsBySpecialty("Хирург");

        Console.ReadKey();
    }
}