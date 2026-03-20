using System;

string[] inputs = Console.ReadLine().Split();
if (inputs.Length >= 2 && int.TryParse(inputs[0], out int A) && int.TryParse(inputs[1], out int B))
{
    int sum = 0;
    for (int i = A; i <= B; i++)
    {
        sum += i * i;
    }
    Console.WriteLine(sum);
}