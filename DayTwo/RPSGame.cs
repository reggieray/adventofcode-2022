namespace AdventOfCode2022.DayTwo
{
    public class RPSGame : BaseRPSGame
    {
        public int Score { get; }

        public RPSGame(string game)
        {
            var play = game.Split(' ');
            var p1 = Choice[play[0]];
            var p2 = Choice[play[1]];

            Score =  (Rules[p2].Beats == p1 ? 6 : p1 == p2 ? 3 : 0) + Rules[p2].Score;
        }
    }
}
