using System;

namespace CFA.Service
{
    public class PuzzleService : IPuzzleService
    {
        public int Solve(string stream)
        {
            var puzzleTree = new PuzzleTree();

            try
            {
                int index = 0;
                int nodeScore = 1;

                puzzleTree.Root = Puzzle.ParseGroup(stream, ref index, nodeScore);
            }
            catch (InvalidStreamException ex)
            {
                throw ex;
            }

            int totalScore = -1;

            try
            {
                totalScore = Puzzle.ComputeScore(puzzleTree.Root);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return totalScore;
        }
    }
}
