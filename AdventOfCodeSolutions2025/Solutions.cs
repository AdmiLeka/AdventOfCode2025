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

            IEnumerable<string> sFileContent = File.ReadLines(sPathToTxtFileWithLockCombinations);

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
        public static long FindAllInvalidIDsAndAddThemPartOne(string sPathToTxtFileWithAllIDsToCheck)
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

        //--- Day 2: Gift Shop --- PART 2
        // SOLUTION ONLY CONSIDERS NUMBERS UP TO 10 DIGITS
        public static long FindAllInvalidIDsAndAddThemPartTwo(string sPathToTxtFileWithAllIDsToCheck)
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

                    else if (sCurrentNumberAsString.Length % 2 == 0 && sCurrentNumberAsString.Substring(0, (sCurrentNumberAsString.Length / 2)) == sCurrentNumberAsString.Substring((sCurrentNumberAsString.Length / 2)))
                    {
                        lInvalidIDsSum += lRangeFrom;
                        lRangeFrom++;
                        continue;
                    }
                    else if (sCurrentNumberAsString.Length % 3 == 0
                        && sCurrentNumberAsString.Substring(0, (sCurrentNumberAsString.Length / 3)) == sCurrentNumberAsString.Substring((sCurrentNumberAsString.Length / 3), (sCurrentNumberAsString.Length / 3))
                        && sCurrentNumberAsString.Substring(0, (sCurrentNumberAsString.Length / 3) * 2) == sCurrentNumberAsString.Substring((sCurrentNumberAsString.Length / 3)))
                    {
                        lInvalidIDsSum += lRangeFrom;
                    }
                    else if (sCurrentNumberAsString.Length == 10
                        && sCurrentNumberAsString.Substring(0, 2) == sCurrentNumberAsString.Substring(2, 2)
                        && sCurrentNumberAsString.Substring(0, 2) == sCurrentNumberAsString.Substring(4, 2)
                        && sCurrentNumberAsString.Substring(4, 2) == sCurrentNumberAsString.Substring(6, 2)
                        && sCurrentNumberAsString.Substring(6, 2) == sCurrentNumberAsString.Substring(8, 2))
                    {
                        lInvalidIDsSum += lRangeFrom;
                    }
                    else if (sCurrentNumberAsString.Length % 2 == 1 && sCurrentNumberAsString.Length > 1)
                    {
                        bool bAreAllNumbersTheSame = false;

                        int iNumberLength = sCurrentNumberAsString.Length;
                        int iCounter = 0;

                        while (iCounter < iNumberLength - 1)
                        {
                            bAreAllNumbersTheSame = sCurrentNumberAsString[iCounter] == sCurrentNumberAsString[iCounter + 1] ? true : false;
                            if (!bAreAllNumbersTheSame) break;
                            iCounter++;
                        }

                        if (bAreAllNumbersTheSame)
                        {
                            lInvalidIDsSum += lRangeFrom;
                        }
                    }

                    lRangeFrom++;
                }
            }

            return lInvalidIDsSum;
        }

        //--- Day 3: Lobby --- PART 1
        public static int FindTheMaximumJoltageFromBatteriesPartOne(string sPathToTxtFileWithAllBatteryBanks)
        {
            int iMaximumJoltage = 0;
            int iIndexOfFirstMaxNumber = 0;
            string sNumberSequence = String.Empty;

            IEnumerable<string> iesBatteryBanks = File.ReadLines(sPathToTxtFileWithAllBatteryBanks);

            foreach (string sBatteryBank in iesBatteryBanks)
            {
                int iFirstMaxDigit = HelperMethods.GetMaxNumberFromAStringNumberSequencePartOne(sBatteryBank, ref iIndexOfFirstMaxNumber);
                int iSecondMaxDigit = 0;

                if (iIndexOfFirstMaxNumber == sBatteryBank.Length - 1)
                {
                    iSecondMaxDigit = HelperMethods.GetMaxNumberFromAStringNumberSequencePartOne(sBatteryBank.Substring(0, sBatteryBank.Length - 1), ref iIndexOfFirstMaxNumber);
                    iMaximumJoltage += Convert.ToInt32($"{iSecondMaxDigit.ToString()}{iFirstMaxDigit.ToString()}");
                }
                else if (iIndexOfFirstMaxNumber == sBatteryBank.Length - 2)
                {
                    iSecondMaxDigit = Convert.ToInt32(sBatteryBank.Last().ToString());
                    iMaximumJoltage += Convert.ToInt32($"{iFirstMaxDigit.ToString()}{iSecondMaxDigit.ToString()}");
                }
                else
                {
                    iSecondMaxDigit = HelperMethods.GetMaxNumberFromAStringNumberSequencePartOne(sBatteryBank.Substring(iIndexOfFirstMaxNumber + 1), ref iIndexOfFirstMaxNumber);

                    iMaximumJoltage += Convert.ToInt32($"{iFirstMaxDigit.ToString()}{iSecondMaxDigit.ToString()}");
                }
            }

            return iMaximumJoltage;
        }

        //--- Day 3: Lobby --- PART 2
        public static long FindTheMaximumJoltageFromBatteriesPartTwo(string sPathToTxtFileWithAllBatteryBanks)
        {
            long iMaximumJoltage = 0;
            string sNumberSequence = String.Empty;
            int iIndexOfFirstMaxNumber = 0;

            StringBuilder sbMaxJoltageNumberAsString = new StringBuilder();

            IEnumerable<string> iesBatteryBanks = File.ReadLines(sPathToTxtFileWithAllBatteryBanks);

            foreach (string sBatteryBank in iesBatteryBanks)
            {
                sNumberSequence = sBatteryBank;

                for (int i = 11; i >= 0; i--)
                {
                    sbMaxJoltageNumberAsString.Append(HelperMethods.GetMaxNumberFromAStringNumberSequencePartTwo(sNumberSequence.Substring(0, sNumberSequence.Length - i), ref iIndexOfFirstMaxNumber, ref sNumberSequence).ToString());
                }
                iMaximumJoltage += Convert.ToInt64(sbMaxJoltageNumberAsString.ToString());
                sbMaxJoltageNumberAsString.Clear();
                iIndexOfFirstMaxNumber = 0;
            }

            return iMaximumJoltage;
        }
    }
}
