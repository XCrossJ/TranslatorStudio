using System.Collections.Generic;
using System.IO;
using Microsoft.Office.Interop.Word;
using Moq;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Exception;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Repository;
using Xunit;

namespace TranslatorStudioClassLibraryTest.Repository
{
    /// <summary>
    /// Contains tests that are run against Project Data Repository class.
    /// </summary>
    [Collection("Project Data Repository Test")]
    [Trait("Category", "Unit")]
    [Trait("Class", "Project Data Repository")]
    public class ProjectDataRepositoryTest
    {
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
        /// Project Data Repository under test.
        /// </summary>
        private readonly IProjectDataRepository projectDataRepository;

        /// <summary>
        /// Constructor to set up test code.
        /// </summary>
        public ProjectDataRepositoryTest()
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

            projectDataRepository = new ProjectDataRepository();
        }

        #region Constructor Tests

        /// <summary>
        /// Given that Project Data Repository is invoked, Default Constructor returns valid Project Data Repository.
        /// </summary>
        [Fact]
        public void ProjectDataRepository_DefaultConstructor_Test()
        {
            //Arrange
            var expected = projectDataRepository;

            //Act
            var actual = new ProjectDataRepository();

            //Assert
            Assert.IsType<ProjectDataRepository>(actual);
            Assert.IsAssignableFrom<IProjectDataRepository>(actual);
            Assert.NotStrictEqual(expected, actual);
        }

        #endregion

        #region Methods Tests

        /// <summary>
        /// Given that Array passes is valid, Create Project Data From Array returns valid Project Data.
        /// </summary>
        [Fact]
        public void CreateProjectDataFromArray_Test()
        {
            //Arrange
            var expected = new ProjectData()
            {
                ProjectName = mockProjectName,
                RawLines = mockRawLines
            };

            //Act
            var actual = projectDataRepository.CreateProjectDataFromArray(mockProjectName, mockRawLines.ToArray());

            //Assert
            Assert.IsType<ProjectData>(actual);
            Assert.IsAssignableFrom<IProjectData>(actual);
            Assert.NotStrictEqual(expected, actual);
            Assert.Equal(expected.RawLines, actual.RawLines);
        }

        /// <summary>
        /// Given that Stream Reader passed is valid, Create Project Data From Stream returns valid Project Data.
        /// </summary>
        [Fact]
        public void CreateProjectDataFromStream_Test()
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
            var projectData = projectDataRepository.CreateProjectDataFromStream(expectedName, reader);
            var actualName = projectData.ProjectName;
            var actualRaw = projectData.RawLines;

            // Assert
            Assert.IsType<ProjectData>(projectData);
            Assert.IsAssignableFrom<IProjectData>(projectData);
            Assert.IsType<string>(actualName);
            Assert.Equal(expectedName, actualName);
            Assert.IsType<List<string>>(actualRaw);
            Assert.Equal(expectedRaw, actualRaw);
        }

        /// <summary>
        /// Given that Document passes is valid, Create Project Data From Document returns valid Project Data;
        /// </summary>
        [Fact]
        [Trait("Category", "Not Implemented Correctly")]
        public void CreateProjectDataFromDocument_Test()
        {
            // Arrange
            var expectedName = mockProjectName;
            var expectedRaw = mockRawLines;
            var document = new Mock<Document>();

            var paragraphs = new Mock<Paragraphs>();

            paragraphs.Setup(
                    x => x.Count)
                .Returns(expectedRaw.Count);

            for (int i = 0; i < expectedRaw.Count; i++)
            {
                paragraphs.Setup(x => x[It.Is<int>(n => n == i)].Range.Text).Returns(expectedRaw[i]);
            }


            document.Setup(
                    x => x.Paragraphs)
                .Returns(paragraphs.Object);


            // Act
            var projectData = projectDataRepository.CreateProjectDataFromDocument(expectedName, document.Object);
            var actualName = projectData.ProjectName;
            var actualRaw = projectData.RawLines;

            // Assert
            Assert.IsType<string>(actualName);
            Assert.Equal(expectedName, actualName);
            Assert.IsType<List<string>>(actualRaw);
            //Assert.Equal(expectedRaw, actualRaw);
            Assert.Equal(expectedRaw.Count, actualRaw.Count); // Not a true assert. Need to redo this test.
        }

        #endregion

        #region Exception Tests

        /// <summary>
        /// Given that Array passed is empty, Create Project Data From Array will throw EmptyRaw Exception.
        /// </summary>
        [Fact]
        [Trait("Category", "Exception")]
        public void GivenEmptyArrayRaiseException()
        {
            // Arrange
            var emptyArray = new string[0];

            var expectedMessage = "No Raw Lines were submitted into the project.";
            var expected = new EmptyRawException(expectedMessage);

            // Act
            var actual = Record.Exception(() => projectDataRepository.CreateProjectDataFromArray(mockProjectName, emptyArray));
            var actualMessage = actual.Message;

            // Assert
            Assert.IsType<EmptyRawException>(actual);
            Assert.NotStrictEqual(expected, actual);
            Assert.IsType<string>(actualMessage);
            Assert.Equal(expectedMessage, actual.Message);
        }

        /// <summary>
        /// Given that Stream Reader passed is empty, Create Project Data From Stream will throw EmptyRaw Exception.
        /// </summary>
        [Fact]
        [Trait("Category", "Exception")]
        public void GivenEmptyStreamRaiseException()
        {
            // Arrange
            var emptyStream = new StreamReader(new MemoryStream());

            var expectedMessage = "No Raw Lines were submitted into the project.";
            var expected = new EmptyRawException(expectedMessage);

            // Act
            var actual = Record.Exception(() => projectDataRepository.CreateProjectDataFromStream(mockProjectName, emptyStream));
            var actualMessage = actual.Message;

            // Assert
            Assert.IsType<EmptyRawException>(actual);
            Assert.NotStrictEqual(expected, actual);
            Assert.IsType<string>(actualMessage);
            Assert.Equal(expectedMessage, actual.Message);
        }

        /// <summary>
        /// Given that Document passes is empty, Create Project Data From Document will throw EmptyRaw Exception.
        /// </summary>
        [Fact]
        [Trait("Category", "Not Implemented Correctly")]
        [Trait("Category", "Exception")]
        public void GivenEmptyDocumentRaiseException()
        {
            // Arrange
            var emptyDocument = new Document();

            var expectedMessage = "No Raw Lines were submitted into the project.";
            var expected = new EmptyRawException(expectedMessage);

            // Act
            var actual = Record.Exception(() => projectDataRepository.CreateProjectDataFromDocument(mockProjectName, emptyDocument));
            var actualMessage = actual.Message;

            // Assert
            Assert.IsType<EmptyRawException>(actual);
            Assert.NotStrictEqual(expected, actual);
            Assert.IsType<string>(actualMessage);
            Assert.Equal(expectedMessage, actual.Message);
        }

        #endregion

    }
}
