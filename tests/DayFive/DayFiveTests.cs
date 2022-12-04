namespace AdventOfCode2022.DayFive
{
    public class DayFiveTests
    {
        [Theory]
        [InlineData("Day5Sample", 0)]
        [InlineData("Day5", 0)]
        public void Part_One(string fileName, int expected)
        {
            //var input = File.ReadAllLines($"Input\\{fileName}.txt");

            1.Should().Be(expected);
        }
    }
}
