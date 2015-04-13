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
            Pokemon p1 = PokemonFactory.getPokemon(50, "ZAPDOS");
            Player player1 = new Player("P1");
            player1.AddToTeam(p1);

            Controller c = new Controller(player1);
            Map m = new Map(c);
            m.setPlayerCoordinates(3, 3);
            c.Map = m;
            // Bij het switchen van Map, haalt MapView n nieuwe map van Controller?
            // of maken we dan n nieuwe MapView aan? (in het laatste geval, new MapView(m) )
            MapView mv = new MapView(c);
            c.mapView = mv;
            c.currentView = mv;
            new Thread(c.runView).Start();
           
           Console.ReadKey();

        }
    }
}
