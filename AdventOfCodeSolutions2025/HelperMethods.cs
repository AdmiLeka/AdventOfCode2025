using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeSolutions2025
{
    public class HelperMethods
    {
        public static int GetMaxNumberFromAStringNumberSequencePartOne(string sNumberSequenceAsString, ref int iIndex)
        {
            List<int> liListOfAllNumbers = new List<int>();

            for (int i = 0; i < sNumberSequenceAsString.Length; i++)
            {
                liListOfAllNumbers.Add(Convert.ToInt32(sNumberSequenceAsString[i].ToString()));
            }
            iIndex = liListOfAllNumbers.IndexOf(liListOfAllNumbers.Max());
            return Convert.ToInt32(liListOfAllNumbers.Max().ToString());
        }


        public static int GetMaxNumberFromAStringNumberSequencePartTwo(string sNumberSequenceAsString, ref int iIndex, ref string sNewNumberSequence)
        {
            List<int> liListOfAllNumbers = new List<int>();

            for (int i = 0; i < sNumberSequenceAsString.Length; i++)
            {
                liListOfAllNumbers.Add(Convert.ToInt32(sNumberSequenceAsString[i].ToString()));
            }
            iIndex = liListOfAllNumbers.IndexOf(liListOfAllNumbers.Max()) + 1;
            if (iIndex == sNewNumberSequence.Length) return Convert.ToInt32(liListOfAllNumbers.Max().ToString());
            sNewNumberSequence = sNewNumberSequence.Substring(iIndex, sNewNumberSequence.Length - iIndex);
            return Convert.ToInt32(liListOfAllNumbers.Max().ToString());
        }
    }
}
