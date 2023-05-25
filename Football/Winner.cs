namespace Football
{
    internal class Winner
    {
        public FootballPlayer MostValuablePlayer { get; set; }
        public int moneyAward { get; } = 1_000;
        public Team TeamWinner { get; }
        public Winner(Team team, int award, FootballPlayer MVP)
        {
            TeamWinner = team;
            moneyAward = award;
            MostValuablePlayer = MVP;
        }
        public override string ToString()
        {
            return $"And the winner is {TeamWinner.Name}. " +
                $"Congradulations to all particiapants in this competition" +
                $" and specially for {MostValuablePlayer.Name}." +
                $" What an amazing match";
        }

    }
}