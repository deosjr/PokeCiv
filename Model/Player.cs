using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokeCiv.Model.Pokedata;

namespace PokeCiv.Model
{
    class Player
    {

        public List<Pokemon> team = new List<Pokemon>();
        public string name;

        public Player(string name)
        {
            this.name = name;
        }

        public void AddToTeam(Pokemon pokemon)
        {
            if (team.Count < 6)
            {
                team.Add(pokemon);
            }
        }

        public bool BlackOut()
        {
            foreach (Pokemon p in team)
            {
                if (p.currentHP > 0)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
