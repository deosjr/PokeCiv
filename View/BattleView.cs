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
    public partial class BattleView : Form
    {

        private Battle battle;

        public BattleView(Battle battle)
        {
            InitializeComponent();
            this.battle = battle;
            drawOnce();
        }

        private void drawOnce()
        {
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

            me.actionTextLabel.Text = "what will " + p1.Name + " do?";

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


        //The Message cycle, updates the msg, and checks other stats (since a turn has passed)
        public void message(string msg)
        {
            var me = this;
            me.actionTextLabel.Text = msg;
            me.BackPokemonHPBar.Value = battle.P1.CurrentHP;

            me.FrontPokemonHPBar.Value = battle.P2.CurrentHP;


            me.BackPokemonXPBar.Maximum = battle.P1.NextXPLevelReq - battle.P1.PreviousXPLevelReq;
            me.BackPokemonXPBar.Value = battle.P1.CurrentXP - battle.P1.PreviousXPLevelReq;

            System.Threading.Thread.Sleep(750);
        }

        public PokemonMove selectMove()
        {
            return battle.P1.Moves[0].move;
        }

    }
}
