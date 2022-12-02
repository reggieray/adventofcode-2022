using FluentAssertions;

namespace AdventOfCode2022.DayOne;

public class DayOneTests
{
    private static readonly string DoubleNewLine = Environment.NewLine + Environment.NewLine;

    [Theory]
    [InlineData("Day1Sample", 24000)]
    [InlineData("Day1", 71780)]
    public void Part_One(string fileName, int expected)
    {
        var input = File.ReadAllText($"Input\\{fileName}.txt");
        var topElf = input.Split(DoubleNewLine)
            .Select(x =>
            {
                return x.Split(Environment.NewLine)
                .Select(y => int.Parse(y))
                .Sum();
            })
            .ToList()
            .OrderDescending()
            .First();

        topElf.Should().Be(expected);
    }

    [Theory]
    [InlineData("Day1Sample", 45000)]
    [InlineData("Day1", 212489)]
    public void Part_Two(string fileName, int expected)
    {
        var input = File.ReadAllText($"Input\\{fileName}.txt");
        var topThreeElves = input.Split(DoubleNewLine)
            .Select(x =>
            {
                return x.Split(Environment.NewLine)
                .Select(y => int.Parse(y))
                .Sum();
            })
            .ToList()
            .OrderDescending()
            .Take(3)
            .Sum();

        topThreeElves.Should().Be(expected);
    }
}