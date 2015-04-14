using PokeCiv.Controllers;
using PokeCiv.Model;
using PokeCiv.Model.Pokedata;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace PokeCiv.View
{
    public partial class PokedexView : IView
    {
        public Controller Control { private get; set; }
        public string infoString = "";
        public PokedexView()
        {
            InitializeComponent();
        }

        public PokedexView(Controller c)
        {
            InitializeComponent();
            Control = c;
        }

        private void PokedexView_Load(object sender, EventArgs e)
        {
            ArrayList pokemonList = new ArrayList();
            for (int i = 1; i < 650; i++)
            {
                pokemonList.Add(PokemonFactory.getSpecies(i));
            }
            
            PokemonListBox.DataSource = pokemonList;
            PokemonListBox.DisplayMember = "Name";
        }

        private void PokemonListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set image
            pokedexPokemonImage.ImageLocation = "../../Data/Graphics/Animations/" + ((Species)PokemonListBox.SelectedItem).ID.ToString().PadLeft(3, '0') + ".gif";
            //set info text
            pokedex_info.Text = ((Species)PokemonListBox.SelectedItem).Pokedex;
             //set kind
            pokemon_kind_lbl.Text = "The " + ((Species)PokemonListBox.SelectedItem).Kind + " Pokemon";

            //set height n weight
            pokedex_height_lbl.Text = ((Species)PokemonListBox.SelectedItem).Height / 10 + "m";
            pokedex_weight_lbl.Text = ((Species)PokemonListBox.SelectedItem).Weight + "kg";

            //set types
            var typesArray = ((Species)PokemonListBox.SelectedItem).Types.ToArray();
            type1.ImageLocation = "../../Data/Graphics/Types/" + typesArray[0].name + ".png";
            //Set a 2th type if avaiable
            if (typesArray.Length > 1)
            {
                type2.ImageLocation = "../../Data/Graphics/Types/" + typesArray[1].name + ".png";
            }
            else
            {
                type2.ImageLocation = "";
            }

            //bouw een nieuwe infostring
                infoString = "";
                var evolutionsArray = ((Species)PokemonListBox.SelectedItem).Evolutions.ToArray();
                if (evolutionsArray.Length > 0)
                {
                    infoString += "Evolves into: " + evolutionsArray[0].name;
                    infoString += System.Environment.NewLine;
                    
                    infoString += "By";
                    int result;
                    bool isNumeric = Int32.TryParse(evolutionsArray[0].info, out result);
                    if (isNumeric) { infoString += " reaching level"; }
                    infoString += " : " + evolutionsArray[0].info;
                    infoString += System.Environment.NewLine;
                }
                




        }

        private void pokedex_back_toMap_btn_Click(object sender, EventArgs e)
        {
            Control.switchFromPokedexToMap(); 
        }

        private void pokedex_info_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(infoString);
        }

    }
}
