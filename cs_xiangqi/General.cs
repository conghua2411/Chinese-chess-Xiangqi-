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

            if (countAnotherPiecesInLine(curPosX, curPosY, desPosX, desPosY, game) == 0 && game.board[desPosX][desPosY][0] == "General")
            {
                return true;
            }

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
            List<List<int>> pos = base.posCanMove(curPosX, curPosY, game);

            string enemySide = "Empty";

            if (side == "Red")
            {
                enemySide = "Black";
            }
            else if(side == "Black")
            {
                enemySide = "Red";
            }

            List<int> generalEnemyPos = getPiecePosition("General", enemySide, game);

            if (countAnotherPiecesInLine(curPosX, curPosY, generalEnemyPos[0], generalEnemyPos[1], game) == 0)
            {
                List<int> temp = new List<int>(new int[] { generalEnemyPos[0], generalEnemyPos[1]});
                pos.Add(temp);
            }

            return pos;
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
