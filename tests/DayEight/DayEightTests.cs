namespace AdventOfCode2022.DayEight
{
    public class DayEightTests
    {
        [Theory]
        [InlineData("Day8Sample", 21)]
        [InlineData("Day8", 1690)]
        public void Part_One(string fileName, int expected)
        {
            var input = File.ReadAllText($"Input\\{fileName}.txt");

            TreetopTreeHouse.VisibleTrees(input).Should().Be(expected);
        }

        [Theory]
        [InlineData("Day8Sample", 8)]
        [InlineData("Day8", 535680)]
        public void Part_Two(string fileName, int expected)
        {
            var input = File.ReadAllText($"Input\\{fileName}.txt");

            TreetopTreeHouse.HighestScenicScore(input).Should().Be(expected);
        }
    }
}
