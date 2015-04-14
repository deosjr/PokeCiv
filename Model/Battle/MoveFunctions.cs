using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokeCiv.Model.Pokedata;

namespace PokeCiv.Model.Battle
{
    class MoveFunctions
    {

        public static void applyMoveFunction(Battle battle, BattleMove m, int damage, double t, bool miss, bool first)
        {
            PokemonMove move = m.move;
            Pokemon source = m.source;
            Pokemon target = m.target;

            bool addEffect = true;
            string fail = "But, it failed!";
            if (move.addEffectChance != 0 && Mechanics.random.Next(101) > move.addEffectChance)
            {
                addEffect = false;
            }

            switch (move.functioncode) 
            {
                case "000":
                    return;
                case "001":
                    battle.message("Nothing happens at all.");
                    return;
                case "002":
                    // TODO: no type, not recoil
                    source.takeDamage((int)Math.Floor(source.HP / 4.0));
                    break;
                case "003":
                    if (!miss)
                    {
                        target.setStatus(battle, "SLP");
                    }
                    break;
                case "005":
                    if (addEffect && !miss)
                    {
                        target.setStatus(battle, "PSN");
                    }
                    break;
                case "006":
                    if (addEffect && !miss)
                    {
                        target.setStatus(battle, "BPSN");
                    }
                    break;
                case "007":
                    // TODO: electric move on electric pokemon doesn't work
                    // TODO: Thunder Wave exception
                    if (addEffect)
                    {
                        target.setStatus(battle, "PAR");
                    }
                    break;
                case "008":
                    // TODO: Thunder exceptions
                    if (addEffect)
                    {
                        target.setStatus(battle, "PAR");
                    }
                    break;
                case "00A":
                    if (addEffect)
                    {
                        target.setStatus(battle, "BRN");
                    }
                    break;
                case "00C":
                    if (addEffect)
                    {
                        target.setStatus(battle, "FRZ");
                    }
                    break;
                case "00D":
                    // TODO: Blizzard exceptions
                    if (addEffect)
                    {
                        target.setStatus(battle, "FRZ");
                    }
                    break;
                case "00E":
                    if (addEffect)
                    {
                        if (first && Mechanics.random.NextDouble() < 0.1)
                        {
                            target.addStatus(battle, "FLINCH");
                        }
                        if (Mechanics.random.NextDouble() < 0.1)
                        {
                            target.setStatus(battle, "FRZ");
                        }
                    }
                    break;
                case "00F":
                    if (addEffect)
                    {
                        if (first)
                        {
                            target.addStatus(battle, "FLINCH");
                        }
                    }
                    break;
                case "013":
                    if (addEffect)
                    {
                        target.addStatus(battle, "CONFUSION");
                    }
                    break;
                case "01C":
                    if (addEffect)
                    {
                        battle.message(source.increaseStat("Attack", 1));
                    }
                    break;
                case "01D":
                    if (addEffect)
                    {
                        battle.message(source.increaseStat("Defense", 1));
                    }
                    break;
                case "01E":
                    // TODO: curl effect
                    if (addEffect)
                    {
                        battle.message(source.increaseStat("Defense", 1));
                    }
                    break;
                case "01F":
                    if (addEffect)
                    {
                        battle.message(source.increaseStat("Speed", 1));
                    }
                    break;
                case "020":
                    if (addEffect)
                    {
                        battle.message(source.increaseStat("SPAttack", 1));
                    }
                    break;
                case "022":
                    if (addEffect)
                    {
                        battle.message(source.increaseStat("Evasion", 1));
                    }
                    break;
                case "024":
                    if (addEffect)
                    {
                        battle.message(source.increaseStat("Attack", 1));
                        battle.message(source.increaseStat("Defense", 1));
                    }
                    break;
                case "025":
                    if (addEffect)
                    {
                        battle.message(source.increaseStat("Attack", 1));
                        battle.message(source.increaseStat("Defense", 1));
                        battle.message(source.increaseStat("Accuracy", 1));
                    }
                    break;
                case "026":
                    if (addEffect)
                    {
                        battle.message(source.increaseStat("Attack", 1));
                        battle.message(source.increaseStat("Speed", 1));
                    }
                    break;
                case "027":
                    if (addEffect)
                    {
                        battle.message(source.increaseStat("Attack", 1));
                        battle.message(source.increaseStat("SPAttack", 1));
                    }
                    break;
                case "029":
                    if (addEffect)
                    {
                        battle.message(source.increaseStat("Attack", 1));
                        battle.message(source.increaseStat("Accuracy", 1));
                    }
                    break;
                case "02A":
                    if (addEffect)
                    {
                        battle.message(source.increaseStat("Defense", 1));
                        battle.message(source.increaseStat("SPDefense", 1));
                    }
                    break;
                case "02B":
                    if (addEffect)
                    {
                        battle.message(source.increaseStat("Speed", 1));
                        battle.message(source.increaseStat("SPAttack", 1));
                        battle.message(source.increaseStat("SPDefense", 1));
                    }
                    break;
                case "02C":
                    if (addEffect)
                    {
                        battle.message(source.increaseStat("SPAttack", 1));
                        battle.message(source.increaseStat("SPDefense", 1));
                    }
                    break;
                case "02D":
                    if (addEffect)
                    {
                        battle.message(source.increaseStat("Attack", 1));
                        battle.message(source.increaseStat("SPAttack", 1));
                        battle.message(source.increaseStat("Defense", 1));
                        battle.message(source.increaseStat("SPDefense", 1));
                        battle.message(source.increaseStat("Speed", 1));
                    }
                    break;
                case "02E":
                    if (addEffect)
                    {
                        battle.message(source.increaseStat("Attack", 2));
                    }
                    break;
                case "02F":
                    if (addEffect)
                    {
                        battle.message(source.increaseStat("Defense", 2));
                    }
                    break;
                case "030":
                    if (addEffect)
                    {
                        battle.message(source.increaseStat("Speed", 2));
                    }
                    break;
                case "032":
                    if (addEffect)
                    {
                        battle.message(source.increaseStat("SPAttack", 2));
                    }
                    break;
                case "033":
                    if (addEffect)
                    {
                        battle.message(source.increaseStat("SPDefense", 2));
                    }
                    break;
                case "035":
                    if (addEffect)
                    {
                        battle.message(source.decreaseStat("Defense", 1));
                        battle.message(source.decreaseStat("SPDefense", 1));
                        battle.message(source.increaseStat("Attack", 2));
                        battle.message(source.increaseStat("SPAttack", 2));
                        battle.message(source.increaseStat("Speed", 2));
                    }
                    break;
                case "036":
                    if (addEffect)
                    {
                        battle.message(source.increaseStat("Speed", 2));
                        battle.message(source.increaseStat("Attack", 1));
                    }
                    break;
                case "038":
                    if (addEffect)
                    {
                        battle.message(source.increaseStat("Defense", 3));
                    }
                    break;
                case "039":
                    if (addEffect)
                    {
                        battle.message(source.increaseStat("SPAttack", 3));
                    }
                    break;
                case "03B":
                    if (addEffect)
                    {
                        battle.message(source.decreaseStat("Attack", 1));
                        battle.message(source.decreaseStat("Defense", 1));
                    }
                    break;
                case "03C":
                    if (addEffect)
                    {
                        battle.message(source.decreaseStat("Defense", 1));
                        battle.message(source.decreaseStat("SPDefense", 1));
                    }
                    break;
                case "03E":
                    if (addEffect)
                    {
                        battle.message(source.decreaseStat("Speed", 1));
                    }
                    break;
                case "03F":
                    if (addEffect)
                    {
                        battle.message(source.decreaseStat("SPAttack", 2));
                    }
                    break;
                case "042":
                    if (addEffect)
                    {
                        battle.message(target.decreaseStat("Attack", 1));
                    }
                    break;
                case "043":
                    if (addEffect)
                    {
                        battle.message(target.decreaseStat("Defense", 1));
                    }
                    break;
                case "044":
                    if (addEffect)
                    {
                        battle.message(target.decreaseStat("Speed", 1));
                    }
                    break;
                case "045":
                    if (addEffect)
                    {
                        battle.message(target.decreaseStat("SPAttack", 1));
                    }
                    break;
                case "046":
                    if (addEffect)
                    {
                        battle.message(target.decreaseStat("SPDefense", 1));
                    }
                    break;
                case "047":
                    if (addEffect)
                    {
                        battle.message(target.decreaseStat("Accuracy", 1));
                    }
                    break;
                case "048":
                    if (addEffect)
                    {
                        battle.message(target.decreaseStat("Evasion", 1));
                    }
                    break;
                case "04A":
                    if (addEffect)
                    {
                        battle.message(target.decreaseStat("Attack", 1));
                        battle.message(target.decreaseStat("Defense", 1));
                    }
                    break;
                case "04B":
                    if (addEffect)
                    {
                        battle.message(target.decreaseStat("Attack", 2));
                    }
                    break;
                case "04C":
                    if (addEffect)
                    {
                        battle.message(target.decreaseStat("Defense", 2));
                    }
                    break;
                case "04D":
                    if (addEffect)
                    {
                        battle.message(target.decreaseStat("Speed", 2));
                    }
                    break;
                case "04F":
                    if (addEffect)
                    {
                        battle.message(target.decreaseStat("SPDefense", 2));
                    }
                    break;
                case "050":
                    if (addEffect)
                    {
                        target.resetStages();
                    }
                    break;
                case "051":
                    if (addEffect)
                    {
                        source.resetStages();
                        target.resetStages();
                    }
                    break;
                case "052":
                    if (addEffect)
                    {
                        source.swapStats(target, "Attack");
                        source.swapStats(target, "SPAttack");
                    }
                    break;
                case "053":
                    if (addEffect)
                    {
                        source.swapStats(target, "Defense");
                        source.swapStats(target, "SPDefense");
                    }
                    break;
                case "054":
                    if (addEffect)
                    {
                        source.swapStats(target, "Attack");
                        source.swapStats(target, "SPAttack");
                        source.swapStats(target, "Defense");
                        source.swapStats(target, "SPDefense");
                        source.swapStats(target, "Accuracy");
                        source.swapStats(target, "Evasion");
                        source.swapStats(target, "Speed");
                    }
                    break;
                case "055":
                    if (addEffect)
                    {
                        source.AttackStat = target.AttackStat;
                        source.SPAttackStat = target.SPAttackStat;
                        source.DefenseStat = target.DefenseStat;
                        source.SPDefenseStat = target.SPDefenseStat;
                        source.AccuracyStat = target.AccuracyStat;
                        source.EvasionStat = target.EvasionStat;
                        source.SpeedStat = target.SpeedStat;
                    }
                    break;
                case "06A":
                    if (t != 0 && !miss)
                    {
                        target.takeDamage(20);
                    }
                    break;
                case "06B":
                    if (t != 0 && !miss)
                    {
                        target.takeDamage(40);
                    }
                    break;
                case "06C":
                    if (t != 0 && !miss)
                    {
                        target.takeDamage(target.CurrentHP/2);
                    }
                    break;
                case "06D":
                    if (t != 0 && !miss)
                    {
                        target.takeDamage(source.Level);
                    }
                    break;
                case "06E":
                    if (t != 0 && !miss)
                    {
                        if (source.CurrentHP > target.CurrentHP)
                        {
                            battle.message(fail);
                            break;
                        }
                        target.takeDamage(target.CurrentHP - source.CurrentHP);
                    }
                    break;
                case "06F":
                    if (t != 0 && !miss)
                    {
                        target.takeDamage(source.Level * ((Mechanics.random.Next(101) + 50) / 100));
                    }
                    break;
                // Affects power, see CombatMechanics.checkPower()
                case "07B":
                    break;
                case "07C":
                    break;
                case "07D":
                    break;
                case "07E":
                    break;
                case "07F":
                    break;
                case "080":
                    break;
                case "08B":
                    break;
                case "08C":
                    break;
                case "08D":
                    break;
                // End power effects

                case "0A5":
                    // Has an exception in determineHit
                    break;
                case "0BD":
                    if (!miss)
                    {
                        CombatMechanics.dealDamage(battle, m);
                        battle.message("Hit 2 times!");
                    }
                    break;
                case "0C0":
                    if (!miss)
                    {
                        // Linear fit to (0,2)(1,2)(2,3)(3,3)(4,4)(5,5)
                        int times = (int)Math.Round( 0.6 * Mechanics.random.Next(6) + 1.666667);
                        for (int i = 0; i < times-1; i++)
                        {
                            CombatMechanics.dealDamage(battle, m);
                        }
                        battle.message("Hit " + times + " times!");
                    }
                    break;
                case "0C2":
                    if (!miss)
                    {
                        source.addStatus(battle, "RECHARGE");
                    }
                    break;
                case "0D5":
                    if (source.CurrentHP == source.HP)
                    {
                        battle.message(fail);
                    }
                    else
                    {
                        source.heal(source.HP / 2);
                    }
                    break;
                case "0DD":
                    source.heal(Math.Min(1, damage / 2));
                    break;
                case "0DE":
                    if (target.checkNonVolatileStatus("SLP"))
                    {
                        source.heal(Math.Min(1, damage / 2));
                    }
                    else
                    {
                        battle.message(fail);
                    }
                    break;
                case "0E0":
                    source.CurrentHP = 0;
                    break;
                default:
                    battle.message("This move effect has not been implemented yet!");
                    break;
            }
        }

        public static bool isImplemented(string movename)
        {
            string code = Moves.getMove(movename).functioncode;
            string[] notImplemented = { 
                                          "004", "009", "00B",
                                          "010", "011", "012", "014", "015", "016", "017", "018", "019", "01A", "01B",
                                          "021", "023", "028",
                                          "031", "034", "037", "03A", "03D",
                                          "040", "041", "049", "04E",
                                          "056", "057", "058", "059", "05A", "05B", "05C", "05D", "05E", "05F",
                                          "060", "061", "062", "063", "064", "065", "066", "067", "068", "069",
                                          "070", "071", "072", "073", "074", "075", "076", "077", "078", "079", "07A",
                                          "081", "082", "083", "084", "085", "086", "087", "088", "089", "08A", "08E", "08F",
                                          "090", "091", "092", "093", "094", "095", "096", "097", "098", "099", "09A", "09B", "09C", "09D", "09E", "09F",
                                          "0A0", "0A1", "0A2", "0A3", "0A4", "0A6", "0A7", "0A8", "0A9", "0AA", "0AB", "0AC", "0AD", "0AE", "0AF",
                                          "0B0", "0B1", "0B2", "0B3", "0B4", "0B5", "0B6", "0B7", "0B8", "0B9", "0BA", "0BB", "0BC", "0BE", "0BF",
                                          "0C1", "0C3", "0C4", "0C5", "0C6", "0C7", "0C8", "0C9", "0CA", "0CB", "0CC", "0CD", "0CE", "0CF",
                                          "0D0", "0D1", "0D2", "0D3", "0D4", "0D6", "0D7", "0D8", "0D9", "0DA", "0DB", "0DC", "0DF",
                                          "0E1", "0E2", "0E3", "0E4", "0E5", "0E6", "0E7", "0E8", "0E9", "0EA", "0EB", "0EC", "0ED", "0EE", "0EF",
                                          "0F0", "0F1", "0F2", "0F3", "0F4", "0F5", "0F6", "0F7", "0F8", "0F9", "0FA", "0FB", "0FC", "0FD", "0FE", "0FF",
                                          "100", "101", "102", "103", "104", "105", "106", "107", "108", "109", "10A", "10B", "10C", "10D", "10E", "10F",
                                          "110", "111", "112", "113", "114", "115", "116", "117", "118", "119", "11A", "11B", "11C", "11D", "11E", "11F",
                                          "120", "121", "122", "123", "124", "125", "126", "127", "128", "129", "12A", "12B", "12C", "12D", "12E", "12F",
                                          "130", "131", "132"
                                      };
            return !notImplemented.Contains(code);
        }

    }
}
