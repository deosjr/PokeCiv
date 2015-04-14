using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokeCiv.Model.Pokedata;

namespace PokeCiv.Model.Battle.Status.Volatile
{
    class Recharge : VolatileCondition
    {

        public override bool preAttack(Battle battle, Pokemon pokemon)
        {
            battle.message(pokemon.Name + " is recharging!");
            pokemon.removeVolatileStatus(this);
            return true;
        }

    }
}
