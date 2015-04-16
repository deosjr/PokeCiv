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
            button1.Enabled = false;

            //TODO: check for out of bounds
            progressBar1.Maximum = Control.Player.Team[0].HP;
            progressBar1.Value = Control.Player.Team[0].CurrentHP;

            progressBar2.Maximum = Control.Player.Team[1].HP;
            progressBar2.Value = Control.Player.Team[1].CurrentHP;

            progressBar3.Maximum = Control.Player.Team[2].HP;
            progressBar3.Value = Control.Player.Team[2].CurrentHP;

            progressBar4.Maximum = Control.Player.Team[3].HP;
            progressBar4.Value = Control.Player.Team[3].CurrentHP;

            progressBar5.Maximum = Control.Player.Team[4].HP;
            progressBar5.Value = Control.Player.Team[4].CurrentHP;

            progressBar6.Maximum = Control.Player.Team[5].HP;
            progressBar6.Value = Control.Player.Team[5].CurrentHP;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            currently_selected_pokemon = ((Pokemon)team_listbox.SelectedItem);
            if (currently_selected_pokemon.CurrentHP < 1)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void sendOut_btn(object sender, EventArgs e)
        {
            switch2thispokemon = currently_selected_pokemon;
            currently_selected_pokemon = null;
            
            //tell the controller to continue its work
            Control.continuebattle(switch2thispokemon);
            this.Close();
            button1.Enabled = false;
        }

    }
}
