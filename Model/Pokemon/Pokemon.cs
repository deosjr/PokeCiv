using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCiv.Model.Pokemon
{
    class Pokemon
    {

        private int level;
        private Species species;

        public Pokemon(int level, Species species)
        {
            this.level = level;
            this.species = species;
        }

        public override string ToString()
        {
            return species.name + " lvl: " + level;
        }

    }
}
