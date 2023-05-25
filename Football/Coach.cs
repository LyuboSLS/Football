using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Football.Coach;

namespace Football
{
    internal class Coach : Person
    {
        public Team LeadsTeam { get; set; }
        public static List<Coach> Coaches { get; } = new List<Coach>();

        public delegate void TeamMeetingDelegate();
        public delegate void ChangePlayer(FootballPlayer newPlayer, FootballPlayer changedPlayer, Team team);

        public Coach(string name, int age)
            : base(name, age)
        {
            if (Age < 18)
            {
                throw new ArgumentOutOfRangeException("A coach must be at least 18 years old");
            }
            Coaches.Add(this);
        }
        public Coach(Team team, string name, int age)
            : base(name, age)
        {
            if (Age < 18)
            {
                throw new ArgumentOutOfRangeException("A coach must be at least 18 years old");
            }
            LeadsTeam = team;
            Coaches.Add(this);
        }

        public void TeamMeetingScheduled(TeamMeetingDelegate teamMeetingScheduled)
        {
            teamMeetingScheduled();
        }
        public override string ToString()
        {
            return $"Coach - Team:{LeadsTeam.Name} Name:{Name} Age:{Age}";
        }
    }
}
