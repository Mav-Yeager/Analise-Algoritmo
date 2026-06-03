using System;

class MaxMin4
{
    // f(n) = 3n/2 - 2 — melhor caso, pior caso e caso medio
    // Linf e Lsup sao indices base-1 conforme o slide
    static void MaxMin(int[] A, int Linf, int Lsup, out int Max, out int Min)
    {
        // Caso base: um ou dois elementos
        if (Lsup - Linf <= 1)
        {
            if (A[Linf - 1] < A[Lsup - 1])
            {
                Max = A[Lsup - 1];
                Min = A[Linf - 1];
            }
            else
            {
                Max = A[Linf - 1];
                Min = A[Lsup - 1];
            }
            return;
        }

        int Meio = (Linf + Lsup) / 2;

        int Max1, Min1, Max2, Min2;
        MaxMin(A, Linf,     Meio, out Max1, out Min1);
        MaxMin(A, Meio + 1, Lsup, out Max2, out Min2);

        Max = (Max1 > Max2) ? Max1 : Max2;
        Min = (Min1 < Min2) ? Min1 : Min2;
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
        MaxMin(A, 1, n, out max, out min);
        Console.WriteLine($"Max = {max}, Min = {min}");
        Console.WriteLine($"f(n) = 3n/2-2 = {3 * n / 2.0 - 2} comparacoes");
    }
}
