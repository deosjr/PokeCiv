﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokeCiv.Model.Pokedata;

namespace PokeCiv.Model.Battle.Status.NonVolatile
{
    class Frozen : NonVolatileCondition
    {

        public new string statuscode = "FRZ";

        public override bool preAttack(Battle battle, Pokemon pokemon)
        {
            if (Mechanics.random.NextDouble() < 0.2)
            {
                pokemon.clearNonVolatileStatus();
                battle.message(pokemon.Name + " thaws!");
                return false;
            }
            battle.message(pokemon.Name + " is frozen solid!");
            return true;
        }

        public override string getInitMessage()
        {
            return " is frozen solid!";
        }

    }
}
