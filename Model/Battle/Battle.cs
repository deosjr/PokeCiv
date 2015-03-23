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

        private Player player1;
        private Player player2;
        public Pokemon P1 { get; private set; }
        public Pokemon P2 { get; private set; }
        public string BattleType { get; private set; }

        public Battle(Player p1, Player p2)
        {
            player1 = p1;
            player2 = p2;
            BattleType = "IndoorA"; // For now
        }

        public void fight()
        {
            P1 = getFirstHealthy(player1);
            P2 = getFirstHealthy(player2);

            if (P1 == null)
            {
                Console.WriteLine("You don't have any pokemon!");
                return;
            }

            setBattleReady();

            Console.WriteLine(player2.Name + " wants to fight!");
            Console.WriteLine(player2.Name + " sent out " + P2.Name + "!");
            Console.WriteLine("Go, " + P1.Name + "!");

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
                if (P1.CurrentHP == 0 || P2.CurrentHP == 0)
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
                if (P1.CurrentHP == 0 || P2.CurrentHP == 0)
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
            if (P1.hasPPLeft())
            {
                p1move = P1.Moves[0].move;
                P1.Moves[0].currentPP -= 1;
            }
            if (P2.hasPPLeft())
            {
                p2move = P2.Moves[0].move;
                P2.Moves[0].currentPP -= 1;
            }

            List<BattleMove> bmoves = new List<BattleMove>();
            bmoves.Add(new BattleMove(P1, P2, p1move, P1.SpeedStat));
            bmoves.Add(new BattleMove(P2, P1, p2move, P2.SpeedStat));
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
            if (move.source.NonVolatile != null)
            {
                return move.source.NonVolatile.preAttack();
            }

            return false;
        }

        private void handlePostAttack(List<BattleMove> bmoves)
        {
            foreach (BattleMove move in bmoves)
            {
                handleStatusPostAttack(move);
                if (move.source.CurrentHP == 0)
                {
                    return;
                }
            }
        }

        private void handleStatusPostAttack(BattleMove move)
        {
            if (move.source.NonVolatile != null)
            {
                move.source.NonVolatile.postAttack();
            }
        }

        private void onFainted()
        {
            if (P2.CurrentHP == 0)
            {
                Console.WriteLine(P2.Name + " fainted!");
            }
            if (P1.CurrentHP == 0)
            {
                Console.WriteLine(P1.Name + " fainted!");
            }
            if (P2.CurrentHP == 0 && P1.CurrentHP > 0)
            {
                Experience.gainXP(P1, P2);
            }
        }

        private Pokemon getFirstHealthy(Player player)
        {
            foreach (Pokemon p in player.Team)
            {
                if (p.CurrentHP > 0)
                {
                    return p;
                }
            }
            return null;
        }

        private void setBattleReady()
        {
            foreach (Pokemon p in player1.Team)
            {
                p.initForBattle();
            }
            foreach (Pokemon p in player2.Team)
            {
                p.initForBattle();
            }
        }

    }
}
