using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokeCiv.Controllers;

namespace PokeCiv.Model.World.Tiles.TileItems
{
    public abstract class TileItem
    {

        public bool blocks = false;

        public string imgsrc;
        public int options = 0;

        public string imageSrc()
        {
            if (options == 0)
            {
                return imgsrc + ".png";
            }
            return  imgsrc + Mechanics.random.Next(1, options+1) + ".png";
        }

        public virtual void stepOn(Controller c) { }

    }
}
