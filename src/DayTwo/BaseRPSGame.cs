namespace AdventOfCode2022.DayTwo
{
    internal abstract class BaseRPSGame
    {
        protected readonly Dictionary<string, (string Beats, int Score)> Rules = new()
        {
            { "Rock", ("Scissors", 1) },
            { "Paper", ("Rock", 2) },
            { "Scissors", ("Paper", 3) }
        };

        protected readonly Dictionary<string, string> Choice = new()
        {
            { "A", "Rock" },
            { "B", "Paper" },
            { "C", "Scissors" },
            { "X", "Rock" },
            { "Y", "Paper" },
            { "Z", "Scissors" }
        };
    }
}