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

        public int accuracy;
        public int evasion;
        public int attackStat;
        public int defenseStat;
        public int spattackStat;
        public int spdefenseStat;
        public int speedStat;

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
            var sorted = from entry in species.movesLearnable orderby entry.Key ascending select entry;
            foreach(KeyValuePair<int, List<PokemonMove>> kv in sorted)
            {
                if (kv.Key > level)
                {
                    break;
                }
                foreach(PokemonMove m in kv.Value)
                {
                    learnMove(m);
                }
            }
        }

        private void learnMove(PokemonMove m)
        {
            Move move = new Move(m, m.PP);
            for (int i = 0; i < moves.Length; i++)
            {
                if (moves[i] == null)
                {
                    moves[i] = move;
                    return;
                }
            }
        }

        public int takeDamage(int damage)
        {
            int temp = currentHP;
            currentHP = Math.Max(0, currentHP - damage);
            return temp - currentHP;
        }

        public void fullHeal()
        {
            currentHP = HP;
            // set volatile status to {}
            // set moves to full PP
        }

        public void initForBattle()
        {
            resetStages();
            // set volatile status to null
        }

        private void resetStages()
        {
            accuracy = 0;
            evasion = 0;
            attackStat = 0;
            defenseStat = 0;
            spattackStat = 0;
            spdefenseStat = 0;
            speedStat = 0;
        }

        public bool hasPPLeft()
        {
            foreach(Move m in moves)
            {
                if (m != null && m.currentPP > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            return species.name + " lvl: " + level;
        }

    }
}
