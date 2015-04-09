using PokeCiv.Model;
using PokeCiv.Model.Battle;
using PokeCiv.Model.Pokedata;
using PokeCiv.Model.World;
using PokeCiv.Model.World.Tiles;
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

namespace PokeCiv.View
{
    public partial class MapRenderer : Iview
    {
        private Map map;
        private Tile[][] grid;

        public MapRenderer(Map map)
        {
            InitializeComponent();
            this.map = map;
            grid = map.GetGrid();
        }

        //merge the player with the correct floor tile, and draw it over the generated map.
        public void UpdatePlayer()
        {
            //TODO: hardcoded totdat ze makkelijk door sjoerd aan de MapRenderer gegeven worden
            int playerX = 3;
            int playerY = 3;

            //positioneer de vloer
            pb_playerFloor.Location = new Point(playerX * 50, playerY * 50);

            //TODO: load the correct tile from the grid
            //pb_playerFloor.ImageLocation = // DE GOEDE TILE!!

            //plak de speler op de vloer
            pb_playerFloor.Controls.Add(pb_player);
            pb_player.Location = new Point(0, 0);
        }

        private void MapRenderer_Load(object sender, EventArgs e)
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

        //TODO: remove this method
        private void test_btn_switch2Battle(object sender, EventArgs e)
        {
            //REMOVE THIS - TEMP BATTLE \/
            Pokemon p1 = PokemonFactory.getPokemon(50, "ZAPDOS");
            Pokemon p2 = PokemonFactory.getPokemon(40, "ZAPDOS");

            Player player1 = new Player("P1");
            Player player2 = new Player("P2");
            player1.AddToTeam(p1);
            player2.AddToTeam(p2);

            Battle battle = new Battle(player1, player2);
            //REMOVE THIS - TEMP BATTLE ^

            BattleView battleView = new BattleView(battle);
            battleView.showView();
        }

        //TODO: remove this method
        private void test_btn_show_Worldmap(object sender, EventArgs e)
        {
            WorldMap wm = new WorldMap();
            wm.showView();
        }


    }

}