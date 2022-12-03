namespace AdventOfCode2022.DayThree;

public class DayThreeTests
{
    [Theory]
    [InlineData("Day3Sample", 157)]
    [InlineData("Day3", 7716)]
    public void Part_One(string fileName, int expected)
    {
        var input = File.ReadAllLines($"Input\\{fileName}.txt");

        RucksackReorganization.SumOfPriorities(input).Should().Be(expected);
    }

    [Theory]
    [InlineData("Day3Sample", 70)]
    [InlineData("Day3", 2973)]
    public void Part_Two(string fileName, int expected)
    {
        var input = File.ReadAllLines($"Input\\{fileName}.txt");

        RucksackReorganization.SumOfThreeElfPriorities(input).Should().Be(expected);
    }
}

