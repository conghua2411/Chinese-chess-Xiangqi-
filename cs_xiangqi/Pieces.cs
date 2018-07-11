using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace cs_xiangqi
{
    public abstract class Pieces
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

        public string side;
        public string type;

        public Pieces()
        {
            side = posSide.Empty.ToString();
            type = posType.Empty.ToString();
        }

        public Pieces(posType pType, posSide pSide)
        {
            this.side = pSide.ToString();
            this.type = pType.ToString();
        }

        protected Boolean desIsEmptyOrDifferenceSide(int desPosX, int desPosY, GameBoard game)
        {
            if (game.board[desPosX][desPosY][0] == posType.Empty.ToString() || game.board[desPosX][desPosY][1] != side)
            {
                return true;
            }
            return false;
        }

        protected Boolean desIsEmpty(int desPosX, int desPosY, GameBoard game)
        {
            if (game.board[desPosX][desPosY][0] == posType.Empty.ToString())
            {
                return true;
            }
            return false;
        }

        protected bool desInPalace(int desPosX, int desPosY, GameBoard game)
        {
            if (desPosY <= 2)
            {
                if (desPosX >= 3 && desPosX <= 5)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (desPosY >= 7)
            {
                if (desPosX >= 3 && desPosX <= 5)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        protected bool isPassTheRiver(int desPosX, int desPosY, GameBoard game)
        {

            if (side == "Red")
            {
                if (desPosY > 4)
                {
                    return true; 
                }
                else
                {
                    return false;
                }
            }
            else if(side == "Black")
            {
                if (desPosY < 5)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        protected int countAnotherPiecesInLine(int curPosX, int curPosY, int desPosX, int desPosY, GameBoard game)
        {
            int i, j, n;
            int count = 0;

            if (curPosX == desPosX)
            {
                j = curPosX;
                if (curPosY < desPosY)
                {
                    i = curPosY;
                    n = desPosY;
                }
                else
                {
                    i = desPosY;
                    n = curPosY;
                }

                i += 1;
                for (; i < n; i++)
                {
                    if(game.board[j][i][0] != posType.Empty.ToString())
                    {
                        count++;
                    }
                }
            }
            else if (curPosY == desPosY)
            {
                j = curPosY;
                if (curPosX < desPosX)
                {
                    i = curPosX;
                    n = desPosX;
                }
                else
                {
                    i = desPosX;
                    n = curPosX;
                }

                i += 1;
                for (; i < n; i++)
                {
                    if (game.board[i][j][0] != posType.Empty.ToString())
                    {
                        count++;
                    }
                }
            }
            else
            {
                return -1;
            }

            return count;
        }

        protected bool outOfBoard(int posX, int posY)
        {
            if (posX < 0 || posX > 8 || posY < 0 || posY > 9)
            {
                return true;
            }
            return false;
        }

        public virtual Boolean move(int curPosX, int curPosY, int desPosX, int desPosY, GameBoard game)
        {
            return desIsEmptyOrDifferenceSide(desPosX, desPosY, game);
        }

        public virtual int countPosCanMove(int curPosX, int curPosY, GameBoard game)
        {
            return 0;
        }

        public virtual List<List<int>> posCanMove(int curPosX, int curPosY, GameBoard game)
        {
            List<List<int>> pos = new List<List<int>>();

            List<int> temp;

            //left
            for (int i = 0; i < curPosX; i++)
            {
                if (move(curPosX, curPosY, curPosX - i - 1, curPosY, game))
                {
                    temp = new List<int>();

                    temp.AddRange(new int[] { curPosX - i - 1, curPosY });

                    pos.Add(temp);
                }
                else
                {
                    break;
                }
            }
            //right
            for (int i = 0; i < 8 - curPosX; i++)
            {
                if (move(curPosX, curPosY, curPosX + i + 1, curPosY, game))
                {
                    temp = new List<int>();

                    temp.AddRange(new int[] { curPosX + i + 1, curPosY });

                    pos.Add(temp);
                }
                else
                {
                    break;
                }
            }

            //up
            for (int i = 0; i < curPosY; i++)
            {
                if (move(curPosX, curPosY, curPosX, curPosY - i - 1, game))
                {
                    temp = new List<int>();

                    temp.AddRange(new int[] { curPosX, curPosY - i - 1 });

                    pos.Add(temp);
                }
                else
                {
                    break;
                }
            }
            //down
            for (int i = 0; i < 9 - curPosY; i++)
            {
                if (move(curPosX, curPosY, curPosX, curPosY + i + 1, game))
                {
                    temp = new List<int>();

                    temp.AddRange(new int[] { curPosX, curPosY + i + 1 });

                    pos.Add(temp);
                }
                else
                {
                    break;
                }
            }

            return pos;
        }
    }
}
