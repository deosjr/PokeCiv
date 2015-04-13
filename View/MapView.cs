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
        public int gridSizePixels = 25;
        Point position = new Point(0, 0);

        public MapView(Controller c)
        {

            //removing scrollbars
            this.HorizontalScroll.Maximum = 0;
            this.VerticalScroll.Maximum = 0;
            //this.AutoScroll = false; //for now
            //this.VerticalScroll.Visible = false;
            //this.HorizontalScroll.Visible = false;
            this.AutoScroll = true; //and re-enable

            InitializeComponent();

            this.mapBackgroundCanvas.Size = new Size(5000, 5000);

            Control = c;
            grid = Control.GetGrid();
        }

        private void MapView_Load(object sender, EventArgs e)
        {
            UpdatePlayer(Control.GetGrid()[Control.Player.Y][Control.Player.X]);
            //this.AutoScrollPosition = new Point(0, 0);

            //set the canvas to the same size as the background
            this.mapBackgroundCanvas.Width = this.Width;
            this.mapBackgroundCanvas.Height = this.Width;

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
            pb_playerFloor.Location = new Point(playerX * gridSizePixels, playerY * gridSizePixels);

            //positioneer de scrollview
            position = new Point((playerX * gridSizePixels)- (this.Width/2), (playerY * gridSizePixels) - (this.Height));
            this.AutoScrollPosition = position;

            //set the correct img        
            pb_playerFloor.ImageLocation = getTileImage(tile);
            
            //draai de speler goed bij
            pb_player.ImageLocation = "../../Data/Graphics/Tiles/player_"+ facingSide +".png";

            //plak de speler op de vloer
            pb_playerFloor.Controls.Add(pb_player);
            pb_player.Location = new Point(0, 0);                 
        }

        private void MapView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 40)
            {
                facingSide = "DOWN";
                Control.playerMoveDown();   
            }
            else if (e.KeyValue == 38)
            {
                facingSide = "UP";
                Control.playerMoveUp();  
            }
            else if (e.KeyValue == 37)
            {
                facingSide = "LEFT";
                Control.playerMoveLeft();              
            }
            else if (e.KeyValue == 39)
            {
                facingSide = "RIGHT";
                Control.playerMoveRight();
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
    }
}