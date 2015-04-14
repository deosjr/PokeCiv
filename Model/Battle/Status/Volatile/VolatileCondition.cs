using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PokeCiv.Model.Pokedata;

namespace PokeCiv.Model.Battle.Status.Volatile
{
    public abstract class VolatileCondition : StatusCondition
    {

        public int priority = 0;

        public virtual bool preAttack(Battle battle, Pokemon pokemon)
        {
            return false;
        }

        public virtual void postAttack(Battle battle, Pokemon pokemon)
        {

        }

        public virtual string getInitMessage()
        {
            return "";
        }
    }
}
