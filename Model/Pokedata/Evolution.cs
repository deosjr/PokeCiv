using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCiv.Model.Pokedata
{
    public class Evolution
    {

        public string name;
        public string type;
        public string info;

        public Evolution(string name, string type, string info)
        {
            this.name = name;
            this.type = type;
            this.info = info;
        }

    }
}
