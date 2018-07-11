using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cs_xiangqi
{

    public class GameBoard
    {
        public enum posType
        {
            Empty,
            Soldier,
            Cannon,
            Chariot,
            Horse,
            Elephant,
            Guard,
            General
        };

        public enum posSide
        {
            Empty,
            Red,
            Black
        }

        public string[][][] board = new string[9][][];
        public string sideTurn;
        public GameBoard()
        {
            sideTurn = "Red";

            for (int i = 0; i < 9; i++)
            {
                board[i] = new string[10][];
                for (int j = 0; j < 10; j++)
                {
                    board[i][j] = new string[2];

                    // set pieces type and side
                    board[i][j][0] = posType.Empty.ToString();
                    board[i][j][1] = posSide.Empty.ToString();
                }
            }
        }

        private void clearBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board[i][j][0] = posType.Empty.ToString();
                    board[i][j][1] = posSide.Empty.ToString();
                }
            }
        }

        public void changeSideTurn()
        {
            if (sideTurn == "Red")
            {
                sideTurn = "Black";
            }
            else if (sideTurn == "Black")
            {
                sideTurn = "Red";
            }
        }

        private bool findPieces(string type, string side)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (board[i][j][0] == type && board[i][j][1] == side)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //-1 red win
        // 0 
        // 1 black win
        public int checkWhoWin()
        {
            if (!findPieces("General", "Black"))
            {
                return -1;
            }
            else if (!findPieces("General", "Red"))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public void newGame()
        {
            sideTurn = "Red";
            clearBoard();
            // Red team
                // Chariot
            board[0][0][0] = posType.Chariot.ToString();
            board[0][0][1] = posSide.Red.ToString();
            board[8][0][0] = posType.Chariot.ToString();
            board[8][0][1] = posSide.Red.ToString();
                
                // Horse
            board[1][0][0] = posType.Horse.ToString();
            board[1][0][1] = posSide.Red.ToString();
            board[7][0][0] = posType.Horse.ToString();
            board[7][0][1] = posSide.Red.ToString();

                // Elephant
            board[2][0][0] = posType.Elephant.ToString();
            board[2][0][1] = posSide.Red.ToString();
            board[6][0][0] = posType.Elephant.ToString();
            board[6][0][1] = posSide.Red.ToString();

                // Guard
            board[3][0][0] = posType.Guard.ToString();
            board[3][0][1] = posSide.Red.ToString();
            board[5][0][0] = posType.Guard.ToString();
            board[5][0][1] = posSide.Red.ToString();

                // General
            board[4][0][0] = posType.General.ToString();
            board[4][0][1] = posSide.Red.ToString();

                // Cannon
            board[1][2][0] = posType.Cannon.ToString();
            board[1][2][1] = posSide.Red.ToString();
            board[7][2][0] = posType.Cannon.ToString();
            board[7][2][1] = posSide.Red.ToString();

                // Soldier
            board[0][3][0] = posType.Soldier.ToString();
            board[0][3][1] = posSide.Red.ToString();
            board[2][3][0] = posType.Soldier.ToString();
            board[2][3][1] = posSide.Red.ToString();
            board[4][3][0] = posType.Soldier.ToString();
            board[4][3][1] = posSide.Red.ToString();
            board[6][3][0] = posType.Soldier.ToString();
            board[6][3][1] = posSide.Red.ToString();
            board[8][3][0] = posType.Soldier.ToString();
            board[8][3][1] = posSide.Red.ToString();


            // Black team
                // Chariot
            board[0][9][0] = posType.Chariot.ToString();
            board[0][9][1] = posSide.Black.ToString();
            board[8][9][0] = posType.Chariot.ToString();
            board[8][9][1] = posSide.Black.ToString();

                // Horse
            board[1][9][0] = posType.Horse.ToString();
            board[1][9][1] = posSide.Black.ToString();
            board[7][9][0] = posType.Horse.ToString();
            board[7][9][1] = posSide.Black.ToString();

                // Elephant
            board[2][9][0] = posType.Elephant.ToString();
            board[2][9][1] = posSide.Black.ToString();
            board[6][9][0] = posType.Elephant.ToString();
            board[6][9][1] = posSide.Black.ToString();

                // Guard
            board[3][9][0] = posType.Guard.ToString();
            board[3][9][1] = posSide.Black.ToString();
            board[5][9][0] = posType.Guard.ToString();
            board[5][9][1] = posSide.Black.ToString();

                // General
            board[4][9][0] = posType.General.ToString();
            board[4][9][1] = posSide.Black.ToString();

                // Cannon
            board[1][7][0] = posType.Cannon.ToString();
            board[1][7][1] = posSide.Black.ToString();
            board[7][7][0] = posType.Cannon.ToString();
            board[7][7][1] = posSide.Black.ToString();

                // Soldier
            board[0][6][0] = posType.Soldier.ToString();
            board[0][6][1] = posSide.Black.ToString();
            board[2][6][0] = posType.Soldier.ToString();
            board[2][6][1] = posSide.Black.ToString();
            board[4][6][0] = posType.Soldier.ToString();
            board[4][6][1] = posSide.Black.ToString();
            board[6][6][0] = posType.Soldier.ToString();
            board[6][6][1] = posSide.Black.ToString();
            board[8][6][0] = posType.Soldier.ToString();
            board[8][6][1] = posSide.Black.ToString();

        }

        public void setPosPieces(posType type, posSide side, int x, int y)
        {
            if (x < 0 || x > 9 || y < 0 || y > 10)
            {
                MessageBox.Show("error setPosPieces out of range");
            }
            else
            {
                board[x][y][0] = type.ToString();
                board[x][y][1] = side.ToString();                
            }
        }

        public void makeMove(int curPosX, int curPosY, int desPosX, int desPosY)
        {
            board[desPosX][desPosY][0] = board[curPosX][curPosY][0];
            board[desPosX][desPosY][1] = board[curPosX][curPosY][1];

            board[curPosX][curPosY][0] = posType.Empty.ToString();
            board[curPosX][curPosY][1] = posSide.Empty.ToString();
        }
    }

}
