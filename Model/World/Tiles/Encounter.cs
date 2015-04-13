using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokeCiv.Model.Pokedata;

namespace PokeCiv.Model.World.Tiles
{
    class Encounter
    {

        public string speciesName;
        public int minlevel;
        public int maxlevel;
        public double p;

        public Encounter(string species, int minlevel, int maxlevel, double p)
        {
            this.speciesName = species;
            this.minlevel = minlevel;
            this.maxlevel = maxlevel;
            this.p = p;
        }

        public Pokemon getPokemon()
        {
            return PokemonFactory.getPokemon(Mechanics.random.Next(minlevel, maxlevel + 1), speciesName);
        }

    }
}
