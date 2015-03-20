using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokeCiv.Model.Pokedata
{
    public class Move
    {
        public PokemonMove move;
        public int currentPP;
        public int totalPP;

        public Move(PokemonMove move, int pp)
        {
            this.move = move;
            currentPP = totalPP = pp;
        }

    }
}
