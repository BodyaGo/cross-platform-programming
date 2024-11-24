using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class DartsGameTests
{
    [Test]
    [TestCase(5, ExpectedResult = 7)]
    [TestCase(50, ExpectedResult = 2)]
    [TestCase(1, ExpectedResult = 0)]
    [TestCase(200, ExpectedResult = 0)]
    public int TestFindWays(int remainingPoints)
    {
        // Arrange
        var scores = new List<string>();
        for (int i = 1; i <= 20; i++)
        {
            scores.Add(i.ToString()); // Сектори 1-20
            scores.Add("D" + i); // Подвоєні сектори D1-D20
            scores.Add("T" + i); // Потроєні сектори T1-T20
        }
        scores.Add("25"); // Зовнішня частина Bull
        scores.Add("Bull"); // Яблучко

        List<string> results = new List<string>();

        // Act
        DartsGame.FindWays(remainingPoints, scores, new List<string>(), results);

        // Assert
        return results.Count;
    }

    [Test]
    public void TestGetPoints()
    {
        // Arrange
        var game = new DartsGame();

        // Act & Assert
        Assert.AreEqual(1, game.GetPoints("1"));
        Assert.AreEqual(25, game.GetPoints("25"));
        Assert.AreEqual(50, game.GetPoints("Bull"));
        Assert.AreEqual(20, game.GetPoints("D10"));
        Assert.AreEqual(30, game.GetPoints("T10"));
    }

    [Test]
    public void TestIsLastThrowDouble()
    {
        // Arrange
        var game = new DartsGame();

        // Act & Assert
        Assert.IsTrue(game.IsLastThrowDouble("D1"));
        Assert.IsTrue(game.IsLastThrowDouble("Bull"));
        Assert.IsFalse(game.IsLastThrowDouble("10"));
        Assert.IsFalse(game.IsLastThrowDouble("T10"));
    }
}