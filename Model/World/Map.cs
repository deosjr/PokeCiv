﻿using System;
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

        // VERY UGLY right now, but will be prettier when mapgeneration gets done
        public void SetGrid()
        {
            string _ = "_";
            string w = "w";
            string x = "x";
            string u = "u";
            string b = "b";
            string[,] ascii = new string[,]{
                {x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,x,_,_,_,_,_},
                {x,_,_,_,_,x,x,_,_,_,_,x,_,b,_,_,w,w,_,b,_,_,_,_},
                {x,_,w,w,_,x,x,_,_,_,_,_,_,b,_,w,w,_,_,_,b,_,_,_},
                {x,_,w,w,_,_,_,_,_,u,u,u,_,b,_,_,_,_,_,_,_,b,_,_},
                {x,_,w,w,_,_,_,_,u,u,u,u,_,b,_,x,x,_,_,_,_,u,u,_},
                {x,_,_,_,_,_,_,_,u,u,u,_,_,b,_,x,x,_,_,_,_,u,u,u},
                {x,x,_,_,_,_,_,_,w,w,w,_,_,b,_,x,x,_,_,_,_,_,_,u},
                {x,x,_,_,_,b,b,b,w,w,w,_,_,_,_,x,x,_,_,_,_,_,_,u},
                {x,x,w,_,_,x,x,x,x,w,w,_,_,_,_,x,x,_,_,_,_,x,_,u},
                {x,w,w,w,_,x,x,w,_,_,w,_,_,_,_,_,_,_,_,_,_,x,_,u},
                {x,w,w,w,w,w,w,w,_,_,w,_,b,b,b,_,_,_,_,_,_,x,_,u},
                {x,_,w,w,_,w,w,w,_,_,_,_,_,b,_,_,_,_,_,_,_,x,_,u},
                {x,_,_,_,_,w,w,w,_,_,_,_,_,b,_,_,_,_,_,_,_,x,_,x},
                {x,x,_,_,_,_,_,_,_,_,_,_,_,u,u,_,_,_,_,_,_,x,_,u},
                {x,x,_,_,_,_,b,b,b,b,b,_,_,u,u,_,_,_,_,_,_,x,_,u},
                {x,_,_,_,_,x,x,_,_,_,_,_,_,_,_,_,_,_,_,_,_,u,u,u},
                {x,_,w,w,_,x,x,_,_,_,_,_,_,_,_,_,_,_,_,_,_,u,u,u},
                {x,_,w,w,x,x,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,u,u,u},
                {x,_,w,w,x,x,_,_,_,_,_,_,_,_,_,_,_,_,_,_,_,u,u,u},
                {x,_,_,_,_,_,_,_,_,_,_,_,x,_,_,_,_,_,_,_,_,u,u,_},
                {u,u,u,_,_,_,_,u,_,_,_,_,x,_,_,_,_,_,_,_,_,b,_,_},
                {_,u,u,u,_,_,u,u,_,_,_,_,_,_,_,_,_,_,_,_,_,b,_,_},
                {_,_,_,u,u,u,u,x,x,x,x,x,x,x,x,x,x,x,x,x,x,b,_,_}
            };

            Grid = new Tile[ascii.GetLength(0), ascii.GetLength(1)];

            // encounters = {0.45: ("PIDGEY", 2, 4), 0.3:("RATTATA",2,2), 0.2:("SENTRET",3,3), 0.05:("FURRET",6,6)}
            ArrayList testWildPokemon = new ArrayList();
            testWildPokemon.Add(new Encounter("KAKUNA", 20, 20, 1.0));

            for (int Y = 0; Y < ascii.GetLength(0); Y++)
            {
                for (int X = 0; X < ascii.GetLength(1); X++)
                {
                    Grid[Y,X] = new Tile();
                    switch (ascii[Y,X]) {
                        case "_":
                            break;
                        case "w":
                            Grid[Y,X].tileItem = new Grass(testWildPokemon, 0.1);
                            Grid[Y,X].tileType = "W";
                            break;
                        case "x":
                            Grid[Y,X].tileItem = new Block();
                            Grid[Y,X].tileType = "X";
                            break;
                        case "u":
                            Grid[Y,X].tileItem = new Water();
                            Grid[Y,X].tileType = "U";
                            break;
                        case "b":
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