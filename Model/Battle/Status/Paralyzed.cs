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

        public new string statuscode = "PAR";

        public override bool preAttack(Battle battle, Pokemon pokemon) 
        {
            if (Mechanics.random.NextDouble() < 0.25)
            {
                battle.message(pokemon.Name + " is paralyzed! It can't move!");
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
