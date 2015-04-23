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
        Tile[,] grid;
        public int gridSizePixels = 40;
        public Point backgroundLocation = new Point(0, 0);

        public MapView(Controller c)
        {
         
            InitializeComponent();
            Control = c;
            grid = Control.GetGrid();

            //hide het menu, en focus op de map
            start_menu_panel.Hide();
            this.Focus();
        }

        private void MapView_Load(object sender, EventArgs e)
        {
            UpdatePlayer(Control.GetGrid()[Control.Player.Y, Control.Player.X]);
            
            //set the canvas to grid size
            this.mapBackgroundCanvas.Size = new Size(grid.GetLength(0) * gridSizePixels, grid.GetLength(1) * gridSizePixels);
            Point current = new Point(0, -gridSizePixels);

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Tile item = grid[i, j];
                    //als t geen leeg vakje is
                    if (item.tileItem != null) {
                        //genereer 1 nieuwe picturebox
                        PictureBox pb = new PictureBox();
                        pb.Size = new Size(gridSizePixels, gridSizePixels);                                            
                        //stel hem in op de nieuwe locatie
                        pb.Location = current;
                        //verschuif de cursor
                        current.X += gridSizePixels;                       
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
            //TODO: dit doorgeven bij t laden
            pb_playerFloor.Location = new Point(7 * gridSizePixels, 5 * gridSizePixels);
            
            //set the correct img        
            pb_playerFloor.ImageLocation = getTileImage(tile);
                                
            //plak de speler op de vloer
            pb_playerFloor.Controls.Add(pb_player);
            pb_player.Location = new Point(0, 0);                 
        }

        private void MapView_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private string getTileImage(Tile tile)
        {
            if (tile.tileItem == null)
            {
                return "";
            }
            return tile.tileItem.imageSrc();
        }

        private void MapView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                    start_menu_panel.Show();
                    start_menu_panel.Focus();                  
            }

            if (e.KeyCode == Keys.Down)
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

        private void close_menu_button(object sender, EventArgs e)
        {
            start_menu_panel.Hide();
            this.Focus();
        }

        private void startmenu_pokedex_btn(object sender, EventArgs e)
        {
            Control.switchFromMapToPokeDex();
        }

        public override void message(string msg)
        {
            Console.WriteLine(msg);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TeamView tv = new TeamView(Control);
            tv.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Trainercard tc = new Trainercard();
            tc.ShowDialog();
        }

    }
}