using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCiv.Model.Battle.Status
{
    class Paralyzed : NonVolatileCondition
    {

        public override bool preAttack() 
        {
            if (CombatMechanics.random.NextDouble() < 0.25)
            {
                Console.WriteLine(" is paralyzed! It can't move!");
                return true;
            }
            return false;
        }

        public override string getInitMessage()
        {
            return " was paralyzed!";
        }

    }
}
