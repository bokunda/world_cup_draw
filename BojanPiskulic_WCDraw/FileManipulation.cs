using System;
using System.Collections.Generic;
using System.IO;
using BojanPiskulic_WCDraw.WorldCupDraw;

namespace BojanPiskulic_WCDraw
{
    public static class FileManipulation
    {
        private static readonly String inputFileName = "ulaz.csv";
        private static readonly String outputFileName = "izlaz.csv";

        public static List<NationalTeam> ImportData()
        {

            if(File.Exists(inputFileName) == true)
            {
                try
                {
                    StreamReader reader = new StreamReader(inputFileName);

                    List<NationalTeam> teams = new List<NationalTeam>();

                    while (!reader.EndOfStream)
                    {
                        String line = reader.ReadLine();
                                                
                        String[] words = line.Split(',');
                        NationalTeam nt = new NationalTeam(words[0], words[1], Int32.Parse(words[2]));

                        teams.Add(nt);
                    }

                    reader.Close();

                    return teams;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return null;
        }

        public static Boolean ExportData(Group[] data)
        {
            try
            {
                String s = "";

                foreach(Group d in data)
                {
                    s += d.ToString();
                    s += "\n";
                }

                File.WriteAllText(outputFileName, s);                

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;
        }
    }

}
