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
    public partial class Combat : Form
    {

        public Combat(Battle battle)
        {
            InitializeComponent();
            var me = this;

            //lazy fetching of pkmns
            Pokemon p1 = battle.P1;
            Pokemon p2 = battle.P2;

            //Nesting all pictures inside each other for transparancy
 
            //add both floors to the background
            battleBack.Controls.Add(frontFloor);
            battleBack.Controls.Add(backFloor);

            //then add the pokemons to the floors
            frontFloor.Controls.Add(frontImageBattlePokemon);
            backFloor.Controls.Add(backImageBattlePokemon);

            //set the floors to transparent, the pokemons will inherrit this
            frontFloor.BackColor = Color.Transparent;
            backFloor.BackColor = Color.Transparent;

            //reset the startpoints of the pokemons (relative to the floors)
            frontImageBattlePokemon.Location = new Point(0, 0);
            backImageBattlePokemon.Location = new Point(0, 0);

            //Pokemon Images
            me.backImageBattlePokemon.ImageLocation = "../../Data/Battlers/" + p1.species.ID.ToString().PadLeft(3, '0') + "b.png";
            me.frontImageBattlePokemon.ImageLocation = "../../Data/Battlers/" + p2.species.ID.ToString().PadLeft(3, '0') + ".png";

            //backgrond Image
            me.battleBack.ImageLocation = "../../Data/Graphics/Battlebacks/battlebg" + battle.BattleType + ".png";

            //floors
            me.frontFloor.ImageLocation = "../../Data/Graphics/Battlebacks/enemybase" + battle.BattleType + ".png";
            me.backFloor.ImageLocation = "../../Data/Graphics/Battlebacks/playerbase" + battle.BattleType + ".png";

            //Pokemon names
            me.backPokemonName.Text = p1.Name;
            me.fontPokemonName.Text = p2.Name;

            //Pokemon Levels
            me.backPokemonLevel.Text = "lvl " + p1.Level.ToString();
            me.frontPokemonLevel.Text = "lvl " + p2.Level.ToString();

            me.label2.Text = p1.Name + " do?";

            //XPbar
            me.BackPokemonXPBar.Maximum = p1.NextXPLevelReq - p1.PreviousXPLevelReq;
            me.BackPokemonXPBar.Value = p1.CurrentXP - p1.PreviousXPLevelReq;

            //HPBars
            me.BackPokemonHPBar.Maximum = p1.HP;
            me.BackPokemonHPBar.Value = p1.CurrentHP;

            me.FrontPokemonHPBar.Maximum = p2.HP;
            me.FrontPokemonHPBar.Value = p2.CurrentHP;

            //Own Pokemon HP Label
            me.BackPokemonHPLabel.Text = p1.CurrentHP + "/" + p1.HP + "HP";

            //moves buttons
            if (p1.Moves[0] != null)
                me.MovesButton1.Text = p1.Moves[0].move.ToString();
            if (p1.Moves[1] != null)
                me.MovesButton2.Text = p1.Moves[1].move.ToString();
            if (p1.Moves[2] != null)
                me.MovesButton3.Text = p1.Moves[2].move.ToString();
            if (p1.Moves[3] != null)
                me.MovesButton4.Text = p1.Moves[3].move.ToString();

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frontFloor_Click(object sender, EventArgs e)
        {

        }
    }
}
