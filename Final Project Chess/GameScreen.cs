using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;

namespace Final_Project_Chess
{
    public partial class GameScreen : Form
    {
        private Timer bt;
        private Timer wt; 
        private int bRemainingTime = 0,wRemainingTime = 0; 
        private Piece p = new Piece(8,'a','b');
        bool userClickedSignOut = false; 
        private char turn = 'w';
        private GameSettings previousWindow;
        private int timeChoice = 0;
        private string timeAmount = "";
        private string username = "";
        private bool pieceIsMoving = false;
        private string pieceMoving = "";
        private string pieceType = "";
        private Piece pMoving;
        private int indexPieceMoving;
        private System.Windows.Forms.Label labelMoving;
        private ChessGame chessGame = new ChessGame();
        private Piece selectedPiece;
        private Piece promotedPiece;
        private string darkSquarePath; // Filepath for light and dark square, used to restore picturebox images to their original state after highlighted moves are no longer shown
        private string lightSquarePath; // Both are set inside constructor
        private bool gameOver = false;
        private bool changingPiece = false;
        private string promotionString;
        private System.Windows.Forms.Label clickedLabel;
        private Pawn pawnToPromote;
        private bool pawnNeedsToPromote = false;

        string saveFileContent = "";

        //List of labels piece can move to.
        List<System.Windows.Forms.Label> labelList = new List<System.Windows.Forms.Label>();
        List<string> previousText = new List<string>();

        public GameScreen(GameSettings previousWindow)
        {
            this.previousWindow = previousWindow;
            previousWindow.Hide();
            InitializeComponent();
        }
        private void promotePiece() //NCB, THP, once pawn reaches enemy side, promotes the piece to given input
        {
            if (pawnToPromote != null)
            {
                int row;
                if(pawnToPromote.getColor() == 'b')
                {
                    row = 1;
                }
                else
                {
                    row = 8;
                }
                System.Windows.Forms.Label pawnToPromoteLabel = getLabelFromColRow(pawnToPromote.getCol(), row);
                if (promotionString.ToLower() == "queen")
                {
                    Queen q = new Queen(row, pawnToPromote.getCol(), pawnToPromote.getColor());
                    chessGame.pieces.Add(q);
                    pawnToPromoteLabel.Text = "♕";
                    userPromotionButton.Visible = false;
                    userPromotionTextBox.Visible = false;
                }
                else if (promotionString.ToLower() == "rook")
                {
                    Rook r = new Rook(row, pawnToPromote.getCol(), pawnToPromote.getColor());
                    chessGame.pieces.Add(r);
                    pawnToPromoteLabel.Text = "♖";
                    userPromotionButton.Visible = false;
                    userPromotionTextBox.Visible = false;
                }
                else if (promotionString.ToLower() == "knight")
                {
                    Knight k = new Knight(row, pawnToPromote.getCol(), pawnToPromote.getColor());
                    chessGame.pieces.Add(k);
                    pawnToPromoteLabel.Text = "♘";
                    userPromotionButton.Visible = false;
                    userPromotionTextBox.Visible = false;
                }
                else if (promotionString.ToLower() == "bishop")
                {
                    Bishop b = new Bishop(row, pawnToPromote.getCol(), pawnToPromote.getColor());
                    chessGame.pieces.Add(b);
                    pawnToPromoteLabel.Text = "♗";
                    userPromotionButton.Visible = false;
                    userPromotionTextBox.Visible = false;
                }
                else
                {
                    MessageBox.Show("Invalid Piece");
                    return;
                }
                chessGame.pieces.Remove(pawnToPromote);
                chessGame.createLegalMoves();
                pawnNeedsToPromote = false;
            }
        }//THP, NCB
        private void signOutGameButton_Click(object sender, EventArgs e)
        {
            userClickedSignOut = true;
            this.Close();
        }
        private System.Windows.Forms.Label getLabelFromColRow(char c, int r) // NCB, iterates through array Control[] to find the label corresponding to a column + row
        {
            string s;
            string endString = "Label";
            string startString = c.ToString() + r.ToString();
            s = startString + endString;
            Control[] foundControl = Controls.Find(s, true);
            return (System.Windows.Forms.Label) foundControl[0];
        }
        // Method and documentation by NCB with help from THP
        private void gameOverCheck() //THP, Called after every turn to detect checkmate or stalemate
        {
            bool noLegalMoves = true; // False if there's a move left to be played
            foreach (Piece p in chessGame.pieces)
            {
                if (p.getColor() != turn)
                {
                    continue;
                }
                if (p.legalMoves.Count > 0)
                {
                    noLegalMoves = false;
                    break;
                }
            }
            if (noLegalMoves)
            {
                if (chessGame.IsKingInCheck(turn))
                {
                    if (turn == 'w')
                    {
                        MessageBox.Show("Black wins!");
                    }
                    else {
                        MessageBox.Show("White wins!");
                    }
                }
                else
                {
                    MessageBox.Show("Stalemate, no one wins");
                }
                gameOver = true;
            }
        } //THP
        private void changeOrientation() //THP iterates through every label and sets position based off of which turn it is
        {
            if (gameOver)
            {
                return;
            }
            SuspendLayout();
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    char c = ChessGame.IntToColumnChar(j);
                    System.Windows.Forms.Label squareLabel = getLabelFromColRow(c, i);

                    // Initial positions chosen based off of what looks good on screen
                    int initialPositionX = 193;
                    int initialPositionY = 407;
                    Point location;
                    if (turn == 'w')
                    {
                        location = new System.Drawing.Point(initialPositionX + j * squareLabel.Height, initialPositionY - i * squareLabel.Height);
                    }
                    // Black's row coordinates are the same, except with the x and y axis flipped.
                    // For Y axis this is done by adding i * 45 instead of subtracting, then adjusting overall position for the subtracted amount
                    // For X axis this is done by subtracting j * 45 instead of adding, then adjusting overall position for the added amount
                    else
                    {
                        location = new System.Drawing.Point(initialPositionX + (squareLabel.Height * 9)  - j * squareLabel.Height, initialPositionY - (squareLabel.Height * 9) + i * squareLabel.Height);
                    }
                    squareLabel.Location = location;
                }
            }
            ResumeLayout();
        } //THP
        private void movingPiece(System.Windows.Forms.Label l, char column, int row) //THP, NCB
        {
            if (gameOver || pawnNeedsToPromote)
            {
                return;
            }
            // This clears all highlighted squares
            SuspendLayout();
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    char c = ChessGame.IntToColumnChar(j);
                    System.Windows.Forms.Label squareLabel = getLabelFromColRow(c, i);
                    squareLabel.Refresh(); 
                }
            }
            ResumeLayout();

            // Set lastMovedTwo in pawn to false for the current color
            foreach(Piece p in chessGame.pieces)
            {
                if (p is Pawn && p.getColor() == turn)
                {
                    ((Pawn)p).movedTwoLastTurn = false;
                }
            }

            Piece pieceAtCurrentLabel = chessGame.getPieceFromLabel(row, column);

            // If no selected piece, check to see if clicked piece can become selected piece
            if (selectedPiece == null)
            {
                if (pieceAtCurrentLabel != null && pieceAtCurrentLabel.getColor() == turn)
                {
                    selectedPiece = pieceAtCurrentLabel;
                    if (selectedPiece.getColor() != turn)
                    {
                        return;
                    }
                }
            }
            // If user clicks on piece of the same color, assume they want to select a different piece
            else if (pieceAtCurrentLabel != null && selectedPiece.getColor() == pieceAtCurrentLabel.getColor())
            {
                selectedPiece = pieceAtCurrentLabel;
            }
            // If they have a valid selected piece, attempt to move to new square
            else
            {
                bool pieceMoved = false;
                // Iterate through each legal move in selectedPiece to make sure the chosen move is legal
                foreach (Tuple<int, char> square in selectedPiece.legalMoves)
                {
                    System.Windows.Forms.Label selectedPieceLabel = getLabelFromColRow(selectedPiece.getCol(), selectedPiece.getRow());
                    if (getLabelFromColRow(square.Item2, square.Item1) == l)
                    {
                        // If piece that moved was pawn, rook, or king then values have to be set in order for en passant and castling to work

                        if (selectedPiece is Pawn)
                        {
                            enPassantSetupAndCapture((Pawn)selectedPiece, square.Item2, square.Item1);
                            //Pawn Promotion
                            if ((selectedPiece.getRow() == 7 && selectedPiece.getColor() == 'w') || (selectedPiece.getRow() == 2 && selectedPiece.getColor() == 'b'))
                            {
                                pawnNeedsToPromote = true;
                                pawnToPromote = (Pawn) selectedPiece;
                                userPromotionButton.Visible = true;
                                userPromotionTextBox.Visible = true;
                                MessageBox.Show("Enter Piece Promotion");
                            }
                            
                        }
                        else if (selectedPiece is Rook)
                        {
                            ((Rook)selectedPiece).hasMoved = true;
                        }
                        else if (selectedPiece is King)
                        {
                            castle((King)selectedPiece, square.Item2, square.Item1);
                            ((King)selectedPiece).hasMoved = true;
                        }
                        
                        selectedPiece.setCol(column);
                        selectedPiece.setRow(row);
                        pieceMoved = true;
                        l.Text = selectedPieceLabel.Text; // Set text to piece
                        if (selectedPiece.getColor() == 'w')
                        {
                            l.ForeColor = Color.White;
                        }
                        else
                        {
                            l.ForeColor = Color.Black;
                        }

                        selectedPieceLabel.Text = " "; // clear text from previous label
                        if (pieceAtCurrentLabel != null)
                        {
                            pieceAtCurrentLabel.legalMoves.Clear();
                            chessGame.pieces.Remove(pieceAtCurrentLabel);
                        }

                        chessGame.createLegalMoves();

                        turn = turn == 'w' ? 'b' : 'w'; // changes turns

                        if (pawnNeedsToPromote)
                        {
                            pawnToPromote = (Pawn)selectedPiece;
                        }

                        break;
                    }
                }
                if (!pieceMoved)
                {
                    MessageBox.Show("Invalid move");
                }
                selectedPiece = null; // clear selected piece
            }
            if (selectedPiece != null)
            {
                SuspendLayout();
                // This highlights possible moves by finding every label corresponding to legal moves and drawing a red border around them
                foreach (Tuple<int, char> square in selectedPiece.legalMoves)
                {
                    System.Windows.Forms.Label squareLabel = getLabelFromColRow(square.Item2, square.Item1);
                    Graphics g = squareLabel.CreateGraphics(); // Although ideally we would use paint events, it's just too much to have to create a new paint event method for all 64 squares
                    ControlPaint.DrawBorder(g, squareLabel.ClientRectangle, Color.Red, ButtonBorderStyle.Solid);
                    g.Dispose();
                }
                { // Highlights selected piece in green
                    System.Windows.Forms.Label squareLabel = getLabelFromColRow(selectedPiece.getCol(), selectedPiece.getRow());
                    Graphics g = squareLabel.CreateGraphics();
                    ControlPaint.DrawBorder(g, squareLabel.ClientRectangle, Color.Green, ButtonBorderStyle.Solid); // Highlights chosen piece in green
                    g.Dispose();
                }
                ResumeLayout();
            }
            gameOverCheck(); // Check for a win or stalemate
            changeOrientation();
        }// Method by THP

        private void castle(King k, char colToMoveTo, int rowToMoveTo) //THP, checks if the column and row is a castling move, then it sets the rook to the correct position if true
        { 
            if (k.hasMoved)
            {
                return;
            }
            bool isCastling = false;
            foreach(Tuple<int, char> square in k.castlingMoves)
            {
                if (square.Item2 == colToMoveTo && square.Item1 == rowToMoveTo)
                {
                    isCastling = true;
                }
            }
            if (isCastling)
            {
                System.Windows.Forms.Label rookDestinationLabel = null;
                System.Windows.Forms.Label rookLabel = null;
                if (colToMoveTo == 'g')
                {
                    rookLabel = getLabelFromColRow('h', rowToMoveTo);
                    rookDestinationLabel = getLabelFromColRow('f', rowToMoveTo);
                    Piece rookToMove = chessGame.getPieceFromLabel(rowToMoveTo, 'h');
                    rookToMove.setCol('f');
                    rookToMove.setRow(rowToMoveTo);
                }
                else
                {
                    rookLabel = getLabelFromColRow('a', rowToMoveTo);
                    rookDestinationLabel = getLabelFromColRow('d', rowToMoveTo);
                    Piece rookToMove = chessGame.getPieceFromLabel(rowToMoveTo, 'a');
                    rookToMove.setCol('d');
                    rookToMove.setRow(rowToMoveTo);
                }
                rookDestinationLabel.Text = rookLabel.Text;
                rookLabel.Text = " ";
            }
        } //THP

        private void enPassantSetupAndCapture(Pawn pawn, char colToMoveTo, int rowToMoveTo) //THP
        {
            // En passant is unique in that the piece to capture is in a different square then where the pawn moves to, this captures that piece, it also sets the flag movedTwoLastTurn to true to set up future en passant
            if (Math.Abs(pawn.getRow() - rowToMoveTo) == 2)
            {
                pawn.movedTwoLastTurn = true;
            }
            else
            {
                foreach(Tuple<int, char> square in pawn.enPassantSquares)
                {
                    if (square.Item1 == rowToMoveTo && square.Item2 == colToMoveTo)
                    {
                        chessGame.pieces.Remove(chessGame.getPieceFromLabel(pawn.getRow(), colToMoveTo)); // En passant capture
                        getLabelFromColRow(colToMoveTo, pawn.getRow()).Text = " "; // Set label to blank text
                    }
                }
            }
        } //THP
        private void GameScreen_FormClosed(object sender, FormClosedEventArgs e) //THP
        {
            // Weird work around. Winforms makes no distinction between exiting a form with the X button or calling Form.Close()
            // This is an issue because if a user clicks sign out the intended behaviour should be to go to the previous window, and if a user clicks X the intended behaviour should be to close the form
            if (userClickedSignOut)
                previousWindow.Show();
            else
            {
                Application.Exit();
            }
        } //THP
        public void updateTimers() //JP
        {
            if (turn == 'b')
            {
                BTime.Text = bRemainingTime.ToString();
            }
            else { 
                WTime.Text = wRemainingTime.ToString();
            }
        } //JP
        private void timerTick(object sender, EventArgs e) //JP
        {
            if (turn == 'w')
            {
                wt.Start();
                bt.Stop();
                if (wRemainingTime > 0)
                {
                    wRemainingTime--;
                    updateTimers();
                }
                else if (wRemainingTime == 0)
                {
                    wt.Stop();
                    MessageBox.Show("White loses Time Ran Out.");
                    signOutGameButton_Click(sender, e);
                }
            }
            else if (turn == 'b')
            {
                bt.Start();
                wt.Stop();
                if (bRemainingTime > 0)
                {
                    bRemainingTime--;
                    updateTimers();
                }
                else if (bRemainingTime == 0)
                {
                    bt.Stop();
                    MessageBox.Show("Black loses Time Ran Out.");
                    signOutGameButton_Click(sender, e);
                }
            }
        }//JP
        private void GameScreen_Load(object sender, EventArgs e) //JP
        {   
            bt = new Timer();
            wt = new Timer();
            bt.Interval = 1000;
            wt.Interval = 1000;
            bt.Tick += timerTick;
            wt.Tick += timerTick;
            timeChoice = previousWindow.getTimeChoice();
            timeAmount = previousWindow.getTimeText();
            username = previousWindow.getUsername();
            userGameLabel.Text = "User: " + username;
            initBoard();
            if (timeChoice == 1)
            {
                timeGameLabel.Visible = false;
                BTime.Visible = false;
                WTime.Visible = false;
                blackLabel.Visible = false;
                whitelabel.Visible = false;
                bRemainingTime = -1;
                wRemainingTime = -1;
            }
            else
            {
                if (timeChoice == 2)
                {
                    bRemainingTime = 300;
                    wRemainingTime = 300;
                    BTime.Text = "300";
                    WTime.Text = "300";
                    wt.Start();
                }
                else if (timeChoice == 3)
                {
                    bRemainingTime = 900;
                    wRemainingTime = 900;
                    BTime.Text = "900";
                    WTime.Text = "900";
                    wt.Start();
                }
                else if (timeChoice == 4)
                {
                    int t = int.Parse(timeAmount);
                    t = t * 60;
                    bRemainingTime = t;
                    wRemainingTime = t;
                    BTime.Text = t.ToString();
                    WTime.Text = t.ToString();
                    wt.Start();
                }
            }//JP

            for (int i = 1; i < 9; i++) //THP, Height and Width kept on accidentally changing anytime one of use edited GameScreen.cs designer
            { // This for loop sets the intended positioning and makes sure every picture box and label are the same font, height, width, and relative position
                for (int j = 1; j < 9; j++)
                {
                    char c = ChessGame.IntToColumnChar(j);
                    System.Windows.Forms.Label squareLabel = getLabelFromColRow(c, i);
                    PictureBox squarePicture = (PictureBox)Controls.Find(c + "" + i, true)[0];
                    Point location = new System.Drawing.Point(193 + j * 45, 407 - i * 45);
                    squarePicture.Height = 45;
                    squarePicture.Width = 45;
                    squareLabel.Height = 45;
                    squareLabel.Width = 45;
                    squareLabel.AutoSize = false;
                    squareLabel.TextAlign = ContentAlignment.MiddleCenter;
                    squarePicture.Location = location;
                    squareLabel.Location = location;
                    squareLabel.Font = new System.Drawing.Font("Microsoft YaHei", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }//THP
        }
        private void c1Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(c1Label, 'c', 1);
        } //NCB
        private void e8Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(e8Label, 'e', 8);
        } //NCB
        private void a2Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(a2Label, 'a', 2);
        } //NCB
        private void b8Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(b8Label, 'b', 8);
        } //NCB
        private void h7Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(h7Label, 'h', 7);
        } //NCB
        private void d2Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(d2Label, 'd', 2);
        } //NCB
        private void d1Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(d1Label, 'd', 1);
        } //NCB
        private void b6Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(b6Label, 'b', 6);
        } //NCB
        private void e6Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(e6Label, 'e', 6);
        } //NCB
        private void a8Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(a8Label, 'a', 8);
        } //NCB
        private void a6Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(a6Label, 'a', 6);
        } //NCB
        private void a1Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(a1Label, 'a', 1);
        } //NCB

        private void a3Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(a3Label, 'a', 3);
        }  //NCB
        private void saveGameButton_Click(object sender, EventArgs e) //ER, deletes pre existing file for user saveFileFinalProject_{username}.txt then creates and fills the file with the label text and the text color.
        {
            string exeFolder = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            File.Delete(exeFolder + $"\\saveFileFinalProject_{username}.txt");
            using (System.IO.FileStream gameText = File.OpenWrite(exeFolder + $"\\saveFileFinalProject_{username}.txt")) ;
            MessageBox.Show(exeFolder + $"\\saveFileFinalProject_{username}.txt was created");
            using (StreamWriter gametext = File.AppendText(exeFolder + $"\\saveFileFinalProject_{username}.txt")) //JRP reference code
            {
                gametext.WriteLine(a8Label.Text + a8Label.ForeColor + ",");
                gametext.WriteLine(b8Label.Text + b8Label.ForeColor + ",");
                gametext.WriteLine(c8Label.Text + c8Label.ForeColor + ",");
                gametext.WriteLine(d8Label.Text + d8Label.ForeColor + ",");
                gametext.WriteLine(e8Label.Text + e8Label.ForeColor + ",");
                gametext.WriteLine(f8Label.Text + f8Label.ForeColor + ",");
                gametext.WriteLine(g8Label.Text + g8Label.ForeColor + ",");
                gametext.WriteLine(h8Label.Text + h8Label.ForeColor + ",");

                gametext.WriteLine(a7Label.Text + a7Label.ForeColor + ",");
                gametext.WriteLine(b7Label.Text + b7Label.ForeColor + ",");
                gametext.WriteLine(c7Label.Text + c7Label.ForeColor + ",");
                gametext.WriteLine(d7Label.Text + d7Label.ForeColor + ",");
                gametext.WriteLine(e7Label.Text + e7Label.ForeColor + ",");
                gametext.WriteLine(f7Label.Text + f7Label.ForeColor + ",");
                gametext.WriteLine(g7Label.Text + g7Label.ForeColor + ",");
                gametext.WriteLine(h7Label.Text + h7Label.ForeColor + ",");

                gametext.WriteLine(a6Label.Text + a6Label.ForeColor + ",");
                gametext.WriteLine(b6Label.Text + b6Label.ForeColor + ",");
                gametext.WriteLine(c6Label.Text + c6Label.ForeColor + ",");
                gametext.WriteLine(d6Label.Text + d6Label.ForeColor + ",");
                gametext.WriteLine(e6Label.Text + e6Label.ForeColor + ",");
                gametext.WriteLine(f6Label.Text + f6Label.ForeColor + ",");
                gametext.WriteLine(g6Label.Text + g6Label.ForeColor + ",");
                gametext.WriteLine(h6Label.Text + h6Label.ForeColor + ",");

                gametext.WriteLine(a5Label.Text + a5Label.ForeColor + ",");
                gametext.WriteLine(b5Label.Text + b5Label.ForeColor + ",");
                gametext.WriteLine(c5Label.Text + c5Label.ForeColor + ",");
                gametext.WriteLine(d5Label.Text + d5Label.ForeColor + ",");
                gametext.WriteLine(e5Label.Text + e5Label.ForeColor + ",");
                gametext.WriteLine(f5Label.Text + f5Label.ForeColor + ",");
                gametext.WriteLine(g5Label.Text + g5Label.ForeColor + ",");
                gametext.WriteLine(h5Label.Text + h5Label.ForeColor + ",");

                gametext.WriteLine(a4Label.Text + a4Label.ForeColor + ",");
                gametext.WriteLine(b4Label.Text + b4Label.ForeColor + ",");
                gametext.WriteLine(c4Label.Text + c4Label.ForeColor + ",");
                gametext.WriteLine(d4Label.Text + d4Label.ForeColor + ",");
                gametext.WriteLine(e4Label.Text + e4Label.ForeColor + ",");
                gametext.WriteLine(f4Label.Text + f4Label.ForeColor + ",");
                gametext.WriteLine(g4Label.Text + g4Label.ForeColor + ",");
                gametext.WriteLine(h4Label.Text + h4Label.ForeColor + ",");

                gametext.WriteLine(a3Label.Text + a3Label.ForeColor + ",");
                gametext.WriteLine(b3Label.Text + b3Label.ForeColor + ",");
                gametext.WriteLine(c3Label.Text + c3Label.ForeColor + ",");
                gametext.WriteLine(d3Label.Text + d3Label.ForeColor + ",");
                gametext.WriteLine(e3Label.Text + e3Label.ForeColor + ",");
                gametext.WriteLine(f3Label.Text + f3Label.ForeColor + ",");
                gametext.WriteLine(g3Label.Text + g3Label.ForeColor + ",");
                gametext.WriteLine(h3Label.Text + h3Label.ForeColor + ",");

                gametext.WriteLine(a2Label.Text + a2Label.ForeColor + ",");
                gametext.WriteLine(b2Label.Text + b2Label.ForeColor + ",");
                gametext.WriteLine(c2Label.Text + c2Label.ForeColor + ",");
                gametext.WriteLine(d2Label.Text + d2Label.ForeColor + ",");
                gametext.WriteLine(e2Label.Text + e2Label.ForeColor + ",");
                gametext.WriteLine(f2Label.Text + f2Label.ForeColor + ",");
                gametext.WriteLine(g2Label.Text + g2Label.ForeColor + ",");
                gametext.WriteLine(h2Label.Text + h2Label.ForeColor + ",");

                gametext.WriteLine(a1Label.Text + a1Label.ForeColor + ",");
                gametext.WriteLine(b1Label.Text + b1Label.ForeColor + ",");
                gametext.WriteLine(c1Label.Text + c1Label.ForeColor + ",");
                gametext.WriteLine(d1Label.Text + d1Label.ForeColor + ",");
                gametext.WriteLine(e1Label.Text + e1Label.ForeColor + ",");
                gametext.WriteLine(f1Label.Text + f1Label.ForeColor + ",");
                gametext.WriteLine(g1Label.Text + g1Label.ForeColor + ",");
                gametext.WriteLine(h1Label.Text + h1Label.ForeColor + ",");
            }
        }


        private void loadGameButton_Click(object sender, EventArgs e) //ER Current work in progress
        {
            string exeFolder = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            List<string> postions = new List<string>();
            List<string> colors = new List<string>();
            try
            {
                using (System.IO.FileStream gameText = File.OpenRead(exeFolder + $"\\saveFileFinalProject_{username}.txt")) 
                {
                    string locationSaveFile = exeFolder + $"\\saveFileFinalProject_{username}.txt";
                    StringReader reader = new StringReader(gameText.ToString());
                    MessageBox.Show(gameText.ToString()+ locationSaveFile);
                    /*for (int i = 0; i < gameText.Length; i++)
                    {
                       
                    }*/
                }
                MessageBox.Show(exeFolder + $"\\saveFileFinalProject_{username}.txt was opened");
            }
            catch
            {
                MessageBox.Show(exeFolder + $"\\saveFileFinalProject_{username}.txt doesn't exist");
            }

        }
        public void initBoard() //ER, changes text from "0" to ""
        {
            a6Label.Text = " ";
            b6Label.Text = " ";
            c6Label.Text = " ";
            d6Label.Text = " ";
            e6Label.Text = " ";
            f6Label.Text = " ";
            g6Label.Text = " ";
            h6Label.Text = " ";

            a5Label.Text = " ";
            b5Label.Text = " ";
            c5Label.Text = " ";
            d5Label.Text = " ";
            e5Label.Text = " ";
            f5Label.Text = " ";
            g5Label.Text = " ";
            h5Label.Text = " ";

            a4Label.Text = " ";
            b4Label.Text = " ";
            c4Label.Text = " ";
            d4Label.Text = " ";
            e4Label.Text = " ";
            f4Label.Text = " ";
            g4Label.Text = " ";
            h4Label.Text = " ";

            a3Label.Text = " ";
            b3Label.Text = " ";
            c3Label.Text = " ";
            d3Label.Text = " ";
            e3Label.Text = " ";
            f3Label.Text = " ";
            g3Label.Text = " ";
            h3Label.Text = " ";

            userPromotionButton.Visible = false;
            userPromotionTextBox.Visible = false;
        }
        private void userPromotionButton_Click(object sender, EventArgs e) //NCB, calls promotePiece() when button is clicked
        {
            promotePiece();
        } //NCB

        private void userPromotionTextBox_TextChanged(object sender, EventArgs e) //NCB, updates promotionString when text changes
        {
            promotionString = (string)userPromotionTextBox.Text;
        } //NCB
        // Label click events below, calling movingPiece with paramerters specific to the label.
        private void b7Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(b7Label, 'b', 7);
        } //NCB
        private void d7Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(d7Label, 'd', 7);
        } //NCB
        private void a4Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(a4Label, 'a', 4);
        } //NCB
        private void b2Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(b2Label, 'b', 2);
        } //NCB
        private void c2Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(c2Label, 'c', 2);
        } //NCB
        private void e2Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(e2Label, 'e', 2);
        } //NCB
        private void f2Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(f2Label, 'f', 2);
        } //NCB
        private void g2Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(g2Label, 'g', 2);
        } //NCB
        private void h2Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(h2Label, 'h', 2);
        } //NCB
        private void b3Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(b3Label, 'b', 3);
        } //NCB
        private void c3Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(c3Label, 'c', 3);
        } //NCB
        private void d3Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(d3Label, 'd', 3);
        } //NCB
        private void e3Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(e3Label, 'e', 3);
        } //NCB
        private void f3Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(f3Label, 'f', 3);
        } //NCB
        private void g3Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(g3Label, 'g', 3);
        } //NCB
        private void h3Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(h3Label, 'h', 3);
        } //NCB
        private void b4Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(b4Label, 'b', 4);
        } //NCB
        private void c4Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(c4Label, 'c', 4);
        } //NCB
        private void d4Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(d4Label, 'd', 4);
        } //NCB
        private void e4Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(e4Label, 'e', 4);
        } //NCB
        private void f4Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(f4Label, 'f', 4);
        } //NCB
        private void g4Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(g4Label, 'g', 4);
        } //NCB
        private void h4Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(h4Label, 'h', 4);
        } //NCB
        private void a5Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(a5Label, 'a', 5);
        } //NCB
        private void b5Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(b5Label, 'b', 5);
        } //NCB
        private void c5Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(c5Label, 'c', 5);
        } //NCB
        private void d5Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(d5Label, 'd', 5);
        } //NCB
        private void e5Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(e5Label, 'e', 5);
        } //NCB
        private void f5Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(f5Label, 'f', 5);
        } //NCB
        private void g5Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(g5Label, 'g', 5);
        } //NCB
        private void h5Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(h5Label, 'h', 5);
        } //NCB
        private void c6Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(c6Label, 'c', 6);
        } //NCB
        private void d6Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(d6Label, 'd', 6);
        } //NCB
        private void f6Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(f6Label, 'f', 6);
        } //NCB
        private void g6Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(g6Label, 'g', 6);
        } //NCB
        private void h6Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(h6Label, 'h', 6);
        } //NCB
        private void a7Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(a7Label, 'a', 7);
        } //NCB
        private void c7Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(c7Label, 'c', 7);
        } //NCB
        private void e7Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(e7Label, 'e', 7);
        } //NCB
        private void f7Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(f7Label, 'f', 7);
        } //NCB
        private void g7Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(g7Label, 'g', 7);
        } //NCB
        private void c8Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(c8Label, 'c', 8);
        } //NCB
        private void d8Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(d8Label, 'd', 8);
        } //NCB
        private void f8Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(f8Label, 'f', 8);
        } //NCB
        private void g8Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(g8Label, 'g', 8);
        } //NCB
        private void h8Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(h8Label, 'h', 8);
        }  //NCB
        private void b1Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(b1Label, 'b', 1);
        } //NCB
        private void h1Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(h1Label, 'h', 1);
        } //NCB
        private void f1Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(f1Label, 'f', 1);
        } //NCB
        private void e1Label_Click(object sender, EventArgs e) //NCB
        {
            movingPiece(e1Label, 'e', 1);
        } //NCB
        private void g1Label_Click(object sender, EventArgs e)
        {
            movingPiece(g1Label, 'g', 1);
        } //NCB
    }
}
