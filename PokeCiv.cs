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
            Random r = new Random();
            Pokemon p1 = PokemonFactory.getPokemon(50, "ZAPDOS");
            Pokemon p2 = PokemonFactory.getPokemon(40, r.Next(1, 650));
         
            Player player1 = new Player("P1");
            Player player2 = new Player("P2");
            player1.AddToTeam(p1);
            player2.AddToTeam(p2);

            Controller c = new Controller(player1);
            Map m = new Map(c);
            m.setPlayerCoordinates(3, 3);
            c.Map = m;
            MapView mv = new MapView(c);
            c.mapView = mv;
            c.currentView = mv;
            c.runView();

            Battle battle = new Battle(c, player1, player2);
            BattleView battleview = new BattleView(battle);
            Thread battleThread = new Thread(battle.fight);
            battleThread.Start();
            c.Battle = battle;

           
           Console.ReadKey();

        }
    }
}
