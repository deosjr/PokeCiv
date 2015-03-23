using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PokeCiv.Model.Pokedata
{
    class Experience
    {

        private static Dictionary<int, List<Tuple<int, int>>> lookupTable = new Dictionary<int, List<Tuple<int, int>>>();

        static Experience()
        {
            loadXPTable();
        }

        private static void loadXPTable()
        {
            string datapath = "../../Data/xp_lookup_table.txt";
            var lines = File.ReadAllLines(datapath);
            int i = 0;
            foreach (var line in lines)
            {
                i++;
                if (i < 3)
                {
                    continue;
                }
                List<Tuple<int, int>> tableEntry = new List<Tuple<int, int>>();
                if (i < 102)
                {
                    var row = new List<int>(from x in Regex.Split(line, @"\s+") select Convert.ToInt32(x));
                    tableEntry.Add(new Tuple<int, int>(row.ElementAt(0), row.ElementAt(7)));
                    tableEntry.Add(new Tuple<int, int>(row.ElementAt(1), row.ElementAt(8)));
                    tableEntry.Add(new Tuple<int, int>(row.ElementAt(2), row.ElementAt(9)));
                    tableEntry.Add(new Tuple<int, int>(row.ElementAt(3), row.ElementAt(10)));
                    tableEntry.Add(new Tuple<int, int>(row.ElementAt(4), row.ElementAt(11)));
                    tableEntry.Add(new Tuple<int, int>(row.ElementAt(5), row.ElementAt(12)));
                }
                else
                {
                    var row = new List<int>(from x in Regex.Split(line, @"\s+").Take(6) select Convert.ToInt32(x));
                    tableEntry.Add(new Tuple<int, int>(row.ElementAt(0), -1));
                    tableEntry.Add(new Tuple<int, int>(row.ElementAt(1), -1));
                    tableEntry.Add(new Tuple<int, int>(row.ElementAt(2), -1));
                    tableEntry.Add(new Tuple<int, int>(row.ElementAt(3), -1));
                    tableEntry.Add(new Tuple<int, int>(row.ElementAt(4), -1));
                    tableEntry.Add(new Tuple<int, int>(row.ElementAt(5), -1));
                }
                lookupTable.Add(i-2, tableEntry);
            }
        }

        public static void gainXP(Pokemon p, Pokemon fainted)
        {
            if (p.level == 100)
            {
                return;
            }

            double a = 1.5; // 1 if fainted was wild
            int b = fainted.species.baseXP;
            int L = fainted.level;
            //L_p = self.level
            // ignoring p,f,e
            double s = 1.0; // for multiple combatants
            double t = 1.0; // 1.5 if not original owner

            int xp = (int) ((a * t * b * L) / (7.0 * s));
            p.currentXP += xp;

            Console.WriteLine(p.name + " gained " + xp + " XP!");

        }

        public static Tuple<int, int> lookupXP(Pokemon p)
        {
            int rate = 0;   // Erratic
            switch (p.species.growthRate)
            {
                case "Fast":
                    rate = 1;
                    break;
                case "Medium":
                    rate = 2;
                    break;
                case "Parabolic":
                    rate = 3;
                    break;
                case "Slow":
                    rate = 4;
                    break;
                case "Fluctuating":
                    rate = 5;
                    break;
            }
            List<Tuple<int,int>> XPinfoRow;
            lookupTable.TryGetValue(p.level, out XPinfoRow);
            return XPinfoRow.ElementAt(rate);
        }

    }
}
