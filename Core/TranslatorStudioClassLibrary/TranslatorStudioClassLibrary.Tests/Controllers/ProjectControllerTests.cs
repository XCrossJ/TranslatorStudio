using AutoFixture;
using AutoFixture.Xunit2;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using TranslatorStudioClassLibrary.Contracts.Controllers;
using TranslatorStudioClassLibrary.Contracts.Types;
using TranslatorStudioClassLibrary.Controllers;
using TranslatorStudioClassLibrary.Tests.TestSetup;
using TranslatorStudioClassLibrary.Tests.TestSetup.Builders;
using TranslatorStudioClassLibrary.Types;
using Xunit;

namespace TranslatorStudioClassLibrary.Tests.Controllers
{
    public class ProjectControllerTests
    {
        [Trait("Project Controller", "Constructor Test")]
        [Trait("Category", "Unit")]
        public class Constructor
        {
            [Theory(DisplayName = "Project Controller: Default Constructor")]
            [AutoMoqData]
            public void DefaultConstructor(Mock<IProjectDataType> mockProjectData)
            {
                // Arrange
                var projectData = mockProjectData.Object;

                // Act
                var actual = new ProjectController(projectData);

                // Assert
                Assert.IsType<ProjectController>(actual);
                Assert.IsAssignableFrom<IProjectController>(actual);
            }

            [Trait("Exception Test", "Argument Null Exception")]
            [Theory(DisplayName = "Project Controller: Throws Exception with Illegal Parameters")]
            [InlineData(null)]
            public void IllegalParams_Throws_Exception(
                IProjectDataType invalidProjectData
                )
            {
                // Arrange

                // Act, Assert
                Assert.Throws<ArgumentNullException>("projectData", () => new ProjectController(invalidProjectData));
            }
        }

        [Trait("Project Controller", "Property Test")]
        [Trait("Category", "Unit")]
        public class Property
        {
            private readonly IList<IProjectLineType> projectLines;
            private readonly Mock<IProjectDataType> mockProjectData;
            private readonly ProjectController sut;

            private readonly IFixture fixture;

            public Property()
            {
                fixture = new FixtureBuilder().Build();

                projectLines = fixture.CreateMany<IProjectLineType>().ToList();
                mockProjectData = fixture.Create<Mock<IProjectDataType>>();

                mockProjectData.Setup(x => x.ProjectLines).Returns(projectLines);

                sut = new ProjectController(mockProjectData.Object);
            }

            #region Current Line
            [Theory(DisplayName = "Project Controller: Get Current Line")]
            [InlineAutoData(0)]
            [InlineAutoData(1)]
            [InlineAutoData(2)]
            public void GetCurrentLine(int validCurrentIndex)
            {
                // Arrange
                sut.CurrentIndex = validCurrentIndex;
                var expected = projectLines[validCurrentIndex];

                // Act
                var actual = sut.CurrentLine;

                // Assert
                Assert.Equal(expected, actual);
            }
            #endregion

            #region Current Raw
            [Theory(DisplayName = "Project Controller: Get Current Raw")]
            [InlineAutoData(0)]
            [InlineAutoData(1)]
            [InlineAutoData(2)]
            public void GetCurrentRaw(int validCurrentIndex)
            {
                // Arrange
                sut.CurrentIndex = validCurrentIndex;
                var expected = projectLines[validCurrentIndex].Raw;

                // Act
                var actual = sut.CurrentRaw;

                // Assert
                Assert.Equal(expected, actual);
            }

            [Theory(DisplayName = "Project Controller: Set Current Raw")]
            [InlineAutoData(0)]
            [InlineAutoData(1)]
            [InlineAutoData(2)]
            public void SetCurrentRaw(int validCurrentIndex, string newRaw)
            {
                // Arrange
                sut.CurrentIndex = validCurrentIndex;
                var expected = newRaw;

                // Act
                sut.CurrentRaw = newRaw;
                var actual = sut.CurrentRaw;

                // Assert
                Assert.Equal(expected, actual);
            }
            #endregion

            #region Current Translation
            [Theory(DisplayName = "Project Controller: Get Current Translation")]
            [InlineAutoData(0)]
            [InlineAutoData(1)]
            [InlineAutoData(2)]
            public void GetCurrentTranslation(int validCurrentIndex)
            {
                // Arrange
                sut.CurrentIndex = validCurrentIndex;
                var expected = projectLines[validCurrentIndex].Translation;

                // Act
                var actual = sut.CurrentTranslation;

                // Assert
                Assert.Equal(expected, actual);
            }

            [Theory(DisplayName = "Project Controller: Set Current Translation")]
            [InlineAutoData(0)]
            [InlineAutoData(1)]
            [InlineAutoData(2)]
            public void SetCurrentTranslation(int validCurrentIndex, string newTranslation)
            {
                // Arrange
                sut.CurrentIndex = validCurrentIndex;
                var expected = newTranslation;

                // Act
                sut.CurrentTranslation = newTranslation;
                var actual = sut.CurrentTranslation;

                // Assert
                Assert.Equal(expected, actual);
            }
            #endregion

            #region Current Comment
            [Theory(DisplayName = "Project Controller: Get Current Comment")]
            [InlineAutoData(0)]
            [InlineAutoData(1)]
            [InlineAutoData(2)]
            public void GetCurrentComment(int validCurrentIndex)
            {
                // Arrange
                sut.CurrentIndex = validCurrentIndex;
                var expected = projectLines[validCurrentIndex].Comment;

                // Act
                var actual = sut.CurrentComment;

                // Assert
                Assert.Equal(expected, actual);
            }

            [Theory(DisplayName = "Project Controller: Set Current Comment")]
            [InlineAutoData(0)]
            [InlineAutoData(1)]
            [InlineAutoData(2)]
            public void SetCurrentComment(int validCurrentIndex, string newComment)
            {
                // Arrange
                sut.CurrentIndex = validCurrentIndex;
                var expected = newComment;

                // Act
                sut.CurrentComment = newComment;
                var actual = sut.CurrentComment;

                // Assert
                Assert.Equal(expected, actual);
            }
            #endregion

            #region Current Completion
            [Theory(DisplayName = "Project Controller: Get Current Completion")]
            [InlineAutoData(0)]
            [InlineAutoData(1)]
            [InlineAutoData(2)]
            public void GetCurrentCompletion(int validCurrentIndex)
            {
                // Arrange
                sut.CurrentIndex = validCurrentIndex;
                var expected = projectLines[validCurrentIndex].Completed;

                // Act
                var actual = sut.CurrentCompletion;

                // Assert
                Assert.Equal(expected, actual);
            }

            [Theory(DisplayName = "Project Controller: Set Current Completion")]
            [InlineAutoData(0)]
            [InlineAutoData(1)]
            [InlineAutoData(2)]
            public void SetCurrentCompletion(int validCurrentIndex, bool newCompletion)
            {
                // Arrange
                sut.CurrentIndex = validCurrentIndex;
                var expected = newCompletion;

                // Act
                sut.CurrentCompletion = newCompletion;
                var actual = sut.CurrentCompletion;

                // Assert
                Assert.Equal(expected, actual);
            }
            #endregion

            #region Current Marked
            [Theory(DisplayName = "Project Controller: Get Current Marked")]
            [InlineAutoData(0)]
            [InlineAutoData(1)]
            [InlineAutoData(2)]
            public void GetCurrentMarked(int validCurrentIndex)
            {
                // Arrange
                sut.CurrentIndex = validCurrentIndex;
                var expected = projectLines[validCurrentIndex].Marked;

                // Act
                var actual = sut.CurrentMarked;

                // Assert
                Assert.Equal(expected, actual);
            }

            [Theory(DisplayName = "Project Controller: Set Current Marked")]
            [InlineAutoData(0)]
            [InlineAutoData(1)]
            [InlineAutoData(2)]
            public void SetCurrentMarked(int validCurrentIndex, bool newMarked)
            {
                // Arrange
                sut.CurrentIndex = validCurrentIndex;
                var expected = newMarked;

                // Act
                sut.CurrentMarked = newMarked;
                var actual = sut.CurrentMarked;

                // Assert
                Assert.Equal(expected, actual);
            }
            #endregion

            #region Current Index
            [Theory(DisplayName = "Project Controller: Set Current Index")]
            [AutoData]
            public void SetCurrentIndex(int newIndex)
            {
                // Arrange
                var expected = newIndex;

                // Act
                sut.CurrentIndex = newIndex;
                var actual = sut.CurrentIndex;

                // Assert
                Assert.Equal(expected, actual);
            }
            #endregion

            #region Max Index
            [Theory(DisplayName = "Project Controller: Get Max Index")]
            [AutoData]
            public void GetMaxIndex(int maxIndex)
            {
                // Arrange
                mockProjectData.SetupGet(x => x.ProjectLines.Count).Returns(maxIndex + 1);
                var expected = maxIndex;

                // Act
                var actual = sut.MaxIndex;

                // Assert
                Assert.Equal(expected, actual);
                mockProjectData.VerifyGet(x => x.ProjectLines.Count, Times.Once);
            }
            #endregion

            #region Number Of Lines
            [Theory(DisplayName = "Project Controller: Get Number Of Lines")]
            [AutoData]
            public void GetNumberOfLines(int numberOfLines)
            {
                // Arrange
                mockProjectData.SetupGet(x => x.ProjectLines.Count).Returns(numberOfLines);
                var expected = numberOfLines;

                // Act
                var actual = sut.NumberOfLines;

                // Assert
                Assert.Equal(expected, actual);
                mockProjectData.VerifyGet(x => x.ProjectLines.Count, Times.Once);
            }
            #endregion

            #region Number Of Completed Lines
            [Fact(DisplayName = "Project Controller: Get Number Of Completed Lines")]
            public void GetNumberOfCompletedLines()
            {
                // Arrange
                var expected = projectLines.Where(x => x.Completed).Count();

                // Act
                var actual = sut.NumberOfCompletedLines;

                // Assert
                Assert.Equal(expected, actual);
            }
            #endregion
        }

        [Trait("Project Controller", "Method Test")]
        [Trait("Category", "Unit")]
        public class Method
        {
            private readonly Mock<IList<IProjectLineType>> mockProjectLines;
            private readonly Mock<IProjectDataType> mockProjectData;
            private readonly ProjectController sut;

            private readonly IFixture fixture;

            public Method()
            {
                fixture = new FixtureBuilder().Build();

                mockProjectLines = fixture.Create<Mock<IList<IProjectLineType>>>();
                mockProjectData = fixture.Create<Mock<IProjectDataType>>();

                mockProjectData.Setup(x => x.ProjectLines).Returns(mockProjectLines.Object);

                sut = new ProjectController(mockProjectData.Object);
            }

            #region Commands
            [Theory(DisplayName = "Project Controller: Increment Current Line")]
            [AutoData]
            public void IncrementCurrentLine(int startingIndex)
            {
                // Arrange
                sut.CurrentIndex = startingIndex;

                // Forces Max Index to be greater than starting index so call is run.
                var newCount = fixture.Create<int>() + startingIndex;
                mockProjectLines.SetupGet(x => x.Count).Returns(newCount);

                var expected = startingIndex + 1;

                // Act
                sut.IncrementCurrentLine();
                var actual = sut.CurrentIndex;

                // Assert
                Assert.Equal(expected, actual);
                mockProjectLines.VerifyGet(x => x.Count, Times.Once);
            }

            [Theory(DisplayName = "Project Controller: Increment Current Line When Index Greater Than Max Index")]
            [AutoData]
            public void IncrementCurrentLineGreaterThanMaxIndex(int startingIndex)
            {
                // Arrange
                sut.CurrentIndex = startingIndex;

                // Forces Max Index to be less than starting index so call is not run.
                var newCount = startingIndex - fixture.Create<int>();
                mockProjectLines.SetupGet(x => x.Count).Returns(newCount);

                var expected = startingIndex;

                // Act
                sut.IncrementCurrentLine();
                var actual = sut.CurrentIndex;

                // Assert
                Assert.Equal(expected, actual);
                mockProjectLines.Verify(x => x.Count, Times.Once);
            }

            [Theory(DisplayName = "Project Controller: Decrement Current Line")]
            [AutoData]
            public void DecrementCurrentLine(int startingIndex)
            {
                // Arrange
                sut.CurrentIndex = startingIndex;
                var expected = startingIndex - 1;

                // Act
                sut.DecrementCurrentLine();
                var actual = sut.CurrentIndex;

                // Assert
                Assert.Equal(expected, actual);
            }

            [Theory(DisplayName = "Project Controller: Decrement Current Line When Index Less Than Min Index")]
            [AutoData]
            public void DecrementCurrentLineLessThanMinIndex(int startingIndex)
            {
                // Arrange
                sut.CurrentIndex = -startingIndex;

                var expected = -startingIndex;

                // Act
                sut.DecrementCurrentLine();
                var actual = sut.CurrentIndex;

                // Assert
                Assert.Equal(expected, actual);
            }


            [Theory(DisplayName = "Project Controller: Insert Line")]
            [AutoData]
            [InlineAutoData(null, null)]
            public void InsertLine(int? index, string rawValue)
            {
                // Arrange
                int expectedIndex = index ?? sut.NumberOfLines;
                IProjectLineType expectedLine = new ProjectLine(rawValue ?? "");

                int actualIndex = 0;
                IProjectLineType actualLine = null;

                mockProjectLines
                    .Setup(x => x.Insert(It.IsAny<int>(), It.IsAny<IProjectLineType>()))
                    .Callback((int i, IProjectLineType insertedLine) =>
                    {
                        actualIndex = i;
                        actualLine = insertedLine;
                    });

                // Act
                sut.InsertLine(index, rawValue);

                //Assert
                mockProjectLines.Verify(x => x.Insert(It.IsAny<int>(), It.IsAny<IProjectLineType>()), Times.Once);

                Assert.Equal(expectedIndex, actualIndex);
                Assert.Equal(expectedLine,  actualLine);
            }

            [Theory(DisplayName = "Project Controller: Remove Line")]
            [AutoData]
            public void RemoveLine(int? index)
            {
                // Arrange
                int expectedIndex = index ?? sut.MaxIndex;

                int actualIndex = 0;

                mockProjectLines
                    .Setup(x => x.RemoveAt(It.IsAny<int>()))
                    .Callback((int i) => actualIndex = i);

                // Act
                sut.RemoveLine(index);

                //Assert
                mockProjectLines.Verify(x => x.RemoveAt(It.IsAny<int>()), Times.Once);

                Assert.Equal(expectedIndex, actualIndex);
            }

            [Trait("Exception Test", "Exception")]
            [Theory(DisplayName = "Project Controller: Remove Line Throws Exception When Only Single Line")]
            [AutoData]
            public void RemoveLineAtSingle(int? index)
            {
                // Arrange
                mockProjectLines.Setup(x => x.Count).Returns(1);

                // Act, Assert
                Assert.Throws<Exception>(() => sut.RemoveLine(index));
                mockProjectLines.Verify(x => x.Count, Times.Once);
            }
            #endregion

            #region Queries
            [Fact(DisplayName = "Project Controller: Get Project Data")]
            public void GetProjectData()
            {
                // Arrange
                var expected = mockProjectData.Object;

                // Act
                var actual = sut.GetProjectData();

                // Assert
                Assert.Equal(expected, actual);
            }
            #endregion
        }
    }
}