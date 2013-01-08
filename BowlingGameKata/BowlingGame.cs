using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameKata
{
    public class BowlingGame
    {
        private int[][] Frames = new int[10][];
        private int FrameIndex = 0;
        private int RollIndex = 0;

        public BowlingGame()
        {
            for (int i = 0; i < Frames.Length; i++)
                Frames[i] = new int[2];
            Frames[9] = new int[3];
        }

        public void Roll(int Pins)
        {
            Frames[FrameIndex][RollIndex++] = Pins;
            if ((RollIndex == 2 && FrameIndex != 9) || IsStrike(Frames[FrameIndex]))
            {
                RollIndex = 0;
                FrameIndex++;
            }
        }

        public int GetScore()
        {
            int score = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(Frames[frame]))
                    score += 10 + StrikeBonus(frame);
                else if (IsSpare(Frames[frame]))
                    score += 10 + SpareBonus(frame);
                else
                    score += FrameScore(Frames[frame]);
            }

            return score;
        }

        private int StrikeBonus(int frame)
        {
            int bonus = Frames[frame + 1][0];
            if (IsStrike(Frames[frame + 1]))
                bonus += Frames[frame + 2][0];
            else
                bonus += Frames[frame + 1][1];
            return bonus;
        }

        private int SpareBonus(int frame)
        {
            return Frames[frame + 1][0];
        }

        private int FrameScore(int[] Frame)
        {
            int score = 0;
            foreach (int Roll in Frame)
                score += Roll;
            return score;
        }

        private bool IsStrike(int[] frame)
        {
            return frame[0] == 10;
        }

        private bool IsSpare(int[] frame)
        {
            return frame[0] + frame[1] == 10;
        }
    }
}
