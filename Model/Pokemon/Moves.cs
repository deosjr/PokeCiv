using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCiv.Model.Pokemon
{
    class Moves
    {
        private static Dictionary<string, int> internalNames = new Dictionary<string, int>();
        private static List<Move> moves = new List<Move>();

        static Moves()
        {
            load_moves();
        }

        private static void load_moves()
        {

            string datapath = "../../Data/moves.txt";
            var lines = File.ReadAllLines(datapath);
            foreach (var line in lines)
            {
                string[] features = line.Split(',');
                Move move = new Move(features);
                moves.Add(move);
                internalNames.Add(features[1], move.id);
            }
        }

        public static Move getType(string name) 
        {
            return moves[internalNames[name] - 1];
        }

        public static Move getType(int id)
        {
            return moves[id - 1];
        }
    }
}
