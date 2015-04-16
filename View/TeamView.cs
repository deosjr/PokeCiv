using PokeCiv.Controllers;
using PokeCiv.Model.Battle;
using PokeCiv.Model.Pokedata;
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
    public partial class TeamView : IView
    {
        public Controller Control { private get; set; }

        public TeamView(Controller c)
        {

            Control = c;
            InitializeComponent();
        }

        private void TeamView_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = Control.Player.Team;
            listBox1.DisplayMember = "Name";
        }

        public Pokemon switchPokemon(){

            //hoe ga je hier de goede aan hangen dan
            return Control.Player.Team[1];
        }
    }
}
