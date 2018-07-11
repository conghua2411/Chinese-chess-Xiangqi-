using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cs_xiangqi
{
    public partial class Form1 : Form
    {
        public GameBoard game = new GameBoard();
        public Pieces currentPieceSelected = new Chariot();
        int currentPieceX;
        int currentPieceY;
        Pieces.posSide currentPieceSide;
        string currentPieceSideStr;
        public bool makeMove = false;

        List<List<int>> posCanMove = new List<List<int>>();
        
        public Form1()
        {
            InitializeComponent();
            
            game.newGame();
        }

        private void changeLbTurn()
        {
            if (lb_turn.Text == "Red turn")
            {
                lb_turn.Text = "Black turn";
                lb_turn.ForeColor = Color.Black;
            }
            else if (lb_turn.Text == "Black turn")
            {
                lb_turn.Text = "Red turn";
                lb_turn.ForeColor = Color.Red;
            }
        }

        private void picBox_Board_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (makeMove == true)
                {
                    makeMove = false;
                    game.changeSideTurn();
                    posCanMove = new List<List<int>>();
                    picBox_Board.Invalidate();
                    pb_piecesSelected.Invalidate();
                       
                }
                return;
            }

            int mouseClickX, mouseClickY;

            mouseClickX = e.X;
            mouseClickY = e.Y;

            int posInBoardX = (mouseClickX - 8) / 46;
            int posInBoardY = mouseClickY / 43;

            bool clickOnPiece = false;

            int piecePosX = posInBoardX * 46 + 8;
            int piecePosY = posInBoardY * 43;

            if (mouseClickX < piecePosX + 8 || mouseClickX > piecePosX + 32 || mouseClickY < piecePosY + 8 || mouseClickY > piecePosY + 32)
            {
                clickOnPiece = false;
            }
            else
            {
                clickOnPiece = true;
            }
            
            if (clickOnPiece)
            {
                if (makeMove == false)
                {
                    if (game.board[posInBoardX][posInBoardY][0] == "Empty")
                    {
                        return;
                    }

                    if (game.board[posInBoardX][posInBoardY][1] == "Red")
                    {
                        currentPieceSide = Pieces.posSide.Red;
                        currentPieceSideStr = "Red";
                    }
                    else
                    {
                        currentPieceSide = Pieces.posSide.Black;
                        currentPieceSideStr = "Black";
                    }

                    if (game.sideTurn != currentPieceSideStr)
                    {
                        MessageBox.Show(string.Format("It's {0} turn", game.sideTurn));
                        return;
                    }
                    else
                    {
                        game.changeSideTurn();
                    }

                    if (game.board[posInBoardX][posInBoardY][0] == "Chariot")
                    {
                        currentPieceSelected = new Chariot(Pieces.posType.Chariot, currentPieceSide);
                        currentPieceSelected.type = "Chariot";
                        currentPieceSelected.side = currentPieceSideStr;
                    }
                    else if (game.board[posInBoardX][posInBoardY][0] == "Horse")
                    {
                        currentPieceSelected = new Horse(Pieces.posType.Horse, currentPieceSide);
                        currentPieceSelected.type = "Horse";
                        currentPieceSelected.side = currentPieceSideStr;
                    }
                    else if (game.board[posInBoardX][posInBoardY][0] == "Elephant")
                    {
                        currentPieceSelected = new Elephant(Pieces.posType.Elephant, currentPieceSide);
                        currentPieceSelected.type = "Elephant";
                        currentPieceSelected.side = currentPieceSideStr;
                    }
                    else if (game.board[posInBoardX][posInBoardY][0] == "Guard")
                    {
                        currentPieceSelected = new Guard(Pieces.posType.Guard, currentPieceSide);
                        currentPieceSelected.type = "Guard";
                        currentPieceSelected.side = currentPieceSideStr;
                    }
                    else if (game.board[posInBoardX][posInBoardY][0] == "General")
                    {
                        currentPieceSelected = new General(Pieces.posType.General, currentPieceSide);
                        currentPieceSelected.type = "General";
                        currentPieceSelected.side = currentPieceSideStr;
                    }
                    else if (game.board[posInBoardX][posInBoardY][0] == "Cannon")
                    {
                        currentPieceSelected = new Cannon(Pieces.posType.Cannon, currentPieceSide);
                        currentPieceSelected.type = "Cannon";
                        currentPieceSelected.side = currentPieceSideStr;
                    }
                    else if (game.board[posInBoardX][posInBoardY][0] == "Soldier")
                    {
                        currentPieceSelected = new Soldier(Pieces.posType.Soldier, currentPieceSide);
                        currentPieceSelected.type = "Soldier";
                        currentPieceSelected.side = currentPieceSideStr;
                    }
                    else
                    {
                        return;
                    }
                    makeMove = true;
                    currentPieceX = posInBoardX;
                    currentPieceY = posInBoardY;

                    posCanMove = currentPieceSelected.posCanMove(currentPieceX,currentPieceY,game);

                    picBox_Board.Invalidate();
                }
                else
                {

                    if (game.board[posInBoardX][posInBoardY][1] == currentPieceSelected.side && game.board[posInBoardX][posInBoardY][0] != "Empty")
                    {
                        if (game.board[posInBoardX][posInBoardY][1] == "Red")
                        {
                            currentPieceSide = Pieces.posSide.Red;
                            currentPieceSideStr = "Red";
                        }
                        else
                        {
                            currentPieceSide = Pieces.posSide.Black;
                            currentPieceSideStr = "Black";
                        }

                        if (game.board[posInBoardX][posInBoardY][0] == "Chariot")
                        {
                            currentPieceSelected = new Chariot(Pieces.posType.Chariot, currentPieceSide);
                            currentPieceSelected.type = "Chariot";
                            currentPieceSelected.side = currentPieceSideStr;
                        }
                        else if (game.board[posInBoardX][posInBoardY][0] == "Horse")
                        {
                            currentPieceSelected = new Horse(Pieces.posType.Horse, currentPieceSide);
                            currentPieceSelected.type = "Horse";
                            currentPieceSelected.side = currentPieceSideStr;
                        }
                        else if (game.board[posInBoardX][posInBoardY][0] == "Elephant")
                        {
                            currentPieceSelected = new Elephant(Pieces.posType.Elephant, currentPieceSide);
                            currentPieceSelected.type = "Elephant";
                            currentPieceSelected.side = currentPieceSideStr;
                        }
                        else if (game.board[posInBoardX][posInBoardY][0] == "Guard")
                        {
                            currentPieceSelected = new Guard(Pieces.posType.Guard, currentPieceSide);
                            currentPieceSelected.type = "Guard";
                            currentPieceSelected.side = currentPieceSideStr;
                        }
                        else if (game.board[posInBoardX][posInBoardY][0] == "General")
                        {
                            currentPieceSelected = new General(Pieces.posType.General, currentPieceSide);
                            currentPieceSelected.type = "General";
                            currentPieceSelected.side = currentPieceSideStr;
                        }
                        else if (game.board[posInBoardX][posInBoardY][0] == "Cannon")
                        {
                            currentPieceSelected = new Cannon(Pieces.posType.Cannon, currentPieceSide);
                            currentPieceSelected.type = "Cannon";
                            currentPieceSelected.side = currentPieceSideStr;
                        }
                        else if (game.board[posInBoardX][posInBoardY][0] == "Soldier")
                        {
                            currentPieceSelected = new Soldier(Pieces.posType.Soldier, currentPieceSide);
                            currentPieceSelected.type = "Soldier";
                            currentPieceSelected.side = currentPieceSideStr;
                        }
                        else
                        {
                            return;
                        }
                        makeMove = true;
                        currentPieceX = posInBoardX;
                        currentPieceY = posInBoardY;

                        posCanMove = currentPieceSelected.posCanMove(currentPieceX, currentPieceY, game);

                        picBox_Board.Invalidate();
                    }
                    else
                    {
                        posCanMove = new List<List<int>>();

                        if (currentPieceSelected.move(currentPieceX, currentPieceY, posInBoardX, posInBoardY, game))
                        {
                            game.makeMove(currentPieceX, currentPieceY, posInBoardX, posInBoardY);
                            changeLbTurn();
                        }
                        else
                        {
                            game.changeSideTurn();
                            MessageBox.Show("can not move");
                        }
                        picBox_Board.Invalidate();
                        makeMove = false;
                    }
                }
                pb_piecesSelected.Invalidate();
            }

            if (game.checkWhoWin() == -1)
            {
                this.picBox_Board.MouseClick -= new System.Windows.Forms.MouseEventHandler(this.picBox_Board_MouseClick);
                MessageBox.Show("Red win");
                btn_new.Enabled = true;
            }
            else if (game.checkWhoWin() == 1)
            {
                this.picBox_Board.MouseClick -= new System.Windows.Forms.MouseEventHandler(this.picBox_Board_MouseClick);
                MessageBox.Show("Black win");
                btn_new.Enabled = true;
            }
            
        }

        private void btn_restart_Click(object sender, EventArgs e)
        {
            if (btn_new.Enabled == true)
            {
                this.picBox_Board.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picBox_Board_MouseClick);
                btn_new.Enabled = false;
            }
            game.newGame();
            picBox_Board.Invalidate();
        }
        public int delete = 0;

        private void drawBoard(object sender, PaintEventArgs e)
        {   
            
            Graphics g = e.Graphics;

            Image img = global::cs_xiangqi.Properties.Resources.pieces;

            Rectangle cropRect = new Rectangle(0, 0, 300, 300);

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (game.board[i][j][0] != "Empty")
                    {
                        if (game.board[i][j][1] == "Red")
                        {
                            cropRect.Y = 0;
                        }
                        else if (game.board[i][j][1] == "Black")
                        {
                            cropRect.Y = 300;
                        }

                        switch (game.board[i][j][0])
                        {
                            case "Chariot":
                                cropRect.X = 1200;
                                break;
                            case "Horse":
                                cropRect.X = 600;
                                break;
                            case "Elephant":
                                cropRect.X = 900;
                                break;
                            case "Guard":
                                cropRect.X = 300;
                                break;
                            case "General":
                                cropRect.X = 0;
                                break;
                            case "Cannon":
                                cropRect.X = 1500;
                                break;
                            case "Soldier":
                                cropRect.X = 1800;
                                break;
                            default:
                                break;
                        }

                        g.DrawImage(img, new Rectangle(8 + i*46, j*43, 40, 40), cropRect, GraphicsUnit.Pixel);
                    }
                }
            }
        }

        private bool checkInList(List<List<int>> l, int x, int y)
        {
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i][0] == x && l[i][1] == y)
                {
                    return true;
                }
            }
            return false;
        }

        private void drawPosCanMove(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Pen p = new Pen(Color.Red, 5);

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (checkInList(posCanMove, i, j))
                    {
                        g.DrawEllipse(p, new Rectangle(8 + i * 46 + 15, j * 43 + 15, 10, 10));
                    }
                }
            }
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            game.newGame();
            this.picBox_Board.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picBox_Board_MouseClick);
            picBox_Board.Invalidate();
            btn_new.Enabled = false;
        }

        private void picBox_Board_Paint(object sender, PaintEventArgs e)
        {
            drawBoard(sender, e);
            if (posCanMove.Count != 0)
            {
                drawPosCanMove(sender, e);
            }
        }


        private void pb_piecesSelected_Paint(object sender, PaintEventArgs e)
        {
            if (makeMove == true)
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Image img = global::cs_xiangqi.Properties.Resources.pieces;

                Rectangle cropRect = new Rectangle(0, 0, 300, 300);

                if (currentPieceSelected.type != "Empty")
                {
                    if (currentPieceSelected.side == "Red")
                    {
                        cropRect.Y = 0;
                    }
                    else if (currentPieceSelected.side == "Black")
                    {
                        cropRect.Y = 300;
                    }

                    switch (currentPieceSelected.type)
                    {
                        case "Chariot":
                            cropRect.X = 1200;
                            break;
                        case "Horse":
                            cropRect.X = 600;
                            break;
                        case "Elephant":
                            cropRect.X = 900;
                            break;
                        case "Guard":
                            cropRect.X = 300;
                            break;
                        case "General":
                            cropRect.X = 0;
                            break;
                        case "Cannon":
                            cropRect.X = 1500;
                            break;
                        case "Soldier":
                            cropRect.X = 1800;
                            break;
                        default:
                            break;
                    }

                    g.DrawImage(img, new Rectangle(0, 0, 50, 50), cropRect, GraphicsUnit.Pixel);
                }
            }
            else
            {
                Graphics g = e.Graphics;

                g.Clear(Color.White);
            }
        }

        private void btn_restart_Click_1(object sender, EventArgs e)
        {

        }


        // 141 157
    }
}
