using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PokeCiv.Model.Pokedata;

namespace PokeCiv.Model.Battle
{
    class BattleMove
    {

        public Pokemon source;
        public Pokemon target;
        public PokemonMove move;
        public int speed;

        public BattleMove(Pokemon source, Pokemon target, PokemonMove move, int speed)
        {
            this.source = source;
            this.target = target;
            this.move = move;
            this.speed = speed;
        }

    }
}
