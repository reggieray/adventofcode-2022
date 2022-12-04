namespace AdventOfCode2022.DayFour;

public class DayFourTests
{
    [Theory]
    [InlineData("Day4Sample", 2)]
    [InlineData("Day4", 507)]
    public void Part_One(string fileName, int expected)
    {
        var input = File.ReadAllText($"Input\\{fileName}.txt");

        CampCleanup.OverlappingPairs(input).Should().Be(expected);
    }

    [Theory]
    [InlineData("Day4Sample", 4)]
    [InlineData("Day4", 897)]
    public void Part_Two(string fileName, int expected)
    {
        var input = File.ReadAllText($"Input\\{fileName}.txt");

        CampCleanup.AnyOverlappingPairs(input).Should().Be(expected);
    }
}

