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
        private Pokemon switch2thispokemon;
        private Pokemon currently_selected_pokemon = null;

        public TeamView(Controller c)
        {

            Control = c;
            InitializeComponent();
        }

        private void TeamView_Load(object sender, EventArgs e)
        {
            team_listbox.DataSource = Control.Player.Team;
            team_listbox.DisplayMember = "Name";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            currently_selected_pokemon = ((Pokemon)team_listbox.SelectedItem);
        }

        private void sendOut_btn(object sender, EventArgs e)
        {
            switch2thispokemon = currently_selected_pokemon;
            currently_selected_pokemon = null;
            this.Close();
            //tell the controller to continue its work
            Control.continuebattle(switch2thispokemon);
        }

    }
}
