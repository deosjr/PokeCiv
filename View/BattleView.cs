using System;
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
using System.Collections;

namespace PokeCiv.View
{
    public partial class BattleView : IView
    {

        public bool waitForInput = true;
        public int currentSelectedMove = 0;
        public Controller Control { private get; set; }

        private Battle battle;
        public Pokemon ready2Switch;

        public BattleView(Battle battle)
        {
            InitializeComponent();
            this.battle = battle;

            //vul het teamscherm met je pokemons
            listBox1.DataSource = battle.player1.Team;
            listBox1.DisplayMember = "Name";

            drawOnce();

            //hide interface items that are unused for now
            groupBox_moves.Hide();
            select_pkmn_panel.Hide();
        }

        private void drawOnce()
        {
            //lazy fetching of pkmns
            Pokemon p1 = battle.P1;
            Pokemon p2 = battle.P2;

            //Nesting all pictures inside each other for transparancy
 
            //add both floors to the background         
            if (battleBack.InvokeRequired)
            {
                battleBack.Invoke(new MethodInvoker(delegate { battleBack.Controls.Add(frontFloor); }));
                battleBack.Invoke(new MethodInvoker(delegate { battleBack.Controls.Add(backFloor); }));
            }
            else
            {
                battleBack.Controls.Add(frontFloor);
                battleBack.Controls.Add(backFloor);
            }

            //then add the pokemons to the floors
            if (battleBack.InvokeRequired)
            {
                battleBack.Invoke(new MethodInvoker(delegate { frontFloor.Controls.Add(frontImageBattlePokemon); }));
                battleBack.Invoke(new MethodInvoker(delegate { backFloor.Controls.Add(backImageBattlePokemon); }));
            }
            else
            {
                frontFloor.Controls.Add(frontImageBattlePokemon);
                backFloor.Controls.Add(backImageBattlePokemon);
            }

            //set the floors to transparent, the pokemons will inherrit this
            if (frontFloor.InvokeRequired || backFloor.InvokeRequired)
            {
                frontFloor.Invoke(new MethodInvoker(delegate { frontFloor.BackColor = Color.Transparent; }));
                backFloor.Invoke(new MethodInvoker(delegate { backFloor.BackColor = Color.Transparent; }));
            }
            else
            {
                frontFloor.BackColor = Color.Transparent;
                backFloor.BackColor = Color.Transparent;
            }

            //reset the startpoints of the pokemons (relative to the floors)
            if (frontFloor.InvokeRequired || backFloor.InvokeRequired)
            {
                frontImageBattlePokemon.Invoke(new MethodInvoker(delegate { frontImageBattlePokemon.Location = new Point(0, 0); }));
                backImageBattlePokemon.Invoke(new MethodInvoker(delegate { backImageBattlePokemon.Location = new Point(0, 0); }));
            }
            else
            {
                frontImageBattlePokemon.Location = new Point(0, 0);
                backImageBattlePokemon.Location = new Point(0, 0);
            }

            //Pokemon Images           
            if (backImageBattlePokemon.InvokeRequired)
            {
                backImageBattlePokemon.Invoke(new MethodInvoker(delegate { backImageBattlePokemon.ImageLocation = "../../Data/Graphics/Animations/" + p1.species.ID.ToString().PadLeft(3, '0') + "b.gif"; }));
                frontImageBattlePokemon.Invoke(new MethodInvoker(delegate { frontImageBattlePokemon.ImageLocation = "../../Data/Graphics/Animations/" + p2.species.ID.ToString().PadLeft(3, '0') + ".gif"; }));          
            }
            else
            {
                backImageBattlePokemon.ImageLocation = "../../Data/Graphics/Animations/" + p1.species.ID.ToString().PadLeft(3, '0') + "b.gif";
                frontImageBattlePokemon.ImageLocation = "../../Data/Graphics/Animations/" + p2.species.ID.ToString().PadLeft(3, '0') + ".gif";
            }

            //backgrond Image
            if (battleBack.InvokeRequired)
            {
                battleBack.Invoke(new MethodInvoker(delegate { battleBack.ImageLocation = "../../Data/Graphics/Battlebacks/battlebg" + battle.BattleType + ".png"; }));
            }
            else
            {
                battleBack.ImageLocation = "../../Data/Graphics/Battlebacks/battlebg" + battle.BattleType + ".png";
            }
            //floors
            //frontFloor.ImageLocation = "../../Data/Graphics/Battlebacks/enemybase" + battle.BattleType + ".png";
            //backFloor.ImageLocation = "../../Data/Graphics/Battlebacks/playerbase" + battle.BattleType + ".png";

            //Pokemon names
            if (backPokemonName.InvokeRequired || fontPokemonName.InvokeRequired)
            {
                backPokemonName.Invoke(new MethodInvoker(delegate { backPokemonName.Text = p1.Name; }));
                fontPokemonName.Invoke(new MethodInvoker(delegate { fontPokemonName.Text = p2.Name; }));
            
            }
            else
            {
                backPokemonName.Text = p1.Name;
                fontPokemonName.Text = p2.Name;
            }
            

            //Pokemon Levels
            //backPokemonLevel.Text = "lvl " + p1.Level.ToString();
            //frontPokemonLevel.Text = "lvl " + p2.Level.ToString();

            if (actionTextLabel.InvokeRequired)
            {
                frontImageBattlePokemon.Invoke(new MethodInvoker(delegate { actionTextLabel.Text = "what will " + p1.Name + " do?"; }));
            }else{
                actionTextLabel.Text = "what will " + p1.Name + " do?";
            }
            
            //XPbar
            //BackPokemonXPBar.Maximum = p1.NextXPLevelReq - p1.PreviousXPLevelReq;
            //BackPokemonXPBar.Value = p1.CurrentXP - p1.PreviousXPLevelReq;

            //HPBars
            //BackPokemonHPBar.Maximum = p1.HP;
            //BackPokemonHPBar.Value = p1.CurrentHP;

            //FrontPokemonHPBar.Maximum = p2.HP;
            //FrontPokemonHPBar.Value = p2.CurrentHP;

            //Own Pokemon HP Label
            if (BackPokemonHPLabel.InvokeRequired)
            {
                BackPokemonHPLabel.Invoke(new MethodInvoker(delegate { BackPokemonHPLabel.Text = p1.CurrentHP + "/" + p1.HP + "HP"; }));
            }
            else
            {
                BackPokemonHPLabel.Text = p1.CurrentHP + "/" + p1.HP + "HP";
            }

            //moves buttons
            #region 4 move buttons
            
            if (MovesButton1.InvokeRequired){
                if (p1.Moves[0] != null)
                {
                    MovesButton1.Invoke(new MethodInvoker(delegate { MovesButton1.Text = p1.Moves[0].move.ToString(); }));
                    labelPP_move1.Invoke(new MethodInvoker(delegate { labelPP_move1.Text = "PP " + p1.Moves[0].currentPP.ToString() + "/" + p1.Moves[0].totalPP.ToString(); }));
                }
             }
            else
            {
                if (p1.Moves[0] != null)
                {
                    MovesButton1.Text = p1.Moves[0].move.ToString();
                    labelPP_move1.Text = "PP " + p1.Moves[0].currentPP.ToString() + "/" + p1.Moves[0].totalPP.ToString();
                }

            }
            if (MovesButton2.InvokeRequired)
            {
                if (p1.Moves[1] != null)
                {
                MovesButton2.Invoke(new MethodInvoker(delegate { MovesButton2.Text = p1.Moves[1].move.ToString(); }));
                labelPP_move2.Invoke(new MethodInvoker(delegate { labelPP_move2.Text = "PP " + p1.Moves[1].currentPP.ToString() + "/" + p1.Moves[1].totalPP.ToString(); }));
                }
            }
            else
            {
                if (p1.Moves[1] != null)
                {
                    MovesButton2.Text = p1.Moves[1].move.ToString();
                    labelPP_move2.Text = "PP " + p1.Moves[1].currentPP.ToString() + "/" + p1.Moves[1].totalPP.ToString();
                }

            }
            if (MovesButton3.InvokeRequired)
            {
                if (p1.Moves[2] != null)
                {
                    MovesButton3.Invoke(new MethodInvoker(delegate { MovesButton3.Text = p1.Moves[2].move.ToString(); }));
                    labelPP_move3.Invoke(new MethodInvoker(delegate { labelPP_move3.Text = "PP " + p1.Moves[2].currentPP.ToString() + "/" + p1.Moves[2].totalPP.ToString(); }));
                }
            }
            else
            {
                if (p1.Moves[2] != null)
                {
                    MovesButton3.Text = p1.Moves[2].move.ToString();
                    labelPP_move3.Text = "PP " + p1.Moves[2].currentPP.ToString() + "/" + p1.Moves[2].totalPP.ToString();
                }

            }
            if (MovesButton4.InvokeRequired)
            {
                if (p1.Moves[3] != null)
                {
                    MovesButton4.Invoke(new MethodInvoker(delegate { MovesButton4.Text = p1.Moves[3].move.ToString(); }));
                    labelPP_move4.Invoke(new MethodInvoker(delegate { labelPP_move4.Text = "PP " + p1.Moves[3].currentPP.ToString() + "/" + p1.Moves[3].totalPP.ToString(); }));
                }
            }
            else
            {
                if (p1.Moves[3] != null)
                {
                    MovesButton4.Text = p1.Moves[3].move.ToString();
                    labelPP_move4.Text = "PP " + p1.Moves[3].currentPP.ToString() + "/" + p1.Moves[3].totalPP.ToString();
                }

            }

            #endregion
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
            //open het panel om de variable "ready2Switch" te setten.
            if (select_pkmn_panel.InvokeRequired)
            {
                select_pkmn_panel.Invoke(new MethodInvoker(delegate { select_pkmn_panel.Show(); }));            
            }

            //TODO: misklikken chrased de boel hier! later fixen
            while (waitForInput)
            {
                //have the cpu run around drooling
                //Must sleep the thead to prevent 100% cpu load on this thread
                System.Threading.Thread.Sleep(10);
            }
            waitForInput = true;
            drawOnce();

            //TODO: dit hierneerzetten is een hotfix voor een race conditie 
            backImageBattlePokemon.ImageLocation = "../../Data/Graphics/Animations/" + ready2Switch.species.ID.ToString().PadLeft(3, '0') + "b.gif";

       
            return ready2Switch;
        }

        //"next" aka "A" op de gameboy
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

        }

        private void MovesButton2_Click(object sender, EventArgs e)
        {
            currentSelectedMove = 1;
            resetbuttonColors();
            MovesButton2.BackColor = Color.DarkCyan;
            waitForInput = false;

        }

        private void MovesButton3_Click(object sender, EventArgs e)
        {
            currentSelectedMove = 2;
            resetbuttonColors();
            MovesButton3.BackColor = Color.DarkCyan;
            waitForInput = false;

        }

        private void MovesButton4_Click(object sender, EventArgs e)
        {
            currentSelectedMove = 3;
            resetbuttonColors();
            MovesButton4.BackColor = Color.DarkCyan;
            waitForInput = false;

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

       private void list_select_pokemon_SelectedIndexChanged(object sender, EventArgs e)
       {
           ready2Switch = ((Pokemon)listBox1.SelectedItem);
       }

       private void hide_select_pokemon_panel(object sender, EventArgs e)
       {
           select_pkmn_panel.Hide();
       }

    }
}
