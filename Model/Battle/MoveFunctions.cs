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

        public static void applyMoveFunction(BattleMove m, int damage, double t, bool miss, bool first)
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
                    Console.WriteLine("Nothing happens at all.");
                    return;
                case "002":
                    // TODO: no type, not recoil
                    source.takeDamage((int)Math.Floor(source.HP / 4.0));
                    break;
                case "003":
                    if (!miss)
                    {
                        target.setStatus("SLP");
                    }
                    break;
                case "005":
                    if (addEffect && !miss)
                    {
                        target.setStatus("PSN");
                    }
                    break;
                case "006":
                    if (addEffect && !miss)
                    {
                        target.setStatus("BPSN");
                    }
                    break;
                case "007":
                    // TODO: electric move on electric pokemon doesn't work
                    // TODO: Thunder Wave exception
                    if (addEffect)
                    {
                        target.setStatus("PAR");
                    }
                    break;
                case "008":
                    // TODO: Thunder exceptions
                    if (addEffect)
                    {
                        target.setStatus("PAR");
                    }
                    break;
                case "00A":
                    if (addEffect)
                    {
                        target.setStatus("BRN");
                    }
                    break;
                case "00C":
                    if (addEffect)
                    {
                        target.setStatus("FRZ");
                    }
                    break;
                case "00D":
                    // TODO: Blizzard exceptions
                    if (addEffect)
                    {
                        target.setStatus("FRZ");
                    }
                    break;
                default:
                    Console.WriteLine("This move hasn't been implemented yet!");
                    break;
            }
        }

    }
}
