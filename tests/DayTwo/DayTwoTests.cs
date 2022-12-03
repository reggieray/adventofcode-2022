namespace AdventOfCode2022.DayTwo;

public class DayTwoTests
{
    [Theory]
    [InlineData("Day2Sample", 15)]
    [InlineData("Day2", 17189)]
    public void Part_One(string fileName, int expected)
    {
        var input = File.ReadAllLines($"Input\\{fileName}.txt");

        RockPaperScissors.CalculateScore(input, useStrategy: false).Should().Be(expected);
    }

    [Theory]
    [InlineData("Day2Sample", 12)]
    [InlineData("Day2", 13490)]
    public void Part_Two(string fileName, int expected)
    {
        var input = File.ReadAllLines($"Input\\{fileName}.txt");

        RockPaperScissors.CalculateScore(input, useStrategy: true).Should().Be(expected);
    }
}