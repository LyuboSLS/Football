using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football
{
    internal class Striker : FootballPlayer
    {
        public Striker(Team team, string name, int age, int number, float height) 
            : base(team, name, age, number, height)
        {
        }
        public Striker(string name, int age, int number, float height)
            : base(name, age, number, height)
        {
        }
        public override string ToString()
        {
            return $"Striker - Number:{Number} Name: {Name} Age:{Age} Height:{Height}";
        }
    }
}
