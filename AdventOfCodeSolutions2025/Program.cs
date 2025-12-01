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
            int SecretCombination = Solutions.GetKeyCombination(50, Path.Combine(AppContext.BaseDirectory, "PuzzleInputs", "SecretEntranceCombination.txt"));
        }
    }
}
