namespace AdventOfCode2022.DayOne;

public class DayOneTests
{
    [Theory]
    [InlineData("Day1Sample", 24000)]
    [InlineData("Day1", 71780)]
    public void Part_One(string fileName, int expected)
    {
        var input = File.ReadAllText($"Input\\{fileName}.txt");

        CalorieCounting.TopElf(input).Should().Be(expected);
    }

    [Theory]
    [InlineData("Day1Sample", 45000)]
    [InlineData("Day1", 212489)]
    public void Part_Two(string fileName, int expected)
    {
        var input = File.ReadAllText($"Input\\{fileName}.txt");

        CalorieCounting.TopThreeElves(input).Should().Be(expected);
    }
}