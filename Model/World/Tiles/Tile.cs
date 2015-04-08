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
        public string tileType = "_"; //default

        public Tile() { }
        public Tile(string itemID)
        {
            switch (itemID)
            {
                case "GRASS":
                    tileItem = new Grass();
                    tileType = "W";
                    break;
                case "BLOCK":
                    tileItem = new Block();
                    tileType = "X";
                    break;
                case "WATER":
                    tileItem = new Water();
                    tileType = "U";
                    break;
            }
        }

    }
}
