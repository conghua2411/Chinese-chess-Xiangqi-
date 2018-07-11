using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_xiangqi
{
    public class General : Pieces
    {
        public General() : base() { }
        public General(posType pType, posSide pSide) : base(pType, pSide) { }

        private bool checkGeneral(int curPosX, int curPosY, int desPosX, int desPosY, GameBoard game)
        {
            int moveDistanceX = desPosX - curPosX;
            int moveDistanceY = desPosY - curPosY;

            if (Math.Abs(moveDistanceX + moveDistanceY) == 1)
            {
                if (desInPalace(desPosX, desPosY, game))
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

        public override List<List<int>> posCanMove(int curPosX, int curPosY, GameBoard game)
        {
            return base.posCanMove(curPosX, curPosY, game);
        }

        public override bool move(int curPosX, int curPosY, int desPosX, int desPosY, GameBoard game)
        {
            if (base.move(curPosX, curPosY, desPosX, desPosY, game))
            {
                if (checkGeneral(curPosX, curPosY, desPosX, desPosY, game))
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
