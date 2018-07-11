using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_xiangqi
{
    public class Elephant : Pieces
    {
        public Elephant() : base() { }
        public Elephant(posType pType, posSide pSide) : base(pType, pSide) { }

        private bool checkElephant(int curPosX, int curPosY, int desPosX, int desPosY, GameBoard game)
        {
            if(isPassTheRiver(desPosX,desPosY,game))
            {
                return false;
            }

            int moveDistanceX = desPosX - curPosX;
            int moveDistanceY = desPosY - curPosY;

            if (Math.Abs(moveDistanceX) == Math.Abs(moveDistanceY) && Math.Abs(moveDistanceX) == 2)
            {
                if (desIsEmpty(curPosX + moveDistanceX / 2, curPosY + moveDistanceY / 2, game))
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

            List<List<int>> elephantCase = new List<List<int>>();

            elephantCase.Add(new List<int>(new int[] { -2, -2 }));
            elephantCase.Add(new List<int>(new int[] { -2, 2 }));
            elephantCase.Add(new List<int>(new int[] { 2, -2 }));
            elephantCase.Add(new List<int>(new int[] { 2, 2 }));

            for (int i = 0; i < 4; i++)
            {
                if (!outOfBoard(curPosX + elephantCase[i][0], curPosY + elephantCase[i][1]) && move(curPosX, curPosY, curPosX + elephantCase[i][0], curPosY + elephantCase[i][1], game))
                {
                    temp = new List<int>();

                    temp.AddRange(new int[] { curPosX + elephantCase[i][0], curPosY + elephantCase[i][1] });

                    pos.Add(temp);
                }
            }

            return pos;
        }

        public override bool move(int curPosX, int curPosY, int desPosX, int desPosY, GameBoard game)
        {
            if (base.move(curPosX, curPosY, desPosX, desPosY, game))
            {
                if (checkElephant(curPosX, curPosY, desPosX, desPosY, game))
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
