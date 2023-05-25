using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football
{
    class FootballPlayer:Person
    {
        protected static List<FootballPlayer> players { get; } = new List<FootballPlayer>();
        public int Number { get; set; }
        public double Height { get; set; }
        public Team Team { get; set; }
        public FootballPlayer(string name, int age, int number, float height)
            : base(name, age)
        {
            Number = number;
            Height = height;
            players.Add(this);
        }


        public FootballPlayer(Team team,string name, int age, int number, float height)
            :base(name, age)
        {
            this.Team = team;
            Number = number;
            Height = height;
            players.Add(this);
        }
        public static void PrintAllFootballPlayers()
        {
            string all = string.Empty;
            foreach (var item in players)
            {
                all += item + Environment.NewLine;
            }
        }
        public override string ToString()
        {
            return $"FootballPlayer - Number:{Number} Name: {Name} Age:{Age} Height:{Height}";
        }
    }
}
