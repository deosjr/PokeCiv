using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PokeCiv.View;
using PokeCiv.Model.Battle;
using PokeCiv.Model.World;
using PokeCiv.Model.World.Tiles;
using PokeCiv.Model;


namespace PokeCiv.Controllers
{
    // This Controller handles messages between Model and View
    public class Controller
    {

        public IView View { private get; set; }
        public Battle Battle { private get; set; }
        public Map Map { private get; set; }
        public Player Player { get; set; }

        public Controller(Player player)
        {
            Player = player;
        }

        public void message(string msg)
        {
            View.message(msg);
        }

        public int selectMove()
        {
            return View.selectMove();
        }

        public Tile[][] GetGrid()
        {
            return Map.Grid;
        }

        public void runView()
        {
            Application.Run(View);
        }

        public void playerMoveUp()
        {
            if (Map.playerMove(0, -1))
            {
                View.UpdatePlayer();
                Console.WriteLine("ctrl-up");
            }
        }

        public void playerMoveDown()
        {
            if (Map.playerMove(0, 1))
            {
                View.UpdatePlayer();
                Console.WriteLine("ctrl-down");
            }
        }

        public void playerMoveLeft()
        {
            if (Map.playerMove(-1, 0))
            {
                View.UpdatePlayer();
                Console.WriteLine("ctrl-left");
            }
        }

        public void playerMoveRight()
        {
            if (Map.playerMove(1, 0))
            {
                View.UpdatePlayer();
                Console.WriteLine("ctrl-right");
            }
        }

    }
}