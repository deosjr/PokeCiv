using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokeCiv.Model.Pokedata;
using PokeCiv.View;

namespace PokeCiv.Model.Battle
{
    public class Battle
    {

        private Player player1;
        private Player player2;
        public Pokemon P1 { get; private set; }
        public Pokemon P2 { get; private set; }
        public string BattleType { get; private set; }
        public BattleView View { private get; set; }

        public Battle(Player p1, Player p2)
        {
            player1 = p1;
            player2 = p2;
            P1 = getFirstHealthy(player1);
            P2 = getFirstHealthy(player2);
            BattleType = "IndoorA"; // For now
        }

        public void fight()
        {

            if (P1 == null)
            {
                message("You don't have any pokemon!");
                return;
            }

            setBattleReady();

            message(player2.Name + " wants to fight!");
            message(player2.Name + " sent out " + P2.Name + "!");
            message("Go, " + P1.Name + "!");

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
                CombatMechanics.handleMove(this, move, first);
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
                p1move = View.selectMove();
                P1.Moves[0].currentPP -= 1;
            }
            if (P2.hasPPLeft())
            {
                p2move = P2.Moves[0].move;
                P2.Moves[0].currentPP -= 1;
            }

            List<BattleMove> bmoves = new List<BattleMove>();
            // TODO: speed should be modified by speedStat
            bmoves.Add(new BattleMove(P1, P2, p1move, P1.Speed));
            bmoves.Add(new BattleMove(P2, P1, p2move, P2.Speed));
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
                return move.source.nonVolatilePreAttack(this);
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
                move.source.nonVolatilePostAttack(this);
            }
        }

        private void onFainted()
        {
            if (P2.CurrentHP == 0)
            {
                message(P2.Name + " fainted!");
            }
            if (P1.CurrentHP == 0)
            {
                message(P1.Name + " fainted!");
            }
            if (P2.CurrentHP == 0 && P1.CurrentHP > 0)
            {
                Experience.gainXP(this, P1, P2);
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

        public void message(string msg)
        {
            View.message(msg);
            Console.WriteLine(msg);
        }
    }
}
