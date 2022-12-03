using System.Text;

namespace AdventOfCode2022.DayThree
{
    public static class RucksackReorganization
    {
        public static int SumOfPriorities(string[] input) => input.Select(x => (x[..(x.Length / 2)], x[(x.Length / 2)..]))
                .Select(y => Encoding.ASCII.GetBytes(y.Item1).Intersect(Encoding.ASCII.GetBytes(y.Item2)))
                .Select(z => Convert.ToInt32(z.First()))
                .Sum(n => n > 90 ? n - 96 : n - 38);

        public static int SumOfThreeElfPriorities(string[] input) => input.Select((s, idx) => (Index: idx / 3, Value: Encoding.ASCII.GetBytes(s)))
                .GroupBy(x => x.Index)
                .Select(g => g.Select(y => y.Value))
                .Select(l => l.Aggregate<IEnumerable<byte>>((p, n) => p.Intersect(n)))
                .Select(b => Convert.ToInt32(b.First()))
                .Sum(n => n > 90 ? n - 96 : n - 38);
    }
}
