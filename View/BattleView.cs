﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PokeCiv.Controllers;
using PokeCiv.Model.Battle;
using PokeCiv.Model.Pokedata;
using PokeCiv.Model.World;

namespace PokeCiv.View
{
    public partial class BattleView : IView
    {

        public bool waitForInput = true;
        public int currentSelectedMove = 0;
        public Controller Control { private get; set; }

        private Battle battle;

        public BattleView(Battle battle)
        {
            InitializeComponent();
            this.battle = battle;
            drawOnce();
            groupBox_moves.Hide();
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
            me.backImageBattlePokemon.ImageLocation = "../../Data/Graphics/Animations/" + p1.species.ID.ToString().PadLeft(3, '0') + "b.gif";
            me.frontImageBattlePokemon.ImageLocation = "../../Data/Graphics/Animations/" + p2.species.ID.ToString().PadLeft(3, '0') + ".gif";

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
            {
                me.MovesButton1.Text = p1.Moves[0].move.ToString();
                me.labelPP_move1.Text = "PP " + p1.Moves[0].currentPP.ToString() + "/" + p1.Moves[0].totalPP.ToString();
            }
            if (p1.Moves[1] != null)
            {
                me.MovesButton2.Text = p1.Moves[1].move.ToString();
                me.labelPP_move2.Text = "PP " + p1.Moves[1].currentPP.ToString() + "/" + p1.Moves[1].totalPP.ToString();
            }
            if (p1.Moves[2] != null)
            {
                me.MovesButton3.Text = p1.Moves[2].move.ToString();
                me.labelPP_move3.Text = "PP " + p1.Moves[2].currentPP.ToString() + "/" + p1.Moves[2].totalPP.ToString();
            }
            if (p1.Moves[3] != null)
            {
                me.MovesButton4.Text = p1.Moves[3].move.ToString();
                me.labelPP_move4.Text = "PP " + p1.Moves[3].currentPP.ToString() + "/" + p1.Moves[3].totalPP.ToString();
            }
        }


        //The Message cycle, updates the msg, and checks other stats (since a turn has passed)
        public override void message(string msg)
        {
 
            if (actionTextLabel.InvokeRequired)
            {
                actionTextLabel.Invoke(new MethodInvoker(delegate { actionTextLabel.Text = msg; }));
            }

            if (BackPokemonHPBar.InvokeRequired)
            {
                BackPokemonHPBar.Invoke(new MethodInvoker(delegate { BackPokemonHPBar.Value = battle.P1.CurrentHP; }));
            }

            if (FrontPokemonHPBar.InvokeRequired)
            {
                FrontPokemonHPBar.Invoke(new MethodInvoker(delegate { FrontPokemonHPBar.Value = battle.P2.CurrentHP; }));
            }

            if (BackPokemonXPBar.InvokeRequired)
            {
                BackPokemonXPBar.Invoke(new MethodInvoker(delegate { BackPokemonXPBar.Maximum = battle.P1.NextXPLevelReq - battle.P1.PreviousXPLevelReq; }));
                BackPokemonXPBar.Invoke(new MethodInvoker(delegate { BackPokemonXPBar.Value = battle.P1.CurrentXP - battle.P1.PreviousXPLevelReq; }));
            }

            if (battle.P1.Moves[0] != null && labelPP_move1.InvokeRequired)
            {
                labelPP_move1.Invoke(new MethodInvoker(delegate { labelPP_move1.Text = "PP " + battle.P1.Moves[0].currentPP.ToString() + "/" + battle.P1.Moves[0].totalPP.ToString(); }));
            }

            if (battle.P1.Moves[1] != null && labelPP_move2.InvokeRequired)
            {
                labelPP_move2.Invoke(new MethodInvoker(delegate { labelPP_move2.Text = "PP " + battle.P1.Moves[1].currentPP.ToString() + "/" + battle.P1.Moves[1].totalPP.ToString(); }));
            }

            if (battle.P1.Moves[2] != null && labelPP_move3.InvokeRequired)
            {
                labelPP_move3.Invoke(new MethodInvoker(delegate { labelPP_move3.Text = "PP " + battle.P1.Moves[2].currentPP.ToString() + "/" + battle.P1.Moves[2].totalPP.ToString(); }));
            }

            if (battle.P1.Moves[3] != null && labelPP_move4.InvokeRequired)
            {
                labelPP_move4.Invoke(new MethodInvoker(delegate { labelPP_move4.Text = "PP " + battle.P1.Moves[3].currentPP.ToString() + "/" + battle.P1.Moves[3].totalPP.ToString(); }));
            }

            if (BackPokemonHPLabel.InvokeRequired)
            {
                BackPokemonHPLabel.Invoke(new MethodInvoker(delegate { BackPokemonHPLabel.Text = battle.P1.CurrentHP + "/" + battle.P1.HP + "HP"; }));
            }

            //TODO: 
            //lvl update
            //pokemon name
            //alle mf-ing images bij een pokemon swap

            while (waitForInput)
            {
                //have the cpu run around drooling
                //Must sleep the thead to prevent 100% cpu load on this thread
                System.Threading.Thread.Sleep(10);              
            }
            waitForInput = true;
        }

        public int selectMove()
        {
            return currentSelectedMove;
        }

        public Pokemon switchPokemon()
        {
            //weten welke je mag selecteren
            throw new NotImplementedException();
        }

        //"next"  aka "A" op de gameboy
        private void BattleView_MouseClick(object sender, MouseEventArgs e)
        {
            waitForInput = false;
        }


        //Buttons that select moves
        private void MovesButton1_Click(object sender, EventArgs e)
        {
            currentSelectedMove = 0;
            resetbuttonColors();
            MovesButton1.BackColor = Color.DarkCyan;
            waitForInput = false;
            groupBox_moves.Hide();
        }

        private void MovesButton2_Click(object sender, EventArgs e)
        {
            currentSelectedMove = 1;
            resetbuttonColors();
            MovesButton2.BackColor = Color.DarkCyan;
            waitForInput = false;
            groupBox_moves.Hide();
        }

        private void MovesButton3_Click(object sender, EventArgs e)
        {
            currentSelectedMove = 2;
            resetbuttonColors();
            MovesButton3.BackColor = Color.DarkCyan;
            waitForInput = false;
            groupBox_moves.Hide();
        }

        private void MovesButton4_Click(object sender, EventArgs e)
        {
            currentSelectedMove = 3;
            resetbuttonColors();
            MovesButton4.BackColor = Color.DarkCyan;
            waitForInput = false;
            groupBox_moves.Hide();
        }

       public void resetbuttonColors(){
 
			 MovesButton1.BackColor = Color.PaleGoldenrod;
             MovesButton2.BackColor = Color.PaleGoldenrod;
             MovesButton3.BackColor = Color.PaleGoldenrod;
             MovesButton4.BackColor = Color.PaleGoldenrod;
        }

       private void battle_fight(object sender, EventArgs e)
       {
           groupBox_moves.Show();
       }

    }
}
