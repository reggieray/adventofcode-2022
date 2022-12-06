
namespace AdventOfCode2022.DaySix
{
    public class DaySixTests
    {
        [Theory]
        [InlineData("Day6Sample", 7)]
        [InlineData("Day6", 1848)]
        public void Part_One(string fileName, int expected)
        {
            var input = File.ReadAllText($"Input\\{fileName}.txt");

            TuningTrouble.StartOfPacketMarker(input).Should().Be(expected);
        }

        [Theory]
        [InlineData("Day6Sample", 19)]
        [InlineData("Day6", 2308)]
        public void Part_Two(string fileName, int expected)
        {
            var input = File.ReadAllText($"Input\\{fileName}.txt");

            TuningTrouble.StartOfMessageMarker(input).Should().Be(expected);
        }
    }
}
