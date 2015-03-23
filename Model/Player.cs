using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokeCiv.Model.Pokedata;

namespace PokeCiv.Model
{
    public class Player
    {

        public List<Pokemon> Team { get; private set; }
        public string Name { get; private set; }

        public Player(string name)
        {
            Name = name;
            Team = new List<Pokemon>();
        }

        public void AddToTeam(Pokemon pokemon)
        {
            if (Team.Count < 6)
            {
                Team.Add(pokemon);
            }
        }

        public bool BlackOut()
        {
            foreach (Pokemon p in Team)
            {
                if (p.CurrentHP > 0)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
