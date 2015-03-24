using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokeCiv.Model.Pokedata;

namespace PokeCiv.Model.Battle.Status
{
    class BadlyPoisoned : NonVolatileCondition
    {

        private int duration;

        public BadlyPoisoned()
        {
            duration = 1;
        }

        public override void postAttack(Battle battle, Pokemon pokemon)
        {
            int poisonDamage = (int)Math.Ceiling(pokemon.HP / 16.0);
            pokemon.takeDamage(duration * poisonDamage);
            duration++;
            battle.message(pokemon.Name + " is hurt by poison!");
        }

        public override string getInitMessage()
        {
            return " was poisoned!";
        }

    }
}