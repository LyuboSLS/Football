using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football
{
    class GoalKeeper : FootballPlayer
    {
        public GoalKeeper(Team team, string name, int age, int number, float height) : 
            base(team, name, age, number, height)
        {
        }
        public GoalKeeper(string name, int age, int number, float height) :
            base(name, age, number, height)
        {
        }
        public override string ToString()
        {
            return $"GoalKeeper - Number:{Number} Name: {Name} Age:{Age} Height:{Height}";
        }
    }
}
