using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_xiangqi
{
    public class Guard : Pieces
    {
        public Guard() : base() { }
        public Guard(posType pType, posSide pSide) : base(pType, pSide) { }

        private bool checkGuard(int curPosX, int curPosY, int desPosX, int desPosY, GameBoard game)
        {
            int moveDistanceX = desPosX - curPosX;
            int moveDistanceY = desPosY - curPosY;

            if (Math.Abs(moveDistanceX) == Math.Abs(moveDistanceY) && Math.Abs(moveDistanceX) == 1)
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
            List<List<int>> pos = new List<List<int>>();

            List<int> temp;

            List<List<int>> guardCase = new List<List<int>>();

            guardCase.Add(new List<int>(new int[] { -1, -1 }));
            guardCase.Add(new List<int>(new int[] { -1, 1 }));
            guardCase.Add(new List<int>(new int[] { 1, -1 }));
            guardCase.Add(new List<int>(new int[] { 1, 1 }));

            for (int i = 0; i < 4; i++)
            {
                if (!outOfBoard(curPosX + guardCase[i][0], curPosY + guardCase[i][1]) && move(curPosX, curPosY, curPosX + guardCase[i][0], curPosY + guardCase[i][1], game))
                {
                    temp = new List<int>();

                    temp.AddRange(new int[] { curPosX + guardCase[i][0], curPosY + guardCase[i][1] });

                    pos.Add(temp);
                }
            }

            return pos;
        }

        public override bool move(int curPosX, int curPosY, int desPosX, int desPosY, GameBoard game)
        {
            if (base.move(curPosX, curPosY, desPosX, desPosY, game))
            {
                if (checkGuard(curPosX, curPosY, desPosX, desPosY, game))
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
