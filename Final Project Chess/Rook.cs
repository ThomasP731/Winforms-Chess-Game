using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project_Chess
{
    internal class Rook : Piece //NCB, JP, THP, ER, child class of piece, redefined hasMoved boolean, and other class specific functions
    {
        private List<Label> moveControlList = new List<Label>();
        public bool hasMoved;
        public Rook(int row, char col, char color, bool hasMoved = false) : base(row, col, color)
        {
            this.hasMoved = hasMoved;
        }
        public bool canMove(int row, int col)
        {
            return false;
        }
    }
}
