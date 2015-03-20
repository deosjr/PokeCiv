using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCiv.Model.Pokedata
{
   public class Types
    {

        private static Dictionary<string, int> internalNames = new Dictionary<string, int>();
        private static List<PokemonType> types = new List<PokemonType>();

        static Types()
        {
            loadTypes();
        }

        private static void loadTypes()
        {

            string datapath = "../../Data/types.txt";
            var lines = File.ReadAllLines(datapath);
            Dictionary<string, string> data = null;
            foreach (var line in lines)
            {
                if (line.StartsWith("["))
                {
                    if (data != null)
                    {
                        addType(data);
                    }
                    data = new Dictionary<string, string>();
                    data.Add("ID", line.Substring(1, line.Length - 2));
                }
                else
                {
                    var keyvalue = line.Split('=');
                    data.Add(keyvalue[0], keyvalue[1]);
                }
            }
            addType(data);
            foreach (PokemonType pt in types){
                pt.setTypes();
            }
        }

        private static void addType(Dictionary<string, string> data)
        {
            PokemonType type = new PokemonType(data);
            types.Add(type);
            internalNames.Add(data["InternalName"], Convert.ToInt32(data["ID"]));
        }

        public static PokemonType getType(string name) 
        {
            return types[internalNames[name]];
        }

        public static double effectiveness(PokemonType move, List<PokemonType> types) 
        {
            double temp = 1.0;
            foreach (PokemonType t in types)
            {
                if (t.immunities.Contains(move))
                {
                    return 0.0;
                }
                if (t.weaknesses.Contains(move))
                {
                    temp *= 2;
                }
                else if (t.resistances.Contains(move))
                {
                    temp *= 0.5;
                }
            }
            return temp;
        }

    }
}
