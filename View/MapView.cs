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
        public string facingSide = "DOWN";
        public int gridSizePixels = 40;
        public Point backgroundLocation = new Point(0, 0);

        public MapView(Controller c)
        {
         
            InitializeComponent();
            Control = c;
            grid = Control.GetGrid();
        }

        private void MapView_Load(object sender, EventArgs e)
        {
            UpdatePlayer(Control.GetGrid()[Control.Player.Y][Control.Player.X]);

            //set the canvas to the same size as the background
            this.mapBackgroundCanvas.Size = new Size(5000, 5000);

            Point current = new Point(-gridSizePixels, 0);

            foreach (var row in grid)
            {
                foreach (var item in row)
                {
                    //genereer 1 nieuwe picturebox
                    PictureBox pb = new PictureBox();
                    pb.Size = new Size(gridSizePixels, gridSizePixels);
                    //stel hem in op de nieuwe locatie
                    current.X += gridSizePixels;
                    pb.Location = current;
                    //set the correct img
                    pb.ImageLocation = getTileImage(item);
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                    //plak hem op de achtergrond
                    mapBackgroundCanvas.Controls.Add(pb);
                }
                //1 rij omlaag, en links beginnen
                current.Y += gridSizePixels;
                current.X = -gridSizePixels;
            }
        
        }

        //merge the player with the correct floor tile, and draw it over the generated map.
        public void UpdatePlayer(Tile tile)
        {
            int playerX = Control.Player.X;
            int playerY = Control.Player.Y;

            //stel ze in op dezelfde schaal
            pb_player.Width = gridSizePixels;
            pb_player.Height = gridSizePixels;
            pb_player.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_playerFloor.Width = gridSizePixels;
            pb_playerFloor.Height = gridSizePixels;
            pb_playerFloor.SizeMode = PictureBoxSizeMode.StretchImage;

            //positioneer de vloer
            //TODO: 9x7 is het absolute midden, dus moet ook aangepast kunnen worden
            pb_playerFloor.Location = new Point(9 * gridSizePixels, 7 * gridSizePixels);
            
            //set the correct img        
            pb_playerFloor.ImageLocation = getTileImage(tile);
            
            
            
            //plak de speler op de vloer
            pb_playerFloor.Controls.Add(pb_player);
            pb_player.Location = new Point(0, 0);                 
        }

        private void MapView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 40)
            {
                facingSide = "DOWN";
                pb_player.ImageLocation = "../../Data/Graphics/Tiles/player_" + facingSide + ".png";
                if (Control.playerMoveDown())
                {
                    //backgroundLocation.Y -= gridSizePixels;
                   // mapBackgroundCanvas.Location = backgroundLocation;

                    for (int iter = 0; iter < 8; iter++)
                    {
                        mapBackgroundCanvas.Location = new Point(mapBackgroundCanvas.Left, mapBackgroundCanvas.Top - 5);
                    }
                    backgroundLocation.Y -= gridSizePixels;


                }



            }
            else if (e.KeyValue == 38)
            {
                facingSide = "UP";
                pb_player.ImageLocation = "../../Data/Graphics/Tiles/player_" + facingSide + ".png";
                if (Control.playerMoveUp())
                {
                   
                    for (int iter = 0; iter < 10; iter++)
                    {
                        mapBackgroundCanvas.Location = new Point(mapBackgroundCanvas.Left, mapBackgroundCanvas.Top + 4);
                    }

                    backgroundLocation.Y += gridSizePixels;
                }
            }
            else if (e.KeyValue == 37)
            {
                facingSide = "LEFT";
                pb_player.ImageLocation = "../../Data/Graphics/Tiles/player_" + facingSide + ".png";
                if (Control.playerMoveLeft())
                {
                    backgroundLocation.X += gridSizePixels;
                    mapBackgroundCanvas.Location = backgroundLocation;
                }
            }
            else if (e.KeyValue == 39)
            {
                facingSide = "RIGHT";
                pb_player.ImageLocation = "../../Data/Graphics/Tiles/player_" + facingSide + ".png";
                if (Control.playerMoveRight())
                {
                    backgroundLocation.X -= gridSizePixels;
                    mapBackgroundCanvas.Location = backgroundLocation;
                }
            }

        }

        private string getTileImage(Tile item)
        {
            var tileImageSrc = "";

            if (item.tileType == "X")
            {
                 tileImageSrc = "../../Data/Graphics/Tiles/block.png";
            }
            else if (item.tileType == "W")
            {
                 tileImageSrc = "../../Data/Graphics/Tiles/gras.png";
            }
            else if (item.tileType == "U")
            {
                 tileImageSrc = "../../Data/Graphics/Tiles/water.png";
            }

            return tileImageSrc;
        }

        private void mapBackgroundCanvas_Click(object sender, EventArgs e)
        {
            Control.switchFromMapToPokeDex();
        }

    }
}