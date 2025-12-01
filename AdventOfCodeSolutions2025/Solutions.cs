using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeSolutions2025
{
    public class Solutions
    {
        //--- Day 1: Secret Entrance --- PART 1
        public static int GetKeyCombination(int iStartingPoint, string sPathToTxtFileWithLockCombinations)
        {
            int iTimesCombinationWasZero = 0;

            int iKeyCombination = iStartingPoint;

            var sFileContent = File.ReadLines(sPathToTxtFileWithLockCombinations);

            foreach (string line in sFileContent) 
            {
                if (line.StartsWith("L"))
                {
                    int iNumberOfLeftTurns = Convert.ToInt32(line.Substring(1)) % 100;

                    int iPositionAfterTurning = iKeyCombination - iNumberOfLeftTurns;

                    if (iPositionAfterTurning < 0)
                    {
                        iKeyCombination = Math.Abs(100 + iPositionAfterTurning);
                    }
                    else
                    {
                        iKeyCombination -= iNumberOfLeftTurns;
                    }
                }
                else if (line.StartsWith("R"))
                {
                    int iNumberOfRightTurns = Convert.ToInt32(line.Substring(1)) % 100;

                    int iPositionAfterTurning = iKeyCombination + iNumberOfRightTurns;

                    if (iPositionAfterTurning >= 100)
                    {
                        iKeyCombination = Math.Abs(100 - iPositionAfterTurning);
                    }
                    else
                    {
                        iKeyCombination += iNumberOfRightTurns;
                    }
                }

                if (iKeyCombination == 0)
                {
                    iTimesCombinationWasZero++;
                }
            }

            return iTimesCombinationWasZero;
        }
    }
}
