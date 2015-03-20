using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCiv.Model.Battle.Status
{
    interface StatusCondition
    {
        bool preAttack();

        void postAttack();
    }
}
