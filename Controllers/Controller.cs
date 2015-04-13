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

        public BattleView battleView { get; set; }
        public MapView mapView { get; set; }
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
            battleView.Hide();
            mapView.Show();
            currentView = mapView;
        }

        public void switchFromMapToBattle()
        {
            mapView.Hide();
            battleView.Show();
            currentView = battleView;
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
                currentTile.stepOn();
            }
        }

    }
}