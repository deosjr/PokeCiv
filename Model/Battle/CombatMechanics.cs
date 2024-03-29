﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokeCiv.Model.Pokedata;

namespace PokeCiv.Model.Battle
{
    class CombatMechanics
    {

        public static void handleMove(Battle battle, BattleMove move, bool first)
        {
            battle.message(move.source.Name + " used " + move.move.name + "!");
            double acc = accStageToModifier(move.source.AccuracyStat);
            double evade = accStageToModifier(move.target.EvasionStat);

            bool miss = determineHit(battle, move, acc, evade);
            int damage = 0;
            double t = 1;

            if (!miss && !move.move.category.Equals("Status"))
            {
                damage = dealDamage(battle, move, out t);
            }
            MoveFunctions.applyMoveFunction(battle, move, damage, t, miss, first);
        }

        // Returns true if attack misses
        private static bool determineHit(Battle battle, BattleMove move, double acc, double evade)
        {
            // Always hit exceptions:
            if (move.move.functioncode.Equals("0A5"))
            {
                return false;
            }

            double p = move.move.accuracy * (acc / evade);
            int r = Mechanics.random.Next(101);
            if (move.move.accuracy != 0 && r > p)
            {
                battle.message(move.source.Name + "'s attack missed!");
                return true;
            }
            return false;
        }

        public static void determineDamage(BattleMove move, out int damage, out double Crit, out double T)
        {
            int attack, attackStat, defense, defenseStat;
            normalOrSpecialAttack(move, out attack, out attackStat, out defense, out defenseStat);

            int L = move.source.Level;
            double A = attack * statStageToModifier(attackStat);
            double D = defense * statStageToModifier(defenseStat);
            double B = checkPower(move);
            double STAB = 1.0;
            if (move.source.species.Types.Contains(move.move.type))
            {
                STAB = 1.5;
            }
            T = Types.effectiveness(move.move.type, move.target.species.Types);
            Crit = 1.0; //TODO
            double other = 1.0; //TODO
            double rand = 1.0 - 0.15 * Mechanics.random.NextDouble();
            double Mod = STAB * T * Crit * other * rand;
            damage = (int) Math.Max(1, Math.Round((((2.0 * L + 10.0) / 250.0) * (A/D) * B + 2.0) * Mod));
            
        }

        public static int dealDamage(Battle battle, BattleMove move)
        {
            int damage = 0;
            double crit, t = 1;
            determineDamage(move, out damage, out crit, out t);
            effectivenessMessages(battle, crit, t, move.target.Name);
            if (t != 0)
            {
                damage = move.target.takeDamage(damage);
                Console.WriteLine(move.target.Name + " takes " + damage + " damage!");
            }
            return damage;
        }

        public static int dealDamage(Battle battle, BattleMove move, out double t)
        {
            int damage = 0;
            double crit = 1;
            t = 1;
            determineDamage(move, out damage, out crit, out t);
            effectivenessMessages(battle, crit, t, move.target.Name);
            if (t != 0)
            {
                damage = move.target.takeDamage(damage);
                Console.WriteLine(move.target.Name + " takes " + damage + " damage!");
            }
            return damage;
        }

        private static void normalOrSpecialAttack(BattleMove move, out int attack, out int attackStat, out int defense, out int defenseStat)
        {
            if (move.move.category.Equals("Special"))
            {
                attack = move.source.Attack;
                attackStat = move.source.AttackStat;
                defense = move.target.Defense;
                defenseStat = move.target.DefenseStat;
            }
            else
            {
                attack = move.source.SPAttack;
                attackStat = move.source.SPAttackStat;
                defense = move.target.SPDefense;
                defenseStat = move.target.SPDefenseStat;
            }
        }

        private static double checkPower(BattleMove move)
        {
            switch (move.move.functioncode)
            {
                case "07B":
                    if (move.target.checkNonVolatileStatus("PSN"))
                    {
                        return move.move.power * 2;
                    }
                    break;
                case "07C":
                    if (move.target.checkNonVolatileStatus("PAR"))
                    {
                        move.target.clearNonVolatileStatus();
                        return move.move.power * 2;
                    }
                    break;
                case "07D":
                    if (move.target.checkNonVolatileStatus("SLP"))
                    {
                        move.target.clearNonVolatileStatus();
                        return move.move.power * 2;
                    }
                    break;
                case "07E":
                    if (move.target.checkNonVolatileStatus("PSN") || move.target.checkNonVolatileStatus("BRN") || move.target.checkNonVolatileStatus("PAR"))
                    {
                        return move.move.power * 2;
                    }
                    break;
                case "07F":
                    if (move.target.NonVolatile != null)
                    {
                        return move.move.power * 2;
                    }
                    break;
                case "08B":
                    return Math.Floor((move.source.CurrentHP / move.source.HP) * 150.0);
                case "08C":
                    return Math.Floor((move.source.CurrentHP / move.source.HP) * 120.0);
                case "08D":
                    return Math.Min(Math.Floor((move.target.SpeedStat / move.source.SpeedStat) * 25.0), 150.0);
            }
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

        private static void effectivenessMessages(Battle battle, double crit, double t, string targetName)
        {
            if (crit > 1)
            {
                battle.message("Critical hit!");
            }
            if (t == 0)
            {
                battle.message("It doesn't affect " + targetName + ".");
            }
            else if (t > 1)
            {
                battle.message("It's super effective!");
            } 
            else if (t < 1)
            {
                battle.message("It's not very effective..");
            }
        }

    }
}
