using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using PokeCiv.Model.Pokedata;
using PokeCiv.Model;
using PokeCiv.Model.Battle;

namespace PokeCiv
{
    class PokeCiv
    {
        static void Main(string[] args)
        {

            Pokemon p1 = PokemonFactory.getPokemon(10, "CHARMANDER");
            Pokemon p2 = PokemonFactory.getPokemon(10, "SQUIRTLE");
            Player player1 = new Player("P1");
            Player player2 = new Player("P2");
            player1.AddToTeam(p1);
            player2.AddToTeam(p2);

            Battle battle = new Battle(player1, player2);
            battle.fight();
            Console.ReadLine();
        }
    }
}
