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

        public Asleep()
        {
            timer = CombatMechanics.random.Next(1,4);
        }

        public override bool preAttack(Pokemon pokemon)
        {
            timer--;
            if (timer == 0)
            {
                pokemon.clearNonVolatileStatus();
                Console.WriteLine(pokemon.Name + " woke up!");
                return false;
            }
            Console.WriteLine(pokemon.Name + " is fast asleep!");
            return true;
        }

        public override string getInitMessage()
        {
            return " fell asleep!";
        }

    }
}
