using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokeCiv.Model.Battle.Status.NonVolatile;
using PokeCiv.Model.Battle.Status.Volatile;

namespace PokeCiv.Model.Battle.Status
{
    // Singleton pattern
    class PokemonStatus
    {

        private static Dictionary<string, StatusCondition> singletons = new Dictionary<string, StatusCondition>();

        static PokemonStatus()
        {
            singletons.Add("PAR", new Paralyzed());
            singletons.Add("FRZ", new Frozen());
            singletons.Add("BRN", new Burned());
            singletons.Add("PSN", new Poisoned());

            singletons.Add("FLINCH", new Flinch());
        }

        public static NonVolatileCondition getNonVolatile(string id)
        {
            // Asleep and Badly Poisoned are not singletons 
            // since they have extra information (timers)
            if (id.Equals("SLP"))
            {
                return new Asleep();
            }
            if (id.Equals("BPSN"))
            {
                return new BadlyPoisoned();
            } 
            StatusCondition condition;
            singletons.TryGetValue(id, out condition);
            return (NonVolatileCondition) condition;
        }

        public static VolatileCondition getVolatile(string id)
        {
            if (id.Equals("CONFUSION"))
            {
                return new Confusion();
            }
            StatusCondition condition;
            singletons.TryGetValue(id, out condition);
            return (VolatileCondition) condition;
        }

    }
}
