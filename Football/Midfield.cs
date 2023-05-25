using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football
{
    class Midfield : FootballPlayer
    {
        public Midfield(Team team, string name, int age, int number, float height) 
            : base(team ,name, age, number, height)
        {
        }
        public Midfield(string name, int age, int number, float height)
            : base(name, age, number, height)
        {
        }
        public override string ToString()
        {
            return $"Midfield - Number:{Number} Name: {Name} Age:{Age} Height:{Height}";
        }
    }
}
