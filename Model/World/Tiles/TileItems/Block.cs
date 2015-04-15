using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCiv.Model.World.Tiles.TileItems
{
    class Block : TileItem
    {

        public Block(){
            blocks = true;
            imageSrc = "../../Data/Graphics/Tiles/block" + Mechanics.random.Next(1, 4) + ".png";
        }
        
    }
}
