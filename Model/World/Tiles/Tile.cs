using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokeCiv.Model.World.Tiles.TileItems;

namespace PokeCiv.Model.World.Tiles
{
    class Tile
    {

        TileItem tileItem;
        string backgroundID;

        public Tile() { }
        public Tile(string itemID)
        {
            switch (itemID)
            {
                case "GRASS":
                    tileItem = new Grass();
                    break;
                case "BLOCK":
                    tileItem = new Block();
                    break;
            }
        }

    }
}
