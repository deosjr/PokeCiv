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

            //lazy fetching of pkmns and setting of images
            Pokemon p1 = battle.getP1();
            Pokemon p2 = battle.getP2();
            

            //Pokemon Images
            me.backImageBattlePokemon.ImageLocation = "../../Data/Battlers/" + p1.species.id.ToString().PadLeft(3, '0') + "b.png";
            me.frontImageBattlePokemon.ImageLocation = "../../Data/Battlers/" + p2.species.id.ToString().PadLeft(3, '0') + ".png";

            //Pokemon names
            me.backPokemonName.Text = p1.name;
            me.fontPokemonName.Text = p2.name;

            //Pokemon Levels
            me.backPokemonLevel.Text = "lvl " + p1.level.ToString();
            me.frontPokemonLevel.Text = "lvl " + p2.level.ToString();

            me.label2.Text = p1.name + " do?";

            //XPbar
            me.BackPokemonXPBar.Maximum = p1.nextXP;
            me.BackPokemonXPBar.Value = p1.XP;

            //HPBars
            me.BackPokemonHPBar.Maximum = p1.HP;
            me.BackPokemonHPBar.Value = p1.currentHP;

            me.FrontPokemonHPBar.Maximum = p2.HP;
            me.FrontPokemonHPBar.Value = p2.currentHP;

            //Own Pokemon HP Label
            me.BackPokemonHPLabel.Text = p1.currentHP + "/" + p1.HP;

            



        }
    }
}
