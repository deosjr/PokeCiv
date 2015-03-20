using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCiv.Model.Pokedata
{
    class PokemonMove
    {

        public int id;
        public string name;
        public string functioncode;
        public int power;
        public PokemonType type;
        public string category;
        public int accuracy;
        public int PP;
        public int addEffectChance;

        public PokemonMove(string[] data)
        {
            id = Convert.ToInt32(data[0]);
            name = data[2];
            functioncode = data[3];
            power = Convert.ToInt32(data[4]);
            type = Types.getType(data[5]);
            category = data[6];
            accuracy = Convert.ToInt32(data[7]);
            PP = Convert.ToInt32(data[8]);
            addEffectChance = Convert.ToInt32(data[9]);
        }

        public override string ToString()
        {
            return name;
        }

    }
}
