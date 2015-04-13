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
                pokemonList.Add(PokemonFactory.getPokemon(25, i));
            }
            
            PokemonListBox.DataSource = pokemonList;
            PokemonListBox.DisplayMember = "Name";
            PokemonListBox.ValueMember = "Name";
        }

        private void pokedexToMapButton_Click(object sender, EventArgs e)
        {
            Control.switchFromPokedexToMap();
        }
    }
}
