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


namespace PokeCiv
{
    class PokeCiv
    {
        [STAThread]
        static void Main(string[] args)
        {
           
            Random r = new Random();

            Pokemon p1 = PokemonFactory.getPokemon(50, "GENGAR");
            Pokemon p2 = PokemonFactory.getPokemon(40, r.Next(1, 650));


            Player player1 = new Player("P1");
            Player player2 = new Player("P2");
            player1.AddToTeam(p1);
            player2.AddToTeam(p2);

            Battle battle = new Battle(player1, player2);
            BattleView battleview = new BattleView(battle);
            battle.View = battleview;


            Thread battleThread = new Thread(battle.fight);
            battleThread.Start();

            Map.setCoordinates(player1, 1, 1);

            //Application.Run(battleview);       
            Application.Run(new MapRenderer());

            Console.ReadKey();
        }
    }
}
