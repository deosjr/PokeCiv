using PokeCiv.Model.World;
using PokeCiv.Model.World.Tiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokeCiv.View
{
    public partial class MapRenderer : Form
    {
        public MapRenderer()
        {
            InitializeComponent();
        }

        private void MapRenderer_Load(object sender, EventArgs e)
        {
            Map map = new Map();
            Tile[][] grid = map.GetGrid();

            Console.WriteLine("Loaded Map:");

            Point current = new Point(-50, -50);

            //maak een array van het aantal tiles in het grid
            PictureBox[] pbAr = new PictureBox[100];

            foreach (var row in grid)
            {              
                Console.WriteLine();
                current.Y += 50;
                                                             
                foreach (var item in row)
                {
                    Console.Write(item.tileType);

                    //genereer 1 nieuwe picturebox
                    PictureBox pb = new PictureBox();
                    //stel hem in op de nieuwe locatie
                    current.X += 50;
                    pb.Location = current;
                    //verhoog zijn id

                    if (item.tileType == "X")
                    {
                        pb.ImageLocation = "../../Data/Graphics/Tiles/block.png";
                    }
                    else if (item.tileType == "W")
                    {
                        pb.ImageLocation = "../../Data/Graphics/Tiles/gras.png";
                    }

                    pictureBox1.Controls.Add(pb);                      
                }
            }

           
        }

         private void setTiles(Tile item){
                if (item.tileType == "X")
                    {
                        pictureBox1.ImageLocation = "../../Data/Graphics/Tiles/block.png";
                    }
                    else if (item.tileType == "W")
                    {
                        pictureBox1.ImageLocation = "../../Data/Graphics/Tiles/gras.png";
                    }

                    
            }
    }
}
