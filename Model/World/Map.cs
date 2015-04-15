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
            //SetGrid();
        }

        public void GridFromASCII(string[] ascii, Dictionary<Char, TileItem> lookup)
        {

            Grid = new Tile[ascii.GetLength(0), ascii[0].Length];

            for (int Y = 0; Y < ascii.GetLength(0); Y++)
            {
                for (int X = 0; X < ascii[0].Length; X++)
                {
                    Grid[Y, X] = new Tile();
                    TileItem item = null;
                    lookup.TryGetValue(ascii[Y].ElementAt(X), out item);
                    Grid[Y, X].tileItem = item;
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