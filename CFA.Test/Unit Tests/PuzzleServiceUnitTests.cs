using System;
using Xunit;
using CFA.Service;

namespace CFA.Test
{
    public class PuzzleServiceUnitTests
    {
        [Theory]
        [InlineData("{}", 1)]
        [InlineData("{{{}}}", 6)]
        [InlineData("{{},{}}", 5)]
        [InlineData("{{{},{},{{}}}}",  16)]
        [InlineData("{< a>,<a>,<a>,<a>}", 1)]
        [InlineData("{{< ab>},{<ab>},{<ab>},{<ab>}}", 9)]
        [InlineData("{{< !!>},{<!!>},{<!!>},{<!!>}}", 9)]
        [InlineData("{{< a!>},{<a!>},{<a!>},{<ab>}}", 3)]

        public void SolvePuzzle(string stream, int expectedScore)
        {
            var puzzleService = new PuzzleService();

            int score = puzzleService.Solve(stream);

            Assert.True(score == expectedScore);
        }

        [Theory]
        [InlineData("<xxxxx>")]
        [InlineData("")]
        [InlineData("  ")]

        public void InvalidStream_GroupStartExpected(string stream)
        {
            var puzzleService = new PuzzleService();

            try
            {
                int score = puzzleService.Solve(stream);

                Assert.False(true, "No error was detected.");
            }
            catch (InvalidStreamException ex) when (ex.Message == InvalidStreamMessage.MissingGroupStart)
            {
                Assert.True(true);
            }     
            catch (Exception ex)
            {
                Assert.False(true, String.Format("Incorrect exception thrown: {0}" , ex.Message));
            }
        }
        [Theory]
        [InlineData("{<xxx>")]
        [InlineData("{{},{}")]
        [InlineData("{{{{{{{}}}}}}")]
        [InlineData("{<xxx>,<xxx>")]

        public void InvalidStream_GroupEndExpected(string stream)
        {
            var puzzleService = new PuzzleService();

            try
            {
                int score = puzzleService.Solve(stream);

                Assert.False(true, "No error was detected.");
            }
            catch (InvalidStreamException ex) when (ex.Message == InvalidStreamMessage.MissingGroupEnding)
            {
                Assert.True(true);
            }
            catch (Exception ex)
            {
                Assert.False(true, String.Format("Incorrect exception thrown: {0}", ex.Message));
            }
        }

        [Theory]
        [InlineData("{<xxx}")]
        [InlineData("{<>,<}")]
        [InlineData("{<asfasdf,!>}")]

        public void InvalidStream_GarbageEndExpected(string stream)
        {
            var puzzleService = new PuzzleService();

            try
            {
                int score = puzzleService.Solve(stream);

                Assert.False(true, "No error was detected.");
            }
            catch (InvalidStreamException ex) when (ex.Message == InvalidStreamMessage.MissingGarbageEnding)
            {
                Assert.True(true);
            }
            catch (Exception ex)
            {
                Assert.False(true, String.Format("Incorrect exception thrown: {0}", ex.Message));
            }
        }
        [Theory]
        [InlineData("{{},{}<,>}")]
        [InlineData("{,{}")]
        [InlineData("{{,{}")]


        public void InvalidStream_InvalidGroupCharacter(string stream)
        {
            var puzzleService = new PuzzleService();

            try
            {
                int score = puzzleService.Solve(stream);

                Assert.False(true, "No error was detected.");
            }
            catch (InvalidStreamException ex) when (ex.Message == InvalidStreamMessage.InvalidGroupCharacter)
            {
                Assert.True(true);
            }
            catch (Exception ex)
            {
                Assert.False(true, String.Format("Incorrect exception thrown: {0}", ex.Message));
            }
        }
    }
}
