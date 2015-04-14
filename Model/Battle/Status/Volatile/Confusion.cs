using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokeCiv.Model.Pokedata;

namespace PokeCiv.Model.Battle.Status.Volatile
{
    class Confusion : VolatileCondition
    {

        private int timer;

        public Confusion()
        {
            timer = Mechanics.random.Next(1,5);
        }

        public override bool preAttack(Battle battle, Pokemon pokemon)
        {
            battle.message(pokemon.Name + " is confused!");
            timer--;
            if (timer == 0)
            {
                pokemon.removeVolatileStatus(this);
                battle.message(pokemon.Name + " snapped out of its confusion!");
                return false;
            }
            if (Mechanics.random.NextDouble() < 0.5)
            {
                battle.message("It hurt itself in its confusion!");
                
                int damage = 0;
                double Crit, T;
                // TODO: TYPELESS ATTACK
                BattleMove move = new BattleMove(pokemon, pokemon, Moves.getMove("POUND"), 0);
                CombatMechanics.determineDamage(move, out damage, out Crit, out T);
                pokemon.takeDamage(damage);
                return true;
            }
            return false;
        }

        public override string getInitMessage()
        {
            return " became confused!";
        }

    }
}
