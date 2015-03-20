using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCiv.Model.Pokedata
{
    public class Species
    {

        public string name;
        public int id;

        public int HP;
        public int attack;
        public int defense;
        public int spattack;
        public int spdefense;
        public int speed;

        public List<PokemonType> types;
        //public List<???> evolutions;
        public Dictionary<int, List<PokemonMove>> movesLearnable = new Dictionary<int, List<PokemonMove>>();

        public string growthRate;
        public int baseXP;
        //public int EP;

        public Species(Dictionary<string, string> data)
        {
            name = data["Name"];
            id = Convert.ToInt32(data["ID"]);
            setBaseStats(data["BaseStats"]);
            setTypes(data);
            growthRate = data["GrowthRate"];
            baseXP = Convert.ToInt32(data["BaseEXP"]);
            //TODO: setEvolutions(data["Evolutions"]);
            setMoves(data["Moves"]);
        }

        private void setBaseStats(string stats)
        {
            var baseStats = new List<int>(from x in stats.Split(',') select Convert.ToInt32(x));
            HP = baseStats[0];
            attack = baseStats[1];
            defense = baseStats[2];
            spattack = baseStats[3];
            spdefense = baseStats[4];
            speed = baseStats[5];

        }

        private void setTypes(Dictionary<string, string> data)
        {
            types = new List<PokemonType>();
            types.Add(Types.getType(data["Type1"]));
            string type2;
            if (data.TryGetValue("Type2", out type2))
            {
                types.Add(Types.getType(type2));
            }
        }

        private void setEvolutions(string evolutions)
        {

        }

        private void setMoves(string moves)
        {
            string[] m = moves.Split(',');
            for (int i = 0; i < m.Length; i += 2)
            {
                int level = Convert.ToInt32(m[i]);
                PokemonMove move = Moves.getMove(m[i + 1]);
                if (movesLearnable.ContainsKey(level))
                {
                    movesLearnable[level].Add(move);
                }
                else
                {
                    List<PokemonMove> list = new List<PokemonMove>();
                    list.Add(move);
                    movesLearnable.Add(level, list);
                }
            }
        }

    }
}
