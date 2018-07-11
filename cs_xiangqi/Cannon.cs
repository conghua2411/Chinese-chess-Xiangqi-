using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_xiangqi
{
    public class Cannon : Pieces
    {
        public Cannon() : base() { }
        public Cannon(posType pType, posSide pSide) : base(pType, pSide) { }

        public override List<List<int>> posCanMove(int curPosX, int curPosY, GameBoard game)
        {
            List<List<int>> pos = base.posCanMove(curPosX, curPosY, game);

            int count = -1;
            List<int> temp;
            //left
            for (int i = 0; i < curPosX; i++)
            {
                if (game.board[curPosX - i - 1][curPosY][0] != "Empty")
                {
                    count++;
                }

                if (move(curPosX, curPosY, curPosX - i - 1, curPosY, game))
                {
                    if (count == 1)
                    {
                        if (side != game.board[curPosX - i - 1][curPosY][1])
                        {
                            temp = new List<int>();

                            temp.AddRange(new int[] { curPosX - i - 1, curPosY });

                            pos.Add(temp);
                        }
                    }
                }
            }

            count = -1;
            //right
            for (int i = 0; i < 8 - curPosX; i++)
            {
                if (game.board[curPosX + i + 1][curPosY][0] != "Empty")
                {
                    count++;
                }

                if (move(curPosX, curPosY, curPosX + i + 1, curPosY, game))
                {
                    if (count == 1)
                    {
                        if (side != game.board[curPosX + i + 1][curPosY][1])
                        {
                            temp = new List<int>();

                            temp.AddRange(new int[] { curPosX + i + 1, curPosY });

                            pos.Add(temp);
                        }
                    }
                }
            }

            count = -1;
            //up
            for (int i = 0; i < curPosY; i++)
            {
                if (game.board[curPosX][curPosY - i - 1][0] != "Empty")
                {
                    count++;
                }

                if (move(curPosX, curPosY, curPosX, curPosY - i - 1, game))
                {
                    if (count == 1)
                    {
                        if (side != game.board[curPosX][curPosY - i - 1][1])
                        {
                            temp = new List<int>();

                            temp.AddRange(new int[] { curPosX, curPosY - i - 1 });

                            pos.Add(temp);
                        }
                    }
                }
            }

            count = -1;
            //down
            for (int i = 0; i < 9 - curPosY; i++)
            {
                if (game.board[curPosX][curPosY + i + 1][0] != "Empty")
                {
                    count++;
                }

                if (move(curPosX, curPosY, curPosX, curPosY + i + 1, game))
                {
                    if (count == 1)
                    {
                        if (side != game.board[curPosX][curPosY + i + 1][1])
                        {
                            temp = new List<int>();

                            temp.AddRange(new int[] { curPosX, curPosY + i + 1 });

                            pos.Add(temp);
                        }
                    }
                }
            }

            return pos;
        }

        public override bool move(int curPosX, int curPosY, int desPosX, int desPosY, GameBoard game)
        {
            if (base.move(curPosX, curPosY, desPosX, desPosY, game))
            {
                if (side != game.board[desPosX][desPosY][1] && countAnotherPiecesInLine(curPosX, curPosY, desPosX, desPosY, game) == 0 && game.board[desPosX][desPosY][1] != "Empty")
                {
                    return false;
                }

                if (countAnotherPiecesInLine(curPosX, curPosY, desPosX, desPosY, game) == 0)
                {
                    return true;
                }
                else if (countAnotherPiecesInLine(curPosX, curPosY, desPosX, desPosY, game) == 1 && game.board[desPosX][desPosY][0] != posType.Empty.ToString() && game.board[desPosX][desPosY][1] != side)
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
    }
}
