using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using PokeCiv.Model.Pokemon;

namespace PokeCiv
{
    class PokeCiv
    {
        static void Main(string[] args)
        {

            Pokemon p = PokemonFactory.getPokemon(10, 4);
            Debug.WriteLine(p);
        }
    }
}
