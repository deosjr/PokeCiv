using System;
using System.Collections;
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
    public partial class PokedexEvolutionView : IView
    {

        public ArrayList pokemon;

        public PokedexEvolutionView(string evolvestring, ArrayList pokenumbers)
        {
            MessageBox.Show(evolvestring);
            pokemon = pokenumbers;
            InitializeComponent();
        }

        private void btn_close_evolutionView_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void PokedexEvolutionView_Load(object sender, EventArgs e)
        {
            stage1.ImageLocation = "../../Data/Graphics/Artwork/" + pokemon[0].ToString().PadLeft(3, '0') + ".jpg";
            stage2.ImageLocation = "../../Data/Graphics/Artwork/" + pokemon[1].ToString().PadLeft(3, '0') + ".jpg";
            stage3.ImageLocation = "../../Data/Graphics/Artwork/" + pokemon[2].ToString().PadLeft(3, '0') + ".jpg";
        }
    }
}
