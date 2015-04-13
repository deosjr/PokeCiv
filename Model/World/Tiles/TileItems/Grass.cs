using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCiv.Model.World.Tiles.TileItems
{
    class Grass : TileItem
    {

        public override void stepOn()
        {
            if (Mechanics.random.NextDouble() < 0.15)
            {
                Console.WriteLine("A wild Pokemon appears!");
            }
        }

    }
}
