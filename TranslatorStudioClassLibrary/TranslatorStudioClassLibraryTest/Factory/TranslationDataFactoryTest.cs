using System;
using System.Collections.Generic;
using System.IO;
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
    /// Contains tests to run against Translation Data Factory class.
    /// </summary>
    [Collection("Translation Data Factory Test")]
    public class TranslationDataFactoryTest
    {
        /// <summary>
        /// Contains tests to run against Translation Data Factory constructors.
        /// </summary>
        [Trait("Category", "Unit")]
        [Trait("Class", "Translation Data Factory")]
        public class Constructors
        {
            /// <summary>
            /// Mock of Project Data Factory.
            /// </summary>
            private readonly Mock<IProjectDataFactory> mockProjectDataFactory;
            /// <summary>
            /// Mock of Sub Translation Data Factory.
            /// </summary>
            private readonly Mock<ISubTranslationDataFactory> mockSubTranslationDataFactory;

            /// <summary>
            /// Constructor to set up test code.
            /// </summary>
            public Constructors()
            {
                mockProjectDataFactory = new Mock<IProjectDataFactory>();
                mockSubTranslationDataFactory = new Mock<ISubTranslationDataFactory>();
            }

            #region Constructor Tests

            /// <summary>
            /// Given that Translation Data Factory is invoked, Default Constructor returns valid Translation Data Factory.
            /// </summary>
            [Fact]
            public void TranslationDataFactory_DefaultConstructor_Test()
            {
                //Arrange
                var projectFactory = mockProjectDataFactory.Object;
                var subFactory = mockSubTranslationDataFactory.Object;

                var expected = new TranslationDataFactory(projectFactory, subFactory);

                //Act
                var actual = new TranslationDataFactory(projectFactory, subFactory);

                //Assert
                Assert.IsType<TranslationDataFactory>(actual);
                Assert.IsAssignableFrom<ITranslationDataFactory>(actual);
                Assert.NotStrictEqual(expected, actual);
            }

            /// <summary>
            /// Given that Project Data Factory is null, Default Constructor throws Argument Null Excpetion.
            /// </summary>
            [Fact]
            [Trait("Category", "Exception")]
            [Trait("Exception", "ArgumentNullException")]
            public void TranslationDataFactory_DefaultConstructor_NullProjectDataFactory_Test()
            {
                //Arrange
                var subFactory = mockSubTranslationDataFactory.Object;

                //Act, Assert
                Assert.Throws<ArgumentNullException>("projectDataFactory", () => new TranslationDataFactory(null, subFactory));
            }

            /// <summary>
            /// Given that Sub Translation Data Factory is null, Default Constructor throws Argument Null Excpetion.
            /// </summary>
            [Fact]
            [Trait("Category", "Exception")]
            [Trait("Exception", "ArgumentNullException")]
            public void TranslationDataFactory_DefaultConstructor_NullSubTranslationDataFactory_Test()
            {
                //Arrange
                var projectFactory = mockProjectDataFactory.Object;
                
                //Act, Assert
                Assert.Throws<ArgumentNullException>("subTranslationDataFactory", () => new TranslationDataFactory(projectFactory, null));
            }

            #endregion
        }

        /// <summary>
        /// Contains tests to run against Translation Data Factory methods.
        /// </summary>
        [Trait("Category", "Unit")]
        [Trait("Class", "Translation Data Factory")]
        public class Methods
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
            /// Mock of Project Data Factory.
            /// </summary>
            private readonly Mock<IProjectDataFactory> mockProjectDataFactory;
            /// <summary>
            /// Mock of Sub Translation Data Factory.
            /// </summary>
            private readonly Mock<ISubTranslationDataFactory> mockSubTranslationDataFactory;
            /// <summary>
            /// Translation Data Factory under test.
            /// </summary>
            private readonly ITranslationDataFactory translationDataFactory;

            /// <summary>
            /// Constructor to set up test code.
            /// </summary>
            public Methods()
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

                mockProjectDataFactory = new Mock<IProjectDataFactory>();

                mockProjectDataFactory.Setup(
                        x => x.CreateProjectDataFromArray(It.IsAny<string>(), It.IsAny<string[]>()))
                    .Returns(mockProjectData.Object);

                mockProjectDataFactory.Setup(
                        x => x.CreateProjectDataFromStream(It.IsAny<string>(), It.IsAny<StreamReader>()))
                    .Returns(mockProjectData.Object);

                mockProjectDataFactory.Setup(
                        x => x.CreateProjectDataFromDocument(It.IsAny<string>(), It.IsAny<Document>()))
                    .Returns(mockProjectData.Object);

                mockSubTranslationDataFactory = new Mock<ISubTranslationDataFactory>();

                translationDataFactory = new TranslationDataFactory(mockProjectDataFactory.Object, mockSubTranslationDataFactory.Object);
            }

            #region Methods Tests

            /// <summary>
            /// Given that Project Data passed is valid, Create Translation Data From Project returns valid Translation Data.
            /// </summary>
            [Fact]
            public void TranslationDataFactory_CreateTranslationDataFromProject_Test()
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
                var expected = new TranslationData(data, mockSubTranslationDataFactory.Object);

                // Act
                var actual = translationDataFactory.CreateTranslationDataFromProject(data);

                // Assert
                Assert.IsType<TranslationData>(actual);
                Assert.IsAssignableFrom<ITranslationData>(actual);
                Assert.NotStrictEqual(expected, actual);
            }

            /// <summary>
            /// Given that Stream Reader passed is valid, Create Translation Data From Stream returns valid Translation Data.
            /// </summary>
            [Fact]
            public void TranslationDataFactory_CreateTranslationDataFromStream_Test()
            {
                // Arrange
                var expected = new TranslationData(mockProjectData.Object, mockSubTranslationDataFactory.Object);

                // Act
                var actual = translationDataFactory.CreateTranslationDataFromStream(mockProjectName, new StreamReader(new MemoryStream()));

                // Assert
                mockProjectDataFactory.Verify(
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
            public void TranslationDataFactory_CreateTranslationDataFromDocument_Test()
            {
                // Arrange
                var expected = new TranslationData(mockProjectData.Object, mockSubTranslationDataFactory.Object);

                // Act
                var actual = translationDataFactory.CreateTranslationDataFromDocument("", new Document());

                // Assert
                mockProjectDataFactory.Verify(
                        x => x.CreateProjectDataFromDocument(It.IsAny<string>(), It.IsAny<Document>()),
                    Times.Once);

                Assert.IsType<TranslationData>(actual);
                Assert.IsAssignableFrom<ITranslationData>(actual);
                Assert.NotStrictEqual(expected, actual);
            }

            #endregion
        }

        /// <summary>
        /// Contains tests to run against Translation Data Factory methods that can throw expected exceptions.
        /// </summary>
        [Trait("Category", "Unit")]
        [Trait("Class", "Translation Data Factory")]
        [Trait("Category", "Exception")]
        public class Exceptions
        {
            /// <summary>
            /// Mock of Project Data Factory.
            /// </summary>
            private readonly Mock<IProjectDataFactory> mockProjectDataFactory;
            /// <summary>
            /// Mock of Sub Translation Data Factory.
            /// </summary>
            private readonly Mock<ISubTranslationDataFactory> mockSubTranslationDataFactory;
            /// <summary>
            /// Translation Data Factory under test.
            /// </summary>
            private readonly ITranslationDataFactory translationDataFactory;

            /// <summary>
            /// Constructor to set up test code.
            /// </summary>
            public Exceptions()
            {
                mockProjectDataFactory = new Mock<IProjectDataFactory>();
                mockSubTranslationDataFactory = new Mock<ISubTranslationDataFactory>();
                translationDataFactory = new TranslationDataFactory(mockProjectDataFactory.Object, mockSubTranslationDataFactory.Object);
            }

            #region Exception Tests

            /// <summary>
            /// Given that Project Data has empty raw, Create Translation Data From Project will throw EmptyRaw Exception.
            /// </summary>
            [Fact]
            [Trait("Exception", "EmptyRawException")]
            public void TranslationDataFactory_GivenNoRawInProjectRaiseException()
            {
                // Arrange
                IProjectData data = new ProjectData()
                {
                    RawLines = new List<string>()
                };

                var expectedMessage = "No Raw Lines were submitted into the project.";
                var expected = new EmptyRawException(expectedMessage);

                // Act
                var actual = Record.Exception(() => translationDataFactory.CreateTranslationDataFromProject(data));
                var actualMessage = actual.Message;

                // Assert
                Assert.IsType<EmptyRawException>(actual);
                Assert.NotStrictEqual(expected, actual);
                Assert.Equal(expectedMessage, actualMessage);
            }

            #endregion
        }
    }
}
