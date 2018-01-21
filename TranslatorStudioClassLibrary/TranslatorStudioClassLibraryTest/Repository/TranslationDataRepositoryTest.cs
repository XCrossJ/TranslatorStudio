using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Office.Interop.Word;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Repository;

namespace TranslatorStudioClassLibraryTest.Factory
{
    [TestClass]
    [TestCategory("Translation Data Repository Test")]
    public class TranslationDataRepositoryTest
    {
        private readonly string mockProjectName;
        private readonly List<string> mockRawLines;
        private readonly List<string> mockTranslatedLines;
        private readonly List<bool> mockMarkedLines;
        private readonly List<bool> mockCompleteLines;

        public TranslationDataRepositoryTest()
        {
            mockProjectName = "Mock Test Project Name";

            mockRawLines = new List<string>
            {
                "Raw Line 1",
                "Raw Line 2",
                "Raw Line 3",
                "Raw Line 4",
                "Raw Line 5",
                "Raw Line 6",
                "Raw Line 7",
                "Raw Line 8",
                "Raw Line 9",
                "Raw Line 10"
            };

            mockTranslatedLines = new List<string>
            {
                "Translated Line 1",
                "Translated Line 2",
                "Translated Line 3",
                "Translated Line 4",
                "Translated Line 5",
                "Translated Line 6",
                "Translated Line 7",
                "Translated Line 8",
                "Translated Line 9",
                "Translated Line 10"
            };

            mockMarkedLines = new List<bool>
            {
                true,
                false,
                true,
                false,
                false,
                true,
                false,
                true,
                true,
                false
            };

            mockCompleteLines = new List<bool>
            {
                false,
                false,
                true,
                false,
                true,
                true,
                true,
                false,
                true,
                false
            };
            
        }

        [TestMethod]
        public void CreateTranslationDataFromProject_Test()
        {
            // Arrange
            var data = new ProjectData()
            {
                ProjectName = mockProjectName,
                RawLines = mockRawLines,
                TranslatedLines = mockTranslatedLines,
                CompletedLines = mockCompleteLines,
                MarkedLines = mockMarkedLines
            };
            var expected = new TranslationData(data);

            // Act
            var actual = new TranslationDataRepository().CreateTranslationDataFromProject(data);

            // Assert
            Assert.AreEqual(expected, actual);
            CollectionAssert.AreEqual(expected.RawLines, actual.RawLines);
            CollectionAssert.AreEqual(expected.TranslatedLines, actual.TranslatedLines);
            CollectionAssert.AreEqual(expected.CompletedLines, actual.CompletedLines);
            CollectionAssert.AreEqual(expected.MarkedLines, actual.MarkedLines);
        }

        [TestMethod]
        public void CreateTranslationDataFromStream_Test()
        {
            // Arrange
            var expectedName = mockProjectName;
            var expectedRaw = mockRawLines;
            var writeStream = new MemoryStream();

            using (StreamWriter writer = new StreamWriter(writeStream))
            {
                foreach (var line in expectedRaw)
                {
                    writer.WriteLine(line);
                }
                writer.Flush();
            }

            var readStream = new MemoryStream(writeStream.ToArray());
            var reader = new StreamReader(readStream);

            // Act
            var translationData = new TranslationDataRepository().CreateTranslationDataFromStream(expectedName, reader);
            var actualName = translationData.ProjectName;
            var actualRaw = translationData.RawLines;

            // Assert
            Assert.AreEqual(expectedName, actualName);
            CollectionAssert.AreEqual(expectedRaw, actualRaw);

        }

        [TestMethod]
        [TestCategory("Not Implemented Correctly")]
        public void CreateTranslationDataFromDocument_Test()
        {
            // Arrange
            var expected = mockRawLines;
            var document = new Mock<Document>();

            var paragraphs = new Mock<Paragraphs>();

            paragraphs.Setup(
                    x => x.Count)
                .Returns(expected.Count);

            for (int i = 0; i < expected.Count; i++)
            {
                paragraphs.Setup(x => x[It.Is<int>(n => n == i)].Range.Text).Returns(expected[i]);
            }

            document.Setup(
                    x => x.Paragraphs)
                .Returns(paragraphs.Object);


            // Act
            var translationData = new TranslationDataRepository().CreateTranslationDataFromDocument("", document.Object);
            var actual = translationData.RawLines;

            // Assert
            //CollectionAssert.AreEqual(expected, actual);
            Assert.AreEqual(expected.Count, actual.Count); // Not a true assert. Need to redo this test.
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GivenNoRawInProjectRaiseException()
        {
            // Arrange
            IProjectData data = new ProjectData()
            {
                ProjectName = "",
                RawLines = new List<string>(),
                TranslatedLines = new List<string>(),
                CompletedLines = new List<bool>(),
                MarkedLines = new List<bool>()
            };
            
            // Act
            var actual = new TranslationDataRepository().CreateTranslationDataFromProject(data);

            // Assert

        }

    }
}
