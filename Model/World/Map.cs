using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokeCiv.Model.World.Tiles;
using PokeCiv.View;
using PokeCiv.Controllers;

namespace PokeCiv.Model.World
{
    public class Map
    {

        public Tile[][] Grid { get; private set; }
        public MapView View { private get; set; }
        public Controller Control { private get; set; }

        public Map(Controller control)
        {
            Control = control;
            SetGrid();
        }

        public void SetGrid()
        {
            Tile _ = new Tile();
            Tile w = new Tile("GRASS");
            Tile x = new Tile("BLOCK");
            Tile u = new Tile("WATER");
            Grid = new Tile[][]{
                new Tile[]{x,x,x,x,x,x,x,x,x,x,x,x},
                new Tile[]{x,_,_,_,_,x,x,_,_,_,_,x},
                new Tile[]{x,_,w,w,_,x,x,_,u,u,_,x},
                new Tile[]{x,_,w,w,_,_,_,_,u,u,_,x},
                new Tile[]{x,_,w,w,_,_,_,_,u,u,_,x},
                new Tile[]{x,_,_,_,_,_,_,_,u,u,_,x},
                new Tile[]{x,_,_,_,_,_,_,_,u,u,_,x},
                new Tile[]{x,_,_,_,_,_,_,_,u,u,_,x},
                new Tile[]{x,x,x,x,x,x,x,x,x,x,x,x}
            };
        }

        public void setPlayerCoordinates(int x, int y)
        {
            Grid[Control.Player.Y][Control.Player.X].Player = null;
            Control.Player.setCoordinates(x, y);
            Grid[y][x].Player = Control.Player;
        }

        public bool playerMove(int xdiff, int ydiff)
        {
            bool canMove = playerCanMove(Control.Player.X + xdiff, Control.Player.Y + ydiff);
            if (canMove)
            {
                setPlayerCoordinates(Control.Player.X + xdiff, Control.Player.Y + ydiff);
            }
            return canMove;
        }

        private bool playerCanMove(int x, int y)
        {
            return !Grid[y][x].blocks();
        }

    }
}