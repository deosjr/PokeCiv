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
            this.pictureBox1.Size = new Size(10920, 7312);
        }

        private void WorldMap_Load(object sender, EventArgs e)
        {

        }
    }
}
