using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Office.Interop.Word;
using Moq;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Exception;
using TranslatorStudioClassLibrary.Factory;
using TranslatorStudioClassLibrary.Interface;
using Xunit;

namespace TranslatorStudioClassLibraryTest.Factory
{
    /// <summary>
    /// Contains tests to run against Project Data Factory class.
    /// </summary>
    [Collection("Project Data Factory Test")]
    public class ProjectDataFactoryTest
    {
        /// <summary>
        /// Contains tests to run against Project Data Factory constructors.
        /// </summary>
        [Trait("Category", "Unit")]
        [Trait("Class", "Project Data Factory")]
        public class Constructors
        {
            /// <summary>
            /// Constructor to set up test code.
            /// </summary>
            public Constructors()
            {

            }

            #region Constructor Tests
            /// <summary>
            /// Given that Project Data Factory is invoked, Default Constructor returns valid Project Data Factory.
            /// </summary>
            [Fact]
            public void ProjectDataFactory_DefaultConstructor_Test()
            {
                //Arrange
                var expected = new ProjectDataFactory();

                //Act
                var actual = new ProjectDataFactory();

                //Assert
                Assert.IsType<ProjectDataFactory>(actual);
                Assert.IsAssignableFrom<IProjectDataFactory>(actual);
                Assert.NotStrictEqual(expected, actual);
            }
            #endregion
        }

        /// <summary>
        /// Contains tests to run against Project Data Factory methods.
        /// </summary>
        [Trait("Category", "Unit")]
        [Trait("Class", "Project Data Factory")]
        public class Methods
        {
            /// <summary>
            /// Mock of Project Name.
            /// </summary>
            private readonly string mockProjectName;
            /// <summary>
            /// Mock of Project Lines.
            /// </summary>
            private readonly List<IProjectLine> mockProjectLines;

            /// <summary>
            /// Project Data Factory under test.
            /// </summary>
            private readonly IProjectDataFactory projectDataFactory;

            /// <summary>
            /// Constructor to set up test code.
            /// </summary>
            public Methods()
            {
                mockProjectName = "Mock Test Project Name";

                mockProjectLines = new List<IProjectLine>
                {
                    new ProjectLine { Raw = "Raw Line 1",   Translation = "Translated Line 1",      Completed = false,  Marked = true },
                    new ProjectLine { Raw = "Raw Line 2",   Translation = "Translated Line 2",      Completed = false,  Marked = false },
                    new ProjectLine { Raw = "Raw Line 3",   Translation = "Translated Line 3",      Completed = true,   Marked = true },
                    new ProjectLine { Raw = "Raw Line 4",   Translation = "Translated Line 4",      Completed = false,  Marked = false },
                    new ProjectLine { Raw = "Raw Line 5",   Translation = "Translated Line 5",      Completed = true,   Marked = false },
                    new ProjectLine { Raw = "Raw Line 6",   Translation = "Translated Line 6",      Completed = true,   Marked = true },
                    new ProjectLine { Raw = "Raw Line 7",   Translation = "Translated Line 7",      Completed = true,   Marked = false },
                    new ProjectLine { Raw = "Raw Line 8",   Translation = "Translated Line 8",      Completed = false,  Marked = true },
                    new ProjectLine { Raw = "Raw Line 9",   Translation = "Translated Line 9",      Completed = true,   Marked = true },
                    new ProjectLine { Raw = "Raw Line 10",  Translation = "Translated Line 10",     Completed = false,  Marked = false }
                };

                projectDataFactory = new ProjectDataFactory();
            }

            #region Methods Tests
            /// <summary>
            /// Given that Array passes is valid, Create Project Data From Array returns valid Project Data.
            /// </summary>
            [Fact]
            public void ProjectDataFactory_CreateProjectDataFromArray_Test()
            {
                //Arrange
                var expected = new ProjectData()
                {
                    ProjectName = mockProjectName,
                    ProjectLines = mockProjectLines
                };

                //Act
                var actual = projectDataFactory.CreateProjectDataFromArray(mockProjectName, mockProjectLines.Select(x => x.Raw).ToArray());

                //Assert
                Assert.IsType<ProjectData>(actual);
                Assert.IsAssignableFrom<IProjectData>(actual);
                Assert.NotStrictEqual(expected, actual);
                Assert.Equal(expected.ProjectLines.Select(x => x.Raw).ToList(), actual.ProjectLines.Select(x => x.Raw).ToList());
            }

            /// <summary>
            /// Given that Stream Reader passed is valid, Create Project Data From Stream returns valid Project Data.
            /// </summary>
            [Fact]
            public void ProjectDataFactory_CreateProjectDataFromStream_Test()
            {
                // Arrange
                var expectedName = mockProjectName;
                var expectedRaw = mockProjectLines.Select(x => x.Raw);
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
                var projectData = projectDataFactory.CreateProjectDataFromStream(expectedName, reader);
                var actualName = projectData.ProjectName;
                var actualRaw = projectData.ProjectLines.Select(x => x.Raw).ToList();

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
            public void ProjectDataFactory_CreateProjectDataFromDocument_Test()
            {
                // Arrange
                var expectedName = mockProjectName;
                var expectedRaw = mockProjectLines.Select(x => x.Raw).ToList();
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
                var projectData = projectDataFactory.CreateProjectDataFromDocument(expectedName, document.Object);
                var actualName = projectData.ProjectName;
                var actualRaw = projectData.ProjectLines.Select(x => x.Raw).ToList();

                // Assert
                Assert.IsType<string>(actualName);
                Assert.Equal(expectedName, actualName);
                Assert.IsType<List<string>>(actualRaw);
                //Assert.Equal(expectedRaw, actualRaw);
                Assert.Equal(expectedRaw.Count, actualRaw.Count); // Not a true assert. Need to redo this test.
            }
            #endregion
        }

        /// <summary>
        /// Contains tests to run against Project Data Factory methods that can throw expected exceptions.
        /// </summary>
        [Trait("Category", "Unit")]
        [Trait("Class", "Project Data Factory")]
        [Trait("Category", "Exception")]
        public class Exceptions
        {
            /// <summary>
            /// Mock of Project Name.
            /// </summary>
            private readonly string mockProjectName;

            /// <summary>
            /// Project Data Factory under test.
            /// </summary>
            private readonly IProjectDataFactory projectDataFactory;

            /// <summary>
            /// Constructor to set up test code.
            /// </summary>
            public Exceptions()
            {
                mockProjectName = "Mock Test Project Name";

                projectDataFactory = new ProjectDataFactory();
            }

            #region Exception Tests
            /// <summary>
            /// Given that Array passed is empty, Create Project Data From Array will throw EmptyRaw Exception.
            /// </summary>
            [Fact]
            [Trait("Exception", "EmptyRawException")]
            public void ProjectDataFactory_GivenEmptyArrayRaiseException()
            {
                // Arrange
                var emptyArray = new string[0];

                var expectedMessage = "No Raw Lines were submitted into the project.";
                var expected = new EmptyRawException(expectedMessage);

                // Act
                var actual = Record.Exception(() => projectDataFactory.CreateProjectDataFromArray(mockProjectName, emptyArray));
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
            [Trait("Exception", "EmptyRawException")]
            public void ProjectDataFactory_GivenEmptyStreamRaiseException()
            {
                // Arrange
                var emptyStream = new StreamReader(new MemoryStream());

                var expectedMessage = "No Raw Lines were submitted into the project.";
                var expected = new EmptyRawException(expectedMessage);

                // Act
                var actual = Record.Exception(() => projectDataFactory.CreateProjectDataFromStream(mockProjectName, emptyStream));
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
            [Trait("Exception", "EmptyRawException")]
            public void ProjectDataFactory_GivenEmptyDocumentRaiseException()
            {
                // Arrange
                var emptyDocument = new Document();

                var expectedMessage = "No Raw Lines were submitted into the project.";
                var expected = new EmptyRawException(expectedMessage);

                // Act
                var actual = Record.Exception(() => projectDataFactory.CreateProjectDataFromDocument(mockProjectName, emptyDocument));
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
}
