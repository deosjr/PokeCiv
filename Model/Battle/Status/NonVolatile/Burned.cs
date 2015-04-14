using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokeCiv.Model.Pokedata;

namespace PokeCiv.Model.Battle.Status.NonVolatile
{
    class Burned : NonVolatileCondition
    {

        public new string statuscode = "BRN";

        public override void postAttack(Battle battle, Pokemon pokemon)
        {
            int burnDamage = (int) Math.Ceiling(pokemon.HP / 8.0);
            pokemon.takeDamage(burnDamage);
            battle.message(pokemon.Name + " is hurt by its burn!");
        }

        public override string getInitMessage()
        {
            return " was burned!";
        }

    }
}
