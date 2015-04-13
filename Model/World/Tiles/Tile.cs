using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokeCiv.Model.World.Tiles.TileItems;
using PokeCiv.Controllers;

namespace PokeCiv.Model.World.Tiles
{
    public class Tile
    {
        public TileItem tileItem;
        public int X { get; set; }
        public int Y { get; set; }

        public Player Player { get; set; }
        public string tileType = "_"; //default

        public Tile() { }

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

        public void stepOn(Controller c)
        {
            if (tileItem != null)
            {
                tileItem.stepOn(c);
            }
        }

    }
}
