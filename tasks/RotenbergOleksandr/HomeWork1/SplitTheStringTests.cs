using System.Collections.Generic;
using System.IO;
using SplitTheString;
using Xunit;

namespace SplitTheStringTests
{
    public class SplitTheStringTests
    {

        [Fact]
        public void ShouldReturnTwoCombinations()
        {
            //Arrange
            FindAllVariants fav = new FindAllVariants();
            HashSet<string> dictionary = new HashSet<string>(){ "cat", "cats", "and", "sand", "dog" };
            string inputText = "catsanddog";
            List<string> expectedResult = new List<string>() { "cat sand dog", "cats and dog" };

            //Act
            var result = fav.FindSeparateWords(inputText, dictionary);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ShouldReturnEmptyList()
        {
            //Arrange
            FindAllVariants fav = new FindAllVariants();
            HashSet<string> dictionary = new HashSet<string>() { "cat", "cats", "and", "sand", "dog" };
            string inputText = "";
            List<string> expectedResult = new List<string>() { };

            //Act
            var result = fav.FindSeparateWords(inputText, dictionary);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ShouldReturn220DifferentValues()
        {
            //Arrange
            FindAllVariants fav = new FindAllVariants();
            HashSet<string> dictionary = new HashSet<string>(File.ReadAllLines(@"Dictionary/dict_en.txt"));
            string inputText = "catsanddog";
            int expectedResult = 220;

            //Act
            var result = fav.FindSeparateWords(inputText, dictionary);

            //Assert
            Assert.Equal(expectedResult, result.Count);
        }
    }
}
