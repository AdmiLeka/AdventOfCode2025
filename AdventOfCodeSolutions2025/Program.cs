using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeSolutions2025
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //--- Day 1: Secret Entrance --- PART 1
            int SecretCombinationPartOne = Solutions.GetKeyCombinationPartOne(50, Path.Combine(AppContext.BaseDirectory, "PuzzleInputs", "SecretEntranceCombination.txt"));
            //--- Day 1: Secret Entrance --- PART 2
            int SecretCombinationPartTwo = Solutions.GetKeyCombinationPartTwo(50, Path.Combine(AppContext.BaseDirectory, "PuzzleInputs", "SecretEntranceCombination.txt"));
            //--- Day 2: Gift Shop --- PART 1
            long lInvalidIDsSum = Solutions.FindAllInvalidIDsAndAddThem(Path.Combine(AppContext.BaseDirectory, "PuzzleInputs", "GiftShopIDRanges.txt"));
        }
    }
}
