using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCiv.Model.Pokemon
{
    class Move
    {

        public int id;
        public string name;
        private string functioncode;
        private int power;
        private PokemonType type;
        private string category;

        public Move(string[] data)
        {
            id = Convert.ToInt32(data[0]);
            name = data[2];
            functioncode = data[3];
            power = Convert.ToInt32(data[4]);
            type = Types.getType(data[5]);
            category = data[6];
        }

        public override string ToString()
        {
            return name;
        }

    }
}
