using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokeCiv.Model.Pokedata;

namespace PokeCiv.Model.Battle
{
    class CombatMechanics
    {
        public static Random random = new Random();

        public static void handleMove(BattleMove move)
        {
            Console.WriteLine(move.source.species.name + " used " + move.move.name + "!");
            double acc = accStageToModifier(move.source.accuracy);
            double evade = accStageToModifier(move.target.evasion);

            bool miss = determineHit(move, acc, evade);
            int damage;
            double crit, t;

            if (!miss && !move.move.category.Equals("Status"))
            {
                determineDamage(move, out damage, out crit, out t);
                if (t != 0)
                {
                    int damageDealt = move.target.takeDamage(damage);
                    Console.WriteLine(move.target.species.name + " takes " + damageDealt + " damage!");
                }
            }
        }

        private static bool determineHit(BattleMove move, double acc, double evade)
        {
            double p = move.move.accuracy * (acc / evade);
            int r = random.Next(101);
            if (move.move.accuracy != 0 && r > p)
            {
                Console.WriteLine(move.source.species.name + "'s attack missed!");
                return true;
            }
            return false;
        }

        private static void determineDamage(BattleMove move, out int damage, out double Crit, out double T)
        {
            int attack, attackStat, defense, defenseStat;
            normalOrSpecialAttack(move, out attack, out attackStat, out defense, out defenseStat);

            int L = move.source.level;
            double A = attack * statStageToModifier(attackStat);
            double D = defense * statStageToModifier(defenseStat);
            double B = checkPower(move);
            double STAB = 1.0;
            if (move.source.species.types.Contains(move.move.type))
            {
                STAB = 1.5;
            }
            T = Types.effectiveness(move.move.type, move.target.species.types);
            Crit = 1.0; //TODO
            double other = 1.0; //TODO
            double rand = 1.0 - 0.15 * random.NextDouble();
            double Mod = STAB * T * Crit * other * rand;
            damage = (int) Math.Max(1, Math.Round((((2.0 * L + 10.0) / 250.0) * (A/D) * B + 2.0) * Mod));
            
        }

        private static void normalOrSpecialAttack(BattleMove move, out int attack, out int attackStat, out int defense, out int defenseStat)
        {
            if (move.move.category.Equals("Special"))
            {
                attack = move.source.attack;
                attackStat = move.source.attackStat;
                defense = move.target.defense;
                defenseStat = move.target.defenseStat;
            }
            else
            {
                attack = move.source.spattack;
                attackStat = move.source.spattackStat;
                defense = move.target.spdefense;
                defenseStat = move.target.spdefenseStat;
            }
        }

        private static double checkPower(BattleMove move)
        {
            return move.move.power;
        }

        public static double accStageToModifier(int stage)
        {
            if (stage >= 0)
            {
                return ((stage + 3) * 100.0) / 3.0;
            }
            return 300.0 / (3.0 - stage);
        }

        public static double statStageToModifier(int stage)
        {
            if (stage >= 0)
            {
                return stage * 0.5 + 1.0;
            }
            return 1.0 / ((-stage * 0.5) + 1.0);
        }

    }
}
