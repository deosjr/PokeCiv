﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCiv.Model.World.Tiles.TileItems
{
    class Water : TileItem
    {

        public Water()
        {
            blocks = true;
            imageSrc = "../../Data/Graphics/Tiles/water.png";
        }

    }
}
