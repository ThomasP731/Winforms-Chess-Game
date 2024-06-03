using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project_Chess
{
    internal class Pawn : Piece //NCB, THP, created unique properties for pawns
    {
        private bool firstMove = true;
        private List<String> moveList = new List<String>();
        private List<Label> moveControlList = new List<Label>();
        public bool movedTwoLastTurn = false;
        public List<Tuple<int, char>> enPassantSquares = new List<Tuple<int, char>>();
        public Pawn(int row, char col, char color) : base(row, col, color)
        {
            //no unique property, previous method not refactored
        }
        public bool canMove(int row, int col)
        {
            return false;
        }
    }
}
