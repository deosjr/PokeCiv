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
            poke_mini1.ImageLocation = "../../Data/Graphics/Icons/" + Control.Player.Team[0].species.ID.ToString().PadLeft(3, '0') + ".png";

            progressBar2.Maximum = Control.Player.Team[1].HP;
            progressBar2.Value = Control.Player.Team[1].CurrentHP;
            poke_mini2.ImageLocation = "../../Data/Graphics/Icons/" + Control.Player.Team[1].species.ID.ToString().PadLeft(3, '0') + ".png";

            progressBar3.Maximum = Control.Player.Team[2].HP;
            progressBar3.Value = Control.Player.Team[2].CurrentHP;
            poke_mini3.ImageLocation = "../../Data/Graphics/Icons/" + Control.Player.Team[2].species.ID.ToString().PadLeft(3, '0') + ".png";

            progressBar4.Maximum = Control.Player.Team[3].HP;
            progressBar4.Value = Control.Player.Team[3].CurrentHP;
            poke_mini4.ImageLocation = "../../Data/Graphics/Icons/" + Control.Player.Team[3].species.ID.ToString().PadLeft(3, '0') + ".png";

            progressBar5.Maximum = Control.Player.Team[4].HP;
            progressBar5.Value = Control.Player.Team[4].CurrentHP;
            poke_mini5.ImageLocation = "../../Data/Graphics/Icons/" + Control.Player.Team[4].species.ID.ToString().PadLeft(3, '0') + ".png";

            progressBar6.Maximum = Control.Player.Team[5].HP;
            progressBar6.Value = Control.Player.Team[5].CurrentHP;
            poke_mini6.ImageLocation = "../../Data/Graphics/Icons/" + Control.Player.Team[5].species.ID.ToString().PadLeft(3, '0') + ".png";
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

    }
}
