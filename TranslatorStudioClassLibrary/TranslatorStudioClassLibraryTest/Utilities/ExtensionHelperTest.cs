using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Repository;
using TranslatorStudioClassLibrary.Utilities;


namespace TranslatorStudioClassLibraryTest.Utilities
{
    [TestClass]
    [TestCategory("Extension Helper Test")]
    public class ExtensionHelperTest
    {
        private readonly IProjectData mockProjectData;
        private readonly string mockProjectName;
        private readonly List<string> mockRawLines;
        private readonly List<string> mockTranslatedLines;
        private readonly List<bool> mockCompletedLines;
        private readonly List<bool> mockMarkedLines;

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
                RawLines = mockRawLines,
                TranslatedLines = mockTranslatedLines,
                CompletedLines = mockCompletedLines,
                MarkedLines = mockMarkedLines
            };
        }

        [TestMethod]
        public void ToJSONStringTest()
        {
            //Arrange
            string expected = JsonConvert.SerializeObject(mockProjectData);

            //Act
            var actual = mockProjectData.ToJSONString();

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void GetNumberFormatTest()
        {
            //Arrange
            var expected = "0000";

            //Act
            var actual = 1000.GetNumberFormat();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
