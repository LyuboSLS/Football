using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football
{
    class Goal
    {
        public Game Game { get; }
        public Team Team { get; }
        public FootballPlayer Player { get;  }
        public DateTime Time { get; }
        public Goal(Game game,Team team,FootballPlayer player, DateTime time)
        {
            Game = game;
            Player = player;
            Time = time;
        }
        public override string ToString()
        {
            return $"{Player.Name} from {Team.Name} scored goal at {Time.Minute}:{Time.Second}";
        }
    }
}
