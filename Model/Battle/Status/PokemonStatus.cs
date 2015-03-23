using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCiv.Model.Battle.Status
{
    // Singleton pattern
    class PokemonStatus
    {

        private static Dictionary<string, NonVolatileCondition> singletons = new Dictionary<string, NonVolatileCondition>();

        static PokemonStatus()
        {
            singletons.Add("PAR", new Paralyzed());
            singletons.Add("FRZ", new Frozen());
            singletons.Add("BRN", new Burned());
            singletons.Add("PSN", new Poisoned());
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
            NonVolatileCondition condition;
            singletons.TryGetValue(id, out condition);
            return condition;
        }

        public static VolatileCondition getVolatile(string id)
        {
            throw new NotImplementedException();
        }

    }
}
