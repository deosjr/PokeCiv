using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PokeCiv.Model.Pokedata;

namespace PokeCiv.Model.Battle.Status
{
    public abstract class VolatileCondition : StatusCondition
    {

        public virtual bool preAttack(Pokemon pokemon)
        {
            return false;
        }

        public virtual void postAttack(Pokemon pokemon)
        {

        }
    }
}
