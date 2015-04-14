using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokeCiv.View.Pokedex
{
    public partial class PokedexStatsView : IView
    {
        public PokedexStatsView(string pokemonNr)
        {
            InitializeComponent();
            pictureBox1.ImageLocation = "../../Data/Graphics/Artwork/" + pokemonNr.PadLeft(3, '0') + ".jpg";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pokedex_back_toMap_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
