using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokeCiv.Model.Battle.Status
{
    abstract class VolatileCondition : StatusCondition
    {

        public virtual bool preAttack()
        {
            return false;
        }

        public virtual void postAttack()
        {

        }
    }
}
