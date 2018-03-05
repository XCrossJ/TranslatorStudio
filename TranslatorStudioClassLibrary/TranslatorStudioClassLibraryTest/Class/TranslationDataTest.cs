using System.Linq;
using System.Collections.Generic;
using Moq;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Exception;
using Xunit;
using System;

namespace TranslatorStudioClassLibraryTest.Class
{
    /// <summary>
    /// Contains tests to run against Translation Data class.
    /// </summary>
    [Collection("Translation Data Test")]
    public class TranslationDataTest
    {
        /// <summary>
        /// Contains tests to run again Translation Data properties.
        /// </summary>
        [Trait("Category", "Unit")]
        [Trait("Class", "Translation Data")]
        public class Properties
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
            /// Mock of Completed lines.
            /// </summary>
            private readonly List<bool> mockCompletedLines;

            /// <summary>
            /// Mock of Sub Translation Data Factory.
            /// </summary>
            private readonly Mock<ISubTranslationDataFactory> mockSubTranslationDataFactory;
            /// <summary>
            /// Translation Data under test.
            /// </summary>
            private ITranslationData translationData;

            /// <summary>
            /// Constructor for test setup.
            /// </summary>
            public Properties()
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

                mockProjectData.SetupAllProperties();
                mockProjectData.Object.ProjectName = mockProjectName;
                mockProjectData.Object.RawLines = mockRawLines;
                mockProjectData.Object.TranslatedLines = mockTranslatedLines;
                mockProjectData.Object.MarkedLines = mockMarkedLines;
                mockProjectData.Object.CompletedLines = mockCompletedLines;

                mockSubTranslationDataFactory = new Mock<ISubTranslationDataFactory>();

                translationData = new TranslationData(mockProjectData.Object, mockSubTranslationDataFactory.Object);
            }

            #region Properties Tests

            #region Project Data Tests

            /// <summary>
            /// Given that Translation Data is successfully created, Default Translation Mode returns translation mode status of the translation project.
            /// </summary>
            [Fact]
            public void TranslationData_DefaultTranslationMode_Test()
            {
                //Arrange
                var expected = true;

                //Act
                var actual = translationData.DefaultTranslationMode;

                //Assert
                Assert.IsType<bool>(actual);
                Assert.Equal(expected, actual);
            }

            /// <summary>
            /// Given that Translation Data is successfully created, Auto Translation Mode returns auto mode status of the translation project.
            /// </summary>
            [Fact]
            public void TranslationData_AutoTranslationMode_Test()
            {
                //Arrange
                var expected = false;

                //Act
                var actual = translationData.AutoTranslationMode;

                //Assert
                Assert.IsType<bool>(actual);
                Assert.Equal(expected, actual);
            }

            /// <summary>
            /// Given that Translation Data is successfully created, Data Changed should return true when property is changed.
            /// </summary>
            [Fact]
            public void TranslationData_DataChanged_Test()
            {
                //Arrange
                Assert.False(translationData.DataChanged);

                var expected = true;
                var expectedValue = "New Value";

                //Act
                translationData.CurrentRaw = expectedValue;
                var actual = translationData.DataChanged;
                var actualValue = translationData.CurrentRaw;

                //Assert
                Assert.Equal("New Value", translationData.CurrentRaw);
                Assert.IsType<bool>(actual);
                Assert.Equal(expected, actual);
            }

            /// <summary>
            /// Given that Translation Data is successfully created, Project Name returns the name of the translation project.
            /// </summary>
            [Fact]
            public void TranslationData_ProjectName_Test()
            {
                //Arrange
                var expected = mockProjectName;

                //Act
                var actual = translationData.ProjectName;

                //Assert
                mockProjectData.Verify(
                        x => x.ProjectName,
                    Times.Once);

                Assert.IsType<string>(actual);
                Assert.Equal(expected, actual);
            }

            /// <summary>
            /// Given that Translation Data is successfully created, Raw Lines returns the raw lines in the translation project.
            /// </summary>
            [Fact]
            public void TranslationData_RawLines_Test()
            {
                //Arrange
                var expected = mockRawLines;

                //Act
                var actual = translationData.RawLines;

                //Assert
                mockProjectData.Verify(
                        x => x.RawLines,
                    Times.Once);

                Assert.IsType<List<string>>(actual);
                Assert.Equal(expected, actual);
            }

            /// <summary>
            /// Given that Translation Data is successfully created, Translated lines returns the translated lines in the translation project.
            /// </summary>
            [Fact]
            public void TranslationData_TranslatedLines_Test()
            {
                //Arrange
                var expected = mockTranslatedLines;

                //Act
                var actual = translationData.TranslatedLines;

                //Assert
                mockProjectData.Verify(
                        x => x.TranslatedLines,
                    Times.Once);

                Assert.IsType<List<string>>(actual);
                Assert.Equal(expected, actual);
            }

            /// <summary>
            /// Given that Translation Data is successfully created, Completed Lines returns the line completion status in the translation project.
            /// </summary>
            [Fact]
            public void TranslationData_CompletedLines_Test()
            {
                //Arrange
                var expected = mockCompletedLines;

                //Act
                var actual = translationData.CompletedLines;

                //Assert
                mockProjectData.Verify(
                        x => x.CompletedLines,
                    Times.Once);

                Assert.IsType<List<bool>>(actual);
                Assert.Equal(expected, actual);
            }

            /// <summary>
            /// Given that Translation Data is successfully created, Marked Lines returns the line marked status in the translation project.
            /// </summary>
            [Fact]
            public void TranslationData_MarkedLines_Test()
            {
                //Arrange
                var expected = mockMarkedLines;

                //Act
                var actual = translationData.MarkedLines;

                //Assert
                mockProjectData.Verify(
                        x => x.MarkedLines,
                    Times.Once);

                Assert.IsType<List<bool>>(actual);
                Assert.Equal(expected, actual);
            }

            #endregion

            #region Project Controls Tests

            /// <summary>
            /// Given that Current Index is assigned a valid integer, Current Raw returns raw line at index from Raw Lines.
            /// </summary>
            /// <param name="currentIndex">A valid integer to be assigned to current index.</param>
            [Theory]
            [InlineData(1)]
            public void TranslationData_CurrentRaw_Test(int currentIndex)
            {
                //Arrange
                translationData.CurrentIndex = currentIndex;

                var expected = mockRawLines[currentIndex];

                //Act
                var actual = translationData.CurrentRaw;

                //Assert
                mockProjectData.Verify(
                        x => x.RawLines,
                    Times.Once);

                Assert.IsType<string>(actual);
                Assert.Equal(expected, actual);
            }

            /// <summary>
            /// Given that Current Index is assigned a valid integer, Current Translation returns translated line at index from Translated Lines
            /// </summary>
            /// <param name="currentIndex">A valid integer to be assigned to current index.</param>
            [Theory]
            [InlineData(1)]
            public void TranslationData_CurrentTranslation_Test(int currentIndex)
            {
                //Arrange
                translationData.CurrentIndex = currentIndex;

                var expected = mockTranslatedLines[currentIndex];

                //Act
                var actual = translationData.CurrentTranslation;

                //Assert
                mockProjectData.Verify(
                        x => x.TranslatedLines,
                    Times.Once);

                Assert.IsType<string>(actual);
                Assert.Equal(expected, actual);
            }

            /// <summary>
            /// Given that Current Index is assigned a valid integer, Current Completion returns line completion status at index from Completed Lines
            /// </summary>
            /// <param name="currentIndex">A valid integer to be assigned to current index.</param>
            [Theory]
            [InlineData(1)]
            public void TranslationData_CurrentCompletion_Test(int currentIndex)
            {
                //Arrange
                translationData.CurrentIndex = currentIndex;

                var expected = mockCompletedLines[currentIndex];

                //Act
                var actual = translationData.CurrentCompletion;

                //Assert
                mockProjectData.Verify(
                    x => x.CompletedLines,
                    Times.Once);

                Assert.IsType<bool>(actual);
                Assert.Equal(expected, actual);
            }

            /// <summary>
            /// Given that Current Index is assigned a valid integer, Current Marked returns line marked status at index from Marked Lines
            /// </summary>
            /// <param name="currentIndex">A valid integer to be assigned to current index.</param>
            [Theory]
            [InlineData(1)]
            public void TranslationData_CurrentMarked_Test(int currentIndex)
            {
                //Arrange
                translationData.CurrentIndex = currentIndex;

                var expected = mockMarkedLines[currentIndex];

                //Act
                var actual = translationData.CurrentMarked;

                //Assert
                mockProjectData.Verify(
                    x => x.MarkedLines,
                    Times.Once);

                Assert.IsType<bool>(actual);
                Assert.Equal(expected, actual);
            }

            /// <summary>
            /// Given that Translation Data is successfully created, Max Index returns maximum possible index of translation project.
            /// </summary>
            [Fact]
            public void TranslationData_MaxIndex_Test()
            {
                //Arrange
                var expected = mockRawLines.Count - 1;

                //Act
                var actual = translationData.MaxIndex;

                //Assert
                mockProjectData.Verify(
                        x => x.RawLines,
                    Times.Once);

                Assert.IsType<int>(actual);
                Assert.Equal(expected, actual);
            }

            /// <summary>
            /// Given that Translation Data is successfully created, Number Of Lines returns the total number of lines in the translation project.
            /// </summary>
            [Fact]
            public void TranslationData_NumberOfLines_Test()
            {
                //Arrange
                var expected = mockRawLines.Count;

                //Act
                var actual = translationData.NumberOfLines;

                //Assert
                mockProjectData.Verify(
                    x => x.RawLines,
                    Times.Once);

                Assert.IsType<int>(actual);
                Assert.Equal(expected, actual);
            }

            /// <summary>
            /// Given that Translation Data is successfully created, Number of Completed Lines returns number of lines marked as completed in the translation project.
            /// </summary>
            [Fact]
            public void TranslationData_NumberOfCompletedLines_Test()
            {
                //Arrange
                var expected = mockCompletedLines.Where(c => c).Count();

                //Act
                var actual = translationData.NumberOfCompletedLines;

                //Assert
                mockProjectData.Verify(
                        x => x.CompletedLines,
                    Times.Once);

                Assert.IsType<int>(actual);
                Assert.Equal(expected, actual);
            }

            #endregion

            #endregion
        }

        /// <summary>
        /// Contains tests to run against Translation Data constructors.
        /// </summary>
        [Trait("Category", "Unit")]
        [Trait("Class", "Translation Data")]
        public class Constructors
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
            /// Mock of Completed lines.
            /// </summary>
            private readonly List<bool> mockCompletedLines;

            /// <summary>
            /// Mock of Sub Translation Data Factory.
            /// </summary>
            private readonly Mock<ISubTranslationDataFactory> mockSubTranslationDataFactory;

            /// <summary>
            /// Constructor for test setup.
            /// </summary>
            public Constructors()
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

                mockProjectData.SetupAllProperties();
                mockProjectData.Object.ProjectName = mockProjectName;
                mockProjectData.Object.RawLines = mockRawLines;
                mockProjectData.Object.TranslatedLines = mockTranslatedLines;
                mockProjectData.Object.MarkedLines = mockMarkedLines;
                mockProjectData.Object.CompletedLines = mockCompletedLines;

                mockSubTranslationDataFactory = new Mock<ISubTranslationDataFactory>();
            }

            #region Constructor Tests

            /// <summary>
            /// Given that Translation Data is invoked, Default Constructor returns valid Translation Data.
            /// </summary>
            [Fact]
            public void TranslationData_DefaultConstructor_Test()
            {
                //Arrange
                var expected = new TranslationData(mockSubTranslationDataFactory.Object);

                //Act
                var actual = new TranslationData(mockSubTranslationDataFactory.Object);

                //Assert
                Assert.IsType<TranslationData>(actual);
                Assert.IsAssignableFrom<ITranslationData>(actual);
                Assert.NotStrictEqual(expected, actual);
            }

            /// <summary>
            /// Given that Sub Translation Data Factory is null, Default Constructor throws Argument Null Excpetion.
            /// </summary>
            [Fact]
            [Trait("Category", "Exception")]
            [Trait("Exception", "ArgumentNullException")]
            public void TranslationData_DefaultConstructor_NullSubTranslationDataFactory_Test()
            {
                //Arrange

                //Act, Assert
                Assert.Throws<ArgumentNullException>("subTranslationDataFactory", () => new TranslationData(null));
            }

            /// <summary>
            /// Given that Project Data is valid, Project Data Constructor returns valid Translation Data.
            /// </summary>
            [Fact]
            public void TranslationData_ProjectDataConstructor_Test()
            {
                //Arrange
                var projectData = mockProjectData.Object;
                var subFactory = mockSubTranslationDataFactory.Object;

                var expected = new TranslationData(projectData, subFactory);

                //Act
                var actual = new TranslationData(projectData, subFactory);

                //Assert
                Assert.IsType<TranslationData>(actual);
                Assert.IsAssignableFrom<ITranslationData>(actual);
                Assert.NotStrictEqual(expected, actual);
            }

            /// <summary>
            /// Given that Project Data is null, Project Data Constructor throws Argument Null Excpetion.
            /// </summary>
            [Fact]
            [Trait("Category", "Exception")]
            [Trait("Exception", "ArgumentNullException")]
            public void TranslationData_ProjectDataConstructor_NullProjectData_Test()
            {
                //Arrange
                var subFactory = mockSubTranslationDataFactory.Object;

                //Act, Assert
                Assert.Throws<ArgumentNullException>("projectData", () => new TranslationData(null, subFactory));
            }

            /// <summary>
            /// Given that Sub Translation Data Factory is null, Project Data Constructor throws Argument Null Excpetion.
            /// </summary>
            [Fact]
            [Trait("Category", "Exception")]
            [Trait("Exception", "ArgumentNullException")]
            public void TranslationData_ProjectDataConstructor_NullSubTranslationDataFactory_Test()
            {
                //Arrange
                var projectData = mockProjectData.Object;

                //Act, Assert
                Assert.Throws<ArgumentNullException>("subTranslationDataFactory", () => new TranslationData(projectData, null));
            }
            #endregion
        }

        /// <summary>
        /// Contains tests to run against Translation Data methods.
        /// </summary>
        [Trait("Category", "Unit")]
        [Trait("Class", "Translation Data")]
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
            /// Mock of Completed lines.
            /// </summary>
            private readonly List<bool> mockCompletedLines;

            /// <summary>
            /// Mock of Sub Translation Data Factory.
            /// </summary>
            private readonly Mock<ISubTranslationDataFactory> mockSubTranslationDataFactory;
            /// <summary>
            /// Mock of Sub Translation Data.
            /// </summary>
            private readonly Mock<ISubTranslationData> mockSubData;
            /// <summary>
            /// Translation Data under test.
            /// </summary>
            private ITranslationData translationData;

            /// <summary>
            /// Constructor for test setup.
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

                mockProjectData.SetupAllProperties();
                mockProjectData.Object.ProjectName = mockProjectName;
                mockProjectData.Object.RawLines = mockRawLines;
                mockProjectData.Object.TranslatedLines = mockTranslatedLines;
                mockProjectData.Object.MarkedLines = mockMarkedLines;
                mockProjectData.Object.CompletedLines = mockCompletedLines;

                mockSubTranslationDataFactory = new Mock<ISubTranslationDataFactory>();

                mockSubTranslationDataFactory.Setup(
                        x => x.GetSubData(It.IsAny<List<bool>>()))
                    .Returns((ISubTranslationData)null);

                mockSubData = new Mock<ISubTranslationData>();
                mockSubData.SetupAllProperties();

                translationData = new TranslationData(mockProjectData.Object, mockSubTranslationDataFactory.Object);
            }

            #region Methods Tests

            /// <summary>
            /// Given that Current Index is assigned a valid integer below Max Index, Increment Current Line increments the current index.
            /// </summary>
            /// <param name="currentIndex">A valid integer to be assigned to current index.</param>
            [Theory]
            [InlineData(5)]
            public void TranslationData_IncrementCurrentLine_Test(int currentIndex)
            {
                //Arrange
                translationData.CurrentIndex = currentIndex;

                var expectedIndex = ++currentIndex;

                //Act
                translationData.IncrementCurrentLine();
                var actualIndex = translationData.CurrentIndex;

                //Assert
                mockProjectData.Verify(
                        x => x.RawLines,
                    Times.Once);

                Assert.IsType<int>(actualIndex);
                Assert.Equal(expectedIndex, actualIndex);
            }

            /// <summary>
            /// Given that Current Index is assigned a valid integer above Min Index, Decrement Current Line decrements the current index.
            /// </summary>
            /// <param name="currentIndex">A valid integer to be assigned to current index.</param>
            [Theory]
            [InlineData(5)]
            public void TranslationData_DecrementCurrentLine_Test(int currentIndex)
            {
                //Arrange
                translationData.CurrentIndex = currentIndex;

                var expectedIndex = --currentIndex;

                //Act
                translationData.DecrementCurrentLine();
                var actualIndex = translationData.CurrentIndex;

                //Assert
                Assert.IsType<int>(actualIndex);
                Assert.Equal(expectedIndex, actualIndex);
            }

            /// <summary>
            /// Given that index passed is a valid integer, Insert Line will insert line into translation project at specified index.
            /// </summary>
            /// <param name="index">A valid integer used to insert line.</param>
            [Theory]
            [InlineData(5)]
            public void TranslationData_InsertLine_Test(int? index)
            {
                //Arrange
                int insertIndex = index ?? translationData.NumberOfLines; 
                string insertRawValue = "Inserted Raw Line";
                string expectedRawValue = insertRawValue ?? "";


                var expectedRawLines = mockRawLines.ToList();
                var expectedTranslatedLines = mockTranslatedLines.ToList();
                var expectedCompletedLines = mockCompletedLines.ToList();
                var expectedMarkedLines = mockMarkedLines.ToList();

                expectedRawLines.Insert(insertIndex, insertRawValue);
                expectedTranslatedLines.Insert(insertIndex, "");
                expectedCompletedLines.Insert(insertIndex, false);
                expectedMarkedLines.Insert(insertIndex, false);

                //Act
                translationData.InsertLine(insertIndex, insertRawValue);

                //Assert
                mockProjectData.Verify(
                        x => x.RawLines,
                    Times.AtLeastOnce);
                mockProjectData.Verify(
                        x => x.TranslatedLines,
                    Times.Once);
                mockProjectData.Verify(
                        x => x.CompletedLines,
                    Times.Once);
                mockProjectData.Verify(
                        x => x.MarkedLines,
                    Times.Once);

                var actualRawValue = translationData.RawLines[insertIndex];
                Assert.IsType<string>(actualRawValue);
                Assert.Equal(expectedRawValue,          actualRawValue);
            
                Assert.Equal(expectedRawLines,          translationData.RawLines);
                Assert.Equal(expectedTranslatedLines,   translationData.TranslatedLines);
                Assert.Equal(expectedCompletedLines,    translationData.CompletedLines);
                Assert.Equal(expectedMarkedLines,       translationData.MarkedLines);

            }

            /// <summary>
            /// Given that index passed is a null value, Insert Line will insert line into translation project at end.
            /// </summary>
            [Fact]
            public void TranslationData_InsertLine_With_Null_Values_Test()
            {
                //Arrange
                int? index = null;
                int insertIndex = index ?? translationData.NumberOfLines;
                string insertRawValue = null;
                string expectedRawValue = insertRawValue ?? "";


                var expectedRawLines = mockRawLines.ToList();
                var expectedTranslatedLines = mockTranslatedLines.ToList();
                var expectedCompletedLines = mockCompletedLines.ToList();
                var expectedMarkedLines = mockMarkedLines.ToList();

                expectedRawLines.Insert(insertIndex, expectedRawValue);
                expectedTranslatedLines.Insert(insertIndex, "");
                expectedCompletedLines.Insert(insertIndex, false);
                expectedMarkedLines.Insert(insertIndex, false);

                //Act
                translationData.InsertLine(insertIndex, insertRawValue);

                //Assert
                mockProjectData.Verify(
                        x => x.RawLines,
                    Times.AtLeastOnce);
                mockProjectData.Verify(
                        x => x.TranslatedLines,
                    Times.Once);
                mockProjectData.Verify(
                        x => x.CompletedLines,
                    Times.Once);
                mockProjectData.Verify(
                        x => x.MarkedLines,
                    Times.Once);

                Assert.Equal(expectedRawValue,          translationData.RawLines[insertIndex]);

                Assert.Equal(expectedRawLines,          translationData.RawLines);
                Assert.Equal(expectedTranslatedLines,   translationData.TranslatedLines);
                Assert.Equal(expectedCompletedLines,    translationData.CompletedLines);
                Assert.Equal(expectedMarkedLines,       translationData.MarkedLines);

            }

            /// <summary>
            /// Given that index passed is a valid integer, Remove Line will remove line from translation project at specified index.
            /// </summary>
            /// <param name="index">A valid integer used to specify line to remove.</param>
            [Theory]
            [InlineData(5)]
            public void TranslationData_RemoveLine_Test(int? index)
            {
                //Arrange
                int removeIndex = index ?? translationData.MaxIndex;

                var expectedRawLines = mockRawLines.ToList();
                var expectedTranslatedLines = mockTranslatedLines.ToList();
                var expectedCompletedLines = mockCompletedLines.ToList();
                var expectedMarkedLines = mockMarkedLines.ToList();

                expectedRawLines.RemoveAt(removeIndex);
                expectedTranslatedLines.RemoveAt(removeIndex);
                expectedCompletedLines.RemoveAt(removeIndex);
                expectedMarkedLines.RemoveAt(removeIndex);

                //Act
                translationData.RemoveLine(removeIndex);

                //Assert
                mockProjectData.Verify(
                        x => x.RawLines,
                    Times.AtLeastOnce);
                mockProjectData.Verify(
                        x => x.TranslatedLines,
                    Times.Once);
                mockProjectData.Verify(
                        x => x.CompletedLines,
                    Times.Once);
                mockProjectData.Verify(
                        x => x.MarkedLines,
                    Times.Once);

                Assert.Equal(expectedRawLines,          translationData.RawLines);
                Assert.Equal(expectedTranslatedLines,   translationData.TranslatedLines);
                Assert.Equal(expectedCompletedLines,    translationData.CompletedLines);
                Assert.Equal(expectedMarkedLines,       translationData.MarkedLines);

            }

            /// <summary>
            /// Given that index passed is a null value, Remove Line will remove line from translation project at end.
            /// </summary>
            [Fact]
            public void TranslationData_RemoveLine_With_Null_Values_Test()
            {
                //Arrange
                int? index = null;
                int removeIndex = index ?? translationData.MaxIndex;

                var expectedRawLines = mockRawLines.ToList();
                var expectedTranslatedLines = mockTranslatedLines.ToList();
                var expectedCompletedLines = mockCompletedLines.ToList();
                var expectedMarkedLines = mockMarkedLines.ToList();

                expectedRawLines.RemoveAt(removeIndex);
                expectedTranslatedLines.RemoveAt(removeIndex);
                expectedCompletedLines.RemoveAt(removeIndex);
                expectedMarkedLines.RemoveAt(removeIndex);

                //Act
                translationData.RemoveLine(removeIndex);

                //Assert
                mockProjectData.Verify(
                        x => x.RawLines,
                    Times.AtLeastOnce);
                mockProjectData.Verify(
                        x => x.TranslatedLines,
                    Times.Once);
                mockProjectData.Verify(
                        x => x.CompletedLines,
                    Times.Once);
                mockProjectData.Verify(
                        x => x.MarkedLines,
                    Times.Once);

                Assert.Equal(expectedRawLines,          translationData.RawLines);
                Assert.Equal(expectedTranslatedLines,   translationData.TranslatedLines);
                Assert.Equal(expectedCompletedLines,    translationData.CompletedLines);
                Assert.Equal(expectedMarkedLines,       translationData.MarkedLines);

            }

            /// <summary>
            /// Given that Current Index is equal to the Max Index, Increment Current Line will not increment index.
            /// </summary>
            [Fact]
            public void TranslationData_IncrementCurrentLine_At_Max_Index_Test()
            {
                //Arrange
                var expectedIndex = mockRawLines.Count() - 1;

                translationData.CurrentIndex = expectedIndex;
            
                //Act
                translationData.IncrementCurrentLine();
                var actualIndex = translationData.CurrentIndex;

                //Assert
                mockProjectData.Verify(
                        x => x.RawLines,
                    Times.Once);

                Assert.IsType<int>(actualIndex);
                Assert.Equal(expectedIndex, actualIndex);

                mockProjectData.Verify(
                        x => x.RawLines,
                    Times.Once());
            }

            /// <summary>
            /// Given that Current Index is equal to the Min Index, Decrement Current Line will not decrement index.
            /// </summary>
            [Fact]
            public void TranslationData_DecrementCurrentLine_At_Min_Index_Test()
            {
                //Arrange
                var expectedIndex = 0;

                translationData.CurrentIndex = expectedIndex;

                //Act
                translationData.DecrementCurrentLine();
                var actualIndex = translationData.CurrentIndex;

                //Assert
                Assert.IsType<int>(actualIndex);
                Assert.Equal(expectedIndex, actualIndex);
            }

            /// <summary>
            /// Given that Project Data returns a save string, Get Project Save String returns project data save string.
            /// </summary>
            [Fact]
            public void TranslationData_GetProjectSaveString_Test()
            {
                //Arrange
                var expectedSaveString = "Mock Save String";

                mockProjectData.Setup(
                        x => x.GetSaveString())
                    .Returns(expectedSaveString);

                //Act
                var actualSaveString = translationData.GetProjectSaveString();

                //Assert
                mockProjectData.Verify(
                        x => x.GetSaveString(),
                    Times.Once);

                Assert.IsType<string>(actualSaveString);
                Assert.Equal(expectedSaveString, actualSaveString);
            }

            /// <summary>
            /// Given that Translation Data is successfully created, Start Default Mode switches translation project to default translation mode.
            /// </summary>
            [Fact]
            public void TranslationData_StartDefaultMode()
            {
                //Arrange
                translationData.DefaultTranslationMode = false;

                var expected = true;

                var expectedNumberOfLines = translationData.NumberOfLines;

                //Act
                translationData.StartDefaultMode();
                var actual = translationData.DefaultTranslationMode;
                var actualNumberOfLines = translationData.NumberOfLines;

                //Assert
                Assert.IsType<bool>(actual);
                Assert.Equal(expected, actual);
                Assert.IsType<int>(actualNumberOfLines);
                Assert.Equal(expectedNumberOfLines, actualNumberOfLines);

                for (int i = 0; i < expectedNumberOfLines; i++)
                {
                    Assert.Equal(mockRawLines[i],           translationData.RawLines[i]);
                    Assert.Equal(mockTranslatedLines[i],    translationData.TranslatedLines[i]);
                    Assert.Equal(mockMarkedLines[i],        translationData.MarkedLines[i]);
                    Assert.Equal(mockCompletedLines[i],     translationData.CompletedLines[i]);
                }

                mockProjectData.Verify(
                        x => x.RawLines,
                    Times.Exactly(expectedNumberOfLines + 2));

                mockProjectData.Verify(
                        x => x.TranslatedLines,
                    Times.Exactly(expectedNumberOfLines));

                mockProjectData.Verify(
                        x => x.MarkedLines,
                    Times.Exactly(expectedNumberOfLines));

                mockProjectData.Verify(
                        x => x.CompletedLines,
                    Times.Exactly(expectedNumberOfLines));

            }

            /// <summary>
            /// Given that Translation Data is successfully created, Start Marked Only Mode switches translation project to marked only mode.
            /// </summary>
            [Fact]
            public void TranslationData_StartMarkedOnlyMode_Test()
            {
                //Arrange
                var indices = mockMarkedLines.Select((v, i) => new { v, i })
                    .Where(x => x.v == true)
                    .Select(x => x.i).ToList();

                mockSubData.Object.IndexReference = indices;
                mockSubData.Setup(
                        x => x.MaxIndex)
                    .Returns(mockSubData.Object.IndexReference.Count - 1);
                mockSubData.Setup(
                        x => x.NumberOfLines)
                    .Returns(mockSubData.Object.IndexReference.Count);

                var expectedNumberOfLines = indices.Count;
                var expectedMaxIndex = expectedNumberOfLines - 1;

                mockSubTranslationDataFactory.Setup(
                        x => x.GetSubData(It.IsAny<List<bool>>()))
                    .Returns(mockSubData.Object);

                //Act
                var actualNumberOfLines = translationData.StartMarkedOnlyMode();
                var actualMaxIndex = translationData.MaxIndex;
                var actualMode = translationData.DefaultTranslationMode;

                //Assert
                mockProjectData.Verify(
                        x => x.MarkedLines,
                    Times.Once);
                mockSubData.Verify(
                        x => x.NumberOfLines,
                    Times.Once);
                mockSubData.Verify(
                        x => x.MaxIndex,
                    Times.Once);

                Assert.IsType<int>(actualNumberOfLines);
                Assert.Equal(expectedNumberOfLines, actualNumberOfLines);
                Assert.IsType<int>(actualMaxIndex);
                Assert.Equal(expectedMaxIndex, actualMaxIndex);
                Assert.IsType<bool>(actualMode);
                Assert.False(actualMode);

                foreach (var index in indices)
                {
                    Assert.True(mockMarkedLines[index]);
                    Assert.True(translationData.MarkedLines[index]);

                    Assert.Equal(mockRawLines[index],           translationData.RawLines[index]);
                    Assert.Equal(mockTranslatedLines[index],    translationData.TranslatedLines[index]);
                    Assert.Equal(mockMarkedLines[index],        translationData.MarkedLines[index]);
                    Assert.Equal(mockCompletedLines[index],     translationData.CompletedLines[index]);
                }

                mockProjectData.Verify(
                        x => x.RawLines,
                    Times.Exactly(expectedNumberOfLines));

                mockProjectData.Verify(
                        x => x.TranslatedLines,
                    Times.Exactly(expectedNumberOfLines));

                mockProjectData.Verify(
                        x => x.MarkedLines,
                    Times.Exactly(expectedNumberOfLines * 2 + 1));

                mockProjectData.Verify(
                        x => x.CompletedLines,
                    Times.Exactly(expectedNumberOfLines));

            }

            /// <summary>
            /// Given that Translation Data is successfully created, Start Incomplete Only Mode switches translation project to incomplete only mode.
            /// </summary>
            [Fact]
            public void TranslationData_StartIncompleteOnlyMode_Test()
            {
                //Arrange
                var indices = mockCompletedLines.Select((v, i) => new { v, i })
                    .Where(x => x.v == false)
                    .Select(x => x.i).ToList();

                mockSubData.Object.IndexReference = indices;
                mockSubData.Setup(
                        x => x.MaxIndex)
                    .Returns(mockSubData.Object.IndexReference.Count - 1);
                mockSubData.Setup(
                        x => x.NumberOfLines)
                    .Returns(mockSubData.Object.IndexReference.Count);

                var expectedNumberOfLines = indices.Count();
                var expectedMaxIndex = expectedNumberOfLines - 1;

                mockSubTranslationDataFactory.Setup(
                        x => x.GetSubData(It.IsAny<List<bool>>()))
                    .Returns(mockSubData.Object);

                //Act
                var actualNumberOfLines = translationData.StartIncompleteOnlyMode();
                var actualMaxIndex = translationData.MaxIndex;
                var actualMode = translationData.DefaultTranslationMode;

                //Assert
                mockProjectData.Verify(
                        x => x.CompletedLines,
                    Times.Once);
                mockSubData.Verify(
                        x => x.NumberOfLines,
                    Times.Once);
                mockSubData.Verify(
                        x => x.MaxIndex,
                    Times.Once);

                Assert.IsType<int>(actualNumberOfLines);
                Assert.Equal(expectedNumberOfLines, actualNumberOfLines);
                Assert.IsType<int>(actualMaxIndex);
                Assert.Equal(expectedMaxIndex, actualMaxIndex);
                Assert.IsType<bool>(actualMode);
                Assert.False(actualMode);

                foreach (var index in indices)
                {
                    Assert.False(mockCompletedLines[index]);
                    Assert.False(translationData.CompletedLines[index]);

                    Assert.Equal(mockRawLines[index],           translationData.RawLines[index]);
                    Assert.Equal(mockTranslatedLines[index],    translationData.TranslatedLines[index]);
                    Assert.Equal(mockMarkedLines[index],        translationData.MarkedLines[index]);
                    Assert.Equal(mockCompletedLines[index],     translationData.CompletedLines[index]);
                }

                mockProjectData.Verify(
                        x => x.RawLines,
                    Times.Exactly(expectedNumberOfLines));

                mockProjectData.Verify(
                        x => x.TranslatedLines,
                    Times.Exactly(expectedNumberOfLines));

                mockProjectData.Verify(
                        x => x.MarkedLines,
                    Times.Exactly(expectedNumberOfLines));

                mockProjectData.Verify(
                        x => x.CompletedLines,
                    Times.Exactly(expectedNumberOfLines * 2 + 1));
            }

            /// <summary>
            /// Given that Translation Data is successfully created, Start Complete Only Mode switches translation project to complete only mode.
            /// </summary>
            [Fact]
            public void TranslationData_StartCompleteOnlyMode_Test()
            {
                //Arrange
                var indices = mockCompletedLines.Select((v, i) => new { v, i })
                    .Where(x => x.v == true)
                    .Select(x => x.i).ToList();

                mockSubData.Object.IndexReference = indices;
                mockSubData.Setup(
                        x => x.MaxIndex)
                    .Returns(mockSubData.Object.IndexReference.Count - 1);
                mockSubData.Setup(
                        x => x.NumberOfLines)
                    .Returns(mockSubData.Object.IndexReference.Count);

                var expectedNumberOfLines = indices.Count;
                var expectedMaxIndex = expectedNumberOfLines - 1;

                mockSubTranslationDataFactory.Setup(
                        x => x.GetSubData(It.IsAny<List<bool>>()))
                    .Returns(mockSubData.Object);

                //Act
                var actualNumberOfLines = translationData.StartCompleteOnlyMode();
                var actualMaxIndex = translationData.MaxIndex;
                var actualMode = translationData.DefaultTranslationMode;

                //Assert
                mockProjectData.Verify(
                        x => x.CompletedLines,
                    Times.Once);
                mockSubData.Verify(
                        x => x.NumberOfLines,
                    Times.Once);
                mockSubData.Verify(
                        x => x.MaxIndex,
                    Times.Once);

                Assert.IsType<int>(actualNumberOfLines);
                Assert.Equal(expectedNumberOfLines, actualNumberOfLines);
                Assert.IsType<int>(actualMaxIndex);
                Assert.Equal(expectedMaxIndex, actualMaxIndex);
                Assert.IsType<bool>(actualMode);
                Assert.False(actualMode);

                foreach (var index in indices)
                {
                    Assert.True(mockCompletedLines[index]);
                    Assert.True(translationData.CompletedLines[index]);

                    Assert.Equal(mockRawLines[index],           translationData.RawLines[index]);
                    Assert.Equal(mockTranslatedLines[index],    translationData.TranslatedLines[index]);
                    Assert.Equal(mockMarkedLines[index],        translationData.MarkedLines[index]);
                    Assert.Equal(mockCompletedLines[index],     translationData.CompletedLines[index]);
                }

                mockProjectData.Verify(
                        x => x.RawLines,
                    Times.Exactly(expectedNumberOfLines));

                mockProjectData.Verify(
                        x => x.TranslatedLines,
                    Times.Exactly(expectedNumberOfLines));

                mockProjectData.Verify(
                        x => x.MarkedLines,
                    Times.Exactly(expectedNumberOfLines));

                mockProjectData.Verify(
                        x => x.CompletedLines,
                    Times.Exactly(expectedNumberOfLines * 2 + 1));
            }

            /// <summary>
            /// Given that Translation Data is successfully created, Get Project Data returns the project data object.
            /// </summary>
            [Fact]
            public void TranslationData_GetProjectData_Test()
            {
                //Arrange
                var expectedProjectData = mockProjectData.Object;

                //Act
                var actualProjectData = translationData.GetProjectData();

                //Assert
                Assert.IsAssignableFrom<IProjectData>(actualProjectData);
                Assert.Equal(expectedProjectData, actualProjectData);
            }

            #endregion
        }

        /// <summary>
        /// Contains tests to run against Translation Data methods that exhibit different behaviour during auto mode.
        /// </summary>
        [Trait("Category", "Unit")]
        [Trait("Class", "Translation Data")]
        public class AutoMode
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
            /// Mock of Completed lines.
            /// </summary>
            private readonly List<bool> mockCompletedLines;

            /// <summary>
            /// Mock of Sub Translation Data Factory.
            /// </summary>
            private readonly Mock<ISubTranslationDataFactory> mockSubTranslationDataFactory;
            /// <summary>
            /// Mock of Sub Translation Data.
            /// </summary>
            private readonly Mock<ISubTranslationData> mockSubData;
            /// <summary>
            /// Translation Data under test.
            /// </summary>
            private ITranslationData translationData;

            /// <summary>
            /// Constructor for test setup.
            /// </summary>
            public AutoMode()
            {
                mockProjectName = "Mock Test Project Name";

                mockRawLines = new List<string>
                {
                    "Raw Line 1",
                    "",
                    "Raw Line 3",
                    "Raw Line 4",
                    "",
                    "",
                    "Raw Line 7",
                    "",
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

                mockProjectData.SetupAllProperties();
                mockProjectData.Object.ProjectName = mockProjectName;
                mockProjectData.Object.RawLines = mockRawLines;
                mockProjectData.Object.TranslatedLines = mockTranslatedLines;
                mockProjectData.Object.MarkedLines = mockMarkedLines;
                mockProjectData.Object.CompletedLines = mockCompletedLines;

                mockSubTranslationDataFactory = new Mock<ISubTranslationDataFactory>();

                mockSubTranslationDataFactory.Setup(
                        x => x.GetSubData(It.IsAny<List<bool>>()))
                    .Returns((ISubTranslationData)null);

                mockSubData = new Mock<ISubTranslationData>();
                mockSubData.SetupAllProperties();

                translationData = new TranslationData(mockProjectData.Object, mockSubTranslationDataFactory.Object);
            }

            #region Auto Mode Tests

            /// <summary>
            /// Given that Translation Data is successfully created, Start Auto Mode switches translation project to auto translation mode.
            /// </summary>
            [Fact]
            public void TranslationData_StartAutoMode_Test()
            {
                //Arrange
                var indices = mockRawLines.Select((v, i) => new { v, i })
                    .Where(x => x.v.Any())
                    .Select(x => x.i).ToList();

                mockSubData.Object.IndexReference = indices;
                mockSubData.Setup(
                        x => x.MaxIndex)
                    .Returns(mockSubData.Object.IndexReference.Count - 1);
                mockSubData.Setup(
                        x => x.NumberOfLines)
                    .Returns(mockSubData.Object.IndexReference.Count);

                var expectedNumberOfLines = indices.Count;
                var expectedMaxIndex = expectedNumberOfLines - 1;
                var expectedComplete = indices.Where(x => mockCompletedLines[x] == true).Count();

                mockSubTranslationDataFactory.Setup(
                        x => x.GetSubData(It.IsAny<List<bool>>()))
                    .Returns(mockSubData.Object);

                //Act
                var actualNumberOfLines = translationData.StartAutoMode();
                var actualComplete = translationData.NumberOfCompletedLines;
                var actualMaxIndex = translationData.MaxIndex;
                var actualMode = translationData.DefaultTranslationMode;
                var actualAutoMode = translationData.AutoTranslationMode;

                //Assert
                mockProjectData.Verify(
                        x => x.RawLines,
                    Times.AtLeastOnce);
                mockSubData.Verify(
                        x => x.NumberOfLines,
                    Times.Once);
                mockSubData.Verify(
                        x => x.MaxIndex,
                    Times.Once);

                Assert.IsType<int>(actualNumberOfLines);
                Assert.Equal(expectedNumberOfLines, actualNumberOfLines);
                Assert.IsType<int>(actualComplete);
                Assert.Equal(expectedComplete, actualComplete);
                Assert.IsType<int>(actualMaxIndex);
                Assert.Equal(expectedMaxIndex, actualMaxIndex);
                Assert.IsType<bool>(actualMode);
                Assert.True(actualMode);
                Assert.IsType<bool>(actualAutoMode);
                Assert.True(actualAutoMode);

                foreach (var index in indices)
                {
                    Assert.True(mockRawLines[index].Any());
                    Assert.True(translationData.RawLines[index].Any());

                    Assert.Equal(mockRawLines[index],           translationData.RawLines[index]);
                    Assert.Equal(mockTranslatedLines[index],    translationData.TranslatedLines[index]);
                    Assert.Equal(mockMarkedLines[index],        translationData.MarkedLines[index]);
                    Assert.Equal(mockCompletedLines[index],     translationData.CompletedLines[index]);
                }

                mockProjectData.Verify(
                        x => x.RawLines,
                    Times.Exactly(expectedNumberOfLines * 2 + 1 + mockCompletedLines.Where(x => x).Count()));

                mockProjectData.Verify(
                        x => x.TranslatedLines,
                    Times.Exactly(expectedNumberOfLines));

                mockProjectData.Verify(
                        x => x.MarkedLines,
                    Times.Exactly(expectedNumberOfLines));

                mockProjectData.Verify(
                        x => x.CompletedLines,
                    Times.Exactly(expectedNumberOfLines + 1));
            }

            /// <summary>
            /// Given that Translation Data is in Auto Mode, Start Marked Only Mode switches translation project to marked only mode.
            /// </summary>
            [Fact]
            public void TranslationData_StartMarkedOnlyMode_AutoModeTest()
            {
                //Arrange
                var indices = mockMarkedLines.Select((v, i) => new { v, i })
                    .Where(x => x.v == true && mockRawLines[x.i].Any())
                    .Select(x => x.i).ToList();

                mockSubData.Object.IndexReference = indices;
                mockSubData.Setup(
                        x => x.MaxIndex)
                    .Returns(mockSubData.Object.IndexReference.Count - 1);
                mockSubData.Setup(
                        x => x.NumberOfLines)
                    .Returns(mockSubData.Object.IndexReference.Count);

                var expectedNumberOfLines = indices.Count;
                var expectedMaxIndex = expectedNumberOfLines - 1;
                var expectedComplete = indices.Where(x => mockMarkedLines[x] == true).Count();

                mockSubTranslationDataFactory.Setup(
                        x => x.GetSubData(It.IsAny<List<bool>>()))
                    .Returns(mockSubData.Object);

                //Act
                translationData.StartAutoMode();
                var actualNumberOfLines = translationData.StartMarkedOnlyMode();
                var actualComplete = translationData.NumberOfCompletedLines;
                var actualMaxIndex = translationData.MaxIndex;
                var actualMode = translationData.DefaultTranslationMode;
                var actualAutoMode = translationData.AutoTranslationMode;

                //Assert
                mockProjectData.Verify(
                        x => x.MarkedLines,
                    Times.Exactly(3));
                mockSubData.Verify(
                        x => x.NumberOfLines,
                    Times.Exactly(2));
                mockSubData.Verify(
                        x => x.MaxIndex,
                    Times.Once);

                Assert.IsType<int>(actualNumberOfLines);
                Assert.Equal(expectedNumberOfLines, actualNumberOfLines);
                Assert.IsType<int>(actualComplete);
                Assert.Equal(expectedComplete, actualComplete);
                Assert.IsType<int>(actualMaxIndex);
                Assert.Equal(expectedMaxIndex, actualMaxIndex);
                Assert.IsType<bool>(actualMode);
                Assert.False(actualMode);
                Assert.IsType<bool>(actualAutoMode);
                Assert.True(actualAutoMode);

                foreach (var index in indices)
                {
                    Assert.True(mockMarkedLines[index]);
                    Assert.True(translationData.MarkedLines[index]);

                    Assert.Equal(mockRawLines[index],           translationData.RawLines[index]);
                    Assert.Equal(mockTranslatedLines[index],    translationData.TranslatedLines[index]);
                    Assert.Equal(mockMarkedLines[index],        translationData.MarkedLines[index]);
                    Assert.Equal(mockCompletedLines[index],     translationData.CompletedLines[index]);
                }

                mockProjectData.Verify(
                        x => x.RawLines,
                    Times.Exactly(expectedNumberOfLines + 1 + mockCompletedLines.Where(x => x).Count()));

                mockProjectData.Verify(
                        x => x.TranslatedLines,
                    Times.Exactly(expectedNumberOfLines));

                mockProjectData.Verify(
                        x => x.MarkedLines,
                    Times.Exactly(expectedNumberOfLines * 2 + 3));

                mockProjectData.Verify(
                        x => x.CompletedLines,
                    Times.Exactly(expectedNumberOfLines + 1));

            }

            /// <summary>
            /// Given that Translation Data is in Auto Mode, Start Incomplete Only Mode switches translation project to incomplete only mode.
            /// </summary>
            [Fact]
            public void TranslationData_StartIncompleteOnlyMode_AutoModeTest()
            {
                //Arrange
                var indices = mockCompletedLines.Select((v, i) => new { v, i })
                    .Where(x => x.v == false && mockRawLines[x.i].Any())
                    .Select(x => x.i).ToList();

                mockSubData.Object.IndexReference = indices;
                mockSubData.Setup(
                        x => x.MaxIndex)
                    .Returns(mockSubData.Object.IndexReference.Count - 1);
                mockSubData.Setup(
                        x => x.NumberOfLines)
                    .Returns(mockSubData.Object.IndexReference.Count);

                var expectedNumberOfLines = indices.Count;
                var expectedMaxIndex = expectedNumberOfLines - 1;
                var expectedComplete = indices.Where(x => mockCompletedLines[x] == false).Count();

                mockSubTranslationDataFactory.Setup(
                        x => x.GetSubData(It.IsAny<List<bool>>()))
                    .Returns(mockSubData.Object);

                //Act
                translationData.StartAutoMode();
                var actualNumberOfLines = translationData.StartIncompleteOnlyMode();
                var actualComplete = translationData.NumberOfCompletedLines;
                var actualMaxIndex = translationData.MaxIndex;
                var actualMode = translationData.DefaultTranslationMode;
                var actualAutoMode = translationData.AutoTranslationMode;

                //Assert
                mockProjectData.Verify(
                        x => x.CompletedLines,
                    Times.Exactly(4));
                mockSubData.Verify(
                        x => x.NumberOfLines,
                    Times.Exactly(2));
                mockSubData.Verify(
                        x => x.MaxIndex,
                    Times.Once);

                Assert.IsType<int>(actualNumberOfLines);
                Assert.Equal(expectedNumberOfLines, actualNumberOfLines);
                Assert.IsType<int>(actualComplete);
                Assert.Equal(expectedComplete, actualComplete);
                Assert.IsType<int>(actualMaxIndex);
                Assert.Equal(expectedMaxIndex, actualMaxIndex);
                Assert.IsType<bool>(actualMode);
                Assert.False(actualMode);
                Assert.IsType<bool>(actualAutoMode);
                Assert.True(actualAutoMode);

                foreach (var index in indices)
                {
                    Assert.False(mockCompletedLines[index]);
                    Assert.False(translationData.CompletedLines[index]);

                    Assert.Equal(mockRawLines[index],           translationData.RawLines[index]);
                    Assert.Equal(mockTranslatedLines[index],    translationData.TranslatedLines[index]);
                    Assert.Equal(mockMarkedLines[index],        translationData.MarkedLines[index]);
                    Assert.Equal(mockCompletedLines[index],     translationData.CompletedLines[index]);
                }

                mockProjectData.Verify(
                        x => x.RawLines,
                    Times.Exactly(expectedNumberOfLines + 1 + mockCompletedLines.Where(x => x).Count()));

                mockProjectData.Verify(
                        x => x.TranslatedLines,
                    Times.Exactly(expectedNumberOfLines));

                mockProjectData.Verify(
                        x => x.MarkedLines,
                    Times.Exactly(expectedNumberOfLines));

                mockProjectData.Verify(
                        x => x.CompletedLines,
                    Times.Exactly(expectedNumberOfLines * 2 + 4));
            }

            /// <summary>
            /// Given that Translation Data is in Auto Mode, Start Complete Only Mode switches translation project to complete only mode.
            /// </summary>
            [Fact]
            public void TranslationData_StartCompleteOnlyMode_AutoModeTest()
            {
                //Arrange
                var indices = mockCompletedLines.Select((v, i) => new { v, i })
                    .Where(x => x.v == true && mockRawLines[x.i].Any())
                    .Select(x => x.i).ToList();

                mockSubData.Object.IndexReference = indices;
                mockSubData.Setup(
                        x => x.MaxIndex)
                    .Returns(mockSubData.Object.IndexReference.Count - 1);
                mockSubData.Setup(
                        x => x.NumberOfLines)
                    .Returns(mockSubData.Object.IndexReference.Count);

                var expectedNumberOfLines = indices.Count;
                var expectedMaxIndex = expectedNumberOfLines - 1;
                var expectedComplete = indices.Where(x => mockCompletedLines[x] == true).Count();

                mockSubTranslationDataFactory.Setup(
                        x => x.GetSubData(It.IsAny<List<bool>>()))
                    .Returns(mockSubData.Object);

                //Act
                translationData.StartAutoMode();
                var actualNumberOfLines = translationData.StartCompleteOnlyMode();
                var actualComplete = translationData.NumberOfCompletedLines;
                var actualMaxIndex = translationData.MaxIndex;
                var actualMode = translationData.DefaultTranslationMode;
                var actualAutoMode = translationData.AutoTranslationMode;

                //Assert
                mockProjectData.Verify(
                        x => x.CompletedLines,
                    Times.Exactly(4));
                mockSubData.Verify(
                        x => x.NumberOfLines,
                    Times.Exactly(2));
                mockSubData.Verify(
                        x => x.MaxIndex,
                    Times.Once);

                Assert.IsType<int>(actualNumberOfLines);
                Assert.Equal(expectedNumberOfLines, actualNumberOfLines);
                Assert.IsType<int>(actualComplete);
                Assert.Equal(expectedComplete, actualComplete);
                Assert.IsType<int>(actualMaxIndex);
                Assert.Equal(expectedMaxIndex, actualMaxIndex);
                Assert.IsType<bool>(actualMode);
                Assert.False(actualMode);
                Assert.IsType<bool>(actualAutoMode);
                Assert.True(actualAutoMode);

                foreach (var index in indices)
                {
                    Assert.True(mockCompletedLines[index]);
                    Assert.True(translationData.CompletedLines[index]);

                    Assert.Equal(mockRawLines[index],           translationData.RawLines[index]);
                    Assert.Equal(mockTranslatedLines[index],    translationData.TranslatedLines[index]);
                    Assert.Equal(mockMarkedLines[index],        translationData.MarkedLines[index]);
                    Assert.Equal(mockCompletedLines[index],     translationData.CompletedLines[index]);
                }

                mockProjectData.Verify(
                        x => x.RawLines,
                    Times.Exactly(expectedNumberOfLines + 1 + mockCompletedLines.Where(x => x).Count()));

                mockProjectData.Verify(
                        x => x.TranslatedLines,
                    Times.Exactly(expectedNumberOfLines));

                mockProjectData.Verify(
                        x => x.MarkedLines,
                    Times.Exactly(expectedNumberOfLines));

                mockProjectData.Verify(
                        x => x.CompletedLines,
                    Times.Exactly(expectedNumberOfLines * 2 + 4));
            }

            #endregion
        }

        /// <summary>
        /// Contains tests to run against Translation Data methods that can throw expected exceptions.
        /// </summary>
        [Trait("Category", "Unit")]
        [Trait("Class", "Translation Data")]
        [Trait("Category", "Exception")]
        public class Exceptions
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
            /// Mock of Completed lines.
            /// </summary>
            private readonly List<bool> mockCompletedLines;

            /// <summary>
            /// Mock of Sub Translation Data Factory.
            /// </summary>
            private readonly Mock<ISubTranslationDataFactory> mockSubTranslationDataFactory;
            /// <summary>
            /// Translation Data under test.
            /// </summary>
            private ITranslationData translationData;

            /// <summary>
            /// Constructor for test setup.
            /// </summary>
            public Exceptions()
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

                mockProjectData.SetupAllProperties();
                mockProjectData.Object.ProjectName = mockProjectName;
                mockProjectData.Object.RawLines = mockRawLines;
                mockProjectData.Object.TranslatedLines = mockTranslatedLines;
                mockProjectData.Object.MarkedLines = mockMarkedLines;
                mockProjectData.Object.CompletedLines = mockCompletedLines;

                mockSubTranslationDataFactory = new Mock<ISubTranslationDataFactory>();

                translationData = new TranslationData(mockProjectData.Object, mockSubTranslationDataFactory.Object);
            }

            #region Exception Tests

            /// <summary>
            /// Given that Translation Data only has one line, Remove Line will throw RemovalOfLastLine Exception.
            /// </summary>
            [Fact]
            [Trait("Exception", "RemovalOfLastLineException")]
            public void TranslationData_GivenRemoveLineAtLastLineRaiseException()
            {
                //Arrange
                int? index = 0;
                int removeIndex = index ?? translationData.MaxIndex;

                mockRawLines.RemoveRange(1, mockRawLines.Count - 1);
                mockTranslatedLines.RemoveRange(1, mockRawLines.Count - 1);
                mockCompletedLines.RemoveRange(1, mockRawLines.Count - 1);
                mockMarkedLines.RemoveRange(1, mockRawLines.Count - 1);

                var expectedMessage = "Cannot remove last line of the translation project.";
                var expected = new RemovalOfLastLineException(expectedMessage);

                //Act
                var actual = Record.Exception(() => translationData.RemoveLine(removeIndex));
                var actualMessage = actual.Message;

                //Assert
                Assert.IsType<RemovalOfLastLineException>(actual);
                Assert.NotStrictEqual(expected, actual);
                Assert.IsType<string>(actualMessage);
                Assert.Equal(expectedMessage, actual.Message);


                mockProjectData.Verify(
                        x => x.RawLines,
                    Times.Once());
            }

            #endregion

        }
    }
}