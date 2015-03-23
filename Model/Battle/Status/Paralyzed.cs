using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokeCiv.Model.Pokedata;

namespace PokeCiv.Model.Battle.Status
{
    class Paralyzed : NonVolatileCondition
    {

        public override bool preAttack(Pokemon pokemon) 
        {
            if (CombatMechanics.random.NextDouble() < 0.25)
            {
                Console.WriteLine(pokemon.Name + " is paralyzed! It can't move!");
                return true;
            }
            return false;
        }

        public override string getInitMessage()
        {
            return " was paralyzed!";
        }

    }
}
