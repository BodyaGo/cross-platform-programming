using NUnit.Framework;

[TestFixture]
public class ProgramTests
{
    [Test]
    public void TestExample1()
    {
        int[,] heights = {
            { 5, 1, 2, 3, 1 },
            { 10, 1, 4, 3, 10 },
            { 10, 1, 5, 5, 5 },
            { 5, 6, 6, 6, 6 }
        };

        int result = Program.CalculateMinDrains(4, 5, heights);
        Assert.AreEqual(2, result);
    }

    [Test]
    public void TestFlatSurface()
    {
        int[,] heights = {
            { 1, 1, 1 },
            { 1, 1, 1 },
            { 1, 1, 1 }
        };

        int result = Program.CalculateMinDrains(3, 3, heights);
        Assert.AreEqual(1, result);
    }

    [Test]
    public void TestIncreasingHeights()
    {
        int[,] heights = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

        int result = Program.CalculateMinDrains(3, 3, heights);
        Assert.AreEqual(0, result);
    }

    [Test]
    public void TestDecreasingHeights()
    {
        int[,] heights = {
            { 9, 8, 7 },
            { 6, 5, 4 },
            { 3, 2, 1 }
        };

        int result = Program.CalculateMinDrains(3, 3, heights);
        Assert.AreEqual(1, result);
    }
}
