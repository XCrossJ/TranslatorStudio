using System;
using System.Collections.Generic;
using TranslatorStudioClassLibrary.Class;
using TranslatorStudioClassLibrary.Interface;
using TranslatorStudioClassLibrary.Utilities;
using Xunit;

namespace TranslatorStudioClassLibraryTest.Class
{
    /// <summary>
    /// Contains tests to run against Project Data class.
    /// </summary>
    [Collection("Project Data Test")]
    public class ProjectDataTest
    {
        /// <summary>
        /// Contains tests to run against Project Data properties.
        /// </summary>
        [Trait("Category", "Unit")]
        [Trait("Class", "Project Data")]
        public class Properties
        {
            /// <summary>
            /// Mock of Project Data.
            /// </summary>
            private readonly IProjectData mockProjectData;
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
            /// Mock of Completed Lines.
            /// </summary>
            private readonly List<bool> mockCompletedLines;
            /// <summary>
            /// Mock of Marked Lines.
            /// </summary>
            private readonly List<bool> mockMarkedLines;

            /// <summary>
            /// Constructor to set up test code.
            /// </summary>
            public Properties()
            {
                mockProjectName = "Mock Project Name";
                mockRawLines = new List<string> { "", "" };
                mockTranslatedLines = new List<string> { "", "" };
                mockCompletedLines = new List<bool> { true, false };
                mockMarkedLines = new List<bool> { false, true };
                mockProjectData = new ProjectData();
            }

            #region Properties Tests
            /// <summary>
            /// Given that Project Name is assigned a valid string, value of Project Name is changed.
            /// </summary>
            [Fact]
            public void ProjectData_ProjectName_Test()
            {
                //Arrange
                var expected = mockProjectName;

                //Act
                var actual = mockProjectData.ProjectName = expected;

                //Assert
                Assert.IsType<string>(actual);
                Assert.Equal(expected, actual);

            }

            /// <summary>
            /// Given that Raw Lines is assigned a valid list of strings, value of Raw Lines is changed.
            /// </summary>
            [Fact]
            public void ProjectData_RawLines_Test()
            {
                //Arrange
                var expected = mockRawLines;

                //Act
                var actual = mockProjectData.RawLines = expected;

                //Assert
                Assert.IsType<List<string>>(actual);
                Assert.Equal(expected, actual);

            }

            /// <summary>
            /// Given that Translated Lines is assigned a valid list of strings, value of Translated Lines is changed.
            /// </summary>
            [Fact]
            public void ProjectData_TranslatedLines_Test()
            {
                //Arrange
                var expected = mockTranslatedLines;

                //Act
                var actual = mockProjectData.TranslatedLines = expected;

                //Assert
                Assert.IsType<List<string>>(actual);
                Assert.Equal(expected, actual);

            }

            /// <summary>
            /// Given that Completed Lines is assigned a valid list of booleans, value of Completed Lines is changed.
            /// </summary>
            [Fact]
            public void ProjectData_CompletedLines_Test()
            {
                //Arrange
                var expected = mockCompletedLines;

                //Act
                var actual = mockProjectData.CompletedLines = expected;

                //Assert
                Assert.IsType<List<bool>>(actual);
                Assert.Equal(expected, actual);

            }

            /// <summary>
            /// Given that Marked Lines is assigned a valid list of booleans, value of Marked Lines is changed.
            /// </summary>
            [Fact]
            public void ProjectData_MarkedLines_Test()
            {
                //Arrange
                var expected = mockMarkedLines;

                //Act
                var actual = mockProjectData.MarkedLines = expected;

                //Assert
                Assert.IsType<List<bool>>(actual);
                Assert.Equal(expected, actual);

            }
            #endregion
        }

        /// <summary>
        /// Contains tests to run against Project Data constructors.
        /// </summary>
        [Trait("Category", "Unit")]
        [Trait("Class", "Project Data")]
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
            /// Given that Project Data is invokved, Default Constructor returns valid Project Data.
            /// </summary>
            [Fact]
            public void ProjectData_DefaultConstructor_Test()
            {
                //Arrange
                var expected = new ProjectData();

                //Act
                var actual = new ProjectData();

                //Assert
                Assert.IsType<ProjectData>(actual);
                Assert.IsAssignableFrom<IProjectData>(actual);
                Assert.NotStrictEqual(expected, actual);
            }

            #endregion
        }

        /// <summary>
        /// Contains tests to run against Project Data methods.
        /// </summary>
        [Trait("Category", "Unit")]
        [Trait("Class", "Project Data")]
        public class Methods
        {
            /// <summary>
            /// Mock of Project Data.
            /// </summary>
            private readonly IProjectData mockProjectData;

            /// <summary>
            /// Constructor to set up test code.
            /// </summary>
            public Methods()
            {
                mockProjectData = new ProjectData();
            }

            #region Methods Tests

            /// <summary>
            /// When calling GetProjectSaveString method, expect ProjectData serialised as JSON string.
            /// </summary>
            [Fact]
            public void ProjectData_GetProjectSaveString_Test()
            {
                //Arrange
                var expectedSaveString = mockProjectData.ToJSONString();

                //Act
                var actualSaveString = mockProjectData.GetSaveString();

                //Assert
                Assert.IsType<string>(actualSaveString);
                Assert.Equal(expectedSaveString, actualSaveString);
            }

            #endregion
        }
    }
}
