using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Football
{
    internal class Team
    {
        public string Name { get; }
        public Coach Coach { get; }
        protected List<FootballPlayer> Players { get; } = new List<FootballPlayer>();
        public delegate void FootballPlayerCantBeAddedDelegate();
        public Dictionary<DateTime, string> TeamWorkoutsWithDescription { get; } = new Dictionary<DateTime, string>();

        public Team(string name, Coach coach, List<FootballPlayer> players)
        {
            if (players.Count < 11 || players.Count > 22)
            {
                throw new ArgumentOutOfRangeException($"Team \"{name}\" must have between 11 and 22 players");
            }
            foreach (var player in players) 
            {
                player.Team = this;
            }
            Players = players;
            Name = name;
            Coach = coach;
        }

        public void AddWorkout(DateTime time, string description)
        {
            if (!TeamWorkoutsWithDescription.ContainsKey(time))
            {
                TeamWorkoutsWithDescription.Add(time, description);
            } 
        }

        public void AddPlayer(FootballPlayer player, FootballPlayerCantBeAddedDelegate? cantBeAdded) 
        {
            if (!HasPlayer(player) && Players.Count < 22)
            {
                Players.Add(player);
            }
            else
            {
                cantBeAdded();
            }
        }
        public bool HasPlayer(FootballPlayer player) {  return Players.Contains(player); }
        public void RemovePlayer(FootballPlayer player) {  Players.Remove(player); }
        public int GetPlayersCount() { return Players.Count; }

        public double AverageAge()
        {
            int sum = 0;
            foreach (var player in Players)
            {
                sum += player.Age;
            }
            return sum/(double)Players.Count;
        }
        public double AverageHeight()
        {
            double sum = 0;
            foreach (var player in Players)
            {
                sum += player.Height;
            }
            return sum / Players.Count;
        }
        public bool Equals(Team team2)
        {
            foreach (var player1 in this.Players)
            {
                if (!this.HasPlayer(player1))
                {
                    return false;
                }
            }
            if (this.Coach != team2.Coach)
            {
                return false;
            }
            return true;
        }
        public override string ToString()
        {
            string a = string.Empty;
            foreach (var player in Players)
            {
                a += player.ToString()+ Environment.NewLine;
            }

            return a;
        }
    }
}
