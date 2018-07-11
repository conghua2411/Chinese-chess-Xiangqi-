using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace cs_xiangqi
{
    public class Chariot : Pieces
    {
        public Chariot() : base()
        { 
  
        }

        public Chariot(posType pType, posSide pSide) : base(pType, pSide) 
        {
        }

        public override int countPosCanMove(int curPosX, int curPosY, GameBoard game)
        {
            int count = 0;

            //left
            for (int i = 0; i < curPosX; i++)
            {
                if (move(curPosX, curPosY, curPosX - i - 1, curPosY, game))
                {
                    count++;
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
                    count++;
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
                    count++;
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
                    count++;
                }
                else
                {
                    break;
                }
            }
            return count;
        }

        public override List<List<int>> posCanMove(int curPosX, int curPosY, GameBoard game)
        {
            return base.posCanMove(curPosX, curPosY, game);
        }

        public override Boolean move(int curPosX, int curPosY, int desPosX, int desPosY, GameBoard game)
        {
            if (base.move(curPosX, curPosY, desPosX, desPosY, game))
            {
                if (countAnotherPiecesInLine(curPosX, curPosY, desPosX, desPosY, game) == 0)
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
