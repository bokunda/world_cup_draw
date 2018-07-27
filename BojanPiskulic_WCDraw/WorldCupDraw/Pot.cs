using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BojanPiskulic_WCDraw.WorldCupDraw
{
    public class Pot : IDraw
    {
        private static int POTNUMBER = 0;

        int potNumber;
        List<NationalTeam> potMembers = new List<NationalTeam>();

        public Pot()
        {
            potNumber = POTNUMBER++;
        }

        public Boolean AddTeam(NationalTeam team)
        {
            if(potMembers.Count < Constants.MAX_TEAMS_IN_POT)
            {                  
                potMembers.Add(team);
                team.Pot = potNumber;

                return true;                
            }

            return false;
        }

        public List<NationalTeam> PotMembers
        {
            get => potMembers;
            set => potMembers = value;
        }

        public void PrintTeams()
        {
            Console.WriteLine("POT: " + (potNumber + 1));
            foreach (NationalTeam nt in potMembers)
            {
                Console.WriteLine(nt.ToString());
            }
        }
    }
}
