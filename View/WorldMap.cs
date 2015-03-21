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
    public partial class WorldMap : Form
    {
        public WorldMap()
        {

            InitializeComponent();
            
            this.pictureBox1.Size = new Size(6527*2, 6400*2);
        }

        Point position = new Point(0,250);

        private void WorldMap_Load(object sender, EventArgs e)
        {
            this.AutoScrollPosition = new Point(0, 250);
        }



        private void WorldMap_KeyDown(object sender, KeyEventArgs e)
        {
            position = new Point(position.X, position.Y + 100);
            this.AutoScrollPosition = position;
        }
    }
}
