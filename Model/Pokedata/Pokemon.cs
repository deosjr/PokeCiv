using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCiv.Model.Pokedata
{
    class Pokemon
    {

        public int level;
        public Species species;
        public int currentHP;

        public int HP;
        public int attack;
        public int defense;
        public int spattack;
        public int spdefense;
        public int speed;

        private int IVHP;
        private int IVattack;
        private int IVdefense;
        private int IVspattack;
        private int IVspdefense;
        private int IVspeed;

        public Move[] moves = new Move[4];

        public Pokemon(int level, Species species)
        {
            this.level = level;
            this.species = species;
            //xp, next = lookup_xp()
            //nextxp = xp + next
            generateIV();
            calculateStats();
            learnMovesUntilLevel();
            currentHP = HP;
        }
        
        private void generateIV()
        {
            Random r = new Random();
            IVHP        = r.Next(33);
            IVattack    = r.Next(33);
            IVdefense   = r.Next(33);
            IVspattack  = r.Next(33);
            IVspdefense = r.Next(33);
            IVspeed     = r.Next(33);
        }

        private void calculateStats()
        {
            HP          = calculateHP(IVHP, species.HP);
            attack      = calculateStat(IVattack, species.attack);
            defense     = calculateStat(IVdefense, species.defense);
            spattack    = calculateStat(IVspattack, species.spattack);
            spdefense   = calculateStat(IVspdefense, species.spdefense);
            speed       = calculateStat(IVspeed, species.speed);
        }

        private int calculateStat(int iv, int baseStat)
        {
            int temp = iv + (2 * baseStat); // + EV/4
            temp = ((temp * level) / 100) + 5;
            return temp; // x Nature?
        }

        private int calculateHP(int iv, int baseStat)
        {
            int temp = iv + (2 * baseStat) + 100; // + EV/4
            temp = ((temp * level) / 100) + 10;
            return temp; // x Nature?
        }

        private void learnMovesUntilLevel()
        {
            
        }

        public void fullHeal()
        {
            currentHP = HP;
            // set volatile status to {}
            // set moves to full PP
        }

        public void initForBattle()
        {
            // resetStages();
            // set volatile status to null
        }

        public override string ToString()
        {
            return species.name + " lvl: " + level;
        }

    }
}
