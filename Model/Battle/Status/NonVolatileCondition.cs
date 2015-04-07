using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PokeCiv.Model.Pokedata;

namespace PokeCiv.Model.Battle.Status
{
    public abstract class NonVolatileCondition : StatusCondition
    {

        public string statuscode;

        public virtual bool preAttack(Battle battle, Pokemon pokemon)
        {
            return false;
        }

        public virtual void postAttack(Battle battle, Pokemon pokemon)
        {

        }

        public abstract string getInitMessage();
    }
}
