using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeSolutions2025
{
    public class HelperMethods
    {
        public static int GetMaxNumberFromAStringNumberSequence(string sNumberSequenceAsString, ref int iIndex)
        {
            List<int> liListOfAllNumbers = new List<int>();

            for (int i = 0; i < sNumberSequenceAsString.Length; i++)
            {
                liListOfAllNumbers.Add(sNumberSequenceAsString[i]);
            }
            iIndex = liListOfAllNumbers.IndexOf(liListOfAllNumbers.Max());
            return liListOfAllNumbers.Max();
        }
    }
}
