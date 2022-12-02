namespace AdventOfCode2022.DayTwo
{
    public static class RockPaperScissors
    {
        public static int StrategyAScore(string[] input)
        {
            return input.Select(x => new RPSGame(x))
                .Sum(y => y.Score);
        }

        public static int StrategyBScore(string[] input)
        {
            return input.Select(x => new RPSGameV2(x))
                .Sum(y => y.Score);
        }
    }
}