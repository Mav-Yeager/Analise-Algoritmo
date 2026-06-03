using System;

class MaxMin2
{
    // f(n): melhor = n-1, pior = 2(n-1), medio = 3n/2 - 3/2
    static void MaxMin(int[] A, out int Max, out int Min)
    {
        Max = A[0];
        Min = A[0];
        for (int i = 1; i < A.Length; i++)
        {
            if (A[i] > Max) Max = A[i];
            else if (A[i] < Min) Min = A[i];
        }
    }

    static void Main()
    {
        Random rng = new Random(42);
        int n = 10;
        int[] A = new int[n];

        Console.Write("Vetor A: [ ");
        for (int i = 0; i < n; i++)
        {
            A[i] = rng.Next(1, 101);
            Console.Write(A[i] + (i < n - 1 ? ", " : " "));
        }
        Console.WriteLine("]");

        int max, min;
        MaxMin(A, out max, out min);
        Console.WriteLine($"Max = {max}, Min = {min}");
        Console.WriteLine($"f(n): melhor = {n - 1}, pior = {2 * (n - 1)}, medio = {3 * n / 2.0 - 1.5:F1}");
    }
}
