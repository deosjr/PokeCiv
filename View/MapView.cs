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
                    //als t geen leeg vakje is
                    if (item.tileType != "_") {
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
                    else
                    {
                        //wel de cursor verschuiven na een leeg vakje
                        current.X += gridSizePixels;
                    }
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
            if(e.KeyCode == Keys.Down)
            {
                pb_player.ImageLocation = "../../Data/Graphics/Tiles/player_DOWN.png";
                if (Control.playerMoveDown())
                {
                   backgroundLocation.Y -= gridSizePixels;
                   mapBackgroundCanvas.Location = backgroundLocation;
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                pb_player.ImageLocation = "../../Data/Graphics/Tiles/player_UP.png";
                if (Control.playerMoveUp())
                {
                    backgroundLocation.Y += gridSizePixels;
                    mapBackgroundCanvas.Location = backgroundLocation;
                }
            }
            else if (e.KeyCode == Keys.Left)
            {
                pb_player.ImageLocation = "../../Data/Graphics/Tiles/player_LEFT.png";
                if (Control.playerMoveLeft())
                {
                    backgroundLocation.X += gridSizePixels;
                    mapBackgroundCanvas.Location = backgroundLocation;
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                pb_player.ImageLocation = "../../Data/Graphics/Tiles/player_RIGHT.png";
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

            switch (item.tileType)
            {
                case "X":
                    tileImageSrc = "../../Data/Graphics/Tiles/block"+Mechanics.random.Next(1,4)+".png";
                    break;
                case "W":
                    tileImageSrc = "../../Data/Graphics/Tiles/gras.png";
                    break;
                case "U":
                    tileImageSrc = "../../Data/Graphics/Tiles/water.png";
                    break;
                case "B":
                    tileImageSrc = "../../Data/Graphics/Tiles/bush.png";
                    break;
                //case "_":
                   // tileImageSrc = "../../Data/Graphics/Tiles/lowgrass" + Mechanics.random.Next(1, 3) + ".png";
                   // break;
            }

            return tileImageSrc;
        }

        private void mapBackgroundCanvas_Click(object sender, EventArgs e)
        {
            Control.switchFromMapToPokeDex();
        }

    }
}