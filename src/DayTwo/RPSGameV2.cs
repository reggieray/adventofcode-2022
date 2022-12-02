namespace AdventOfCode2022.DayTwo
{
    internal class RPSGameV2 : BaseRPSGame
    {
        private readonly Dictionary<string, Dictionary<string, string>> Strategy = new()
        {
            { "X", new() { { "Rock", "Scissors" }, { "Paper", "Rock" }, { "Scissors", "Paper" } } },
            { "Y", new() { { "Rock", "Rock" }, { "Paper", "Paper" }, { "Scissors", "Scissors" } } },
            { "Z", new() { { "Rock", "Paper" }, { "Paper", "Scissors" }, { "Scissors", "Rock" } } }
        };

        public int Score { get; }

        public RPSGameV2(string game)
        {
            var play = game.Split(' ');
            var p1 = Choice[play[0]];
            var p2 = Strategy[play[1]][p1];

            Score = (Rules[p2].Beats == p1 ? 6 : p1 == p2 ? 3 : 0) + Rules[p2].Score;
        }
    }
}