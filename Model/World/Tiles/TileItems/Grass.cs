using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

using PokeCiv.Controllers;
using PokeCiv.Model.Pokedata;

namespace PokeCiv.Model.World.Tiles.TileItems
{
    class Grass : TileItem
    {

        Player wildPokemon = new Player("WILD_POKEMON");
        ArrayList encounters;
        double p;

        public Grass(ArrayList encounters, double p)
        {
            this.encounters = encounters;
            this.p = p;
            imageSrc = "../../Data/Graphics/Tiles/gras.png";
        }
            
        public override void stepOn(Controller c)
        {
            if (Mechanics.random.NextDouble() < p)
            {
                double r = Mechanics.random.NextDouble();
                double temp = 0.0;

                foreach (Encounter e in encounters)
                {
                    if (r < e.p + temp)
                    {
                        wildPokemon.ClearTeam();
                        wildPokemon.AddToTeam(e.getPokemon());
                        c.switchFromMapToBattle(wildPokemon);
                        break;
                    }
                    else
                    {
                        temp += e.p;
                    }
                }
            }
        }

    }
}
