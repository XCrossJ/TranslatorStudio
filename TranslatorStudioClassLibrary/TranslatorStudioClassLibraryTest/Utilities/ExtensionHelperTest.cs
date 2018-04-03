using Newtonsoft.Json;
using System.Collections.Generic;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Utilities;
using Xunit;

namespace TranslatorStudioClassLibraryTest.Utilities
{
    /// <summary>
    /// Contains tests to run against Extension Helper class.
    /// </summary>
    [Collection("Project Helper Test")]
    [Trait("Category", "Unit")]
    [Trait("Class", "Extension Helper")]
    public class ExtensionHelperTest
    {
        /// <summary>
        /// Mock of Project Data.
        /// </summary>
        private readonly IProjectData mockProjectData;
        /// <summary>
        /// Mock of Project Name.
        /// </summary>
        private readonly string mockProjectName;
        /// <summary>
        /// Mock of Raw Lines.
        /// </summary>
        private readonly List<string> mockRawLines;
        /// <summary>
        /// Mock of Translated Lines.
        /// </summary>
        private readonly List<string> mockTranslatedLines;
        /// <summary>
        /// Mock of Completed Lines.
        /// </summary>
        private readonly List<bool> mockCompletedLines;
        /// <summary>
        /// Mock of Marked Lines.
        /// </summary>
        private readonly List<bool> mockMarkedLines;

        /// <summary>
        /// Constructor to set up test code.
        /// </summary>
        public ExtensionHelperTest()
        {
            mockProjectName = "Mock Project Name";
            mockRawLines = new List<string> { "", "" };
            mockTranslatedLines = new List<string> { "", "" };
            mockCompletedLines = new List<bool> { true, false };
            mockMarkedLines = new List<bool> { false, true };
            mockProjectData = new ProjectData()
            {
                ProjectName = mockProjectName,
                ProjectLines = new List<IProjectLine>()
            };
        }

        /// <summary>
        /// Given that Object is valid, To JSON String returns serialised json string.
        /// </summary>
        [Fact]
        public void ExtensionHelper_ToJSONString_Test()
        {
            //Arrange
            string expected = JsonConvert.SerializeObject(mockProjectData);

            //Act
            var actual = mockProjectData.ToJSONString();

            //Assert
            Assert.Equal(expected, actual);

        }

        /// <summary>
        /// Given that number is valid, Get Number Format returns string format to use.
        /// </summary>
        /// <param name="number">Number to get format of.</param>
        /// <param name="expectedFormat">The expected format.</param>
        [Theory]
        [InlineData(1, "0")]
        [InlineData(31, "00")]
        [InlineData(123, "000")]
        [InlineData(1000, "0000")]
        [InlineData(10000, "00000")]
        public void ExtensionHelper_GetNumberFormat_Test(int number, string expectedFormat)
        {
            //Arrange
            var expected = expectedFormat;

            //Act
            var actual = number.GetNumberFormat();

            //Assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Given that text is valid, Is Not Empty returns whether text is empty (whitespace) or not.
        /// </summary>
        /// <param name="text">Text to check.</param>
        [Theory]
        [InlineData("Test 1")]
        [InlineData("")]
        [InlineData("     ")]
        public void ExtensionHelper_IsNotEmpty_Test(string text)
        {
            //Arrange
            var expected = !string.IsNullOrWhiteSpace(text);

            //Act
            var actual = text.IsNotEmpty();

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
