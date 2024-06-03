using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project_Chess
{
    internal class ChessGame
    {
        // ChessGame is created every time a new chess game is started.
        private GameScreen GameScreen;
        public List<Piece> pieces = new List<Piece>(); // This will store all the initial pieces
        private char[] columnList = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
        public ChessGame()
        {
            InitialGameSetup();
        }
        private void InitialGameSetup() //THP creates all pieces
        {
            // Will create new Pawn 16 times, 8 for white, 8 for black

            for (int i = 0; i < 8; i++)
            {
                Pawn pawnWhite = new Pawn(2, columnList[i], 'w');
                pieces.Add(pawnWhite);
            }
            for (int i = 0; i < 8; i++)
            {
                Pawn pawnBlack = new Pawn(7, columnList[i], 'b');
                pieces.Add(pawnBlack);
            }
            // Will create new Rook 4 times, 2 for white, 2 for black

            Rook rookWhite1 = new Rook(1, 'a', 'w');
            Rook rookWhite2 = new Rook(1, 'h', 'w');
            pieces.Add(rookWhite1);
            pieces.Add(rookWhite2);

            Rook rookBlack1 = new Rook(8, 'a', 'b');
            Rook rookBlack2 = new Rook(8, 'h', 'b');
            pieces.Add(rookBlack1);
            pieces.Add(rookBlack2);

            // Will create new Bishop 4 times, 2 for white, 2 for black

            Bishop bishopWhite1 = new Bishop(1, 'c', 'w');
            Bishop bishopWhite2 = new Bishop(1, 'f', 'w');
            pieces.Add(bishopWhite1);
            pieces.Add(bishopWhite2);

            Bishop bishopBlack1 = new Bishop(8, 'c', 'b');
            Bishop bishopBlack2 = new Bishop(8, 'f', 'b');
            pieces.Add(bishopBlack1);
            pieces.Add(bishopBlack2);

            // Will create new Knight 4 times, 2 for white, 2 for black

            Knight whiteKnight1 = new Knight(1, 'b', 'w');
            Knight whiteKnight2 = new Knight(1, 'g', 'w');
            pieces.Add(whiteKnight1);
            pieces.Add(whiteKnight2);

            Knight blackKnight1 = new Knight(8, 'b', 'b');
            Knight blackKnight2 = new Knight(8, 'g', 'b');
            pieces.Add(blackKnight1);
            pieces.Add(blackKnight2);

            // Will create new king 2 times, 1 for white, 1 for black

            King whiteKing = new King(1, 'e', 'w');
            pieces.Add(whiteKing);

            King blackKing = new King(8, 'e', 'b');
            pieces.Add(blackKing);

            //Will create new queen 2 times, 1 for white, 1 for black
            Queen whiteQueen = new Queen(1, 'd', 'w');
            pieces.Add(whiteQueen);

            Queen blackQueen = new Queen(8, 'd', 'b');
            pieces.Add(blackQueen);

            createLegalMoves();
        }//THP

        public Piece getPieceFromLabel(int row, char col) //NCB, gets the col and row of each piece
        {
            for (int i = 0; i < pieces.Count; i++)
            {
                Piece piece = pieces[i];
                if (piece.getRow() == row && piece.getCol() == col)
                {
                    return piece;
                }
            }
            return null;
        }//NCB

        // Method created by THP, used to easily convert columns into a correspond integer
        public static int ColumnCharToInt(char c)
        {
            switch (c)
            {
                case 'a':
                    return 1;
                case 'b':
                    return 2;
                case 'c':
                    return 3;
                case 'd':
                    return 4;
                case 'e':
                    return 5;
                case 'f':
                    return 6;
                case 'g':
                    return 7;
                case 'h':
                    return 8;
                default:
                    throw new ArgumentOutOfRangeException("Column Char must be between a-h for ColumnCharToInt method");
            }
        }//THP 
        public static char IntToColumnChar(int i) //// Method created by THP, Used to convert integer to corresponding column character
        {
            switch (i)
            {
                case 1:
                    return 'a';
                case 2:
                    return 'b';
                case 3:
                    return 'c';
                case 4:
                    return 'd';
                case 5:
                    return 'e';
                case 6:
                    return 'f';
                case 7:
                    return 'g';
                case 8:
                    return 'h';
                default:
                    throw new ArgumentOutOfRangeException("Int must be between 1-8 for IntToColumnChar method");
            }
        }//THP
        public Piece getFirstPieceInLine(int row, char col, int upTransformation, int rightTransformation) // Method created by THP, returns first piece in line
        {
            for (int i = 1; i < 8; i++)
            {
                int r = upTransformation * i + row;
                int c = rightTransformation * i + ColumnCharToInt(col);
                if (r > 8 || r < 1)
                {
                    break;
                }
                if (c > 8 || c < 1)
                {
                    break;
                }
                Piece pieceInLine = getPieceFromLabel(r, IntToColumnChar(c));
                if (pieceInLine != null)
                {
                    return pieceInLine;
                }
            }
            return null;
        } //THP
        public bool IsKingInCheck(char kingColor) // Method created by THP, Checks if king is in check with given pieces, pawn currently is not working
        {

            King king = null;
            foreach (Piece piece in pieces)
            {
                if (piece is King && piece.getColor() == kingColor)
                {
                    king = (King)piece;
                }
            }

            int row = king.getRow();
            char col = king.getCol();

            // Most of checking if a king is in check boils down to:
            //      1. Choose a diagonal, horizontal, or vertical line starting at the king and continuing to the edge of the board
            //      2. Get the piece on the square, if null get the piece on the next square
            //      3. If the piece is not a rook, or bishop, or queen (depends on what type of line you're checking) then break loop, since any kind of check is blocked
            //      4. If the piece is a rook, or bishop or queen and there's nothing blocking it, return true
            //      5. Repeat for every vertical, horizontal, and diagonal line from the king
            // THP

            // up from king
            Piece p;
            p = getFirstPieceInLine(row, col, 1, 0);
            if (p != null && p.getColor() != kingColor)
            {
                if (p is Rook || p is Queen)
                {
                    return true;
                }
            }
            // down from king
            p = getFirstPieceInLine(row, col, -1, 0);
            if (p != null && p.getColor() != kingColor)
            {
                if (p is Rook || p is Queen)
                {
                    return true;
                }
            }

            // right from king
            p = getFirstPieceInLine(row, col, 0, 1);
            if (p != null && p.getColor() != kingColor)
            {
                if (p is Rook || p is Queen)
                {
                    return true;
                }
            }
            // left from king
            p = getFirstPieceInLine(row, col, 0, -1);
            if (p != null && p.getColor() != kingColor)
            {
                if (p is Rook || p is Queen)
                {
                    return true;
                }
            }
            // up and right from king
            p = getFirstPieceInLine(row, col, 1, 1);
            if (p != null && p.getColor() != kingColor)
            {
                if (p is Bishop || p is Queen)
                {
                    return true;
                }
            }
            // down and right from king
            p = getFirstPieceInLine(row, col, -1, 1);
            if (p != null && p.getColor() != kingColor)
            {
                if (p is Bishop || p is Queen)
                {
                    return true;
                }
            }
            // up and left from king
            p = getFirstPieceInLine(row, col, 1, -1);
            if (p != null && p.getColor() != kingColor)
            {
                if (p is Bishop || p is Queen)
                {
                    return true;
                }
            }
            // down and left from king
            p = getFirstPieceInLine(row, col, -1, -1);
            if (p != null && p.getColor() != kingColor)
            {
                if (p is Bishop || p is Queen)
                {
                    return true;
                }
            }

            // Horsey checks!
            int[] kn1 = new int[2] { 2, 1 };
            int[] kn2 = new int[2] { -2, 1 };
            int[] kn3 = new int[2] { 2, -1 };
            int[] kn4 = new int[2] { -2, -1 };
            int[] kn5 = new int[2] { 1, 2 };
            int[] kn6 = new int[2] { -1, 2 };
            int[] kn7 = new int[2] { 1, -2 };
            int[] kn8 = new int[2] { -1, -2 };
            int[][] knightChecks = new int[][] { kn1, kn2, kn3, kn4, kn5, kn6, kn7, kn8 };

            foreach (int[] knightCheck in knightChecks)
            {
                int r = knightCheck[0] + row;
                int c = knightCheck[1] + ColumnCharToInt(col);
                if (r > 8 || c > 8 || r < 1 || c < 1)
                {
                    continue; // Check if position is outside of board;
                }
                p = getPieceFromLabel(r, IntToColumnChar(c));
                if (p == null)
                {
                    continue;
                }
                if (p is Knight && p.getColor() != kingColor)
                {
                    return true;
                }
            }

            // Pawn checks
            // If king is white, then pawn checks will always be up one row and + or - one column
            if (kingColor == 'w')
            {
                if (row + 1 < 8 && ColumnCharToInt(col) + 1 < 8)
                {
                    p = getPieceFromLabel(row + 1, IntToColumnChar(ColumnCharToInt(col) + 1));

                    if (p != null && p.getColor() != kingColor && p is Pawn)
                    {
                        return true;
                    }
                }
                if (row + 1 < 8 && ColumnCharToInt(col) - 1 > 0)
                {
                    p = getPieceFromLabel(row + 1, IntToColumnChar(ColumnCharToInt(col) - 1));

                    if (p != null && p.getColor() != kingColor && p is Pawn)
                    {
                        return true;
                    }
                }
            }
            // If king is black, then pawn checks will always be down one row and + or - one column
            else
            {
                if (row + 1 < 8 && ColumnCharToInt(col) + 1 < 8)
                {
                    p = getPieceFromLabel(row - 1, IntToColumnChar(ColumnCharToInt(col) + 1));
                    if (p != null && p.getColor() != kingColor && p is Pawn)
                    {
                        return true;
                    }
                }
                if (row + 1 < 8 && ColumnCharToInt(col) - 1 > 0)
                {
                    p = getPieceFromLabel(row + 1, IntToColumnChar(ColumnCharToInt(col) - 1));
                    if (p != null && p.getColor() != kingColor && p is Pawn)
                    {
                        return true;
                    }
                }
            }

            // King check
            // Note kings can't actually check in a game of chess, but it's important for determing if a move is legal or not
            // If you were to move a king next to another king, then one king can take another, and it's illegal for you to put yourself into check
            int[] k1 = new int[] { 1, 1 };
            int[] k2 = new int[] { 1, 0 };
            int[] k3 = new int[] { 1, -1 };
            int[] k4 = new int[] { 0, -1 };
            int[] k5 = new int[] { 0, 1 };
            int[] k6 = new int[] { -1, 1 };
            int[] k7 = new int[] { -1, 0 };
            int[] k8 = new int[] { -1, -1 };
            int[][] kingChecks = { k1, k2, k3, k4, k5, k6, k7, k8 };

            foreach (int[] kingCheck in kingChecks)
            {
                int r = kingCheck[0] + row;
                int c = kingCheck[1] + ColumnCharToInt(col);
                if (r > 8 || r < 1 || c > 8 || c < 1)
                {
                    continue;
                }
                p = getPieceFromLabel(r, IntToColumnChar(c));
                if (p != null && p is King)
                {
                    return true;
                }
            }

            return false;
        } //THP
        bool CanMove(Piece pieceToMove, int rowToMoveTo, char colToMoveTo) //Method created by THP
        {
            int currentRow = pieceToMove.getRow();
            char currentCol = pieceToMove.getCol();
            char pieceToMoveColor = pieceToMove.getColor();

            Piece pieceAtNewPosition = getPieceFromLabel(rowToMoveTo, colToMoveTo);

            // Indicates whether the piece is moving up or down, and left or right
            int verticalDirection; // 0 no movement, 1 up, -1 down
            int horizontalDirection; // 0 no movement, 1 right, -1 left
            if (currentRow - rowToMoveTo == 0)
                verticalDirection = 0;
            else if (currentRow - rowToMoveTo > 0)
                verticalDirection = -1;
            else
                verticalDirection = 1;
            if (ColumnCharToInt(currentCol) - ColumnCharToInt(colToMoveTo) == 0)
                horizontalDirection = 0;
            else if (ColumnCharToInt(currentCol) - ColumnCharToInt(colToMoveTo) > 0)
                horizontalDirection = -1;
            else
                horizontalDirection = 1;
            // Pieces cannot move to their own square
            if (currentRow == rowToMoveTo && currentCol == colToMoveTo)
            {
                return false;
            }

            if (pieceAtNewPosition != null)
            {
                if (pieceToMoveColor == pieceAtNewPosition.getColor())
                {
                    return false;
                }
            }
            if (pieceToMove is Pawn)
            {
                bool canMoveTwo;
                if (pieceToMoveColor == 'w')
                {
                    if (verticalDirection != 1)
                    {
                        return false; // white pawns can only move forward
                    }
                    canMoveTwo = currentRow == 2;
                }
                else
                {
                    if (verticalDirection != -1)
                    {
                        return false; // black pawns can only move backward
                    }
                    canMoveTwo = currentRow == 7;
                }

                if (canMoveTwo && rowToMoveTo == currentRow + 2 * verticalDirection)
                {
                    // If there is a piece between 
                    if (getPieceFromLabel(currentRow + 1 * verticalDirection, currentCol) != null)
                    {
                        return false;
                    }
                }
                else if (rowToMoveTo != currentRow + 1 * verticalDirection)
                {
                    return false;
                }

                if (currentCol != colToMoveTo)
                {
                    if (pieceAtNewPosition == null) // Pawn must make a capture if it is moving into an adjacent column
                    {
                        // Check for en passant (obscure chess rule) first
                        if (getPieceFromLabel(currentRow, colToMoveTo) is Pawn) // Piece to the left or right of pawn during en passant must be a pawn as well. It must also have just moved two squares
                        {
                            Pawn pawn = (Pawn)getPieceFromLabel(currentRow, colToMoveTo);
                            if (pawn.movedTwoLastTurn != true || pawn.getColor() == pieceToMoveColor)
                            {
                                return false;
                            }
                            else
                            {
                                ((Pawn)pieceToMove).enPassantSquares.Add(Tuple.Create(rowToMoveTo, colToMoveTo));
                            }
                        }
                        else
                        {
                            return false;

                        }
                    }
                    if (Math.Abs(rowToMoveTo - currentRow) == 2) // Pawns cannot move up two and capture a piece in the same turn
                    {
                        return false;
                    }
                    if (Math.Abs( ColumnCharToInt(currentCol) - ColumnCharToInt(colToMoveTo) ) != 1) // Pawns can only move within one column
                    {
                        return false;
                    }
                }
                else // if not moving to new column, then it should be impossible for pawn to capture
                {
                    if (pieceAtNewPosition != null)
                    {
                        return false;
                    }
                }
            }
            else if (pieceToMove is Bishop)
            {
                // Checks to see if the move is within the same diagonal
                if ((rowToMoveTo - currentRow) == (ColumnCharToInt(colToMoveTo) - ColumnCharToInt(currentCol))) ;
                else if ((-rowToMoveTo + currentRow) == (ColumnCharToInt(colToMoveTo) - ColumnCharToInt(currentCol))) ;
                else
                {
                    return false;
                }
            }
            else if (pieceToMove is Rook)
            {
                // Rooks can only move one direction at a time, so either row or column must stay the same
                if ((currentCol != colToMoveTo) && (currentRow != rowToMoveTo))
                {
                    return false;
                }
            }
            else if (pieceToMove is Knight)
            {
                // Checks that the move is within 2 columns and 1 row of current column and current row, or vice versa
                if (Math.Abs(rowToMoveTo - currentRow) == 2 && (Math.Abs(ColumnCharToInt(colToMoveTo) - ColumnCharToInt(currentCol)) == 1)) ;
                else if (Math.Abs(rowToMoveTo - currentRow) == 1 && (Math.Abs(ColumnCharToInt(colToMoveTo) - ColumnCharToInt(currentCol)) == 2)) ;
                else
                {
                    return false;
                }
            }
            else if (pieceToMove is Queen)
            {
                // Combination of rook and bishop checking
                if ((rowToMoveTo - currentRow) == (ColumnCharToInt(colToMoveTo) - ColumnCharToInt(currentCol))) ;
                else if ((-rowToMoveTo + currentRow) == (ColumnCharToInt(colToMoveTo) - ColumnCharToInt(currentCol))) ;
                else if (  (currentCol == colToMoveTo) || (currentRow == rowToMoveTo) ) ;
                else
                {
                    return false;
                }

            }
            else if (pieceToMove is King)
            {
                // Checks if kng has moved already and if the move is in the castling squares
                bool isCastling = false;
                King k = (King)pieceToMove;
                if (!k.hasMoved)
                {
                    foreach (Tuple<int, char> square in k.castlingMoves)
                    {
                        if (colToMoveTo == square.Item2 && rowToMoveTo == square.Item1)
                        {
                            isCastling = true;
                            break;
                        }
                    }
                }
                if (isCastling)
                {
                    if (IsKingInCheck(pieceToMoveColor)) // king cannot castle to get out of check
                    {
                        return false;
                    }
                    // Checking every square in between king and rook to make sure that no piece occupies it, and that king isn't in check if it were to pass through
                    for (int i = 1; i < 4; i++)
                    {
                        char c = IntToColumnChar(ColumnCharToInt(currentCol) + 1 * horizontalDirection);
                        if (c == 'h')
                        {
                            break;
                        }
                        if (getPieceFromLabel(currentRow, c) != null)
                        {
                            return false;
                        }
                        // When castling to the left you don't have to check if the spot next to the rook is safe, only the spots the king passes through
                        if (c != 'b')
                        {
                            k.setCol(c);
                            if (IsKingInCheck(pieceToMoveColor))
                            {
                                k.setCol(currentCol);
                                return false;
                            }
                            k.setCol(currentCol);
                        }
                    }
                    Piece rook = null; // When castling there must be a rook in it's starting square that has not moved
                    if (horizontalDirection == -1)
                        rook = getPieceFromLabel(currentRow, 'a');
                    else
                        rook = getPieceFromLabel(currentRow, 'h');
                    if (rook is null || !(rook is Rook))
                    {
                        return false;
                    }
                    if ( ((Rook) rook).hasMoved == true)
                    {
                        return false;
                    }
                }
                else
                {
                    // If the king is not castling, check to see if the new move is within 1 spot
                    if (Math.Abs(rowToMoveTo - currentRow) > 1)
                        return false;
                    if (Math.Abs(ColumnCharToInt(colToMoveTo) - ColumnCharToInt(currentCol)) > 1)
                        return false;
                }
            }

            // Check to make sure piece is not in the way
            if (pieceToMove is Queen || pieceToMove is Bishop || pieceToMove is Rook)
            {
                Piece firstPieceInLine = getFirstPieceInLine(currentRow, currentCol, verticalDirection, horizontalDirection);
                if (firstPieceInLine != null)
                {
                    if (verticalDirection == 1)
                    {
                        if (firstPieceInLine.getRow() < rowToMoveTo)
                        {
                            return false;
                        }
                    }
                    else if (verticalDirection == -1)
                    {
                        if (firstPieceInLine.getRow() > rowToMoveTo)
                        {
                            return false;
                        }
                    }
                    if (horizontalDirection == 1)
                    {
                        if (ColumnCharToInt(firstPieceInLine.getCol()) < ColumnCharToInt(colToMoveTo))
                        {
                            return false;
                        }
                        
                    }
                    else if (horizontalDirection == -1)
                    {
                        if (ColumnCharToInt(firstPieceInLine.getCol()) > ColumnCharToInt(colToMoveTo))
                        {
                            return false;
                        }
                    }
                }
            } //THP

            // Changes the piece to the new location temporarily, this is in order to see if the king is still in check
            pieceToMove.setCol(colToMoveTo);
            pieceToMove.setRow(rowToMoveTo);
            if (IsKingInCheck(pieceToMove.getColor()))
            {
                pieceToMove.setCol(currentCol);
                pieceToMove.setRow(currentRow);
                return false;
            }
            pieceToMove.setCol(currentCol);
            pieceToMove.setRow(currentRow);

            return true;
        }
        public void createLegalMoves() //THP creates a list of legal moves per piece
        {
            foreach (Piece p in pieces)
            {
                p.legalMoves.Clear();
                if (p is Pawn)
                {
                    ((Pawn)p).enPassantSquares.Clear();
                }
                // Calls CanMove() with every combination of column and row and adds the move to legal moves if CanMove returns true
                for (int i = 1; i < 9; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        bool b = CanMove(p, i, IntToColumnChar(j));
                        if (b)
                        {
                            Tuple<int, char> temp = new Tuple<int, char>(i, IntToColumnChar(j));
                            p.legalMoves.Add(temp);
                        }
                    }
                }
            }
        }
    }
}