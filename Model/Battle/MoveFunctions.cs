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
            if (move.addEffectChance != 0 && CombatMechanics.random.Next(101) > move.addEffectChance)
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
                default:
                    battle.message("This move hasn't been implemented yet!");
                    break;
            }
        }

    }
}
