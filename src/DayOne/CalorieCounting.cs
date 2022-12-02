namespace AdventOfCode2022.DayOne
{
    public static class CalorieCounting
    {
        private static readonly string DoubleNewLine = Environment.NewLine + Environment.NewLine;

        public static int TopElf(string input)
        {
            return input.Split(DoubleNewLine)
            .Select(x =>
            {
                return x.Split(Environment.NewLine)
                .Select(y => int.Parse(y))
                .Sum();
            })
            .ToList()
            .OrderDescending()
            .First();
        }

        public static int TopThreeElves(string input)
        {
            return input.Split(DoubleNewLine)
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
        }
    }
}