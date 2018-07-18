using AutoFixture;
using AutoFixture.Xunit2;
using Moq;
using System;
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
    public class AutoProjectControllerTests
    {
        [Trait("Auto Project Controller", "Constructor Test")]
        [Trait("Category", "Unit")]
        public class Constructor
        {
            [Theory(DisplayName = "Auto Project Controller: Default Constructor")]
            [AutoMoqData]
            public void DefaultConstructor(Mock<IProjectController> mockProjectController)
            {
                // Arrange
                var projectController = mockProjectController.Object;

                // Act
                var actual = new AutoProjectController(projectController);

                // Assert
                Assert.IsType<AutoProjectController>(actual);
                Assert.IsAssignableFrom<IProjectController>(actual);
            }

            [Trait("Exception Test", "Argument Null Exception")]
            [Theory(DisplayName = "Auto Project Controller: Throws Exception with Illegal Parameters")]
            [InlineData(null)]
            public void IllegalParams_Throws_Exception(
                IProjectController invalidProjectController
                )
            {
                // Arrange

                // Act, Assert
                Assert.Throws<ArgumentNullException>("projectController", () => new AutoProjectController(invalidProjectController));
            }
        }

        [Trait("Auto Project Controller", "Property Test")]
        [Trait("Category", "Unit")]
        public class Property
        {
            private readonly Mock<IProjectController> mockProjectController;
            private readonly AutoProjectController sut;

            private readonly IFixture fixture;

            public Property()
            {
                fixture = new FixtureBuilder().Build();

                mockProjectController = fixture.Create<Mock<IProjectController>>();

                sut = new AutoProjectController(mockProjectController.Object);
            }

            #region Current Line
            [Theory(DisplayName = "Auto Project Controller: Get Current Line")]
            [AutoMoqData]
            public void GetCurrentLine(IProjectLineType currentLine)
            {
                // Arrange
                var expected = currentLine;
                mockProjectController.Setup(x => x.CurrentLine).Returns(currentLine);

                // Act
                var actual = sut.CurrentLine;

                // Assert
                Assert.Equal(expected, actual);
                mockProjectController.Verify(x => x.CurrentLine, Times.Once);
            }
            #endregion

            #region Current Raw
            [Theory(DisplayName = "Auto Project Controller: Get Current Raw")]
            [AutoData]
            public void GetCurrentRaw(string raw)
            {
                // Arrange
                var expected = raw;
                mockProjectController.Setup(x => x.CurrentRaw).Returns(raw);

                // Act
                var actual = sut.CurrentRaw;

                // Assert
                Assert.Equal(expected, actual);
                mockProjectController.VerifyGet(x => x.CurrentRaw, Times.Once);
            }

            [Theory(DisplayName = "Auto Project Controller: Set Current Raw")]
            [AutoData]
            public void SetCurrentRaw(string newRaw)
            {
                // Arrange
                var expected = newRaw;

                // Act
                sut.CurrentRaw = newRaw;
                var actual = sut.CurrentRaw;

                // Assert
                Assert.Equal(expected, actual);
                mockProjectController.VerifySet(x => x.CurrentRaw = newRaw, Times.Once);
            }
            #endregion

            #region Current Translation
            [Theory(DisplayName = "Auto Project Controller: Get Current Translation")]
            [AutoData]
            public void GetCurrentTranslation(string translation)
            {
                // Arrange
                var expected = translation;
                mockProjectController.Setup(x => x.CurrentTranslation).Returns(translation);

                // Act
                var actual = sut.CurrentTranslation;

                // Assert
                Assert.Equal(expected, actual);
                mockProjectController.VerifyGet(x => x.CurrentTranslation, Times.Once);
            }

            [Theory(DisplayName = "Auto Project Controller: Set Current Translation")]
            [AutoData]
            public void SetCurrentTranslation(string newTranslation)
            {
                // Arrange
                var expected = newTranslation;

                // Act
                sut.CurrentTranslation = newTranslation;
                var actual = sut.CurrentTranslation;

                // Assert
                Assert.Equal(expected, actual);
                mockProjectController.VerifySet(x => x.CurrentTranslation = newTranslation, Times.Once);
            }
            #endregion

            #region Current Comment
            [Theory(DisplayName = "Auto Project Controller: Get Current Comment")]
            [AutoData]
            public void GetCurrentComment(string comment)
            {
                // Arrange
                var expected = comment;
                mockProjectController.Setup(x => x.CurrentComment).Returns(comment);

                // Act
                var actual = sut.CurrentComment;

                // Assert
                Assert.Equal(expected, actual);
                mockProjectController.VerifyGet(x => x.CurrentComment, Times.Once);
            }

            [Theory(DisplayName = "Auto Project Controller: Set Current Comment")]
            [AutoData]
            public void SetCurrentComment(string newComment)
            {
                // Arrange
                var expected = newComment;

                // Act
                sut.CurrentComment = newComment;
                var actual = sut.CurrentComment;

                // Assert
                Assert.Equal(expected, actual);
                mockProjectController.VerifySet(x => x.CurrentComment = newComment, Times.Once);
            }
            #endregion

            #region Current Completion
            [Theory(DisplayName = "Auto Project Controller: Get Current Completion")]
            [AutoData]
            public void GetCurrentCompletion(bool completion)
            {
                // Arrange
                var expected = completion;
                mockProjectController.Setup(x => x.CurrentCompletion).Returns(completion);

                // Act
                var actual = sut.CurrentCompletion;

                // Assert
                Assert.Equal(expected, actual);
                mockProjectController.VerifyGet(x => x.CurrentCompletion, Times.Once);
            }

            [Theory(DisplayName = "Auto Project Controller: Set Current Completion")]
            [AutoData]
            public void SetCurrentCompletion(bool newCompletion)
            {
                // Arrange
                var expected = newCompletion;

                // Act
                sut.CurrentCompletion = newCompletion;
                var actual = sut.CurrentCompletion;

                // Assert
                Assert.Equal(expected, actual);
                mockProjectController.VerifySet(x => x.CurrentCompletion = newCompletion, Times.AtLeastOnce);
            }
            #endregion

            #region Current Marked
            [Theory(DisplayName = "Auto Project Controller: Get Current Marked")]
            [AutoData]
            public void GetCurrentMarked(bool marked)
            {
                // Arrange
                var expected = marked;
                mockProjectController.Setup(x => x.CurrentMarked).Returns(marked);

                // Act
                var actual = sut.CurrentMarked;

                // Assert
                Assert.Equal(expected, actual);
                mockProjectController.VerifyGet(x => x.CurrentMarked, Times.Once);
            }

            [Theory(DisplayName = "Auto Project Controller: Set Current Marked")]
            [AutoData]
            public void SetCurrentMarked(bool newMarked)
            {
                // Arrange
                var expected = newMarked;

                // Act
                sut.CurrentMarked = newMarked;
                var actual = sut.CurrentMarked;

                // Assert
                Assert.Equal(expected, actual);
                mockProjectController.VerifySet(x => x.CurrentMarked = newMarked, Times.Once);
            }
            #endregion

            #region Current Index
            [Theory(DisplayName = "Auto Project Controller: Set Current Index")]
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
                mockProjectController.VerifySet(x => x.CurrentIndex = newIndex, Times.Once);
            }
            #endregion

            #region Max Index
            [Theory(DisplayName = "Auto Project Controller: Get Max Index")]
            [AutoData]
            public void GetMaxIndex(int maxIndex)
            {
                // Arrange
                var expected = maxIndex;
                mockProjectController.SetupGet(x => x.MaxIndex).Returns(maxIndex);

                // Act
                var actual = sut.MaxIndex;

                // Assert
                Assert.Equal(expected, actual);
                mockProjectController.VerifyGet(x => x.MaxIndex, Times.Once);
            }
            #endregion

            #region Number Of Lines
            [Theory(DisplayName = "Auto Project Controller: Get Number Of Lines")]
            [AutoData]
            public void GetNumberOfLines(int numberOfEmptyLines, int numberOfNonEmptyLines)
            {
                // Arrange
                #region Mock Project Data
                var emptyProjectLines = fixture.Build<ProjectLine>()
                                        .Without(x => x.Raw)
                                        .CreateMany(numberOfEmptyLines);

                var projectLines = fixture.CreateMany<ProjectLine>(numberOfNonEmptyLines).ToList<IProjectLineType>();
                projectLines.AddRange(emptyProjectLines);

                var projectData = fixture.Build<ProjectData>()
                                        .With(x => x.ProjectLines, projectLines)
                                        .Create();
                #endregion

                mockProjectController.Setup(x => x.GetProjectData()).Returns(projectData);

                var expected = numberOfNonEmptyLines;

                // Act
                var actual = sut.NumberOfLines;

                // Assert
                Assert.Equal(expected, actual);
                mockProjectController.Verify(x => x.GetProjectData(), Times.Once);
            }
            #endregion

            #region Number Of Completed Lines
            [Theory(DisplayName = "Auto Project Controller: Get Number Of Completed Lines")]
            [AutoData]
            public void GetNumberOfCompletedLines(int numberOfCompletedLines)
            {
                // Arrange
                var expected = numberOfCompletedLines;
                mockProjectController.SetupGet(x => x.NumberOfCompletedLines).Returns(numberOfCompletedLines);

                // Act
                var actual = sut.NumberOfCompletedLines;

                // Assert
                Assert.Equal(expected, actual);
                mockProjectController.VerifyGet(x => x.NumberOfCompletedLines, Times.Once);
            }
            #endregion
        }

        [Trait("Auto Project Controller", "Method Test")]
        [Trait("Category", "Unit")]
        public class Method
        {
            private readonly Mock<IProjectController> mockProjectController;
            private readonly AutoProjectController sut;

            private readonly IFixture fixture;

            public Method()
            {
                fixture = new FixtureBuilder().Build();

                mockProjectController = fixture.Create<Mock<IProjectController>>();

                sut = new AutoProjectController(mockProjectController.Object);
            }

            #region Commands
            [Theory(DisplayName = "Auto Project Controller: Increment Current Line")]
            [AutoData]
            public void IncrementCurrentLine(int startingIndex, int expectedLoops)
            {
                // Arrange
                var currentIndex = startingIndex;
                sut.CurrentIndex = currentIndex;

                // Forces Max Index to be greater than starting index so call is run.
                var newCount = fixture.Create<int>() + startingIndex + expectedLoops;
                mockProjectController.Setup(x => x.MaxIndex).Returns(newCount);

                var expected = startingIndex + expectedLoops;

                mockProjectController.SetupGet(x => x.CurrentRaw).Returns("");

                #region Mock Increment Current Line
                mockProjectController
                    .Setup(x => x.IncrementCurrentLine())
                    .Callback(() =>
                    {
                        currentIndex++;
                        mockProjectController.SetupGet(x => x.CurrentIndex).Returns(currentIndex);
                        if (currentIndex == expected)
                        {
                            mockProjectController.SetupGet(x => x.CurrentRaw).Returns(fixture.Create("ValidRaw"));
                        }
                    });
                #endregion

                // Act
                sut.IncrementCurrentLine();
                var actual = sut.CurrentIndex;

                // Assert
                Assert.Equal(expected, actual);

                mockProjectController.VerifyGet(x => x.CurrentIndex, Times.Exactly(expectedLoops));
                mockProjectController.VerifyGet(x => x.MaxIndex, Times.Exactly(expectedLoops - 1));
                mockProjectController.VerifyGet(x => x.CurrentRaw, Times.Exactly(expectedLoops));
                mockProjectController.VerifyGet(x => x.CurrentCompletion, Times.Once);
                mockProjectController.VerifySet(x => x.CurrentCompletion = true, Times.Exactly(expectedLoops + 1));

                mockProjectController.Verify(x => x.IncrementCurrentLine(), Times.Exactly(expectedLoops));
            }

            [Theory(DisplayName = "Auto Project Controller: Increment Current Line When Index Greater Than Max Index")]
            [AutoData]
            public void IncrementCurrentLineGreaterThanMaxIndex(int startingIndex)
            {
                // Arrange
                sut.CurrentIndex = startingIndex;

                // Forces Max Index to be less than starting index so call is not run.
                var newCount = startingIndex - fixture.Create<int>();
                mockProjectController.SetupGet(x => x.MaxIndex).Returns(newCount);

                var expected = startingIndex;

                mockProjectController.SetupGet(x => x.CurrentRaw).Returns("");

                // Act
                sut.IncrementCurrentLine();
                var actual = sut.CurrentIndex;

                // Assert
                Assert.Equal(expected, actual);

                mockProjectController.VerifyGet(x => x.MaxIndex, Times.Once);
                mockProjectController.VerifyGet(x => x.CurrentRaw, Times.Once);
                mockProjectController.VerifySet(x => x.CurrentCompletion = true, Times.Exactly(2));

                mockProjectController.Verify(x => x.IncrementCurrentLine(), Times.Once);
            }

            [Theory(DisplayName = "Auto Project Controller: Decrement Current Line")]
            [AutoData]
            public void DecrementCurrentLine(int finishingIndex, int expectedLoops)
            {
                // Arrange
                var currentIndex = finishingIndex + expectedLoops;
                sut.CurrentIndex = currentIndex;

                var expected = finishingIndex;

                mockProjectController.SetupGet(x => x.CurrentRaw).Returns("");

                #region Mock Decrement Current Line
                mockProjectController
                    .Setup(x => x.DecrementCurrentLine())
                    .Callback(() =>
                    {
                        currentIndex--;
                        mockProjectController.SetupGet(x => x.CurrentIndex).Returns(currentIndex);
                        if (currentIndex == expected)
                        {
                            mockProjectController.SetupGet(x => x.CurrentRaw).Returns(fixture.Create("ValidRaw"));
                        }
                    });
                #endregion

                // Act
                sut.DecrementCurrentLine();
                var actual = sut.CurrentIndex;

                // Assert
                Assert.Equal(expected, actual);

                mockProjectController.VerifyGet(x => x.CurrentIndex, Times.Exactly(expectedLoops));
                mockProjectController.VerifyGet(x => x.CurrentRaw, Times.Exactly(expectedLoops));
                mockProjectController.VerifyGet(x => x.CurrentCompletion, Times.Once);
                mockProjectController.VerifySet(x => x.CurrentCompletion = true, Times.Exactly(expectedLoops + 1));

                mockProjectController.Verify(x => x.DecrementCurrentLine(), Times.Exactly(expectedLoops));
            }

            [Theory(DisplayName = "Auto Project Controller: Decrement Current Line When Index Less Than Min Index")]
            [AutoData]
            public void DecrementCurrentLineLessThanMinIndex(int startingIndex)
            {
                // Arrange
                sut.CurrentIndex = -startingIndex;

                var expected = -startingIndex;

                mockProjectController.SetupGet(x => x.CurrentRaw).Returns("");

                // Act
                sut.DecrementCurrentLine();
                var actual = sut.CurrentIndex;

                // Assert
                Assert.Equal(expected, actual);

                mockProjectController.VerifyGet(x => x.CurrentIndex, Times.Exactly(2));
                mockProjectController.VerifyGet(x => x.CurrentRaw, Times.Once);
                mockProjectController.VerifySet(x => x.CurrentCompletion = true, Times.Exactly(2));

                mockProjectController.Verify(x => x.DecrementCurrentLine(), Times.Once);
            }


            [Theory(DisplayName = "Auto Project Controller: Insert Line")]
            [AutoData]
            [InlineAutoData(null, null)]
            public void InsertLine(int? index, string raw)
            {
                // Arrange

                // Act
                sut.InsertLine(index, raw);

                //Assert
                mockProjectController.Verify(x => x.InsertLine(It.Is<int?>(y => y == index), It.Is<string>(y => y == raw)), Times.Once);
            }

            [Theory(DisplayName = "Auto Project Controller: Remove Line")]
            [AutoData]
            public void RemoveLine(int? index)
            {
                // Arrange

                // Act
                sut.RemoveLine(index);

                //Assert
                mockProjectController.Verify(x => x.RemoveLine(It.Is<int?>(y => y == index)), Times.Once);
            }
            #endregion

            #region Queries
            [Theory(DisplayName = "Auto Project Controller: Get Project Data")]
            [AutoMoqData]
            public void GetProjectData(IProjectDataType projectData)
            {
                // Arrange
                var expected = projectData;
                mockProjectController.Setup(x => x.GetProjectData()).Returns(projectData);

                // Act
                var actual = sut.GetProjectData();

                // Assert
                Assert.Equal(expected, actual);
                mockProjectController.Verify(x => x.GetProjectData(), Times.Once);
            }
            #endregion
        }
    }
}
