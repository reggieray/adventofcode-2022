namespace AdventOfCode2022.DayFive
{
    public class DayFiveTests
    {
        [Theory]
        [InlineData("Day5Sample", "CMZ")]
        [InlineData("Day5", "FZCMJCRHZ")]
        public void Part_One(string fileName, string expected)
        {
            var input = File.ReadAllText($"Input\\{fileName}.txt");

            SupplyStacks.MoveCrates(input, CrateType.NineThousand).Should().Be(expected);
        }

        [Theory]
        [InlineData("Day5Sample", "MCD")]
        [InlineData("Day5", "JSDHQMZGF")]
        public void Part_Two(string fileName, string expected)
        {
            var input = File.ReadAllText($"Input\\{fileName}.txt");

            SupplyStacks.MoveCrates(input, CrateType.NineThousandOne).Should().Be(expected);
        }
    }
}
