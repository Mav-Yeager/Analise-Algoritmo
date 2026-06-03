using System;

class MaxMin1
{
    // f(n) = 2(n-1) — melhor caso, pior caso e caso médio
    static void MaxMin(int[] A, out int Max, out int Min)
    {
        Max = A[0];
        Min = A[0];
        for (int i = 1; i < A.Length; i++)
        {
            if (A[i] > Max) Max = A[i];
            if (A[i] < Min) Min = A[i];
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
        Console.WriteLine($"f(n) = 2(n-1) = {2 * (n - 1)} comparacoes");
    }
}
