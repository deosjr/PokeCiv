using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCiv.Model.Pokemon
{
    class PokemonFactory
    {

        private static List<Species> pokemonData = new List<Species>();
        private static Dictionary<string, int> internalNames = new Dictionary<string, int>();

        public PokemonFactory()
        {
            initialize();
        }

        private void initialize() {
            string datapath = "../../Data/pokemon.txt";
            var lines = File.ReadAllLines(datapath);
            Dictionary<string, string> data = null;
            foreach (var line in lines)
            {
                if (line.StartsWith("["))
                {
                    if (data != null)
                    {
                        addSpecies(data);
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
            addSpecies(data);
            
        }

        private void addSpecies(Dictionary<string, string> data)
        {
            Species species = new Species(data);
            pokemonData.Add(species);
            internalNames.Add(data["InternalName"], species.id);
        }

        public Pokemon getPokemon(int level, int id)
        {
            Species species = pokemonData[id - 1];
            return new Pokemon(level, species);
        }

        public Pokemon getPokemon(int level, string name)
        {
            Species species = pokemonData[internalNames[name] - 1];
            return new Pokemon(level, species);
        }

    }
}
