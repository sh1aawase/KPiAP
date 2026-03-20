using System;

class Program
{
    static void Main()
    {
        int[][] jagged = new int[3][];
        jagged[0] = new int[] { 1, 2, 3 };
        jagged[1] = new int[] { 4, 5 };
        jagged[2] = new int[] { 6, 7, 8, 9 };

        int[][] newJagged = new int[jagged.Length + 1][];

        for (int i = 0; i < jagged.Length; i++)
        {
            newJagged[i] = jagged[i];
        }

        newJagged[jagged.Length] = new int[jagged.Length];

        for (int i = 0; i < jagged.Length; i++)
        {
            double sum = 0;
            for (int j = 0; j < jagged[i].Length; j++)
            {
                sum += jagged[i][j];
            }
            newJagged[jagged.Length][i] = (int)(sum / jagged[i].Length);
        }

        for (int i = 0; i < newJagged.Length; i++)
        {
            for (int j = 0; j < newJagged[i].Length; j++)
            {
                Console.Write(newJagged[i][j] + " ");
            }
            Console.WriteLine();
        }
    }
}