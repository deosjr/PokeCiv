using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PokeCiv.Model.Battle; // TODO: remove this dependency

namespace PokeCiv.Model.Pokedata
{
    public class Moves
    {
        private static Dictionary<string, int> internalNames = new Dictionary<string, int>();
        private static List<PokemonMove> moves = new List<PokemonMove>();

        static Moves()
        {
            loadMoves();
            printMovesImplemented();
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

        // DEBUG:
        private static void printMovesImplemented()
        {
            int implemented = 0;
            int numMoves = 0;
            foreach (PokemonMove m in moves)
            {
                numMoves++;
                if (MoveFunctions.isImplemented(m.internalName))
                {
                    implemented++;
                }
            }
            Console.WriteLine("Percentage of moves implemented: " + (implemented / (double)numMoves));
        }
    }
}
