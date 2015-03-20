using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCiv.Model.Pokedata
{
    public class Moves
    {
        private static Dictionary<string, int> internalNames = new Dictionary<string, int>();
        private static List<PokemonMove> moves = new List<PokemonMove>();

        static Moves()
        {
            loadMoves();
        }

        private static void loadMoves()
        {

            string datapath = "../../Data/moves.txt";
            var lines = File.ReadAllLines(datapath);
            foreach (var line in lines)
            {
                string[] features = line.Split(',');
                PokemonMove move = new PokemonMove(features);
                moves.Add(move);
                internalNames.Add(features[1], move.id);
            }
        }

        public static PokemonMove getMove(string name)
        {
            return moves[internalNames[name] - 1];
        }

        public static PokemonMove getMove(int id)
        {
            return moves[id - 1];
        }
    }
}
