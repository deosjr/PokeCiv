using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokeCiv.Model.Pokedata;

namespace PokeCiv.Model.Battle.Status
{
    class Asleep : NonVolatileCondition
    {

        private int timer;
        public new string statuscode = "SLP";

        public Asleep()
        {
            timer = Mechanics.random.Next(1,4);
        }

        public override bool preAttack(Battle battle, Pokemon pokemon)
        {
            timer--;
            if (timer == 0)
            {
                pokemon.clearNonVolatileStatus();
                battle.message(pokemon.Name + " woke up!");
                return false;
            }
            battle.message(pokemon.Name + " is fast asleep!");
            return true;
        }

        public override string getInitMessage()
        {
            return " fell asleep!";
        }

    }
}
