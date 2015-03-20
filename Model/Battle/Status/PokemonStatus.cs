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
        }

        public static NonVolatileCondition getNonVolatile(string id)
        {
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
