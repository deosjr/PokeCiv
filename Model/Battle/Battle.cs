using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokeCiv.Model.Pokedata;
using PokeCiv.View;
using PokeCiv.Controllers;

namespace PokeCiv.Model.Battle
{
    public class Battle
    {

        public Player player1;
        public Player player2;
        public Pokemon P1 { get; private set; }
        public Pokemon P2 { get; private set; }
        public string BattleType { get; private set; }
        public Controller Control { private get; set; }

        private bool loop = true;
        private int escapeAttempts = 0;

        public Battle(Controller c, Player pl1, Player pl2, Pokemon p1, Pokemon p2, string mapType)
        {
            Control = c;
            player1 = pl1;
            player2 = pl2;
            P1 = p1;
            P2 = p2;
            BattleType = mapType;
        }

        public void fight(bool start)
        {
            if (start)
            {
                setBattleReady();
                if (player2.Name.Equals("WILD_POKEMON"))
                {
                    message("A wild " + player2.Team.ElementAt(0).Name + " appeared!");
                }
                else
                {
                    message(player2.Name + " wants to fight!");
                    message(player2.Name + " sent out " + P2.Name + "!");
                }
                message("Go, " + P1.Name + "!");
            }

            while (loop)
            {
                battleLoop();
            }
        }

        private void battleLoop()
        {
            bool faint = false;
            bool first = true;
            List<BattleMove> bmoves = selectMoves();
            escapeAttempts = 0;
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
                int moveID = Control.selectMove();
                p1move = P1.Moves[moveID].move;
                P1.Moves[moveID].currentPP -= 1;
            }
            if (P2.hasPPLeft())
            {
                bool moveChosen = false;
                while (!moveChosen)
                {
                    int i = Mechanics.random.Next(4);
                    Move m = P2.Moves[i];
                    if (m != null)
                    {
                        p2move = m.move;
                        moveChosen = true;
                        P2.Moves[i].currentPP -= 1;
                    }
                }                
            }

            List<BattleMove> bmoves = new List<BattleMove>();
            bmoves.Add(new BattleMove(P1, P2, p1move));
            bmoves.Add(new BattleMove(P2, P1, p2move));
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
            return move.source.handleStatusPreAttack(this);
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
            move.source.handleStatusPostAttack(this);
        }

        private void onFainted()
        {
            if (P2.CurrentHP == 0)
            {
                message(P2.Name + " fainted!");
                if (P1.CurrentHP > 0)
                {
                    Experience.gainXP(this, P1, P2);
                }
                loop = false;
                Control.opponentSwitchPokemon(player2);
            }
            if (P1.CurrentHP == 0)
            {
                message(P1.Name + " fainted!");
                loop = false;
                Control.switchPokemon();
            }
        }

        public static Pokemon getFirstHealthy(Player player)
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

        public void attemptEscape()
        {
            Console.WriteLine("Attempting to escape");
            if (player2.Name.Equals("WILD_POKEMON"))
            {
                escapeAttempts++;
                int f = ((P1.Speed * 128) / Math.Max(P2.Speed, 1) + 30 * escapeAttempts) % 256;
                bool escapeSuccesful = Mechanics.random.Next(256) < f;
                if (escapeSuccesful || P1.hasType("Ghost"))
                {
                    message("Got away safely!");
                    Control.switchFromBattleToMap();
                }
                else
                {
                    message("Can't escape!");
                    //TODO: enemy gets a free attack in
                }
            }
            else
            {
                message("Can't run in a battle!");
            }
        }

        //send a message and message string to the view to inform the view about updates.
        public void message(string msg)
        {
            Console.WriteLine(msg);
            Control.message(msg);
        }
    }
}
