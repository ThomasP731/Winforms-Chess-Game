using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Final_Project_Chess
{
    internal class Knight : Piece //NCB, JP, THP, ER, child class of piece, and other class specific functions
    {
        private List<Label> moveControlList = new List<Label>();
        public Knight(int row, char col, char color) : base(row, col, color)
        {
            //no unique property, previous method not refactored
        }
        public bool canMove(int row, int col)
        {
            return false;
        }
    }
}
