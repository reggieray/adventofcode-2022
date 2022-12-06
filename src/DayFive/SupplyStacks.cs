using System.Text.RegularExpressions;

namespace AdventOfCode2022.DayFive
{
    public static class SupplyStacks
    {
        private static readonly string DoubleNewLine = Environment.NewLine + Environment.NewLine;

        public static string MoveCrates(string input, CrateMover crateMover)
        {
            var stacks = input.Split(DoubleNewLine);
            return MoveCrates(
                SetupCrates(stacks[0].Split(Environment.NewLine)), 
                crateMover, stacks[1].Split(Environment.NewLine));
        }

        private static IDictionary<int, Stack<char>> SetupCrates(string[] intialState)
        {
            var crates = new Dictionary<int, Stack<char>>();

            foreach (var p in intialState.Last().ToCharArray())
            {
                if (char.IsDigit(p))
                {
                    crates.Add(int.Parse(p.ToString()), new Stack<char>());
                }
            }

            foreach (var line in intialState.SkipLast(1).Reverse().ToArray())
            {
                var chuncks = line.Chunk(4);
                var index = 1;
                foreach (var chunck in chuncks)
                {
                    if (char.IsLetter(chunck[1]))
                    {
                        crates[index].Push(chunck[1]);
                    }
                    index++;
                }
            }

            return crates;
        }

        private static string MoveCrates(IDictionary<int, Stack<char>> crates, CrateMover crateMover, string[] instructions)
        {
            Action<IDictionary<int, Stack<char>>, Move> mover =
                crateMover == CrateMover.NineThousand ? MoverNineThousand : MoverNineThousandOne;

            var moves = instructions
                .Select(x => Regex.Match(x, @"move (.*) from (.*) to (.*)"))
                .Select(m => new Move(
                       int.Parse(m.Groups[1].Value),
                       int.Parse(m.Groups[2].Value),
                       int.Parse(m.Groups[3].Value)));

            foreach (var move in moves)
            {
                mover.Invoke(crates, move);
            }

            return string.Join("", crates.Select(c => c.Value.Pop()));
        }

        static void MoverNineThousand(IDictionary<int, Stack<char>> crates, Move move)
        {
            for (int i = 0; i < move.Amount; i++)
            {
                crates[move.To].Push(crates[move.From].Pop());
            }
        }

        static void MoverNineThousandOne(IDictionary<int, Stack<char>> crates, Move move)
        {
            var mover = new Stack<char>();
            for (int i = 0; i < move.Amount; i++)
            {
                mover.Push(crates[move.From].Pop());
            }

            foreach (var c in mover)
            {
                crates[move.To].Push(c);
            }
        }
    }

    internal record Move(int Amount, int From, int To);

    public enum CrateMover
    {
        NineThousand,
        NineThousandOne
    }
}