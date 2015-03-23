using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokeCiv.Model.Pokedata;

namespace PokeCiv.Model.Battle.Status
{
    class Frozen : NonVolatileCondition
    {

        public override bool preAttack(Pokemon pokemon)
        {
            if (CombatMechanics.random.NextDouble() < 0.2)
            {
                pokemon.clearNonVolatileStatus();
                Console.WriteLine(pokemon.Name + " thaws!");
                return false;
            }
            Console.WriteLine(pokemon.Name + " is frozen solid!");
            return true;
        }

        public override string getInitMessage()
        {
            return " is frozen solid!";
        }

    }
}
