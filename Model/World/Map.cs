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

        // VERY UGLY right now, but will be prettier when mapgeneration gets done
        public void SetGrid()
        {
            string _ = "_";
            string w = "w";
            string x = "x";
            string u = "u";
            string[][] ascii = new string[][]{
                new string[]{x,x,x,x,x,x,x,x,x,x,x,x},
                new string[]{x,_,_,_,_,x,x,_,_,_,_,x},
                new string[]{x,_,w,w,_,x,x,_,u,u,_,x},
                new string[]{x,_,w,w,_,_,_,_,u,u,_,x},
                new string[]{x,_,w,w,_,_,_,_,u,u,_,x},
                new string[]{x,_,_,_,_,_,_,_,u,u,_,x},
                new string[]{x,_,_,_,u,u,u,u,u,u,_,x},
                new string[]{x,_,_,_,_,_,_,_,u,u,_,x},
                new string[]{x,x,x,x,x,x,x,x,x,x,x,x}
            };

            //TODO: have the [i] in tale (9 & 12) now calculated dynamicly by .lenght() stuff
            Grid = new Tile[9][];

            for (int Y = 0; Y < 9; Y++)
            {
                Grid[Y] = new Tile[12];
                for (int X = 0; X < 12; X++)
                {
                    switch (ascii[Y][X]) {
                        case "_":
                            Grid[Y][X] = new Tile();
                            break;
                        case "w":
                            Grid[Y][X] = new Tile("GRASS");
                            break;
                        case "x":
                            Grid[Y][X] = new Tile("BLOCK");
                            break;
                        case "u":
                            Grid[Y][X] = new Tile("WATER");
                            break;
                    }
                }
            }
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
            // TODO: do we check x,y < 0 and > gridsize? 
            // or just block it with boundaries always as in Pokemon?
            //A: Always make visible obstacles, like in the game, makes for much clearer maps.
            //no blocks usaly is a path to the next zone (e.a. safari zone)
            return !Grid[y][x].blocks();
        }

    }
}