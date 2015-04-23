using PokeCiv.Controllers;
using PokeCiv.Model.Pokedata;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCiv.Model.World.Tiles.TileItems
{
    // WE DONT WANT TO KEEP THIS IN!
    // TRAINERS ARE PLAYERS, NOT TILEITEMS
    class Trainer : TileItem
    {

        Player trainer = new Player("Team Rocket Grunt");

        public Trainer()
        {
            imgsrc = "../../Data/Graphics/Tiles/trainertile";
        }

        public override void stepOn(Controller c)
        {
            trainer.ClearTeam();
            trainer.AddToTeam(PokemonFactory.getPokemon(10, Mechanics.random.Next(650)));
            c.switchFromMapToBattle(trainer);
        }
    }
}
