using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokeCiv.Controllers;
using PokeCiv.Model.Pokedata;

namespace PokeCiv.Model.World.Tiles.TileItems
{
    class Grass : TileItem
    {

        Player wildPokemon = new Player("WILD_POKEMON");

        public override void stepOn(Controller c)
        {
            if (Mechanics.random.NextDouble() < 0.15)
            {
                Console.WriteLine("A wild Pokemon appears!");
                Pokemon wild = PokemonFactory.getPokemon(40, Mechanics.random.Next(1, 650));
                wildPokemon.ClearTeam();
                wildPokemon.AddToTeam(wild);
                c.switchFromMapToBattle(wildPokemon);
            }
        }

    }
}
