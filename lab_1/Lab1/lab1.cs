using System;
using System.Collections.Generic;
using System.IO;

public class DartsGame
{
    static void Main()
    {
        int n = int.Parse(File.ReadAllText("INPUT.TXT").Trim());
        List<string> results = new List<string>();

        // Визначення можливих очок
        List<string> scores = new List<string>();
        for (int i = 1; i <= 20; i++)
        {
            scores.Add(i.ToString()); // Сектори 1-20
            scores.Add("D" + i); // Подвоєні сектори D1-D20
            scores.Add("T" + i); // Потроєні сектори T1-T20
        }
        scores.Add("25"); // Зовнішня частина Bull
        scores.Add("Bull"); // Яблучко

        // Генерація всіх можливих комбінацій
        FindWays(n, scores, new List<string>(), results);

        // Вивід результатів
        File.WriteAllText("OUTPUT.TXT", results.Count + "\n" + string.Join("\n", results));
    }

    static void FindWays(int remainingPoints, List<string> scores, List<string> currentCombination, List<string> results)
    {
        // Якщо залишилося 0 очок, перевіряємо, чи останній кидок є подвоєним
        if (remainingPoints == 0)
        {
            if (currentCombination.Count > 0 && IsLastThrowDouble(currentCombination[currentCombination.Count - 1]))
            {
                results.Add(string.Join(" ", currentCombination));
            }
            return;
        }

        // Якщо залишилося менше 0 очок, повертаємось
        if (remainingPoints < 0)
            return;

        // Перебір всіх можливих кидків
        foreach (var score in scores)
        {
            int points = GetPoints(score);
            currentCombination.Add(score);
            FindWays(remainingPoints - points, scores, currentCombination, results);
            currentCombination.RemoveAt(currentCombination.Count - 1);
        }
    }

    static int GetPoints(string score)
    {
        if (score == "Bull") return 50;
        if (score == "25") return 25;
        if (score.StartsWith("D")) return int.Parse(score.Substring(1)) * 2;
        if (score.StartsWith("T")) return int.Parse(score.Substring(1)) * 3;
        return int.Parse(score);
    }

    static bool IsLastThrowDouble(string lastThrow)
    {
        return lastThrow.StartsWith("D") || lastThrow == "Bull";
    }
}