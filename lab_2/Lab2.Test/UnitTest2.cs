using NUnit.Framework;

[TestFixture]
public class ProgramTests
{
    /// <summary>
    /// Тестує метод CountWaysToReachShop з різними вхідними даними.
    /// </summary>
    /// <param name="N">Початкова відстань до магазину.</param>
    /// <param name="K">Кількість кроків.</param>
    /// <param name="expected">Очікуваний результат.</param>
    [TestCase(2, 4, 2)]
    [TestCase(5, 5, 1)]
    [TestCase(1, 3, 0)]
    [TestCase(0, 2, 1)]
    [TestCase(3, 7, 15)]
    [TestCase(10, 20, 184756)]
    public void CountWaysToReachShop_Tests(int N, int K, long expected)
    {
        // Викликаємо метод і перевіряємо результат
        long actual = Program.CountWaysToReachShop(N, K);
        Assert.AreEqual(expected, actual);
    }

    /// <summary>
    /// Тестує метод BinomialCoefficient для обчислення біноміальних коефіцієнтів.
    /// </summary>
    [Test]
    public void BinomialCoefficient_Tests()
    {
        // Перевіряємо правильність обчислення біноміальних коефіцієнтів
        Assert.AreEqual(1, Program.BinomialCoefficient(5, 0));
        Assert.AreEqual(5, Program.BinomialCoefficient(5, 1));
        Assert.AreEqual(10, Program.BinomialCoefficient(5, 2));
        Assert.AreEqual(10, Program.BinomialCoefficient(5, 3));
        Assert.AreEqual(5, Program.BinomialCoefficient(5, 4));
        Assert.AreEqual(1, Program.BinomialCoefficient(5, 5));
    }
}
