using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static readonly int[] dx = { -1, 1, 0, 0 }; // Зміщення для сусідів (рядки)
    static readonly int[] dy = { 0, 0, -1, 1 }; // Зміщення для сусідів (колонки)

    static void Main(string[] args)
    {
        // Зчитування даних із файлу INPUT.TXT
        var input = File.ReadAllLines("INPUT.TXT");
        var dimensions = input[0].Split(' ');
        int N = int.Parse(dimensions[0]);
        int M = int.Parse(dimensions[1]);

        int[,] heights = new int[N, M];
        for (int i = 0; i < N; i++)
        {
            var row = input[i + 1].Split(' ');
            for (int j = 0; j < M; j++)
            {
                heights[i, j] = int.Parse(row[j]);
            }
        }

        // Обчислення мінімальної кількості водостоків
        int result = CalculateMinDrains(N, M, heights);

        // Запис результату у файл OUTPUT.TXT
        File.WriteAllText("OUTPUT.TXT", result.ToString());
    }

    /// <summary>
    /// Обчислює мінімальну кількість водостоків для карти.
    /// </summary>
    public static int CalculateMinDrains(int N, int M, int[,] heights)
    {
        bool[,] visited = new bool[N, M];
        int drains = 0;

        // Проходимо по кожному квадрату
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                if (!visited[i, j])
                {
                    // Перевіряємо зв'язану область
                    if (NeedsDrain(i, j, N, M, heights, visited))
                    {
                        drains++;
                    }
                }
            }
        }

        return drains;
    }

    /// <summary>
    /// Перевіряє, чи потрібен водосток для зв'язаної області.
    /// </summary>
    private static bool NeedsDrain(int x, int y, int N, int M, int[,] heights, bool[,] visited)
    {
        Queue<(int, int)> queue = new();
        List<(int, int)> region = new();
        queue.Enqueue((x, y));
        visited[x, y] = true;
        region.Add((x, y));

        bool isDrainNeeded = true;

        while (queue.Count > 0)
        {
            var (cx, cy) = queue.Dequeue();

            for (int d = 0; d < 4; d++)
            {
                int nx = cx + dx[d];
                int ny = cy + dy[d];

                if (nx >= 0 && nx < N && ny >= 0 && ny < M)
                {
                    if (heights[nx, ny] < heights[cx, cy])
                    {
                        isDrainNeeded = false; // Вода може стекти природним шляхом
                    }
                    else if (heights[nx, ny] == heights[cx, cy] && !visited[nx, ny])
                    {
                        visited[nx, ny] = true;
                        queue.Enqueue((nx, ny));
                        region.Add((nx, ny));
                    }
                }
            }
        }

        return isDrainNeeded;
    }
}
