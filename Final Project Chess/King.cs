using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_Chess
{
    internal class King : Piece //THP, child class of piece, redefined hasMoved boolean, and other class specific functions
    {
        public List<Tuple<int, char>> castlingMoves = new List<Tuple<int, char>>();
        public Tuple<int, char> startingSquare;
        public King(int row, char col, char color) : base(row, col, color) //specifies postition of king per color
        {
            startingSquare = Tuple.Create(row, col);
            if (color == 'w')
            {
                castlingMoves.Add(Tuple.Create(1, 'g'));
                castlingMoves.Add(Tuple.Create(1, 'c'));
            }
            else
            {
                castlingMoves.Add(Tuple.Create(8, 'g'));
                castlingMoves.Add(Tuple.Create(8, 'c'));
            }
        }
        public bool hasMoved = false;
        public bool canMove(int row, int col) //unfinished, promotes object oriented programming.
        {
            // If it's beyond the board's height or width, return false
            // If same color piece is occupying chosen position, return false
            // If king would still be in check, return false
            return false;
        }
        // Returns a tuple of positions that is within a given piece's moveset
        public List<Tuple<int, char> > returnPotentialMoves() //makes a list of potential moves, unfinished
        { // Originally canMove() in ChessGame.cs was meant to be a temporary proof of concept
          // Ideally we would switch over to generating potentialMoves then verifying those moves in ChessGame that there wasn't a piece in the way and that king wasn't in check
            List<Tuple<int, char>> potentialMoves = new List<Tuple<int, char>>();
            
            int[] k1 = new int[] { 1, 1 };
            int[] k2 = new int[] { 1, 0 };
            int[] k3 = new int[] { 1, -1 };
            int[] k4 = new int[] { 0, -1 };
            int[] k5 = new int[] { 0, 1 };
            int[] k6 = new int[] { -1, 1 };
            int[] k7 = new int[] { -1, 0 };
            int[] k8 = new int[] { -1, -1 };

            int[][] kingMoves = { k1, k2, k3, k4, k5, k6, k7, k8 };

            foreach (int[] kingMove in kingMoves)
            {
                int newRow = currentRow + kingMove[0];
                int newCol = ChessGame.ColumnCharToInt(currentCol) + kingMove[1];
                if (newRow > 8 || newRow < 1)
                {
                    continue;
                }
                if (newCol > 8 || newCol < 1)
                {
                    continue;
                }
                Tuple<int,char> temp = Tuple.Create(currentRow + kingMove[0], ChessGame.IntToColumnChar(newCol));
                potentialMoves.Add(temp);
            }

            return potentialMoves;
        }
    }
}
