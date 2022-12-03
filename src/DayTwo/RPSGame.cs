namespace AdventOfCode2022.DayTwo
{
    internal class RPSGame
    {
        private readonly Dictionary<string, (string Lose, string Win, int Score)> Rules = new()
        {
            { "Rock", ("Scissors", "Paper", 1) },
            { "Paper", ("Rock", "Scissors", 2) },
            { "Scissors", ("Paper", "Rock", 3) }
        };

        public int Score { get; }

        public RPSGame(string game, bool useStrategy) => Score = CalculateScore(game, useStrategy);

        private int CalculateScore(string game, bool useStrategy)
        {
            var play = game.Split(' ');
            var p1 = GetChoice(play[0]);
            var p2 = useStrategy ? GetStrategyChoice(p1, play[1]) : GetChoice(play[1]);
            return (p1 == Rules[p2].Lose ? 6 : p1 == p2 ? 3 : 0) + Rules[p2].Score;
        }

        private static string GetChoice(string input) => input switch
        {
            "A" or "X" => "Rock",
            "B" or "Y" => "Paper",
            _ => "Scissors",
        };

        private string GetStrategyChoice(string p1, string p2Input) => p2Input switch
        {
            "X" => Rules[p1].Lose,
            "Z" => Rules[p1].Win,
            _ => p1,
        };
    }
}