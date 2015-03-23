using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokeCiv.Model.Battle.Status;

namespace PokeCiv.Model.Pokedata
{
    public class Pokemon
    {

        public int Level                { get; set; }
        public Species species          { get; private set; }
        public string Name              { get; private set; } 
        public int CurrentHP            { get; private set; }
        public int PreviousXPLevelReq   { get; private set; }
        public int CurrentXP            { get; set; }
        public int NextXPLevelReq       { get; private set; }

        public int HP                   { get; private set; }
        public int Attack               { get; private set; }
        public int Defense              { get; private set; }
        public int SPAttack             { get; private set; }
        public int SPDefense            { get; private set; }
        public int Speed                { get; private set; } 

        private int IVHP;
        private int IVattack;
        private int IVdefense;
        private int IVspattack;
        private int IVspdefense;
        private int IVspeed;

        public int Accuracy             { get; private set; } 
        public int Evasion              { get; private set; }
        public int AttackStat           { get; private set; }
        public int DefenseStat          { get; private set; }
        public int SPAttackStat         { get; private set; }
        public int SPDefenseStat        { get; private set; }
        public int SpeedStat            { get; private set; }

        public Move[] Moves { get; private set; }
        public NonVolatileCondition NonVolatile { get; private set; }
        public List<VolatileCondition> VolatileConditions { get; private set; }

        public Pokemon(int level, Species species)
        {
            Level = level;
            this.species = species;
            this.Name = species.Name;
            Moves = new Move[4];
            VolatileConditions = new List<VolatileCondition>();
            setXPBoundaries();
            generateIV();
            calculateStats();
            learnMovesUntilLevel();
            CurrentHP = HP;
        }

        public void setXPBoundaries()
        {
            Tuple<int, int> XPinfo = Experience.lookupXP(this);
            PreviousXPLevelReq = CurrentXP = XPinfo.Item1;
            NextXPLevelReq = XPinfo.Item1 + XPinfo.Item2;
        }

        private void generateIV()
        {
            Random r = new Random();
            IVHP = r.Next(33);
            IVattack = r.Next(33);
            IVdefense = r.Next(33);
            IVspattack = r.Next(33);
            IVspdefense = r.Next(33);
            IVspeed = r.Next(33);
        }

        private void calculateStats()
        {
            HP = calculateHP(IVHP, species.HP);
            Attack = calculateStat(IVattack, species.Attack);
            Defense = calculateStat(IVdefense, species.Defense);
            SPAttack = calculateStat(IVspattack, species.SPAttack);
            SPDefense = calculateStat(IVspdefense, species.SPDefense);
            Speed = calculateStat(IVspeed, species.Speed);
        }

        private int calculateStat(int iv, int baseStat)
        {
            int temp = iv + (2 * baseStat); // + EV/4
            temp = ((temp * Level) / 100) + 5;
            return temp; // x Nature?
        }

        private int calculateHP(int iv, int baseStat)
        {
            int temp = iv + (2 * baseStat) + 100; // + EV/4
            temp = ((temp * Level) / 100) + 10;
            return temp; // x Nature?
        }

        private void learnMovesUntilLevel()
        {
            var sorted = from entry in species.MovesLearnable orderby entry.Key ascending select entry;
            foreach (KeyValuePair<int, List<PokemonMove>> kv in sorted)
            {
                if (kv.Key > Level)
                {
                    break;
                }
                foreach (PokemonMove m in kv.Value)
                {
                    learnMove(m);
                }
            }
        }

        private void learnMove(PokemonMove m)
        {
            Move move = new Move(m, m.PP);
            for (int i = 0; i < Moves.Length; i++)
            {
                if (Moves[i] == null)
                {
                    Moves[i] = move;
                    return;
                }
            }
        }

        public int takeDamage(int damage)
        {
            int temp = CurrentHP;
            CurrentHP = Math.Max(0, CurrentHP - damage);
            return temp - CurrentHP;
        }

        public void fullHeal()
        {
            CurrentHP = HP;
            NonVolatile = null;
            foreach (Move move in Moves)
            {
                if (move != null)
                {
                    move.currentPP = move.totalPP;
                }
            }
        }

        public void initForBattle()
        {
            resetStages();
            VolatileConditions = new List<VolatileCondition>();
        }

        private void resetStages()
        {
            Accuracy = 0;
            Evasion = 0;
            AttackStat = 0;
            DefenseStat = 0;
            SPAttackStat = 0;
            SPDefenseStat = 0;
            SpeedStat = 0;
        }

        public bool hasPPLeft()
        {
            foreach (Move m in Moves)
            {
                if (m != null && m.currentPP > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public void setStatus(string statuscode)
        {
            if (NonVolatile == null)
            {
                NonVolatile = PokemonStatus.getNonVolatile(statuscode);
                Console.WriteLine(Name + NonVolatile.getInitMessage());
            }

        }

        public void addStatus(string statuscode)
        {

        }

        public void clearNonVolatileStatus()
        {
            NonVolatile = null;
        }

        public bool nonVolatilePreAttack()
        {
            return NonVolatile.preAttack(this);
        }

        public void nonVolatilePostAttack()
        {
            NonVolatile.postAttack(this);
        }

        public override string ToString()
        {
            return species.Name + " lvl: " + Level;
        }

    }
}
