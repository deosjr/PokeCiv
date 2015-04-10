using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using PokeCiv.Model;
using PokeCiv.Model.Battle;
using PokeCiv.Model.Pokedata;
using PokeCiv.Model.World;
using PokeCiv.Model.World.Tiles;
using PokeCiv.Controllers;

namespace PokeCiv.View
{
    public partial class MapView : IView
    {
        public Controller Control { private get; set; }
        Tile[][] grid;

        public MapView(Controller c)
        {
            InitializeComponent();
            Control = c;
            grid = Control.GetGrid();
        }

        //merge the player with the correct floor tile, and draw it over the generated map.
        public override void UpdatePlayer()
        {
            int playerX = Control.Player.X;
            int playerY = Control.Player.Y;

            //positioneer de vloer
            pb_playerFloor.Location = new Point(playerX * 50, playerY * 50);

            //TODO: load the correct tile from the grid
            //pb_playerFloor.ImageLocation = // DE GOEDE TILE!!

            //plak de speler op de vloer
            pb_playerFloor.Controls.Add(pb_player);
            pb_player.Location = new Point(0, 0);
        }

        private void MapView_Load(object sender, EventArgs e)
        {
            UpdatePlayer();

            //set the canvas to the same size as the background
            this.mapBackgroundCanvas.Width = this.Width;
            this.mapBackgroundCanvas.Height = this.Width;

            Point current = new Point(-50, 0);

            foreach (var row in grid)
            {

                foreach (var item in row)
                {

                    //genereer 1 nieuwe picturebox
                    PictureBox pb = new PictureBox();
                    pb.Size = new Size(50, 50);

                    //stel hem in op de nieuwe locatie
                    current.X += 50;
                    pb.Location = current;

                    //kijken welk plaatje het moet worden (kan later beter)
                    if (item.tileType == "X")
                    {
                        pb.ImageLocation = "../../Data/Graphics/Tiles/block.png";
                    }
                    else if (item.tileType == "W")
                    {
                        pb.ImageLocation = "../../Data/Graphics/Tiles/gras.png";
                    }
                    else if (item.tileType == "U")
                    {
                        pb.ImageLocation = "../../Data/Graphics/Tiles/water.png";
                    }

                    //plak hem op de achtergrond
                    mapBackgroundCanvas.Controls.Add(pb);
                }

                //1 rij omlaag, en links beginnen
                current.Y += 50;
                current.X = -50;
            }

            

        }


        private void MapView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 40)
            {
                Console.WriteLine("UP");
                Control.playerMoveUp();
            }
            else if (e.KeyValue == 38)
            {
                Console.WriteLine("DOWN");
                Control.playerMoveDown();
            }
            else if (e.KeyValue == 37)
            {
                Console.WriteLine("LEFT");
                Control.playerMoveLeft();
            }
            else if (e.KeyValue == 39)
            {
                Console.WriteLine("RIGHT");
                Control.playerMoveRight();
            }
        }
    }
}