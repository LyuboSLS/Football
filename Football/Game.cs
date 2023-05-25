using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football
{
    class Game
    {
        private DateTime StartTime = new DateTime();
        
        public Team Team1 { get;private set; }
        public Team Team2 { get; private set; }
        public Team Winner { get; private set; }
        public Referee GameReferee { get; private set; }
        public List<Referee> AsistReffees { get; private set; } = new List<Referee>();
        public List<Goal> Goals { get; private set; } = new List<Goal>();

        public delegate void GoalScoredDelegate(FootballPlayer player, DateTime time);
        public delegate void DrawResultDelegate();
        public delegate void WinnerDelegate(Team team);
        ///public delegate string StartTheMatch();
        public Game(Team team1, Team team2, Referee gameReferee, List<Referee> asistReffees)
        {
            if (team1.GetPlayersCount() != 11 || team2.GetPlayersCount() != 11)
            {
                throw new ArgumentOutOfRangeException($"Both teams must have exactly 11 players");
            }
            if (AsistReffees.Count != 2)
            {
                throw new ArgumentOutOfRangeException($"You must have exactly 2 assist reffeers");
            }
            Team1 = team1;
            Team2 = team2;
            GameReferee = gameReferee;
            AsistReffees = asistReffees;
        }

        public void Start()
        {
            StartTime = DateTime.Now;
        }

        public void ChangePlayer(Team teamOfTheNewPlayer, FootballPlayer oldPlayer, FootballPlayer newPlayer)
        {
            if (teamOfTheNewPlayer == Team1)
            {
                Team1.AddPlayer(newPlayer, null);
                Team1.RemovePlayer(oldPlayer);
            }
            else if (teamOfTheNewPlayer == Team2)
            {
                Team2.AddPlayer(newPlayer, null);
                Team2.RemovePlayer(oldPlayer);
            }

        }
        public void ChangeReferee(Referee referee)
        {
            GameReferee = referee;
        }
        
        public int GetTeam1Result()
        {
            int score = 0;
            foreach (Goal goal in Goals)
            {
                if (goal.Team == Team1)
                {
                    score++;
                }
            }
            return score;
        }
        public int GetTeam2Result()
        {
            int score = 0;
            foreach (Goal goal in Goals)
            {
                if (goal.Team == Team2)
                {
                    score++;
                }
            }
            return score;
        }
        public void ScorredGoal(FootballPlayer player, DateTime time, GoalScoredDelegate goalScored)
        {
            Goals.Add(new Goal(this, player.Team, player, time));
            goalScored(player, time);
        }

        public void Finish(WinnerDelegate winnerDelegate,DrawResultDelegate draw)
        {
            if (GetTeam1Result() > GetTeam2Result())
            {
                Winner = Team1;
                winnerDelegate(Team1);
            }
            else if (GetTeam1Result() < GetTeam2Result())
            {
                Winner = Team2;
                winnerDelegate(Team2);
            }
            else draw();
        }

        /* public override string ToString()
         {
             string result = string.Empty;
             result += $" {Team1.Name}   vs   {Team2.Name}";
             foreach (var goal in Goals)
             {
                 result += goal+ Environment.NewLine;
             }
             result += Environment.NewLine;
             int goalsTeam1 = GetTeam1Result();
             int goalsTeam2 = GetTeam2Result();
             if (goalsTeam1 > goalsTeam2)
             {
                 result += $"The match finished {goalsTeam1}:{goalsTeam2}";
                 Winner winner = new Winner();

             }
             return result;
         }*/
        public override string ToString()
        { 
            return $"{Team1.Name}:{GetTeam1Result()},{Team2.Name}:{GetTeam2Result()}";
        }
    }
}
