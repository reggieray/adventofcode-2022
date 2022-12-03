namespace AdventOfCode2022.DayTwo
{
    public static class RockPaperScissors
    {
        public static int CalculateScore(string[] input, bool useStrategy) => input.Select(x => new RPSGame(x, useStrategy))
            .Sum(y => y.Score);
    }
}