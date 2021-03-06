﻿using System.Linq;
using System.Collections.Generic;
using Moq;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Exception;
using Xunit;
using System;
using TranslatorStudioClassLibrary.Utilities;

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
            /// Mock of Project Lines.
            /// </summary>
            private readonly List<IProjectLine> mockProjectLines;

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

                mockProjectData = new Mock<IProjectData>();

                mockProjectData.SetupAllProperties();
                mockProjectData.Object.ProjectName = mockProjectName;
                mockProjectData.Object.ProjectLines = mockProjectLines;

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
                mockProjectData.Verify(x => x.ProjectName, Times.Once);

                Assert.IsType<string>(actual);
                Assert.Equal(expected, actual);
            }

            /// <summary>
            /// Given that Translation Data is successfully created, Project Lines returns the project lines in the translation project.
            /// </summary>
            [Fact]
            public void TranslationData_ProjectLines_Test()
            {
                //Arrange
                var expected = mockProjectLines;

                //Act
                var actual = translationData.ProjectLines;

                //Assert
                mockProjectData.Verify(x => x.ProjectLines, Times.Once);

                Assert.IsType<List<IProjectLine>>(actual);
                Assert.Equal(expected, actual);
            }
            #endregion

            #region Project Controls Tests
            /// <summary>
            /// Given that Current Index is assigned a valid integer, Current Line returns project line at index from Project Lines.
            /// </summary>
            /// <param name="currentIndex">A valid integer to be assigned to current index.</param>
            [Theory]
            [InlineData(1)]
            public void TranslationData_CurrentLine_Test(int currentIndex)
            {
                //Arrange
                translationData.CurrentIndex = currentIndex;

                var expected = mockProjectLines[currentIndex];

                //Act
                var actual = translationData.CurrentLine;

                //Assert
                mockProjectData.Verify(
                        x => x.ProjectLines,
                    Times.Once);

                Assert.IsType<ProjectLine>(actual);
                Assert.IsAssignableFrom<IProjectLine>(actual);
                Assert.Equal(expected, actual);
            }

            /// <summary>
            /// Given that Current Index is assigned a valid integer, Current Raw returns raw line at index from Project Lines.
            /// </summary>
            /// <param name="currentIndex">A valid integer to be assigned to current index.</param>
            [Theory]
            [InlineData(1)]
            public void TranslationData_CurrentRaw_Test(int currentIndex)
            {
                //Arrange
                translationData.CurrentIndex = currentIndex;

                var expected = mockProjectLines[currentIndex].Raw;

                //Act
                var actual = translationData.CurrentRaw;

                //Assert
                mockProjectData.Verify(x => x.ProjectLines, Times.Once);

                Assert.IsType<string>(actual);
                Assert.Equal(expected, actual);
            }

            /// <summary>
            /// Given that Current Index is assigned a valid integer, Current Translation returns translated line at index from Project Lines
            /// </summary>
            /// <param name="currentIndex">A valid integer to be assigned to current index.</param>
            [Theory]
            [InlineData(1)]
            public void TranslationData_CurrentTranslation_Test(int currentIndex)
            {
                //Arrange
                translationData.CurrentIndex = currentIndex;

                var expected = mockProjectLines[currentIndex].Translation;

                //Act
                var actual = translationData.CurrentTranslation;

                //Assert
                mockProjectData.Verify(x => x.ProjectLines, Times.Once);

                Assert.IsType<string>(actual);
                Assert.Equal(expected, actual);
            }

            /// <summary>
            /// Given that Current Index is assigned a valid integer, Current Completion returns line completion status at index from Project Lines
            /// </summary>
            /// <param name="currentIndex">A valid integer to be assigned to current index.</param>
            [Theory]
            [InlineData(1)]
            public void TranslationData_CurrentCompletion_Test(int currentIndex)
            {
                //Arrange
                translationData.CurrentIndex = currentIndex;

                var expected = mockProjectLines[currentIndex].Completed;

                //Act
                var actual = translationData.CurrentCompletion;

                //Assert
                mockProjectData.Verify(x => x.ProjectLines, Times.Once);

                Assert.IsType<bool>(actual);
                Assert.Equal(expected, actual);
            }

            /// <summary>
            /// Given that Current Index is assigned a valid integer, Current Marked returns line marked status at index from Project Lines
            /// </summary>
            /// <param name="currentIndex">A valid integer to be assigned to current index.</param>
            [Theory]
            [InlineData(1)]
            public void TranslationData_CurrentMarked_Test(int currentIndex)
            {
                //Arrange
                translationData.CurrentIndex = currentIndex;

                var expected = mockProjectLines[currentIndex].Marked;

                //Act
                var actual = translationData.CurrentMarked;

                //Assert
                mockProjectData.Verify( x => x.ProjectLines, Times.Once);

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
                var expected = mockProjectLines.Count - 1;

                //Act
                var actual = translationData.MaxIndex;

                //Assert
                mockProjectData.Verify(x => x.ProjectLines, Times.Once);

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
                var expected = mockProjectLines.Count;

                //Act
                var actual = translationData.NumberOfLines;

                //Assert
                mockProjectData.Verify(x => x.ProjectLines, Times.Once);

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
                var expected = mockProjectLines.Where(c => c.Completed).Count();

                //Act
                var actual = translationData.NumberOfCompletedLines;

                //Assert
                mockProjectData.Verify(x => x.ProjectLines, Times.Once);

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
            /// Mock of Project Lines.
            /// </summary>
            private readonly List<IProjectLine> mockProjectLines;

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

                mockProjectData = new Mock<IProjectData>();

                mockProjectData.SetupAllProperties();
                mockProjectData.Object.ProjectName = mockProjectName;
                mockProjectData.Object.ProjectLines = mockProjectLines;

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
            /// Mock of Project Lines.
            /// </summary>
            private readonly List<IProjectLine> mockProjectLines;

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

                mockProjectData = new Mock<IProjectData>();

                mockProjectData.SetupAllProperties();
                mockProjectData.Object.ProjectName = mockProjectName;
                mockProjectData.Object.ProjectLines = mockProjectLines;

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
                mockProjectData.Verify(x => x.ProjectLines, Times.Once);

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
            /// <param name="raw">A valid string used as insert value.</param>
            /// <param name="index">A valid integer used to insert line.</param>
            [Theory]
            [InlineData("Inserted Raw Line", 5)]
            [InlineData("Inserted Raw Line", 7)]
            [InlineData("Inserted Raw Line", 4)]
            public void TranslationData_InsertLine_Test(string raw, int? index)
            {
                //Arrange
                int insertIndex = index ?? translationData.NumberOfLines;
                string insertRawValue = raw ?? "";
                string expectedRawValue = insertRawValue;

                var expectedProjectLines = mockProjectLines.ToList();

                var insertLineValue = new ProjectLine
                {
                    Raw = insertRawValue,
                    Translation = "",
                    Completed = false,
                    Marked = false
                };

                expectedProjectLines.Insert(insertIndex, insertLineValue);

                //Act
                translationData.InsertLine(insertIndex, insertRawValue);

                //Assert
                mockProjectData.Verify(x => x.ProjectLines, Times.AtLeastOnce);

                var actualRawValue = translationData.ProjectLines[insertIndex].Raw;
                var actualProjectLines = translationData.ProjectLines;

                Assert.IsType<string>(actualRawValue);
                Assert.Equal(expectedRawValue, actualRawValue);

                Assert.IsType<List<IProjectLine>>(actualProjectLines);
                Assert.Equal(expectedProjectLines, actualProjectLines);
            }

            /// <summary>
            /// Given that index passed is a null value, Insert Line will insert line into translation project at end.
            /// </summary>
            [Fact]
            public void TranslationData_InsertLine_With_Null_Values_Test()
            {
                //Arrange
                string raw = null;
                int? index = null;

                //Act, Assert
                TranslationData_InsertLine_Test(raw, index);
            }

            /// <summary>
            /// Given that index passed is a valid integer, Remove Line will remove line from translation project at specified index.
            /// </summary>
            /// <param name="index">A valid integer used to specify line to remove.</param>
            [Theory]
            [InlineData(5)]
            [InlineData(1)]
            [InlineData(8)]
            public void TranslationData_RemoveLine_Test(int? index)
            {
                //Arrange
                int removeIndex = index ?? translationData.MaxIndex;

                var expectedProjectLines = mockProjectLines.ToList();

                expectedProjectLines.RemoveAt(removeIndex);

                //Act
                translationData.RemoveLine(removeIndex);

                //Assert
                mockProjectData.Verify(x => x.ProjectLines, Times.AtLeast(2));

                var actualProjectLines = translationData.ProjectLines;

                Assert.IsType<List<IProjectLine>>(actualProjectLines);
                Assert.Equal(expectedProjectLines, actualProjectLines);
            }

            /// <summary>
            /// Given that index passed is a null value, Remove Line will remove line from translation project at end.
            /// </summary>
            [Fact]
            public void TranslationData_RemoveLine_With_Null_Values_Test()
            {
                //Arrange
                int? index = null;

                //Act, Assert
                TranslationData_RemoveLine_Test(index);
            }

            /// <summary>
            /// Given that Current Index is equal to the Max Index, Increment Current Line will not increment index.
            /// </summary>
            [Fact]
            public void TranslationData_IncrementCurrentLine_At_Max_Index_Test()
            {
                //Arrange
                var expectedIndex = mockProjectLines.Count() - 1;

                translationData.CurrentIndex = expectedIndex;

                //Act
                translationData.IncrementCurrentLine();
                var actualIndex = translationData.CurrentIndex;

                //Assert
                mockProjectData.Verify(x => x.ProjectLines, Times.Once);

                Assert.IsType<int>(actualIndex);
                Assert.Equal(expectedIndex, actualIndex);
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
                mockProjectData.Verify(x => x.GetSaveString(), Times.Once);

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
                mockProjectData.Verify(x => x.ProjectLines, Times.Exactly(2));

                Assert.IsType<bool>(actual);
                Assert.Equal(expected, actual);
                Assert.IsType<int>(actualNumberOfLines);
                Assert.Equal(expectedNumberOfLines, actualNumberOfLines);

                for (int i = 0; i < expectedNumberOfLines; i++)
                {
                    Assert.Equal(mockProjectLines[i], translationData.ProjectLines[i]);
                }
            }

            /// <summary>
            /// Given that Translation Data is successfully created, Start Marked Only Mode switches translation project to marked only mode.
            /// </summary>
            [Fact]
            public void TranslationData_StartMarkedOnlyMode_Test()
            {
                //Arrange
                var indices = mockProjectLines.Select((v, i) => new { v, i })
                    .Where(x => x.v.Marked == true)
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
                mockProjectData.Verify(x => x.ProjectLines, Times.Exactly(2));
                mockSubData.Verify(x => x.NumberOfLines, Times.Once);
                mockSubData.Verify(x => x.MaxIndex, Times.Once);

                Assert.IsType<int>(actualNumberOfLines);
                Assert.Equal(expectedNumberOfLines, actualNumberOfLines);
                Assert.IsType<int>(actualMaxIndex);
                Assert.Equal(expectedMaxIndex, actualMaxIndex);
                Assert.IsType<bool>(actualMode);
                Assert.False(actualMode);

                foreach (var index in indices)
                {
                    Assert.True(mockProjectLines[index].Marked);
                    Assert.True(translationData.ProjectLines[index].Marked);

                    Assert.Equal(mockProjectLines[index], translationData.ProjectLines[index]);
                }
            }

            /// <summary>
            /// Given that Translation Data is successfully created, Start Incomplete Only Mode switches translation project to incomplete only mode.
            /// </summary>
            [Fact]
            public void TranslationData_StartIncompleteOnlyMode_Test()
            {
                //Arrange
                var indices = mockProjectLines.Select((v, i) => new { v, i })
                    .Where(x => x.v.Completed == false)
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
                mockProjectData.Verify(x => x.ProjectLines, Times.Exactly(2));
                mockSubData.Verify(x => x.NumberOfLines, Times.Once);
                mockSubData.Verify(x => x.MaxIndex, Times.Once);

                Assert.IsType<int>(actualNumberOfLines);
                Assert.Equal(expectedNumberOfLines, actualNumberOfLines);
                Assert.IsType<int>(actualMaxIndex);
                Assert.Equal(expectedMaxIndex, actualMaxIndex);
                Assert.IsType<bool>(actualMode);
                Assert.False(actualMode);
                
                foreach (var index in indices)
                {
                    Assert.False(mockProjectLines[index].Completed);
                    Assert.False(translationData.ProjectLines[index].Completed);

                    Assert.Equal(mockProjectLines[index], translationData.ProjectLines[index]);
                }
            }

            /// <summary>
            /// Given that Translation Data is successfully created, Start Complete Only Mode switches translation project to complete only mode.
            /// </summary>
            [Fact]
            public void TranslationData_StartCompleteOnlyMode_Test()
            {
                //Arrange
                var indices = mockProjectLines.Select((v, i) => new { v, i })
                    .Where(x => x.v.Completed == true)
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
                mockProjectData.Verify(x => x.ProjectLines, Times.Exactly(2));
                mockSubData.Verify(x => x.NumberOfLines, Times.Once);
                mockSubData.Verify(x => x.MaxIndex, Times.Once);

                Assert.IsType<int>(actualNumberOfLines);
                Assert.Equal(expectedNumberOfLines, actualNumberOfLines);
                Assert.IsType<int>(actualMaxIndex);
                Assert.Equal(expectedMaxIndex, actualMaxIndex);
                Assert.IsType<bool>(actualMode);
                Assert.False(actualMode);
                
                foreach (var index in indices)
                {
                    Assert.True(mockProjectLines[index].Completed);
                    Assert.True(translationData.ProjectLines[index].Completed);

                    Assert.Equal(mockProjectLines[index], translationData.ProjectLines[index]);
                }
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
            /// Mock of Project Lines.
            /// </summary>
            private readonly List<IProjectLine> mockProjectLines;

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

                mockProjectLines = new List<IProjectLine>
                {
                    new ProjectLine { Raw = "Raw Line 1",   Translation = "Translated Line 1",      Completed = false,  Marked = true },
                    new ProjectLine { Raw = "",             Translation = "Translated Line 2",      Completed = false,  Marked = false },
                    new ProjectLine { Raw = "Raw Line 3",   Translation = "Translated Line 3",      Completed = true,   Marked = true },
                    new ProjectLine { Raw = "Raw Line 4",   Translation = "Translated Line 4",      Completed = false,  Marked = false },
                    new ProjectLine { Raw = "",             Translation = "Translated Line 5",      Completed = true,   Marked = false },
                    new ProjectLine { Raw = "",             Translation = "Translated Line 6",      Completed = true,   Marked = true },
                    new ProjectLine { Raw = "Raw Line 7",   Translation = "Translated Line 7",      Completed = true,   Marked = false },
                    new ProjectLine { Raw = "",             Translation = "Translated Line 8",      Completed = false,  Marked = true },
                    new ProjectLine { Raw = "Raw Line 9",   Translation = "Translated Line 9",      Completed = true,   Marked = true },
                    new ProjectLine { Raw = "Raw Line 10",  Translation = "Translated Line 10",     Completed = false,  Marked = false }
                };


                mockProjectData = new Mock<IProjectData>();

                mockProjectData.SetupAllProperties();
                mockProjectData.Object.ProjectName = mockProjectName;
                mockProjectData.Object.ProjectLines = mockProjectLines;

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
            /// Given that Auto Mode is off, Toggle Auto Mode switches translation project to auto translation mode.
            /// </summary>
            [Fact]
            public void TranslationData_ToggleAutoMode_On_Test()
            {
                //Arrange
                var indices = mockProjectLines
                    .Select((v, i) => new { v, i })
                    .Where(x => x.v.Raw.IsNotEmpty())
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
                var expectedComplete = indices.Where(x => mockProjectLines[x].Completed == true).Count();

                mockSubTranslationDataFactory.Setup(
                        x => x.GetSubData(It.IsAny<List<bool>>()))
                    .Returns(mockSubData.Object);

                //Act
                var actualNumberOfLines = translationData.ToggleAutoMode(true);
                var actualComplete = translationData.NumberOfCompletedLines;
                var actualMaxIndex = translationData.MaxIndex;
                var actualMode = translationData.DefaultTranslationMode;
                var actualAutoMode = translationData.AutoTranslationMode;

                //Assert
                mockProjectData.Verify(x => x.ProjectLines, Times.AtLeastOnce);
                mockSubData.Verify(x => x.NumberOfLines, Times.Once);
                mockSubData.Verify(x => x.MaxIndex, Times.Once);

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
                    Assert.True(mockProjectLines[index].Raw.IsNotEmpty());
                    Assert.True(translationData.ProjectLines[index].Raw.IsNotEmpty());

                    Assert.Equal(mockProjectLines[index], translationData.ProjectLines[index]);
                }
            }

            /// <summary>
            /// Given that Auto Mode is on, Toggle Auto Mode switches translation project to auto translation mode.
            /// </summary>
            [Fact]
            public void TranslationData_ToggleAutoMode_Off_Test()
            {
                //Arrange
                var indices = mockProjectLines
                    .Select((v, i) => new { v, i })
                    .Where(x => x.v.Raw.IsNotEmpty())
                    .Select(x => x.i).ToList();

                mockSubData.Object.IndexReference = indices;
                mockSubData.Setup(
                        x => x.MaxIndex)
                    .Returns(mockSubData.Object.IndexReference.Count - 1);
                mockSubData.Setup(
                        x => x.NumberOfLines)
                    .Returns(mockSubData.Object.IndexReference.Count);

                var expectedNumberOfLines = mockProjectLines.Count;
                var expectedMaxIndex = expectedNumberOfLines - 1;
                var expectedComplete = mockProjectLines.Where(x => x.Completed).Count();

                mockSubTranslationDataFactory.Setup(
                        x => x.GetSubData(It.IsAny<List<bool>>()))
                    .Returns(mockSubData.Object);

                //Act
                translationData.ToggleAutoMode(true);
                var actualNumberOfLines = translationData.ToggleAutoMode(false);
                var actualComplete = translationData.NumberOfCompletedLines;
                var actualMaxIndex = translationData.MaxIndex;
                var actualMode = translationData.DefaultTranslationMode;
                var actualAutoMode = translationData.AutoTranslationMode;

                //Assert
                mockProjectData.Verify(x => x.ProjectLines, Times.AtLeastOnce);
                mockSubData.Verify(x => x.NumberOfLines, Times.Once);

                Assert.IsType<int>(actualNumberOfLines);
                Assert.Equal(expectedNumberOfLines, actualNumberOfLines);
                Assert.IsType<int>(actualComplete);
                Assert.Equal(expectedComplete, actualComplete);
                Assert.IsType<int>(actualMaxIndex);
                Assert.Equal(expectedMaxIndex, actualMaxIndex);
                Assert.IsType<bool>(actualMode);
                Assert.True(actualMode);
                Assert.IsType<bool>(actualAutoMode);
                Assert.False(actualAutoMode);

                for (int index = 0; index < expectedNumberOfLines; index++)
                {
                    Assert.Equal(mockProjectLines[index], translationData.ProjectLines[index]);
                }
            }

            /// <summary>
            /// Given that Translation Data is in Auto Mode, Start Marked Only Mode switches translation project to marked only mode.
            /// </summary>
            [Fact]
            public void TranslationData_StartMarkedOnlyMode_AutoModeTest()
            {
                //Arrange
                var indices = mockProjectLines
                    .Select((v, i) => new { v, i })
                    .Where(x => x.v.Marked && x.v.Raw.IsNotEmpty())
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
                var expectedComplete = indices.Where(x => mockProjectLines[x].Marked == true).Count();

                mockSubTranslationDataFactory.Setup(
                        x => x.GetSubData(It.IsAny<List<bool>>()))
                    .Returns(mockSubData.Object);

                //Act
                translationData.ToggleAutoMode(true);
                var actualNumberOfLines = translationData.StartMarkedOnlyMode();
                var actualComplete = translationData.NumberOfCompletedLines;
                var actualMaxIndex = translationData.MaxIndex;
                var actualMode = translationData.DefaultTranslationMode;
                var actualAutoMode = translationData.AutoTranslationMode;

                //Assert
                mockProjectData.Verify(x => x.ProjectLines, Times.Exactly(expectedNumberOfLines + 1));
                mockSubData.Verify(x => x.NumberOfLines, Times.Exactly(2));
                mockSubData.Verify(x => x.MaxIndex, Times.Once);

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
                    Assert.True(mockProjectLines[index].Marked);
                    Assert.True(translationData.ProjectLines[index].Marked);

                    Assert.True(mockProjectLines[index].Raw.IsNotEmpty());
                    Assert.True(translationData.ProjectLines[index].Raw.IsNotEmpty());

                    Assert.Equal(mockProjectLines[index], translationData.ProjectLines[index]);
                }
            }

            /// <summary>
            /// Given that Translation Data is in Auto Mode, Start Incomplete Only Mode switches translation project to incomplete only mode.
            /// </summary>
            [Fact]
            public void TranslationData_StartIncompleteOnlyMode_AutoModeTest()
            {
                //Arrange
                var indices = mockProjectLines
                    .Select((v, i) => new { v, i })
                    .Where(x => !x.v.Completed && x.v.Raw.IsNotEmpty())
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
                var expectedComplete = indices.Where(x => mockProjectLines[x].Completed == false).Count();

                mockSubTranslationDataFactory.Setup(
                        x => x.GetSubData(It.IsAny<List<bool>>()))
                    .Returns(mockSubData.Object);

                //Act
                translationData.ToggleAutoMode(true);
                var actualNumberOfLines = translationData.StartIncompleteOnlyMode();
                var actualComplete = translationData.NumberOfCompletedLines;
                var actualMaxIndex = translationData.MaxIndex;
                var actualMode = translationData.DefaultTranslationMode;
                var actualAutoMode = translationData.AutoTranslationMode;

                //Assert
                mockProjectData.Verify(x => x.ProjectLines, Times.Exactly(expectedNumberOfLines + 1));
                mockSubData.Verify(x => x.NumberOfLines, Times.Exactly(2));
                mockSubData.Verify(x => x.MaxIndex, Times.Once);

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
                    Assert.False(mockProjectLines[index].Completed);
                    Assert.False(translationData.ProjectLines[index].Completed);
                    
                    Assert.True(mockProjectLines[index].Raw.IsNotEmpty());
                    Assert.True(translationData.ProjectLines[index].Raw.IsNotEmpty());

                    Assert.Equal(mockProjectLines[index], translationData.ProjectLines[index]);
                }
            }

            /// <summary>
            /// Given that Translation Data is in Auto Mode, Start Complete Only Mode switches translation project to complete only mode.
            /// </summary>
            [Fact]
            public void TranslationData_StartCompleteOnlyMode_AutoModeTest()
            {
                //Arrange
                var indices = mockProjectLines
                    .Select((v, i) => new { v, i })
                    .Where(x => x.v.Completed && x.v.Raw.IsNotEmpty())
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
                var expectedComplete = indices.Where(x => mockProjectLines[x].Completed == true).Count();

                mockSubTranslationDataFactory.Setup(
                        x => x.GetSubData(It.IsAny<List<bool>>()))
                    .Returns(mockSubData.Object);

                //Act
                translationData.ToggleAutoMode(true);
                var actualNumberOfLines = translationData.StartCompleteOnlyMode();
                var actualComplete = translationData.NumberOfCompletedLines;
                var actualMaxIndex = translationData.MaxIndex;
                var actualMode = translationData.DefaultTranslationMode;
                var actualAutoMode = translationData.AutoTranslationMode;

                //Assert
                mockProjectData.Verify(x => x.ProjectLines, Times.Exactly(expectedNumberOfLines + 1));
                mockSubData.Verify(x => x.NumberOfLines, Times.Exactly(2));
                mockSubData.Verify(x => x.MaxIndex, Times.Once);

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
                    Assert.True(mockProjectLines[index].Completed);
                    Assert.True(translationData.ProjectLines[index].Completed);
                    
                    Assert.True(mockProjectLines[index].Raw.IsNotEmpty());
                    Assert.True(translationData.ProjectLines[index].Raw.IsNotEmpty());

                    Assert.Equal(mockProjectLines[index], translationData.ProjectLines[index]);
                }
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
            /// Mock of Project Lines.
            /// </summary>
            private readonly List<IProjectLine> mockProjectLines;

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

                mockProjectData = new Mock<IProjectData>();

                mockProjectData.SetupAllProperties();
                mockProjectData.Object.ProjectName = mockProjectName;
                mockProjectData.Object.ProjectLines = mockProjectLines;

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

                mockProjectLines.RemoveRange(1, mockProjectLines.Count - 1);

                var expectedMessage = "Cannot remove last line of the translation project.";
                var expected = new RemovalOfLastLineException(expectedMessage);

                //Act
                var actual = Record.Exception(() => translationData.RemoveLine(removeIndex));
                var actualMessage = actual.Message;

                //Assert
                mockProjectData.Verify(x => x.ProjectLines, Times.Once());

                Assert.IsType<RemovalOfLastLineException>(actual);
                Assert.NotStrictEqual(expected, actual);
                Assert.IsType<string>(actualMessage);
                Assert.Equal(expectedMessage, actual.Message);
            }
            #endregion
        }
    }
}