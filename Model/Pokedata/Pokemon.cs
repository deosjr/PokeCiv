using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokeCiv.Model.Battle.Status;
using PokeCiv.Model.Battle.Status.NonVolatile;
using PokeCiv.Model.Battle.Status.Volatile;
using PokeCiv.Model.Battle;
using System.Reflection;

namespace PokeCiv.Model.Pokedata
{
    public class Pokemon
    {

        public int Level                { get; private set; }
        public Species species          { get; private set; }
        public string Name              { get; private set; } 
        public int CurrentHP            { get; set; }
        public int PreviousXPLevelReq   { get; private set; }
        public int CurrentXP            { get; private set; }
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

        public int AccuracyStat         { get; set; } 
        public int EvasionStat          { get; set; }
        public int AttackStat           { get; set; }
        public int DefenseStat          { get; set; }
        public int SPAttackStat         { get; set; }
        public int SPDefenseStat        { get; set; }
        public int SpeedStat            { get; set; }

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
            CurrentXP = PreviousXPLevelReq;
            generateIV();
            calculateStats();
            learnMovesUntilLevel();
            CurrentHP = HP;
        }

        public void setXPBoundaries()
        {
            Tuple<int, int> XPinfo = Experience.lookupXP(this);
            PreviousXPLevelReq = XPinfo.Item1;
            NextXPLevelReq = XPinfo.Item1 + XPinfo.Item2;
        }

        private void generateIV()
        {
            Random r = Mechanics.random;
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

        private void learnMovesAtLevel()
        {
            List<PokemonMove> moves;
            species.MovesLearnable.TryGetValue(Level, out moves);
            if (moves == null)
            {
                return;
            }
            foreach (PokemonMove m in moves)
            {
                learnMove(m);
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
            // TODO: Delete one move to make room?
        }

        public int takeDamage(int damage)
        {
            int temp = CurrentHP;
            CurrentHP = Math.Max(0, CurrentHP - damage);
            return temp - CurrentHP;
        }

        public void heal(int amount)
        {
            CurrentHP = Math.Min(HP, CurrentHP + amount);
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

        public void resetStages()
        {
            AccuracyStat = 0;
            EvasionStat = 0;
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

        public void setStatus(Battle.Battle battle, string statuscode)
        {
            if (NonVolatile == null)
            {
                NonVolatile = PokemonStatus.getNonVolatile(statuscode);
                battle.message(Name + NonVolatile.getInitMessage());
            }

        }

        public bool checkNonVolatileStatus(string statuscode)
        {
            if (NonVolatile == null)
            {
                return false;
            }
            return statuscode.Equals(NonVolatile.statuscode);
        }

        public void addStatus(Battle.Battle battle, string statuscode)
        {

        }

        public void clearNonVolatileStatus()
        {
            NonVolatile = null;
        }

        public bool nonVolatilePreAttack(Battle.Battle battle)
        {
            return NonVolatile.preAttack(battle, this);
        }

        public void nonVolatilePostAttack(Battle.Battle battle)
        {
            NonVolatile.postAttack(battle, this);
        }

        public void gainXP(Battle.Battle battle, int xp)
        {
            CurrentXP += xp;
            battle.message(Name + " gained " + xp + " XP!");
            while (levelUp())
            {
                battle.message(Name + " grew to level " + Level.ToString() + "!");
                string old_name = Name;
                if (evolve())
                {
                    //TODO: let view know that pokemon-image has changed!
                    battle.message(old_name + " evolved into " + Name + '!');
                }
                learnMovesAtLevel();
            }
        }

        public bool levelUp()
        {
            if (Level == 100)
            {
                return false;
            }

            if (CurrentXP > NextXPLevelReq)
            {
                Level++;
                if (Level != 100)
                {
                    setXPBoundaries();
                }
                return true;
            }
            return false;
        }

        private bool evolve()
        {
            //TODO: non-standard evolutions
            foreach (Evolution e in species.Evolutions) {
                if (e.type == "Level" && Convert.ToInt32(e.info) == Level)
                {
                    species = PokemonFactory.getSpecies(e.name);
                    calculateStats();
                    Name = species.Name;
                    return true;
                }
            }
            return false;
        }

        private int calculateStatIncrease(int stat, int amount)
        {
            return Math.Min(6, stat + amount);
        }

        private int calculateStatDecrease(int stat, int amount)
        {
            return Math.Max(-6, stat - amount);
        }

        public string increaseStat(string stat, int amount)
        {
            string statname = stat + "Stat";
            PropertyInfo propertyInfo = this.GetType().GetProperty(statname);
            int currentValue = (int) propertyInfo.GetValue(this);
            if (currentValue == 6)
            {
                return Name + "'s " + stat + " won't go any higher!";
            }
            int change = calculateStatIncrease(currentValue, amount);
            propertyInfo.SetValue(this, change, null);
            return Name + "'s " + stat + (amount > 1 ? " sharply" : "") + " rose!";
        }

        public string decreaseStat(string stat, int amount)
        {
            string statname = stat + "Stat";
            PropertyInfo propertyInfo = this.GetType().GetProperty(statname);
            int currentValue = (int)propertyInfo.GetValue(this);
            int change = calculateStatDecrease(currentValue, amount);
            propertyInfo.SetValue(this, change, null);
            return Name + "'s " + stat + (amount > 1 ? " sharply" : "") + " fell!";
        }

        public void swapStats(Pokemon target, string stat)
        {
            string statname = stat + "Stat";
            PropertyInfo propertyInfoSource = this.GetType().GetProperty(statname);
            PropertyInfo propertyInfoTarget = target.GetType().GetProperty(statname);
            int sourceStatValue = (int)this.GetType().GetProperty(statname).GetValue(this);
            int targetStatValue = (int)target.GetType().GetProperty(statname).GetValue(target);
            propertyInfoSource.SetValue(this, targetStatValue, null);
            propertyInfoTarget.SetValue(target, sourceStatValue, null);
        }

        public override string ToString()
        {
            return species.Name + " lvl: " + Level;
        }

    }
}
