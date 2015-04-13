using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using PokeCiv.View;
using PokeCiv.Model.Battle;
using PokeCiv.Model.World;
using PokeCiv.Model.World.Tiles;
using PokeCiv.Model;


namespace PokeCiv.Controllers
{
    // This Controller handles exchanges between Model and View
    public class Controller
    {

        public BattleView battleView { get; set; }
        public MapView mapView { get; set; }
        public PokedexView pokedexView { get; set; }
        public IView currentView { private get; set; }
        public Battle Battle { private get; set; }
        public Map Map { private get; set; }
        public Player Player { get; set; }

        public Controller(Player player)
        {
            Player = player;
        }

        public void message(string msg)
        {
            currentView.message(msg);
        }

        public int selectMove()
        {
            return battleView.selectMove();
        }

        public void switchFromBattleToMap()
        {
            if (battleView.InvokeRequired)
            {
                battleView.Invoke(new MethodInvoker(delegate { battleView.Close(); }));
            }            
            mapView.Show();
            currentView = mapView;
        }

        public void switchFromMapToBattle(Player opponent)
        {
            mapView.Hide();
            Battle = new Battle(this, Player, opponent);
            battleView = new BattleView(Battle);
            currentView = battleView;
            new Thread(runView).Start();
            Battle.fight();
        }

        public void switchFromMapToPokeDex()
        {          
            pokedexView.Show();
            currentView = pokedexView;
        }

        public void switchFromPokedexToMap()
        {
            //if (pokedexView.InvokeRequired)
            //{
                pokedexView.Invoke(new MethodInvoker(delegate { pokedexView.Close(); }));
            //}
            mapView.Show();
            currentView = mapView;
        }

        public Tile[][] GetGrid()
        {
            return Map.Grid;
        }

        public void runView()
        {
            Application.Run(currentView);
        }

        public void playerMoveUp()
        {
            playerMove(0, -1, "ctrl-up");
        }

        public void playerMoveDown()
        {
            playerMove(0, 1, "ctrl-down");
        }

        public void playerMoveLeft()
        {
            playerMove(-1, 0, "ctrl-left");
        }

        public void playerMoveRight()
        {
            playerMove(1, 0, "ctrl-right");
        }

        private void playerMove(int xdiff, int ydiff, string debug)
        {
            if (Map.playerMove(xdiff, ydiff))
            {
                Tile currentTile = Map.Grid[Player.Y][Player.X];
                mapView.UpdatePlayer(currentTile);
                Console.WriteLine(debug);
                currentTile.stepOn(this);
            }
        }

    }
}