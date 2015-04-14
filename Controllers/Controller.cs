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
            Battle = new Battle(this, Player, opponent, Map.mapType);
            battleView = new BattleView(Battle);
            currentView = battleView;
            new Thread(runView).Start();
            Battle.fight();
        }

        public void switchFromMapToPokeDex()
        {          
            pokedexView.Show();
            mapView.Hide();
            currentView = pokedexView;
        }

        public void switchFromPokedexToMap()
        {
            mapView.Show();
            pokedexView.Hide();
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

        public bool playerMoveUp()
        {
            return playerMove(0, -1);
        }

        public bool playerMoveDown()
        {
            return playerMove(0, 1);
        }

        public bool playerMoveLeft()
        {
            return playerMove(-1, 0);
        }

        public bool playerMoveRight()
        {
            return playerMove(1, 0);
        }

        private bool playerMove(int xdiff, int ydiff)
        {
            if (Map.playerMove(xdiff, ydiff))
            {
                Tile currentTile = Map.Grid[Player.Y][Player.X];
                mapView.UpdatePlayer(currentTile);
                currentTile.stepOn(this);
                return true;
            }
            return false;
        }

    }
}