using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BojanPiskulic_WCDraw.WorldCupDraw
{
    public class NationalTeam
    {
        private String name;
        private String region;

        private int fifaRank;

        private int pot = -1;
        private char group = ' ';

        public NationalTeam(String name, String region, int fifaRank)
        {
            this.name = name;
            this.region = region;
            this.fifaRank = fifaRank;
        }

        public String Name
        {
            get => name;
            set => name = value;
        }

        public String Region
        {
            get => region;
            set => region = value;
        }

        public int FifaRank
        {
            get => fifaRank;
            set => fifaRank = value;
        }

        public int Pot
        {
            get => pot;
            set => pot = value;
        }

        public char Group
        {
            get => group;
            set => group = value;
        }

        public override String ToString()
        {
            return name;
        }
    }
}
