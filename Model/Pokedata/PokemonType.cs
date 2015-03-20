using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCiv.Model.Pokedata
{
    public class PokemonType
    {

        private string name;
        public List<PokemonType> weaknesses = new List<PokemonType>();
        public List<PokemonType> resistances = new List<PokemonType>();
        public List<PokemonType> immunities = new List<PokemonType>();

        private string weaknessData;
        private string resistanceData;
        private string immunityData;

        public PokemonType(Dictionary<string, string> data)
        {
            name = data["Name"];
            data.TryGetValue("Weaknesses", out weaknessData);
            data.TryGetValue("Resistances", out resistanceData);
            data.TryGetValue("Immunities", out immunityData);
        }

        public void setTypes()
        {
            if (weaknessData != null) {
                foreach (string type in weaknessData.Split(','))
                {
                    weaknesses.Add(Types.getType(type));
                }
            }
            if (resistanceData != null)
            {
                foreach (string type in resistanceData.Split(','))
                {
                    resistances.Add(Types.getType(type));
                }
            }
            if (immunityData != null)
            {
                foreach (string type in immunityData.Split(','))
                {
                    immunities.Add(Types.getType(type));
                }
            }
        }

    }
}
