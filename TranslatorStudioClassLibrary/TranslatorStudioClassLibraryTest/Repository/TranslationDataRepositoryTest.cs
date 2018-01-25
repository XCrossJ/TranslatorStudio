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
        private readonly Mock<IProjectData> mockProjectData;
        private readonly string mockProjectName;
        private readonly List<string> mockRawLines;
        private readonly List<string> mockTranslatedLines;
        private readonly List<bool> mockMarkedLines;
        private readonly List<bool> mockCompleteLines;

        private readonly Mock<IProjectDataRepository> mockProjectDataRepository;
        private readonly ITranslationDataRepository translationDataRepository;

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

            mockProjectData = new Mock<IProjectData>();

            mockProjectData.Setup(
                    x => x.ProjectName)
                .Returns(mockProjectName);

            mockProjectData.Setup(
                    x => x.RawLines)
                .Returns(mockRawLines);

            mockProjectData.Setup(
                    x => x.TranslatedLines)
                .Returns(mockTranslatedLines);

            mockProjectData.Setup(
                    x => x.MarkedLines)
                .Returns(mockMarkedLines);

            mockProjectData.Setup(
                    x => x.CompletedLines)
                .Returns(mockCompleteLines);

            mockProjectDataRepository = new Mock<IProjectDataRepository>();

            mockProjectDataRepository.Setup(
                    x => x.CreateProjectDataFromArray(It.IsAny<string>(), It.IsAny<string[]>()))
                .Returns(mockProjectData.Object);

            mockProjectDataRepository.Setup(
                    x => x.CreateProjectDataFromStream(It.IsAny<string>(), It.IsAny<StreamReader>()))
                .Returns(mockProjectData.Object);

            mockProjectDataRepository.Setup(
                    x => x.CreateProjectDataFromDocument(It.IsAny<string>(), It.IsAny<Document>()))
                .Returns(mockProjectData.Object);

            translationDataRepository = new TranslationDataRepository();
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
            
            // Act
            var translationData = translationDataRepository.CreateTranslationDataFromStream(mockProjectDataRepository.Object, expectedName, new StreamReader(new MemoryStream()));
            var actualName = translationData.ProjectName;
            var actualRaw = translationData.RawLines;

            // Assert
            mockProjectDataRepository.Verify(
                    x => x.CreateProjectDataFromStream(It.IsAny<string>(), It.IsAny<StreamReader>()),
                Times.Once);

            Assert.AreEqual(expectedName, actualName);
            CollectionAssert.AreEqual(expectedRaw, actualRaw);

        }

        [TestMethod]
        public void CreateTranslationDataFromDocument_Test()
        {
            // Arrange
            var expected = mockRawLines;
            
            // Act
            var translationData = translationDataRepository.CreateTranslationDataFromDocument(mockProjectDataRepository.Object, "", new Document());
            var actual = translationData.RawLines;

            // Assert
            mockProjectDataRepository.Verify(
                    x => x.CreateProjectDataFromDocument(It.IsAny<string>(), It.IsAny<Document>()),
                Times.Once);

            CollectionAssert.AreEqual(expected, actual);
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
            var actual = translationDataRepository.CreateTranslationDataFromProject(data);

            // Assert

        }

    }
}
