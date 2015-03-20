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
                case "008":
                    if (addEffect)
                    {
                        target.setStatus("PAR");
                    }
                    break;
                default:
                    Console.WriteLine("This move hasn't been implemented yet!");
                    break;
            }
        }

    }
}
