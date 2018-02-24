using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Office.Interop.Word;
using Moq;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Repository;
using Xunit;

namespace TranslatorStudioClassLibraryTest.Factory
{
    /// <summary>
    /// Contains tests that are run against Translation Data Repository class.
    /// </summary>
    [Collection("Translation Data Repository Test")]
    [Trait("Category", "Unit")]
    [Trait("Class", "Translation Data Repository")]
    public class TranslationDataRepositoryTest
    {
        /// <summary>
        /// Mock of Project Data.
        /// </summary>
        private readonly Mock<IProjectData> mockProjectData;
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
        /// Mock of Marked Lines.
        /// </summary>
        private readonly List<bool> mockMarkedLines;
        /// <summary>
        /// Mock of Completed Lines.
        /// </summary>
        private readonly List<bool> mockCompletedLines;

        /// <summary>
        /// Mock of Project Data Repository.
        /// </summary>
        private readonly Mock<IProjectDataRepository> mockProjectDataRepository;
        /// <summary>
        /// Translation Data Repository under test.
        /// </summary>
        private readonly ITranslationDataRepository translationDataRepository;

        /// <summary>
        /// Constructor to set up test code.
        /// </summary>
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

            mockCompletedLines = new List<bool>
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
                .Returns(mockCompletedLines);

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

        #region Constructor Tests

        /// <summary>
        /// Given that Translation Data Repository is invoked, Default Constructor returns valid Translation Data Repository.
        /// </summary>
        [Fact]
        public void TranslationDataRepository_DefaultConstructor_Test()
        {
            //Arrange
            var expected = translationDataRepository;

            //Act
            var actual = new TranslationDataRepository();

            //Assert
            Assert.IsType<TranslationDataRepository>(actual);
            Assert.IsAssignableFrom<ITranslationDataRepository>(actual);
            Assert.NotStrictEqual(expected, actual);
        }

        #endregion

        #region Methods Tests

        /// <summary>
        /// Given that Project Data passed is valid, Create Translation Data From Project returns valid Translation Data.
        /// </summary>
        [Fact]
        public void CreateTranslationDataFromProject_Test()
        {
            // Arrange
            var data = new ProjectData()
            {
                ProjectName = mockProjectName,
                RawLines = mockRawLines,
                TranslatedLines = mockTranslatedLines,
                CompletedLines = mockCompletedLines,
                MarkedLines = mockMarkedLines
            };
            var expected = new TranslationData(data);

            // Act
            var actual = translationDataRepository.CreateTranslationDataFromProject(data);

            // Assert
            Assert.IsType<TranslationData>(actual);
            Assert.IsAssignableFrom<ITranslationData>(actual);
            Assert.NotStrictEqual(expected, actual);
        }

        /// <summary>
        /// Given that Stream Reader passed is valid, Create Translation Data From Stream returns valid Translation Data.
        /// </summary>
        [Fact]
        public void CreateTranslationDataFromStream_Test()
        {
            // Arrange
            var expected = new TranslationData(mockProjectData.Object);

            // Act
            var actual = translationDataRepository.CreateTranslationDataFromStream(mockProjectDataRepository.Object, mockProjectName, new StreamReader(new MemoryStream()));

            // Assert
            mockProjectDataRepository.Verify(
                    x => x.CreateProjectDataFromStream(It.IsAny<string>(), It.IsAny<StreamReader>()),
                Times.Once);

            Assert.IsType<TranslationData>(actual);
            Assert.IsAssignableFrom<ITranslationData>(actual);
            Assert.NotStrictEqual(expected, actual);
        }

        /// <summary>
        /// Given that Document passed is valid, Create Translation Data From Document returns valid Translation Data.
        /// </summary>
        [Fact]
        public void CreateTranslationDataFromDocument_Test()
        {
            // Arrange
            var expected = new TranslationData(mockProjectData.Object);

            // Act
            var actual = translationDataRepository.CreateTranslationDataFromDocument(mockProjectDataRepository.Object, "", new Document());

            // Assert
            mockProjectDataRepository.Verify(
                    x => x.CreateProjectDataFromDocument(It.IsAny<string>(), It.IsAny<Document>()),
                Times.Once);

            Assert.IsType<TranslationData>(actual);
            Assert.IsAssignableFrom<ITranslationData>(actual);
            Assert.NotStrictEqual(expected, actual);
        }

        #endregion

        #region Exception Tests

        /// <summary>
        /// Given that Project Data has empty raw, Create Translation Data From Project will throw EmptyRaw Exception.
        /// </summary>
        [Fact]
        [Trait("Category", "Exception")]
        public void GivenNoRawInProjectRaiseException()
        {
            // Arrange
            IProjectData data = new ProjectData()
            {
                RawLines = new List<string>()
            };

            var expectedMessage = "No Raw Lines were submitted into the project.";
            var expected = new Exception(expectedMessage);

            // Act
            var actual = Record.Exception(() => translationDataRepository.CreateTranslationDataFromProject(data));
            var actualMessage = actual.Message;

            // Assert
            Assert.IsType<Exception>(actual);
            Assert.NotStrictEqual(expected, actual);
            Assert.Equal(expectedMessage, actualMessage);
        }

        #endregion


    }
}
