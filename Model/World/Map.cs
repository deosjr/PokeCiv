using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

using PokeCiv.Model.World.Tiles;
using PokeCiv.View;
using PokeCiv.Controllers;
using PokeCiv.Model.World.Tiles.TileItems;


namespace PokeCiv.Model.World
{
    public class Map
    {

        public Tile[,] Grid { get; private set; }
        public MapView View { private get; set; }
        public Controller Control { private get; set; }
        public string mapType;

        public Map(Controller control, string type)
        {
            Control = control;
            mapType = type;
            SetGrid();
        }

        public void SetGrid()
        {
            string[] ascii = new string[]{
                "xxxxxxxxxxxxxxxxxxx     ",
                "x    xx    x b  ww b    ",
                "x ww xx      b ww   b   ",
                "x ww     uuu b       b  ",
                "x ww    uuuu b xx    uu ",
                "x       uuu  b xx    uuu",
                "xx      www  b xx      u",
                "xx   bbbwww    xx      u",
                "xxw  xxxxww    xx    x u",
                "xwww xxw  w          x u",
                "xwwwwwww  w bbb      x u",
                "x ww www     b       x u",
                "x    www     b       x x",
                "xx           uu      x u",
                "xx    bbbbb  uu      x u",
                "x    xx              uuu",
                "x ww xx              uuu",
                "x wwxx               uuu",
                "x wwxx               uuu",
                "x           x        uu ",
                "uuu    u    x        b  ",
                " uuu  uu             b  ",
                "   uuuuxxxxxxxxxxxxxxb  "
            };

            Grid = new Tile[ascii.GetLength(0), ascii[0].Length];

            // encounters = {0.45: ("PIDGEY", 2, 4), 0.3:("RATTATA",2,2), 0.2:("SENTRET",3,3), 0.05:("FURRET",6,6)}
            ArrayList testWildPokemon = new ArrayList();
            testWildPokemon.Add(new Encounter("KAKUNA", 20, 20, 1.0));

            for (int Y = 0; Y < ascii.GetLength(0); Y++)
            {
                for (int X = 0; X < ascii[0].Length; X++)
                {
                    Grid[Y,X] = new Tile();
                    switch (ascii[Y].ElementAt(X)) {
                        case ' ':
                            break;
                        case 'w':
                            Grid[Y,X].tileItem = new Grass(testWildPokemon, 0.1);
                            Grid[Y,X].tileType = "W";
                            break;
                        case 'x':
                            Grid[Y,X].tileItem = new Block();
                            Grid[Y,X].tileType = "X";
                            break;
                        case 'u':
                            Grid[Y,X].tileItem = new Water();
                            Grid[Y,X].tileType = "U";
                            break;
                        case 'b':
                            Grid[Y,X].tileItem = new Block();
                            Grid[Y, X].tileItem.imageSrc = "../../Data/Graphics/Tiles/bush.png";
                            Grid[Y,X].tileType = "B";
                            break;
                    }
                }
            }
        }

        public void setPlayerCoordinates(int x, int y)
        {
            Grid[Control.Player.Y, Control.Player.X].Player = null;
            Control.Player.setCoordinates(x, y);
            Grid[y, x].Player = Control.Player;
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
            return !Grid[y, x].blocks();
        }

    }
}