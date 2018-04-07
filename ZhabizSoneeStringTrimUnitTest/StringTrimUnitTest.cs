using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace ZhabizSoneeStringTrimUnitTest
{
    /// <summary>
    /// Unit test class for <see cref="string.Trim"/>.
    /// </summary>
    [TestClass]
    public class StringTrimUnitTest
    {
        /// <summary>
        /// Number of characters that will be used across this unit test to limit
        /// maximum number of characters for test input.
        /// </summary>
        private const uint numberOfCharacters = 100;

        /// <summary>
        /// Ensures that if no characters can be trimmed from the current instance, 
        /// <see cref="string.Trim"/> returns the current instance unchanged.
        /// </summary>
        [TestMethod]
        public void TrimReturnSameInstance()
        {
            string randomString = GetRandomString(numberOfCharacters);
            string afterTrim = randomString.Trim();
            Assert.AreSame(randomString, afterTrim);
        }

        /// <summary>
        /// Ensures that if the current string equals <see cref="string.Empty"/> the <see cref="string.Trim"/> 
        /// returns <see cref="string.Empty"/>.
        /// </summary>
        [TestMethod]
        public void TrimEmptyString()
        {
            string emptyString = string.Empty;
            string afterTrim = emptyString.Trim();
            Assert.AreSame(emptyString, afterTrim);
        }

        /// <summary>
        /// Ensures that if all the characters in the current string instance consist of white-space 
        /// characters, <see cref="string.Trim"/> returns <see cref="string.Empty"/>.
        /// </summary>
        [TestMethod]
        public void TrimAllSpaceString()
        {
            for (uint i = 1; i < numberOfCharacters; i++)
            {
                string whiteSpaceString = GenerateWhiteSpaceString(i);
                string afterTrim = whiteSpaceString.Trim();
                Assert.AreSame(String.Empty, afterTrim);
            }
        }

        /// <summary>
        /// Ensures <see cref="string.Trim"/> removes any leading white space characters.
        /// </summary>
        [TestMethod]
        public void TrimAllSpaceOnLeftSideOnly()
        {
            var stringBuilder = new StringBuilder();
            for (uint stringLength = 1; stringLength < numberOfCharacters; stringLength++)
            {
                string randomString = GetRandomString(stringLength);
                for (uint whiteSpaceLength = 1; whiteSpaceLength < numberOfCharacters; whiteSpaceLength++)
                {
                    stringBuilder.Clear();
                    stringBuilder.Append(GenerateWhiteSpaceString(whiteSpaceLength));
                    stringBuilder.Append(randomString);
                    string afterTrim = stringBuilder.ToString().Trim();

                    Assert.AreEqual(randomString, afterTrim);
                    Assert.AreNotSame(randomString, afterTrim);
                }
            }
        }

        /// <summary>
        /// Ensures <see cref="string.Trim"/> removes any trailing white space characters.
        /// </summary>
        [TestMethod]
        public void TrimAllSpaceOnRightSideOnly()
        {
            var stringBuilder = new StringBuilder();
            for (uint stringLength = 1; stringLength < numberOfCharacters; stringLength++)
            {
                string randomString = GetRandomString(stringLength);
                for (uint whiteSpaceLength = 1; whiteSpaceLength < numberOfCharacters; whiteSpaceLength++)
                {
                    stringBuilder.Clear();
                    stringBuilder.Append(randomString);
                    stringBuilder.Append(GenerateWhiteSpaceString(whiteSpaceLength));
                    string afterTrim = stringBuilder.ToString().Trim();

                    Assert.AreEqual(randomString, afterTrim);
                    Assert.AreNotSame(randomString, afterTrim);
                }
            }
        }

        /// <summary>
        /// Ensures <see cref="string.Trim"/> removes any leading and trailing white space characters.
        /// </summary>
        [TestMethod]
        public void TrimAllSpaceOnBothSide()
        {
            var stringBuilder = new StringBuilder();
            for (uint stringLength = 1; stringLength < numberOfCharacters; stringLength++)
            {
                string randomString = GetRandomString(stringLength);
                for (uint whiteSpaceLength = 1; whiteSpaceLength < numberOfCharacters; whiteSpaceLength++)
                {
                    stringBuilder.Clear();
                    stringBuilder.Append(GenerateWhiteSpaceString(whiteSpaceLength));
                    stringBuilder.Append(randomString);
                    stringBuilder.Append(GenerateWhiteSpaceString(whiteSpaceLength));
                    string afterTrim = stringBuilder.ToString().Trim();

                    Assert.AreEqual(randomString, afterTrim);
                    Assert.AreNotSame(randomString, afterTrim);
                }
            }
        }

        /// <summary>
        /// Generates whitespace string.
        /// </summary>
        /// <param name="length">Length of the string.</param>
        /// <returns>Whitespace string.</returns>
        private static string GenerateWhiteSpaceString(uint length)
        {
            var stringBuilder = new StringBuilder();
            for (uint i = 0; i < length; i++)
            {
                stringBuilder.Append(" ");
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Generates a random string with no leading and trailing white space characters.
        /// </summary>
        /// <param name="length">Length of the string.</param>
        /// <returns>A string with no leading and trailing white space characters.</returns>
        private static String GetRandomString(uint length)
        {
            const String characterSet = "qwertyuiopasdfghjklzxcvbnm"
                                      + "QWERTYUIOPASDFGHJKLZXCVBNM"
                                      + "1234567890"
                                      + "`~!@#$%^&*()_+-=[]\\{}|;':\",./<>?";
            var stringBuilder = new StringBuilder();
            var rand = new Random();

            for (uint i = 0; i < length; i++)
            {
                bool isOnTheEdgeOfString = (i == 0 || i == length - 1);
                int randomIndex = rand.Next(characterSet.Length);
                string randomCharacter = characterSet.Substring(randomIndex, 1);

                if (isOnTheEdgeOfString)
                {
                    stringBuilder.Append(randomCharacter);
                }
                else
                {
                    bool addSpaceCharacter = (rand.NextDouble() < 0.3);
                    if (addSpaceCharacter)
                    {
                        stringBuilder.Append(" ");
                    }
                    else
                    {
                        stringBuilder.Append(randomCharacter);
                    }
                }
            }

            return stringBuilder.ToString();
        }
    }
}
