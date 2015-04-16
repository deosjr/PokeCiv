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
using PokeCiv.Model.Pokedata;


namespace PokeCiv.Controllers
{
    // This Controller handles exchanges between Model and View
    public class Controller
    {

        public BattleView battleView { get; set; }
        public MapView mapView { get; set; }
        public PokedexView pokedexView { get; set; }
        public TeamView teamView { get; set; }
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

        public void switchPokemon()
        {
            if (Player.BlackOut())
            {
                switchFromBattleToMap();
                return;
            }
            // This now hard-terminates the battle while its still running.
            // Could this be done more elegantly?
            // TODO: battle-wide parameters such as weather, leech seed etc need to be passed
            Player opponent = Battle.player2;
            Pokemon oppPokemon = Battle.P2;
            if (battleView.InvokeRequired)
            {
                battleView.Invoke(new MethodInvoker(delegate { battleView.Close(); }));
            }
            teamView = new TeamView(this);
            Pokemon newPokemon = teamView.switchPokemon();
            continueBattle(opponent, newPokemon, oppPokemon);
        }

        public void switchFromBattleToMap()
        {
            if (battleView.InvokeRequired)
            {
                battleView.Invoke(new MethodInvoker(delegate { battleView.Close(); }));
            }            
            mapView.Show();
            currentView = mapView;
            foreach (Pokemon p in Player.Team)
            {
                string oldName = p.Name;
                if (p.evolve())
                {
                    message(oldName + " evolved into " + p.Name + "!");
                }
            }
        }

        public void switchFromMapToBattle(Player opponent)
        {
            mapView.Hide();
            startBattle(opponent);
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

        private void startBattle(Player opponent)
        {
            Pokemon p1 = Battle.getFirstHealthy(Player);
            if (p1 == null)
            {
                message("You don't have any pokemon!");
                return;
            }
            Pokemon p2 = Battle.getFirstHealthy(opponent);
            Battle = new Battle(this, Player, opponent, p1, p2, Map.mapType, true);
            battleView = new BattleView(Battle);
            currentView = battleView;
            new Thread(runView).Start();
            Battle.fight();
        }

        private void continueBattle(Player opponent, Pokemon p1, Pokemon p2)
        {
            Battle = new Battle(this, Player, opponent, p1, p2, Map.mapType, false);
            battleView = new BattleView(Battle);
            currentView = battleView;
            new Thread(runView).Start();
            Battle.fight();
        }

        public Tile[,] GetGrid()
        {
            return Map.Grid;
        }

        public void runView()
        {
            Application.Run(currentView);
        }

        public bool playerMoveUp()
        {
            return playerMove(0, -1, "UP");
        }

        public bool playerMoveDown()
        {
            return playerMove(0, 1, "DOWN");
        }

        public bool playerMoveLeft()
        {
            return playerMove(-1, 0, "LEFT");
        }

        public bool playerMoveRight()
        {
            return playerMove(1, 0, "RIGHT");
        }

        private bool playerMove(int xdiff, int ydiff, string facing)
        {
            Player.Facing = facing;
            if (Map.playerMove(xdiff, ydiff))
            {
                Tile currentTile = Map.Grid[Player.Y, Player.X];
                mapView.UpdatePlayer(currentTile);
                currentTile.stepOn(this);
                return true;
            }
            return false;
        }

    }
}