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
    public partial class WorldView : Form
    {
        public WorldView()
        {

            //removing scrollbars
            this.HorizontalScroll.Maximum = 0;
            this.VerticalScroll.Maximum = 0;
            this.AutoScroll = false; //for now
            this.VerticalScroll.Visible = false;
            this.HorizontalScroll.Visible = false;
            this.AutoScroll = true; //and re-enable

            InitializeComponent();
            
            this.pictureBox1.Size = new Size(6527*2, 6400*2);


        }

        Point position = new Point(0,250);

        private void WorldMap_Load(object sender, EventArgs e)
        {
            this.AutoScrollPosition = new Point(0, 250);
       
        }


        //basic view movement over a 100x100 grid
        private void WorldMap_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyValue == 40)
            {
                position = new Point(position.X, position.Y + 100);
            }
            else if (e.KeyValue == 38)
            {
                position = new Point(position.X, position.Y - 100);
            }
            else if (e.KeyValue == 37)
            {
                position = new Point(position.X - 100, position.Y);
            }
            else if (e.KeyValue == 39)
            {
                position = new Point(position.X + 100, position.Y);
            }

            this.AutoScrollPosition = position;
        }
    }
}
