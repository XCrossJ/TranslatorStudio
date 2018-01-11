using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Repository;

namespace TranslatorStudioClassLibraryTest.Repository
{
    [TestClass]
    public class ProjectDataRepositoryTest
    {
        [TestMethod]
        public void CreateProjectDataFromArrayTest()
        {
            //Arrange
            var projectName = "Test";
            var newRawLines = new string[] { "Line1", "Line2", "Line3" };
            var rawLines = new List<string>() { "Line1", "Line2", "Line3" };
            ProjectData expected = new ProjectData()
            {
                ProjectName = projectName,
                RawLines = rawLines,
                TranslatedLines = new string[rawLines.Count],
                CompletedLines = new bool[rawLines.Count],
                MarkedLines = new bool[rawLines.Count]
            };

            //Act
            ProjectData actual = new ProjectDataRepository().CreateProjectDataFromArray(projectName, newRawLines);

            //Assert
            Assert.AreEqual(expected, actual); // Is not a true equals. Need to develop more.
            CollectionAssert.AreEqual(expected.RawLines, actual.RawLines);
            CollectionAssert.AreEqual(expected.TranslatedLines, actual.TranslatedLines);
            CollectionAssert.AreEqual(expected.CompletedLines, actual.CompletedLines);
            CollectionAssert.AreEqual(expected.MarkedLines, actual.MarkedLines);
        }


    }
}
