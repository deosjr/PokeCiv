using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokeCiv.Model.World.Tiles;
using PokeCiv.View;

namespace PokeCiv.Model.World
{
    public class Map
    {

        Tile[][] grid;
        public MapRenderer View { private get; set; }

        public Map()
        {
            GetGrid();
        }

        public Tile[][] GetGrid()
        {
            Tile _ = new Tile();    
            Tile w = new Tile("GRASS");    
            Tile x = new Tile("BLOCK");
            Tile u = new Tile("WATER"); 
            grid = new Tile[][]{
                new Tile[]{x,x,x,x,x,x,x,x,x,x,x,x},
                new Tile[]{x,_,_,_,_,x,x,_,_,_,_,x},
                new Tile[]{x,_,w,w,_,x,x,_,u,u,_,x},
                new Tile[]{x,_,w,w,_,_,_,_,u,u,_,x},
                new Tile[]{x,_,_,_,_,_,_,_,u,u,_,x},
                new Tile[]{x,x,x,x,x,x,x,x,x,x,x,x}
            };

            return grid;
        }

        public void setCoordinates(Player player, int x, int y)
        {
            player.setCoordinates(x, y);
            grid[y][x].Player = player;
        }

    }
}
