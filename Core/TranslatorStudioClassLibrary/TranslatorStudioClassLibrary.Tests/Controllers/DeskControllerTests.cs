using AutoFixture;
using AutoFixture.Xunit2;
using Moq;
using System;
using System.Linq;
using TranslatorStudioClassLibrary.Contracts.Controllers;
using TranslatorStudioClassLibrary.Contracts.Enums;
using TranslatorStudioClassLibrary.Contracts.Types;
using TranslatorStudioClassLibrary.Controllers;
using TranslatorStudioClassLibrary.Tests.TestSetup;
using TranslatorStudioClassLibrary.Tests.TestSetup.Builders;
using TranslatorStudioClassLibrary.Types;
using Xunit;

namespace TranslatorStudioClassLibrary.Tests.Controllers
{
    public class DeskControllerTests
    {
        [Trait("Desk Controller", "Constructor Test")]
        [Trait("Category", "Unit")]
        public class Constructor
        {
            [Theory(DisplayName = "Desk Controller: Default Constructor")]
            [AutoMoqData]
            public void DefaultConstructor(
                Mock<ITranslationController> mockTranslationController,
                Mock<IProjectController> mockProjectController
                )
            {
                // Arrange
                var translationController = mockTranslationController.Object;
                var projectController = mockProjectController.Object;

                // Act
                var actual = new DeskController(translationController, projectController);

                // Assert
                Assert.IsType<DeskController>(actual);
                Assert.IsAssignableFrom<ITranslationController>(actual);
                Assert.IsAssignableFrom<IProjectController>(actual);
            }

            [Trait("Exception Test", "Argument Null Exception")]
            [Theory(DisplayName = "Desk Controller: Throws Exception with Illegal Parameters")]
            [AutoMoqData]
            public void IllegalParams_Throws_Exception(
                ITranslationController translationController,
                IProjectController projectController
                )
            {
                // Arrange
                ITranslationController invalidTranslationController = null;
                IProjectController invalidProjectController = null;

                // Act, Assert
                Assert.Throws<ArgumentNullException>("translationController", () => new DeskController(invalidTranslationController, projectController));
                Assert.Throws<ArgumentNullException>("defaultProjectController", () => new DeskController(translationController, invalidProjectController));
            }
        }

        [Trait("Desk Controller", "Property Test")]
        [Trait("Category", "Unit")]
        public class Property
        {
            private readonly Mock<ITranslationController> mockTranslationController;
            private readonly Mock<IProjectController> mockProjectController;
            private readonly DeskController sut;

            private readonly IFixture fixture;

            public Property()
            {
                fixture = new FixtureBuilder().Build();

                mockTranslationController = fixture.Create<Mock<ITranslationController>>();
                mockTranslationController.Setup(x => x.AutoTranslationMode).Returns(false);
                mockTranslationController.Setup(x => x.TranslationMode).Returns(TranslationModeEnum.Default);

                mockProjectController = fixture.Create<Mock<IProjectController>>();

                sut = new DeskController(mockTranslationController.Object, mockProjectController.Object);
            }

            #region Translation Controller
            #region Translation Mode
            [Theory(DisplayName = "Desk Controller: Get Translation Mode")]
            [AutoData]
            public void GetTranslationMode(TranslationModeEnum translationMode)
            {
                // Arrange
                var expected = translationMode;

                mockTranslationController.SetupGet(x => x.TranslationMode).Returns(translationMode);

                // Act
                var actual = sut.TranslationMode;

                // Assert
                Assert.Equal(expected, actual);

                mockTranslationController.VerifyGet(x => x.TranslationMode, Times.Exactly(2));
            }
            #endregion

            #region Auto Translation Mode
            [Theory(DisplayName = "Desk Controller: Get Auto Translation Mode")]
            [AutoData]
            public void GetAutoTranslationMode(bool autoTranslationMode)
            {
                // Arrange
                var expected = autoTranslationMode;

                mockTranslationController.SetupGet(x => x.AutoTranslationMode).Returns(autoTranslationMode);

                // Act
                var actual = sut.AutoTranslationMode;

                // Assert
                Assert.Equal(expected, actual);

                mockTranslationController.VerifyGet(x => x.AutoTranslationMode, Times.Exactly(2));
            }
            #endregion
            #endregion

            #region Project Controller
            #region Current Line
            [Theory(DisplayName = "Desk Controller: Get Current Line")]
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
            [Theory(DisplayName = "Desk Controller: Get Current Raw")]
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

            [Theory(DisplayName = "Desk Controller: Set Current Raw")]
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
            [Theory(DisplayName = "Desk Controller: Get Current Translation")]
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

            [Theory(DisplayName = "Desk Controller: Set Current Translation")]
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
            [Theory(DisplayName = "Desk Controller: Get Current Comment")]
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

            [Theory(DisplayName = "Desk Controller: Set Current Comment")]
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
            [Theory(DisplayName = "Desk Controller: Get Current Completion")]
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

            [Theory(DisplayName = "Desk Controller: Set Current Completion")]
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
            [Theory(DisplayName = "Desk Controller: Get Current Marked")]
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

            [Theory(DisplayName = "Desk Controller: Set Current Marked")]
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
            [Theory(DisplayName = "Desk Controller: Get Current Index")]
            [AutoData]
            public void GetCurrentIndex(int index)
            {
                // Arrange
                var expected = index;
                mockProjectController.Setup(x => x.CurrentIndex).Returns(index);

                // Act
                var actual = sut.CurrentIndex;

                // Assert
                Assert.Equal(expected, actual);
                mockProjectController.VerifyGet(x => x.CurrentIndex, Times.Once);
            }

            [Theory(DisplayName = "Desk Controller: Set Current Index")]
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
            [Theory(DisplayName = "Desk Controller: Get Max Index")]
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
            [Theory(DisplayName = "Desk Controller: Get Number Of Lines")]
            [AutoData]
            public void GetNumberOfLines(int numberOfLines)
            {
                // Arrange
                var expected = numberOfLines;

                mockProjectController.Setup(x => x.NumberOfLines).Returns(numberOfLines);

                // Act
                var actual = sut.NumberOfLines;

                // Assert
                Assert.Equal(expected, actual);
                mockProjectController.Verify(x => x.NumberOfLines, Times.Once);
            }

            [Theory(DisplayName = "Desk Controller: Get Number Of Lines in Filter Mode")]
            [InlineAutoData(TranslationModeEnum.Complete)]
            [InlineAutoData(TranslationModeEnum.Incomplete)]
            [InlineAutoData(TranslationModeEnum.Marked)]
            public void GetNumberOfLinesFilterMode(TranslationModeEnum translationMode, int numberOfFilteredLines, int numberOfFilteredOutLines)
            {
                // Arrange
                #region Mock Project Data
                var completeValue = translationMode == TranslationModeEnum.Complete;

                var markedValue = translationMode == TranslationModeEnum.Marked;

                var filteredProjectLines = fixture.Build<ProjectLine>()
                                                    .With(x => x.Completed, completeValue)
                                                    .With(x => x.Marked, markedValue)
                                                    .CreateMany(numberOfFilteredLines);

                var filteredOutProjectLines = fixture.Build<ProjectLine>()
                                                    .With(x => x.Completed, !completeValue)
                                                    .With(x => x.Marked, !markedValue)
                                                    .CreateMany(numberOfFilteredOutLines);

                var projectLines = filteredProjectLines.ToList<IProjectLineType>();
                projectLines.AddRange(filteredOutProjectLines);

                var projectData = fixture.Build<ProjectData>()
                                        .With(x => x.ProjectLines, projectLines)
                                        .Create();
                #endregion

                mockProjectController.Setup(x => x.GetProjectData()).Returns(projectData);

                var expected = numberOfFilteredLines;

                #region Turn On Filter Mode
                mockTranslationController.Setup(x => x.TranslationMode).Returns(translationMode);
                sut.ChangeTranslationMode(translationMode);
                #endregion

                // Act
                var actual = sut.NumberOfLines;

                // Assert
                Assert.Equal(expected, actual);

                mockProjectController.Verify(x => x.GetProjectData(), Times.Exactly(2));
            }

            [Theory(DisplayName = "Desk Controller: Get Number Of Lines In Auto Mode")]
            [AutoData]
            public void GetNumberOfLinesAutoMode(int numberOfEmptyLines, int numberOfNonEmptyLines)
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

                #region Turn On Auto Mode
                mockTranslationController.Setup(x => x.AutoTranslationMode).Returns(true);
                sut.ToggleAutoMode(true);
                #endregion

                // Act
                var actual = sut.NumberOfLines;

                // Assert
                Assert.Equal(expected, actual);

                mockProjectController.Verify(x => x.GetProjectData(), Times.Exactly(3));
                mockTranslationController.VerifyGet(x => x.AutoTranslationMode, Times.Exactly(2));
            }

            [Theory(DisplayName = "Desk Controller: Get Number Of Lines in Auto Filter Mode")]
            [InlineAutoData(TranslationModeEnum.Complete)]
            [InlineAutoData(TranslationModeEnum.Incomplete)]
            [InlineAutoData(TranslationModeEnum.Marked)]
            public void GetNumberOfLinesAutoFilterMode(TranslationModeEnum translationMode, int numberOfFilteredLines, int numberOfFilteredOutLines)
            {
                // Arrange
                #region Mock Project Data
                var completeValue = translationMode == TranslationModeEnum.Complete;

                var markedValue = translationMode == TranslationModeEnum.Marked;

                var filteredProjectLines = fixture.Build<ProjectLine>()
                                                    .With(x => x.Completed, completeValue)
                                                    .With(x => x.Marked, markedValue)
                                                    .CreateMany(numberOfFilteredLines);

                var filteredOutProjectLines = fixture.Build<ProjectLine>()
                                                    .Without(x => x.Raw)
                                                    .CreateMany(numberOfFilteredOutLines);

                var projectLines = filteredProjectLines.ToList<IProjectLineType>();
                projectLines.AddRange(filteredOutProjectLines);

                var projectData = fixture.Build<ProjectData>()
                                        .With(x => x.ProjectLines, projectLines)
                                        .Create();
                #endregion

                mockProjectController.Setup(x => x.GetProjectData()).Returns(projectData);

                var expected = numberOfFilteredLines;

                #region Turn On Filter Mode
                mockTranslationController.Setup(x => x.TranslationMode).Returns(translationMode);
                sut.ChangeTranslationMode(translationMode);
                #endregion

                #region Turn On Auto Mode
                mockTranslationController.Setup(x => x.AutoTranslationMode).Returns(true);
                sut.ToggleAutoMode(true);
                #endregion

                // Act
                var actual = sut.NumberOfLines;

                // Assert
                Assert.Equal(expected, actual);

                mockProjectController.Verify(x => x.GetProjectData(), Times.Exactly(4));
            }
            #endregion

            #region Number Of Completed Lines
            [Theory(DisplayName = "Desk Controller: Get Number Of Completed Lines")]
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
            #endregion
        }

        [Trait("Desk Controller", "Method Test")]
        [Trait("Category", "Unit")]
        public class Method
        {
            private readonly Mock<ITranslationController> mockTranslationController;
            private readonly Mock<IProjectController> mockProjectController;
            private readonly DeskController sut;

            private readonly IFixture fixture;

            public Method()
            {
                fixture = new FixtureBuilder().Build();

                mockTranslationController = fixture.Create<Mock<ITranslationController>>();
                mockTranslationController.Setup(x => x.AutoTranslationMode).Returns(false);
                mockTranslationController.Setup(x => x.TranslationMode).Returns(TranslationModeEnum.Default);

                mockProjectController = fixture.Create<Mock<IProjectController>>();

                sut = new DeskController(mockTranslationController.Object, mockProjectController.Object);
            }

            #region Translation Controller
            [Theory(DisplayName = "Desk Controller: Change Translation Mode")]
            [AutoData]
            public void ChangeTranslationMode(TranslationModeEnum newTranslationMode)
            {
                // Arrange

                // Act
                sut.ChangeTranslationMode(newTranslationMode);

                // Assert
                mockTranslationController.Verify(x => x.ChangeTranslationMode(It.Is<TranslationModeEnum>(y => y == newTranslationMode)), Times.Once);
            }

            [Theory(DisplayName = "Desk Controller: Toggle Auto Mode")]
            [AutoData]
            public void ToggleAutoMode(bool autoModeOn)
            {
                // Arrange
                
                // Act
                sut.ToggleAutoMode(autoModeOn);

                // Assert
                mockTranslationController.Verify(x => x.ToggleAutoMode(It.Is<bool>(y => y == autoModeOn)), Times.Once);
            }
            #endregion

            #region Project Controller
            #region Commands
            [Fact(DisplayName = "Desk Controller: Increment Current Line")]
            public void IncrementCurrentLine()
            {
                // Arrange

                // Act
                sut.IncrementCurrentLine();

                // Assert
                mockProjectController.Verify(x => x.IncrementCurrentLine(), Times.Once);
            }

            [Fact(DisplayName = "Desk Controller: Decrement Current Line")]
            public void DecrementCurrentLine()
            {
                // Arrange
                
                // Act
                sut.DecrementCurrentLine();
                
                // Assert
                mockProjectController.Verify(x => x.DecrementCurrentLine(), Times.Once);
            }


            [Theory(DisplayName = "Desk Controller: Insert Line")]
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

            [Theory(DisplayName = "Desk Controller: Remove Line")]
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
            [Theory(DisplayName = "Desk Controller: Get Project Data")]
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
                mockProjectController.Verify(x => x.GetProjectData(), Times.Exactly(2));
            }
            #endregion
            #endregion
        }
    }
}