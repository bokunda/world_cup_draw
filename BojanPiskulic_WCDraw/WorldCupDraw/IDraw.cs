using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BojanPiskulic_WCDraw.WorldCupDraw
{
    public interface IDraw
    {
        Boolean AddTeam(NationalTeam team);

        void PrintTeams();
    }
}
