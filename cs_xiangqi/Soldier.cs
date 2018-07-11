using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_xiangqi
{
    public class Soldier : Pieces
    {
        public Soldier() : base() { }
        public Soldier(posType pType, posSide pSide) : base(pType, pSide) { }

        public bool passTheRiver = false;

        private bool checkSoldier(int curPosX, int curPosY, int desPosX, int desPosY, GameBoard game)
        {
            if (Math.Abs(desPosX - curPosX) + Math.Abs(desPosY - curPosY) > 1)
            {
                return false;
            }

            if (isPassTheRiver(desPosX, desPosY, game))
            {
                passTheRiver = true;
            }

            if (passTheRiver == false)
            {
                if (game.board[curPosX][curPosY][1] == posSide.Red.ToString())
                {
                    if (desPosY - curPosY == 1 && desPosX == curPosX)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if(game.board[curPosX][curPosY][1] == posSide.Black.ToString())
                {
                    if (desPosY - curPosY == -1 && desPosX == curPosX)
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
            else
            {
                if (side == posSide.Red.ToString())
                {
                    if (desPosY - curPosY == -1 && desPosX == curPosX)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else if (side == posSide.Black.ToString())
                {
                    if (desPosY - curPosY == 1 && desPosX == curPosX)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public override List<List<int>> posCanMove(int curPosX, int curPosY, GameBoard game)
        {
            return base.posCanMove(curPosX, curPosY, game);
        }

        public override bool move(int curPosX, int curPosY, int desPosX, int desPosY, GameBoard game)
        {
            if (base.move(curPosX, curPosY, desPosX, desPosY, game))
            {
                if (checkSoldier(curPosX, curPosY, desPosX, desPosY, game))
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
