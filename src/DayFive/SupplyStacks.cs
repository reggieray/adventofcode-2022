using System.Text.RegularExpressions;

namespace AdventOfCode2022.DayFive
{
    public static class SupplyStacks
    {
        private static readonly string DoubleNewLine = Environment.NewLine + Environment.NewLine;

        private static readonly IDictionary<int, Stack<string>> _crates = new Dictionary<int, Stack<string>>();

        public static string MoveCrates(string input, CrateType crateType)
        {
            _crates.Clear();
            var stacks = input.Split(DoubleNewLine);
            var crates = stacks[0].Split(Environment.NewLine);
            foreach (var p in crates[^1].Replace(" ", string.Empty).ToCharArray())
            {
                _crates.Add(int.Parse(p.ToString()), new Stack<string>());
            }

            foreach (var c in crates.SkipLast(1).Reverse().ToArray())
            {
                var individualCrates = c.Chunk(4).Select(x => new string(x)).ToArray();
                for (int i = 0; i < individualCrates.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(individualCrates[i]))
                    {
                        _crates[i + 1].Push(individualCrates[i].ToCharArray()[1].ToString());
                    }
                }
            }

            var instructions = stacks[1].Split(Environment.NewLine);
            foreach (var instruction in instructions)
            {
                var match = Regex.Match(instruction, @"move (.*) from (.*) to (.*)");

                if (crateType == CrateType.NineThousand)
                {
                    for (int i = 0; i < int.Parse(match.Groups[1].Value); i++)
                    {
                        var crate = _crates[int.Parse(match.Groups[2].Value)].Pop();
                        _crates[int.Parse(match.Groups[3].Value)].Push(crate);
                    }
                }

                if (crateType == CrateType.NineThousandOne)
                {
                    var mover = new Stack<string>();
                    for (int i = 0; i < int.Parse(match.Groups[1].Value); i++)
                    {
                        var crate = _crates[int.Parse(match.Groups[2].Value)].Pop();
                        mover.Push(crate);
                    }

                    foreach (var c in mover)
                    {
                        _crates[int.Parse(match.Groups[3].Value)].Push(c);
                    }
                }
            }

            return string.Join("", _crates.Select(c => c.Value.Pop()));
        }
    }

    public enum CrateType
    {
        NineThousand,
        NineThousandOne
    }
}