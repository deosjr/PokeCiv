﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokeCiv.Model.Pokedata;

namespace PokeCiv.Model.Battle.Status
{
    class Poisoned : NonVolatileCondition
    {

        public override void postAttack(Pokemon pokemon)
        {
            int poisonDamage = (int)Math.Ceiling(pokemon.HP / 8.0);
            pokemon.takeDamage(poisonDamage);
            Console.WriteLine(pokemon.Name + " is hurt by poison!");
        }

        public override string getInitMessage()
        {
            return " was poisoned!";
        }

    }
}
