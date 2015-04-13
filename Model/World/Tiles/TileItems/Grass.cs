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

        public override void stepOn(Controller c)
        {
            if (Mechanics.random.NextDouble() < 0.15)
            {
                Console.WriteLine("A wild Pokemon appears!");
                Pokemon p2 = PokemonFactory.getPokemon(40, Mechanics.random.Next(1, 650));
                Player player2 = new Player("P2");
                player2.AddToTeam(p2);
                c.switchFromMapToBattle(player2);
            }
        }

    }
}
