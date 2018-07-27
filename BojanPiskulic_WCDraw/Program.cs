using System;
using System.Collections.Generic;
using BojanPiskulic_WCDraw.WorldCupDraw;

namespace BojanPiskulic_WCDraw
{
    class Program
    {
        static void Main(string[] args)
        {
            WCDrawManager wcd = new WCDrawManager();
            wcd.Draw();
        }
    }
}
