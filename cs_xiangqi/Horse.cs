using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_xiangqi
{
    public class Horse : Pieces
    {
        public Horse() : base() { }
        public Horse(posType pType, posSide pSide) : base() { }

        private Boolean checkHorse(int curPosX, int curPosY, int desPosX, int desPosY, GameBoard game)
        {
            int moveDistanceX = desPosX - curPosX;
            int moveDistanceY = desPosY - curPosY;

            if (Math.Abs(moveDistanceX) == 1 && Math.Abs(moveDistanceY) == 2)
            {
                if (moveDistanceY == -2)
                {
                    if (desIsEmpty(curPosX, curPosY - 1, game))
                    {
                        return true;
                    }
                }
                else
                {
                    if (desIsEmpty(curPosX, curPosY + 1, game))
                    {
                        return true;
                    }
                }
            }
            else if(Math.Abs(moveDistanceX) == 2 && Math.Abs(moveDistanceY) == 1)
            {
                if (moveDistanceX == -2)
                {
                    if (desIsEmpty(curPosX -1, curPosY, game))
                    {
                        return true;
                    }
                }
                else
                {
                    if (desIsEmpty(curPosX + 1, curPosY, game))
                    {
                        return true;
                    }
                }
            }
            else
            {
                return false;
            }

            return false;
        }

        public override List<List<int>> posCanMove(int curPosX, int curPosY, GameBoard game)
        {
            List<List<int>> pos = new List<List<int>>();

            List<int> temp;

            List<List<int>> horseCase = new List<List<int>>();

            horseCase.Add(new List<int>(new int[] { -1, -2}));
            horseCase.Add(new List<int>(new int[] { -1, 2 }));
            horseCase.Add(new List<int>(new int[] { 1, -2 }));
            horseCase.Add(new List<int>(new int[] { 1, 2 }));
            horseCase.Add(new List<int>(new int[] { -2, -1}));
            horseCase.Add(new List<int>(new int[] { -2, 1 }));
            horseCase.Add(new List<int>(new int[] { 2, -1 }));
            horseCase.Add(new List<int>(new int[] { 2, 1 }));

            for (int i = 0; i < 8; i++)
            {
                if (!outOfBoard(curPosX + horseCase[i][0], curPosY + horseCase[i][1]) && move(curPosX, curPosY, curPosX + horseCase[i][0], curPosY + horseCase[i][1], game))
                {
                    temp = new List<int>();

                    temp.AddRange(new int[] { curPosX + horseCase[i][0], curPosY + horseCase[i][1] });

                    pos.Add(temp);
                }
            }

            // 8 case
            //-1,-2
            //-1,2
            //1,-2
            //1,2
            //-2,-1
            //-2,1
            //2,-1
            //2,1

            return pos;
        }

        public override bool move(int curPosX, int curPosY, int desPosX, int desPosY, GameBoard game)
        {
            if (base.move(curPosX, curPosY, desPosX, desPosY, game))
            {
                if (checkHorse(curPosX, curPosY, desPosX, desPosY, game))
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
