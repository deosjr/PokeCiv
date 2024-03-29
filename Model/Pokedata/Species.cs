﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCiv.Model.Pokedata
{
    public class Species
    {

        public string Name      { get; private set; }
        public int ID           { get; private set; }

        public int HP           { get; private set; }
        public int Attack       { get; private set; }
        public int Defense      { get; private set; }
        public int SPAttack     { get; private set; }
        public int SPDefense    { get; private set; }
        public int Speed        { get; private set; }

        public List<PokemonType> Types { get; private set; }
        public List<Evolution> Evolutions { get; private set; }
        public Dictionary<int, List<PokemonMove>> MovesLearnable { get; private set; }

        public string GrowthRate{ get; private set; }
        public int BaseXP       { get; private set; }
        //public int EP;

        public string Pokedex   { get; private set; }
        public string Color     { get; private set; }
        public string Kind      { get; private set; }
        public double Height    { get; private set; }
        public double Weight    { get; private set; }

        public int BattlerPlayerY   { get; private set; }
        public int BattlerEnemyY    { get; private set; }
        public int BattlerAltitude  { get; private set; }

        public Species(Dictionary<string, string> data)
        {
            Name = data["Name"];
            ID = Convert.ToInt32(data["ID"]);
            setBaseStats(data["BaseStats"]);
            setTypes(data);
            GrowthRate = data["GrowthRate"];
            BaseXP = Convert.ToInt32(data["BaseEXP"]);
            setEvolutions(data["Evolutions"]);
            setMoves(data["Moves"]);
            Pokedex = data["Pokedex"];
            Color = data["Color"];
            Kind = data["Kind"];
            Height = Convert.ToDouble(data["Height"]);
            Weight = Convert.ToDouble(data["Weight"]);
            if (data.ContainsKey("BattlerPlayerY"))
            {
                BattlerPlayerY = Convert.ToInt32(data["BattlerPlayerY"]);
            }
            if (data.ContainsKey("BattlerEnemyY"))
            {
                BattlerEnemyY = Convert.ToInt32(data["BattlerEnemyY"]);
            }
            if (data.ContainsKey("BattlerAltitude"))
            {
                BattlerAltitude = Convert.ToInt32(data["BattlerAltitude"]);
            }
        }

        private void setBaseStats(string stats)
        {
            var baseStats = new List<int>(from x in stats.Split(',') select Convert.ToInt32(x));
            HP = baseStats[0];
            Attack = baseStats[1];
            Defense = baseStats[2];
            SPAttack = baseStats[3];
            SPDefense = baseStats[4];
            Speed = baseStats[5];

        }

        private void setTypes(Dictionary<string, string> data)
        {
            Types = new List<PokemonType>();
            Types.Add(Pokedata.Types.getType(data["Type1"]));
            string type2;
            if (data.TryGetValue("Type2", out type2))
            {
                Types.Add(Pokedata.Types.getType(type2));
            }
        }

        private void setEvolutions(string evolutions)
        {
            Evolutions = new List<Evolution>();
            string[] evos = evolutions.Split(',');
            for (int i = 0; i < evos.Length-1; i += 3 )
            {
                Evolutions.Add(new Evolution(evos[i], evos[i+1], evos[i+2]));
            }
        }

        private void setMoves(string moves)
        {
            MovesLearnable = new Dictionary<int, List<PokemonMove>>();
            string[] m = moves.Split(',');
            for (int i = 0; i < m.Length; i += 2)
            {
                int level = Convert.ToInt32(m[i]);
                PokemonMove move = Moves.getMove(m[i + 1]);
                if (MovesLearnable.ContainsKey(level))
                {
                    MovesLearnable[level].Add(move);
                }
                else
                {
                    List<PokemonMove> list = new List<PokemonMove>();
                    list.Add(move);
                    MovesLearnable.Add(level, list);
                }
            }
        }

    }
}
