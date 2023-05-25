using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football
{
    class Defender : FootballPlayer
    {
        public static List<Defender> Defenders { get; } = new List<Defender>();

        public delegate void SavesGoalDelegate();
        public Defender(string name, int age, int number, float height)
            : base(name, age, number, height)
        {
            Defenders.Add(this);
        }
        public Defender(Team team,string name, int age, int number, float height) 
            : base(team,name, age, number, height)
        {
            Defenders.Add(this);
        }
        public void Remove()
        {
            Defenders.Remove(this);
        }
        public void GoalSaved(SavesGoalDelegate saved)
        {
            saved();
        }
        public override string ToString()
        {
            return $"Defender - Number:{Number} Name: {Name} Age:{Age} Height:{Height}";
        }
    }
}

