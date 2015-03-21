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

            //lazy fetching of pkmns and setting of images
            Pokemon p1 = battle.getP1();
            Pokemon p2 = battle.getP2();

            this.backImageBattlePokemon.ImageLocation = "../../Data/Battlers/" + p1.species.id.ToString().PadLeft(3, '0') + "b.png";
            this.frontImageBattlePokemon.ImageLocation = "../../Data/Battlers/" + p2.species.id.ToString().PadLeft(3, '0') + ".png";

            this.backPokemonName.Text = p1.name;
            this.fontPokemonName.Text = p2.name;

            this.backPokemonLevel.Text = "lvl " +p1.level.ToString();
            this.frontPokemonLevel.Text = "lvl " + p2.level.ToString();

            this.label2.Text = p1.name + " do?";
        }

       

    }
}
