using System.Collections.Generic;

namespace CFA.Service
{
    public class PuzzleTreeNode
    {
        public PuzzleTreeNode(int score)
        {
            Score = score;
            Children = new List<PuzzleTreeNode>();
        }
        public string Stream { get; set; }
        public int Score { get; set; }
        public List<PuzzleTreeNode> Children { get; set; }
    }
}
