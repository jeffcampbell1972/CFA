
namespace CFA.Service
{
    public static class Puzzle
    {
        public static PuzzleTreeNode ParseGroup(string stream, ref int index, int score)
        {
            if (stream.Trim().Length == 0 || stream[index] != '{')
            {
                throw new InvalidStreamException(InvalidStreamMessage.MissingGroupStart);
            }

            int startIndex = index;
            index++;
            var treeNode = new PuzzleTreeNode(score);
            bool commaIsAppropriate = false;

            while (index < stream.Length)
            {
                if (stream[index] == '<' && !commaIsAppropriate)
                {
                    var garbageNode = ParseGarbage(stream, ref index);

                    treeNode.Children.Add(garbageNode);
                    commaIsAppropriate = true;
                }
                else if (stream[index] == '{' && !commaIsAppropriate)
                {
                    var groupNode = ParseGroup(stream, ref index, score + 1);   // recursively call ParseGroup()
                    commaIsAppropriate = true;

                    treeNode.Children.Add(groupNode);
                }
                else if (stream[index] == '}')
                {
                    treeNode.Stream = stream.Substring(startIndex, index - startIndex);
                    index++;

                    return treeNode;                                            // end recursive call
                }
                else if (stream[index] == ',' && commaIsAppropriate)
                {
                    index++;
                    commaIsAppropriate = false;
                }
                else
                {
                    throw new InvalidStreamException(InvalidStreamMessage.InvalidGroupCharacter);
                }

            }

            throw new InvalidStreamException(InvalidStreamMessage.MissingGroupEnding);
        }
        public static PuzzleTreeNode ParseGarbage(string stream, ref int index)
        {
            if (stream[index] != '<')
            {
                throw new InvalidStreamException(InvalidStreamMessage.MissingGarbageStart);
            }

            index++;
            var treeNode = new PuzzleTreeNode(0);  // garbage has no score

            while (index < stream.Length)
            {
                if (stream[index] == '!')
                {
                    index += 1;  // increment index so that next character is skipped.
                }
                else if (stream[index] == '>')
                {
                    index++;

                    return treeNode;
                }
                index++;
            }

            throw new InvalidStreamException(InvalidStreamMessage.MissingGarbageEnding);
        }

        public static int ComputeScore(PuzzleTreeNode treeNode)
        {
            int score = treeNode.Score;

            foreach (var child in treeNode.Children)
            {
                score += ComputeScore(child);
            }

            return score;
        }
    }
}
