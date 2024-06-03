using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Final_Project_Chess
{
    internal class Piece //THP, NCB, creates specification for piece traits, and capture function
    {
        private GameScreen f;
        protected int currentRow;
        protected char currentCol;
        protected char pieceColor; // 'b' or 'w' b for black, w for white
        protected bool kingInCheck; // is the king that belongs to the piece's color, in check
        public List<Tuple<int, char>> legalMoves;
        public Piece(int row, char col, char color)
        {
            currentRow = row;
            currentCol = col;
            pieceColor = color;
            legalMoves = new List<Tuple<int, char>>();
        }
        public int getRow() { return currentRow; }
        public char getCol() { return currentCol; }
        public char getColor() { return pieceColor; }
        public void setRow(int i)
        {
            currentRow = i;
        }
        public void setCol(char c)
        {
            currentCol = c;
        }// Child class will have bool canMove(string position) 
        public void Capture(Form f)
        {
            string s;
            s = currentCol.ToString() + currentRow.ToString() + "Label";
            Control[] foundControls = f.Controls.Find(s, true);
            if (foundControls.Length > 0 && foundControls[0] is Label)
            {
                Label l = (Label)foundControls[0];
                l.Text = " ";
            }// Deletes itself from board
        }
    }
}
