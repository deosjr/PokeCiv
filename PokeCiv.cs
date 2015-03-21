using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using PokeCiv.View;

using PokeCiv.Model.Pokedata;
using PokeCiv.Model;
using PokeCiv.Model.Battle;


namespace PokeCiv
{
    class PokeCiv
    {
        [STAThread]
        static void Main(string[] args)
        {
           
            Random r = new Random();

            Pokemon p1 = PokemonFactory.getPokemon(50, r.Next(1, 650));
            Pokemon p2 = PokemonFactory.getPokemon(45, r.Next(1, 650));


            Player player1 = new Player("P1");
            Player player2 = new Player("P2");
            player1.AddToTeam(p1);
            player2.AddToTeam(p2);

            Battle battle = new Battle(player1, player2);
            battle.fight();
            

           // Application.Run(new WorldMap());
            Application.Run(new Combat(battle));

            Console.ReadLine();
        }
    }
}
