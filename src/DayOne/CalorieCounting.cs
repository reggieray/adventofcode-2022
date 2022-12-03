namespace AdventOfCode2022.DayOne
{
    public static class CalorieCounting
    {
        private static readonly string DoubleNewLine = Environment.NewLine + Environment.NewLine;

        public static int TopElf(string input) => input.Split(DoubleNewLine)
            .Select(x => x.Split(Environment.NewLine).Sum(y => int.Parse(y)))
            .OrderDescending()
            .First();

        public static int TopThreeElves(string input) => input.Split(DoubleNewLine)
            .Select(x => x.Split(Environment.NewLine).Sum(y => int.Parse(y)))
            .OrderDescending()
            .Take(3)
            .Sum();
        
    }
}