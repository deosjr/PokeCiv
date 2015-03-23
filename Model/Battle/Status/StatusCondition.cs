using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokeCiv.Model.Pokedata;

namespace PokeCiv.Model.Battle.Status
{
    interface StatusCondition
    {
        bool preAttack(Pokemon pokemon);

        void postAttack(Pokemon pokemon);
    }
}
