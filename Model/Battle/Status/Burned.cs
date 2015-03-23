using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokeCiv.Model.Pokedata;

namespace PokeCiv.Model.Battle.Status
{
    class Burned : NonVolatileCondition
    {

        public override void postAttack(Pokemon pokemon)
        {
            int burnDamage = (int) Math.Ceiling(pokemon.HP / 8.0);
            pokemon.takeDamage(burnDamage);
            Console.WriteLine(pokemon.Name + " is hurt by its burn!");
        }

        public override string getInitMessage()
        {
            return " was burned!";
        }

    }
}
