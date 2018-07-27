using System;
using System.Collections.Generic;
using System.Linq;

namespace BojanPiskulic_WCDraw.WorldCupDraw
{
    public class WCDrawManager
    {
        List<NationalTeam> teams;
        Pot[] pots;
        Group[] groups;

        public WCDrawManager()
        {

        }

        public void GetNationalTeams(List<NationalTeam> teams)
        {
            // linq for sorting
            this.teams = teams.OrderBy(o => o.FifaRank).ToList();
        }

        public void setPots()
        {
            pots = new Pot[Constants.MAX_POTS];
            int i = 0;
            int temp_c = 0;            

            foreach(NationalTeam nt in teams)
            {                
                if (temp_c == Constants.MAX_TEAMS_IN_POT)
                {
                    i++;
                    temp_c = 0;
                }
                
                if(pots[i] == null)
                {
                    pots[i] = new Pot();
                }

                pots[i].AddTeam(nt);
                temp_c++;
            }
        }

        public Group[] setGroups()
        {
            groups = new Group[Constants.MAX_GROUPS];

            List<int> groupIndex = new List<int>();
            
            for(int i = 0; i < groups.Length; i++)
            {
                groups[i] = new Group();
                groupIndex.Add(i);
            }

            Random r = new Random();

            int index = r.Next(0, groupIndex.Count);

            int br = 0;

            Boolean flag = false;

            foreach (Pot p in pots)
            {
                foreach(NationalTeam nt in p.PotMembers)
                {
                    while (groups[index].AddTeam(nt) != true)
                    {
                        groupIndex.Remove(index);
                        index = r.Next(0, Constants.MAX_GROUPS);
                        br++;

                        if(br > 128)
                        {                            
                            flag = true;
                            break;
                        }
                    };
                }

                br = 0;
            }

            if(flag == true)
            {
                Group.ResetStartGroup();
                setGroups();
            }

            return groups;
        }

        public void Draw()
        {
            List<NationalTeam> nationalTeams = FileManipulation.ImportData();

            GetNationalTeams(nationalTeams);
            setPots();
            
            Group[] g = setGroups();
            
            FileManipulation.ExportData(g);

        }

        public void PrintPots()
        {
            for (int i = 0; i < pots.Length; i++)
            {
                pots[i].PrintTeams();
            }
        }

        public void PrintGroups()
        {
            for (int i = 0; i < groups.Length; i++)
            {
                if (groups[i] != null) groups[i].PrintTeams();
            }
        }
    }
}
