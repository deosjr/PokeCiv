using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokeCiv.Model.Pokedata;

namespace PokeCiv.Model.Battle
{
    class Battle
    {

        Player player1;
        Player player2;

        public Battle(Player p1, Player p2)
        {
            player1 = p1;
            player2 = p2;
        }

        public void fight()
        {
            Pokemon p1 = getFirstHealthy(player1);
            Pokemon p2 = getFirstHealthy(player2);

            if (p1 == null)
            {
                Console.WriteLine("You don't have any pokemon!");
                return;
            }

            setBattleReady();

            Console.WriteLine(player2.name + " wants to fight!");
            Console.WriteLine(player2.name + " sent out " + p2.species.name + "!");
            Console.WriteLine("Go, " + p1.species.name + "!");

            while (!(player1.BlackOut() || player2.BlackOut())) 
            {

            }
        }

        private Pokemon getFirstHealthy(Player player)
        {
            foreach(Pokemon p in player.team)
            {
                if (p.currentHP > 0)
                {
                    return p;
                }
            }
            return null;
        }

        private void setBattleReady()
        {
            foreach (Pokemon p in player1.team)
            {
                p.initForBattle();
            }
            foreach (Pokemon p in player2.team)
            {
                p.initForBattle();
            }
        }

    }
}
