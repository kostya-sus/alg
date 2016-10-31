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
            string str1 = "abcdef";
            string str2 = "abcdef";
            string expectedResult = "abcdef";

            //Act
            var result = LongestCommonSubsequence.FindLcs(str1.ToCharArray(),str2.ToCharArray());

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ShouldReturnEmptySubstringIfAtLeastOneStringIsEmpry()
        {
            //Arrange
            string str1 = "";
            string str2 = "abcdef";
            string expectedResult = "";

            //Act
            var result = LongestCommonSubsequence.FindLcs(str1.ToCharArray(), str2.ToCharArray());

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ShouldReturnTheBiggestSubstringIfStringHasCommonSubstrings()
        {
            //Arrange
            string str1 = "fsdfsdgfhgd";
            string str2 = "dfsdfsdgsdf";
            string expectedResult = "fsdfsdgf";

            //Act
            var result = LongestCommonSubsequence.FindLcs(str1.ToCharArray(), str2.ToCharArray());

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
