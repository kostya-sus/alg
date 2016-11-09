using Xunit;
using LCS;

namespace LCSTests
{
    public class LcsUnitTests
    {
        [Fact]
        public void ShouldReturnWholeStringIfStringsAreEquals()
        {
            //Arrange
            string str1 = "a b c d e f";
            string str2 = "a b c d e f";
            string expectedResult = "a b c d e f";

            //Act
            var result = LongestCommonSubsequence.FindLcs(str1.Split(' '),str2.Split(' '));
            result = result.Remove(result.Length - 1);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ShouldReturnEmptySubstringIfAtLeastOneStringIsEmpry()
        {
            //Arrange
            string str1 = "";
            string str2 = "a b c d e f";
            string expectedResult = "";

            //Act
            var result = LongestCommonSubsequence.FindLcs(str1.Split(' '), str2.Split(' '));
            result = result.Remove(result.Length - 1);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ShouldReturnTheBiggestSubstringIfStringHasCommonSubstrings()
        {
            //Arrange
            string str1 = "f s d f s d g f h g d";
            string str2 = "d f s d f s d g s d f";
            string expectedResult = "f s d f s d g f";

            //Act
            var result = LongestCommonSubsequence.FindLcs(str1.Split(' '), str2.Split(' '));
            result = result.Remove(result.Length - 1);

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
