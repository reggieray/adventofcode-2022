namespace AdventOfCode2022.DayFour
{
    public static class CampCleanup
    {
        public static int OverlappingPairs(string input) => Pairs(input)
                .Count(z => Contains(z.First(), z.Last()) ||
                Contains(z.Last(), z.First()));

        public static int AnyOverlappingPairs(string input) => Pairs(input)
                .Count(z => Overlaps(z.First(), z.Last()) ||
                Overlaps(z.Last(), z.First()));

        private static IEnumerable<IEnumerable<Pair>> Pairs(string input) => input.Split(Environment.NewLine)
                .Select(x => x.Split(',').Select(y =>
                {
                    var p = y.Split('-').Select(int.Parse);
                    return new Pair(p.First(), p.Last());
                }));

        private static bool Contains(Pair p1, Pair p2) => p1.From >= p2.From && p1.To <= p2.To;

        private static bool Overlaps(Pair p1, Pair p2) => p1.To >= p2.From && p1.From <= p2.To;
    }

    internal record struct Pair(int From, int To);
}
