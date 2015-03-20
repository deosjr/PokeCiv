using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokeCiv.Model.Battle.Status
{
    public abstract class NonVolatileCondition : StatusCondition
    {

        public virtual bool preAttack()
        {
            return false;
        }

        public virtual void postAttack()
        {

        }

        public abstract string getInitMessage();
    }
}
