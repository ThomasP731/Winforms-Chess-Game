using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_Chess
{
    internal class Queen : Piece //NCB, JP, THP, ER, child class of piece, and other class specific functions
    {
        public Queen(int row, char col, char color) : base(row, col, color)
        {
            //no unique property, previous method not refactored
        }
        public bool canMove(int row, int col)
        {
            return false;
        }
    }
}
