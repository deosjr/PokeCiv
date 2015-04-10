using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokeCiv.Model.World.Tiles.TileItems;

namespace PokeCiv.Model.World.Tiles
{
    public class Tile
    {
        TileItem tileItem;
        public int X { get; set; }
        public int Y { get; set; }

        public Player Player { get; set; }
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

        public bool blocks()
        {
            if (Player != null)
            {
                return true;
            }
            if (tileItem == null)
            {
                return false;
            }
            return tileItem.blocks;
        }

    }
}
