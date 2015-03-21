using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokeCiv.Model.Pokedata;

namespace PokeCiv.Model.Battle
{
    public class Battle
    {

        Player player1;
        Player player2;
        Pokemon p1;
        Pokemon p2;

        string type;

        public Pokemon getP1()
        {
            return p1;
        }

        public Pokemon getP2()
        {
            return p2;
        }

        public Battle(Player p1, Player p2)
        {
            player1 = p1;
            player2 = p2;
            type = "IndoorA"; // For now
        }

        public void fight()
        {
            p1 = getFirstHealthy(player1);
            p2 = getFirstHealthy(player2);

            if (p1 == null)
            {
                Console.WriteLine("You don't have any pokemon!");
                return;
            }

            setBattleReady();

            Console.WriteLine(player2.name + " wants to fight!");
            Console.WriteLine(player2.name + " sent out " + p2.name + "!");
            Console.WriteLine("Go, " + p1.species.name + "!");

            while (!(player1.BlackOut() || player2.BlackOut()))
            {
                battleLoop();
            }
        }

        private void battleLoop()
        {
            bool faint = false;
            bool first = true;
            List<BattleMove> bmoves = selectMoves();
            foreach (BattleMove move in bmoves)
            {
                bool halt = handleStatusPreAttack(move);
                if (p1.currentHP == 0 || p2.currentHP == 0)
                {
                    faint = true;
                    break;
                }
                if (halt)
                {
                    continue;
                }
                CombatMechanics.handleMove(move, first);
                first = false;
                if (p1.currentHP == 0 || p2.currentHP == 0)
                {
                    faint = true;
                    break;
                }
            }
            if (!faint)
            {
                handlePostAttack(bmoves);
            }
            // Pokemon can faint due to poison or burn
            // so check again if fainted
            onFainted();
        }

        // TODO: handle input in order to choose moves
        private List<BattleMove> selectMoves()
        {
            PokemonMove p1move = Moves.getMove("STRUGGLE");
            PokemonMove p2move = Moves.getMove("STRUGGLE");
            if (p1.hasPPLeft())
            {
                p1move = p1.moves[0].move;
                p1.moves[0].currentPP -= 1;
            }
            if (p2.hasPPLeft())
            {
                p2move = p2.moves[0].move;
                p2.moves[0].currentPP -= 1;
            }

            List<BattleMove> bmoves = new List<BattleMove>();
            bmoves.Add(new BattleMove(p1, p2, p1move, p1.speedStat));
            bmoves.Add(new BattleMove(p2, p1, p2move, p2.speedStat));
            return sortBySpeed(bmoves);
        }

        // TODO: move priority?
        private List<BattleMove> sortBySpeed(List<BattleMove> bmoves)
        {
            return bmoves.OrderByDescending(m => m.speed).ToList();
        }

        // return true if source is not allowed to attack
        private bool handleStatusPreAttack(BattleMove move)
        {
            if (move.source.nonVolatile != null)
            {
                return move.source.nonVolatile.preAttack();
            }

            return false;
        }

        private void handlePostAttack(List<BattleMove> bmoves)
        {
            foreach (BattleMove move in bmoves)
            {
                handleStatusPostAttack(move);
                if (move.source.currentHP == 0)
                {
                    return;
                }
            }
        }

        private void handleStatusPostAttack(BattleMove move)
        {
            if (move.source.nonVolatile != null)
            {
                move.source.nonVolatile.postAttack();
            }
        }

        private void onFainted()
        {
            if (p2.currentHP == 0)
            {
                Console.WriteLine(p2.name + " fainted!");
            }
            if (p1.currentHP == 0)
            {
                Console.WriteLine(p1.name + " fainted!");
            }
            if (p2.currentHP == 0 && p1.currentHP > 0)
            {
                Experience.gainXP(p1, p2);
            }
        }

        private Pokemon getFirstHealthy(Player player)
        {
            foreach (Pokemon p in player.team)
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
