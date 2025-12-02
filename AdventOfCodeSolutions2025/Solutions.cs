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
        public static int GetKeyCombinationPartOne(int iStartingPoint, string sPathToTxtFileWithLockCombinations)
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

        //--- Day 1: Secret Entrance --- PART 2
        public static int GetKeyCombinationPartTwo(int iStartingPoint, string sPathToTxtFileWithLockCombinations)
        {
            int iTimesCombinationWasZero = 0;
            int iKeyCombination = iStartingPoint;

            var sFileContent = File.ReadLines(sPathToTxtFileWithLockCombinations);

            foreach (string line in sFileContent)
            {
                if (line.StartsWith("L"))
                {
                    int iNumberOfLeftTurns = Convert.ToInt32(line.Substring(1)) % 100;

                    iTimesCombinationWasZero += Convert.ToInt32(line.Substring(1)) / 100;

                    int iPositionAfterTurning = iKeyCombination - iNumberOfLeftTurns;

                    if (iPositionAfterTurning < 0)
                    {
                        //iTimesCombinationWasZero++;
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

                    iTimesCombinationWasZero += Convert.ToInt32(line.Substring(1)) / 100;

                    int iPositionAfterTurning = iKeyCombination + iNumberOfRightTurns;

                    if (iPositionAfterTurning >= 100)
                    {
                        iTimesCombinationWasZero++;
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

        //--- Day 2: Gift Shop --- PART 1
        public static long FindAllInvalidIDsAndAddThem(string sPathToTxtFileWithAllIDsToCheck)
        {
            long lInvalidIDsSum = 0;

            string[] sArrayOfIDRanges = File.ReadAllText(sPathToTxtFileWithAllIDsToCheck).Split(',');
            
            foreach (string sID in sArrayOfIDRanges)
            {
                string[] IDRanges = sID.Split('-');

                long lRangeFrom = Convert.ToInt64(IDRanges[0]);
                long lRangeTo = Convert.ToInt64(IDRanges[1]);

                while (lRangeFrom < lRangeTo)
                {

                    string sCurrentNumberAsString = lRangeFrom.ToString();

                    if (sCurrentNumberAsString[0] == '0') continue;

                    if (sCurrentNumberAsString.Length % 2 == 0 && sCurrentNumberAsString.Substring(0, (sCurrentNumberAsString.Length / 2)) == sCurrentNumberAsString.Substring((sCurrentNumberAsString.Length / 2)))
                    {
                        lInvalidIDsSum += lRangeFrom;
                    }

                    lRangeFrom++;
                }
            }

            return lInvalidIDsSum;
        }
    }
}
