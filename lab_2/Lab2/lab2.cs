using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Зчитуємо вхідні дані з файлу INPUT.TXT
        var input = File.ReadAllText("INPUT.TXT").Split(' ');
        int N = int.Parse(input[0]); // Початкова відстань до магазину
        int K = int.Parse(input[1]); // Кількість кроків

        // Обчислюємо кількість способів досягти магазину
        long result = CountWaysToReachShop(N, K);

        // Записуємо результат у файл OUTPUT.TXT
        File.WriteAllText("OUTPUT.TXT", result.ToString());
    }

    /// <summary>
    /// Обчислює кількість способів досягти магазину за задану кількість кроків.
    /// </summary>
    /// <param name="N">Початкова відстань до магазину.</param>
    /// <param name="K">Кількість кроків.</param>
    /// <returns>Кількість способів досягти магазину.</returns>
    public static long CountWaysToReachShop(int N, int K)
    {
        // Якщо відстань більша за кількість кроків або задача неможлива (непарний залишок), повертаємо 0
        if (N > K || (N + K) % 2 != 0) return 0;

        // x — кількість кроків у напрямку до магазину
        int x = (K + N) / 2;

        // Обчислюємо кількість комбінацій
        return BinomialCoefficient(K, x);
    }

    /// <summary>
    /// Обчислює біноміальний коефіцієнт \"n choose k\".
    /// </summary>
    /// <param name="n">Загальна кількість кроків.</param>
    /// <param name="k">Кількість кроків у напрямку до магазину.</param>
    /// <returns>Біноміальний коефіцієнт.</returns>
    public static long BinomialCoefficient(int n, int k)
    {
        // Якщо k більше за n, повертаємо 0
        if (k > n) return 0;

        // Якщо k дорівнює 0 або n, результат — 1
        if (k == 0 || k == n) return 1;

        // Масив для обчислення біноміальних коефіцієнтів
        long[] dp = new long[k + 1];
        dp[0] = 1; // Ініціалізуємо перший коефіцієнт

        // Динамічне програмування для обчислення коефіцієнтів
        for (int i = 1; i <= n; i++)
        {
            for (int j = Math.Min(i, k); j > 0; j--)
            {
                dp[j] += dp[j - 1];
            }
        }

        return dp[k];
    }
}
