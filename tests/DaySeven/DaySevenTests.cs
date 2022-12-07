namespace AdventOfCode2022.DaySeven
{
    public class DaySevenTests
    {
        [Theory]
        [InlineData("Day7Sample", 95437)]
        [InlineData("Day7", 1334506)]
        public void Part_One(string fileName, int expected)
        {
            var input = File.ReadAllText($"Input\\{fileName}.txt");

            NoSpaceLeftOnDevice.TotalSizeOfDirectories(input).Should().Be(expected);
        }

        [Theory]
        [InlineData("Day7Sample", 24933642)]
        [InlineData("Day7", 7421137)]
        public void Part_Two(string fileName, int expected)
        {
            var input = File.ReadAllText($"Input\\{fileName}.txt");

            NoSpaceLeftOnDevice.TotalSizeOfDirectoryToDelete(input).Should().Be(expected);
        }
    }
}
