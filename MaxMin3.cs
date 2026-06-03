using System;

class MaxMin3
{
    // f(n) = 3n/2 - 2 — melhor caso, pior caso e caso medio
    static void MaxMin(int[] A, out int Max, out int Min)
    {
        int n = A.Length;

        // Se n e impar, duplica o ultimo elemento na posicao extra
        int[] B;
        if (n % 2 != 0)
        {
            B = new int[n + 1];
            Array.Copy(A, B, n);
            B[n] = B[n - 1];
        }
        else
        {
            B = (int[])A.Clone();
        }

        int[] maiores = new int[B.Length / 2];
        int[] menores = new int[B.Length / 2];

        // Passo 1: comparar pares — separa maiores e menores
        for (int i = 0, j = 0; i < B.Length; i += 2, j++)
        {
            if (B[i] < B[i + 1]) { maiores[j] = B[i + 1]; menores[j] = B[i]; }
            else                  { maiores[j] = B[i];     menores[j] = B[i + 1]; }
        }

        // Passo 2: Max no subconjunto dos maiores
        Max = maiores[0];
        for (int i = 1; i < maiores.Length; i++)
            if (maiores[i] > Max) Max = maiores[i];

        // Passo 3: Min no subconjunto dos menores
        Min = menores[0];
        for (int i = 1; i < menores.Length; i++)
            if (menores[i] < Min) Min = menores[i];
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
        Console.WriteLine($"f(n) = 3n/2-2 = {3 * n / 2.0 - 2} comparacoes");
    }
}
