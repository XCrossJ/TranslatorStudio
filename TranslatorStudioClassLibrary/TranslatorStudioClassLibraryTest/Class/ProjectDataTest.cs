using Moq;
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
            /// Mock of Project Lines.
            /// </summary>
            private readonly List<IProjectLine> mockProjectLines;

            /// <summary>
            /// Mock of Project Data.
            /// </summary>
            private readonly IProjectData mockProjectData;

            /// <summary>
            /// Constructor to set up test code.
            /// </summary>
            public Properties()
            {
                mockProjectLines = new List<IProjectLine>();
                mockProjectData = new ProjectData();
            }

            #region Properties Tests
            /// <summary>
            /// Given that Project Name is assigned a valid string, value of Project Name is changed.
            /// </summary>
            [Theory]
            [InlineData("Mock Project Name")]
            public void ProjectData_ProjectName_Test(string projectName)
            {
                //Arrange
                var expected = projectName;

                //Act
                mockProjectData.ProjectName = projectName;
                var actual = mockProjectData.ProjectName;

                //Assert
                Assert.IsType<string>(actual);
                Assert.Equal(expected, actual);
            }

            /// <summary>
            /// Given that Project Lines is assigned a valid list of ProjectLines, value of Project Lines is changed.
            /// </summary>
            [Fact]
            public void ProjectData_ProjectLines_Test()
            {
                //Arrange
                var expected = mockProjectLines;
                mockProjectData.ProjectLines = mockProjectLines;

                //Act
                var actual = mockProjectData.ProjectLines;

                //Assert
                Assert.IsType<List<IProjectLine>>(actual);
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
