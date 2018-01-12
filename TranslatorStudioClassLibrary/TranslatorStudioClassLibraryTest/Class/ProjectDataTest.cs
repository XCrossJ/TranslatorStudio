using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Interface;

namespace TranslatorStudioClassLibraryTest.Class
{
    [TestClass]
    [TestCategory("Project Data Test")]
    public class ProjectDataTest
    {
        private readonly IProjectData mockProjectData;
        private readonly string mockProjectName;
        private readonly List<string> mockRawLines;
        private readonly string[] mockTranslatedLines;
        private readonly bool[] mockCompletedLines;
        private readonly bool[] mockMarkedLines;

        public ProjectDataTest()
        {
            mockProjectName = "Mock Project Name";
            mockRawLines = new List<string> { "", "" };
            mockTranslatedLines = new string[] { "", "" };
            mockCompletedLines = new bool[] { true, false };
            mockMarkedLines = new bool[] { false, true };
            mockProjectData = new ProjectData();
            //{
            //    ProjectName = mockProjectName,
            //    RawLines = mockRawLines,
            //    TranslatedLines = mockTranslatedLines,
            //    MarkedLines = mockMarkedLines,
            //    CompletedLines = mockCompletedLines
            //};
        }

        [TestMethod]
        public void ProjectName_Test()
        {
            //Arrange
            var expected = mockProjectName;

            //Act
            var actual = mockProjectData.ProjectName = expected;

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void RawLines_Test()
        {
            //Arrange
            var expected = mockRawLines;

            //Act
            var actual = mockProjectData.RawLines = expected;

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TranslatedLines_Test()
        {
            //Arrange
            var expected = mockTranslatedLines;

            //Act
            var actual = mockProjectData.TranslatedLines = expected;

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void CompletedLines_Test()
        {
            //Arrange
            var expected = mockCompletedLines;

            //Act
            var actual = mockProjectData.CompletedLines = expected;

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void MarkedLines_Test()
        {
            //Arrange
            var expected = mockMarkedLines;

            //Act
            var actual = mockProjectData.MarkedLines = expected;

            //Assert
            Assert.AreEqual(expected, actual);

        }
    }
}
