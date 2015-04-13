using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokeCiv.Controllers;

namespace PokeCiv.Model.World.Tiles.TileItems
{
    abstract class TileItem
    {

        public bool blocks = false;

        public virtual void stepOn(Controller c) { }

    }
}
