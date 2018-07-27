using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BojanPiskulic_WCDraw.WorldCupDraw
{
    public class Group : IDraw
    {
        private static char GROUPNAME = 'A';

        private char name;
        NationalTeam[] groupMembers;

        public Group()
        {
            name = GROUPNAME++;
            groupMembers = new NationalTeam[Constants.MAX_TEAMS_IN_GROUPS];
        }

        public char Name
        {
            get => name;
            set => name = value;
        }

        public static void ResetStartGroup()
        {
            GROUPNAME = 'A';
        }

        public Boolean AddTeam(NationalTeam team)
        {
            int mesta;
            if (team.Pot == 0 && groupMembers[0] == null)
            {
                groupMembers[0] = team;
                team.Group = name;

                return true;
            }
            else
            {
                List<int> emptyFiels = new List<int>();

                for(int i = 1; i < groupMembers.Length; i++)
                {
                    if(groupMembers[i] == null)
                    {
                        emptyFiels.Add(i);
                    }
                }                

                if ((mesta = emptyFiels.Count) > 0)
                {
                    int c = 0;
                    int potCount = 0;
                    for (int i = 0; i < groupMembers.Length; i++)
                    {
                        if (groupMembers[i] != null && team.Region == groupMembers[i].Region)
                        {
                            c++;
                        }

                        if(groupMembers[i] != null && team.Pot == groupMembers[i].Pot)
                        {
                            potCount++;
                        }
                    }

                    if ((c == 0 || (team.Region == "Evropa" && c < 2)) && potCount == 0)
                    {
                        Random r = new Random();
                        int index = emptyFiels[r.Next(0, emptyFiels.Count)];
                                                    
                        groupMembers[index] = team;                        
                        team.Group = name;
                        emptyFiels.Remove(index);                        

                        return true;
                    }
                    else
                    {   
                        return false;
                    }
                }
                else
                {                    
                    return false;
                }
            }
           
        }


        public void PrintTeams()
        {
            Console.WriteLine("GROUP: " + name);
            for(int i = 0; i < groupMembers.Length; i++)
            {
                if(groupMembers[i] != null) Console.WriteLine((i+1) + ". " + groupMembers[i].ToString() + " team pot: " + groupMembers[i].Pot);
            }
        }

        public override string ToString()
        {
            return name + "," + "1." + groupMembers[0] + ",2." + groupMembers[1] + ",3." + groupMembers[2] + ",4." + groupMembers[3];
        }
    }
}
