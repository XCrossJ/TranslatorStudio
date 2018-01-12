using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Repository;

namespace TranslatorStudioClassLibraryTest.Factory
{
    [TestClass]
    [TestCategory("Translation Data Repository Test")]
    public class TranslationDataRepositoryTest
    {
        [TestMethod]
        public void CreateTranslationDataFromProject()
        {
            //Arrange
            var projectName = "Test";
            var rawLines = new List<string>() { "Line1", "Line2", "Line3" };
            ProjectData data = new ProjectData()
            {
                ProjectName = projectName,
                RawLines = rawLines,
                TranslatedLines = new string[rawLines.Count],
                CompletedLines = new bool[rawLines.Count],
                MarkedLines = new bool[rawLines.Count]
            };
            TranslationData expected = new TranslationData(data);

            //Act
            ITranslationData actual = new TranslationDataRepository().CreateTranslationDataFromProject(data);

            //Assert
            Assert.AreEqual(expected, actual);
            CollectionAssert.AreEqual(expected.RawLines, actual.RawLines);
            CollectionAssert.AreEqual(expected.TranslatedLines, actual.TranslatedLines);
            CollectionAssert.AreEqual(expected.CompletedLines, actual.CompletedLines);
            CollectionAssert.AreEqual(expected.MarkedLines, actual.MarkedLines);

            
        }
    }
}
