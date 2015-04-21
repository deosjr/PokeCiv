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
    public partial class PokedexEvolutionView : IView
    {
        public PokedexEvolutionView(string evolvestring)
        {
            MessageBox.Show(evolvestring);
            InitializeComponent();
        }

        private void btn_close_evolutionView_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }
    }
}
