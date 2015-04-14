using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

using PokeCiv.View;
using PokeCiv.Model.Pokedata;
using PokeCiv.Model;
using PokeCiv.Model.Battle;
using PokeCiv.Model.World;
using PokeCiv.Controllers;

namespace PokeCiv
{
    class PokeCiv
    {
        [STAThread]
        static void Main(string[] args)
        {

            //Debug values
            //Random r = Mechanics.random;
            Pokemon p1 = PokemonFactory.getPokemon(20, "BEEDRILL");
            Player player1 = new Player("P1");
            player1.AddToTeam(p1);

            Controller c = new Controller(player1);
            Map m = new Map(c, "Field");
            m.setPlayerCoordinates(9, 7);
            c.Map = m;
            c.pokedexView = new PokedexView(c);
            // Bij het switchen van Map, haalt MapView n nieuwe map van Controller?
            // of maken we dan n nieuwe MapView aan? (in het laatste geval, new MapView(m) )
            MapView mv = new MapView(c);
            c.mapView = mv;
            c.currentView = mv;
            new Thread(c.runView).Start();

            // Debug: moves implemented
            for (int i = 1; i < 151; i++ )
            {
                Species species = PokemonFactory.getSpecies(i);
                int level = 0;
                var sorted = from entry in species.MovesLearnable orderby entry.Key ascending select entry;
                foreach (KeyValuePair<int, List<PokemonMove>> kv in sorted)
                {
                    level = kv.Key;
                    foreach(PokemonMove move in kv.Value)
                    {
                        if (!MoveFunctions.isImplemented(move.internalName))
                        {
                            goto End;
                        }
                    }
                }
            End:
                Console.WriteLine(species.Name + " implemented up until level " + level);
            }
       
           Console.ReadKey();

        }
    }
}
