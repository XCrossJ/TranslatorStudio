using AutoFixture;
using AutoFixture.Xunit2;
using System;
using System.Collections.Generic;
using System.Linq;
using TranslatorStudioClassLibrary.Contracts.Enums;
using TranslatorStudioClassLibrary.Contracts.Roles;
using TranslatorStudioClassLibrary.Contracts.Types;
using TranslatorStudioClassLibrary.Tests.TestSetup;
using TranslatorStudioClassLibrary.Tests.TestSetup.Builders;
using TranslatorStudioClassLibrary.Types;
using TranslatorStudioClassLibrary.Utilities;
using Xunit;

namespace TranslatorStudioClassLibrary.Tests.Types
{
    public class ProjectDataTests
    {
        [Trait("Project Data", "Constructor Test")]
        [Trait("Category", "Unit")]
        public class Constructor
        {
            [Theory(DisplayName = "Project Data: Json Constructor Test")]
            [AutoData]
            public void JsonConstructor(IList<ProjectLine> projectLines)
            {
                // Arrange
                var expected = new ProjectData(projectLines)
                {
                    ProjectLines = projectLines.ToList<IProjectLineType>(),
                    ProjectName = null,
                    SaveFormatVersion = SaveFormatVersionEnum.Legacy,
                    SourceLink = null
                };

                // Act
                var actual = new ProjectData(projectLines);

                // Assert
                Assert.Equal(expected, actual);

                Assert.IsType<ProjectData>(actual);
                Assert.IsAssignableFrom<IProjectDataType>(actual);
                Assert.IsAssignableFrom<IProjectSaveable>(actual);
            }

            [Theory(DisplayName = "Project Data: Default Constructor")]
            [AutoMoqData]
            public void DefaultConstructor(IList<IProjectLineType> projectLines)
            {
                // Arrange
                var expected = new ProjectData(projectLines)
                {
                    ProjectLines = projectLines,
                    ProjectName = null,
                    SaveFormatVersion = SaveFormatVersionEnum.Legacy,
                    SourceLink = null
                };

                // Act
                var actual = new ProjectData(projectLines);

                // Assert
                Assert.Equal(expected, actual);

                Assert.IsType<ProjectData>(actual);
                Assert.IsAssignableFrom<IProjectDataType>(actual);
                Assert.IsAssignableFrom<IProjectSaveable>(actual);
            }

            [Theory(DisplayName = "Project Data: Project Name Constructor")]
            [AutoMoqData]
            public void ProjectNameConstructor(
                IList<IProjectLineType> projectLines,
                string projectName
                )
            {
                // Arrange
                var expected = new ProjectData(projectLines)
                {
                    ProjectLines = projectLines,
                    ProjectName = projectName,
                    SaveFormatVersion = SaveFormatVersionEnum.Legacy,
                    SourceLink = null
                };

                // Act
                var actual = new ProjectData(projectLines, projectName);

                // Assert
                Assert.Equal(expected, actual);

                Assert.IsType<ProjectData>(actual);
                Assert.IsAssignableFrom<IProjectDataType>(actual);
                Assert.IsAssignableFrom<IProjectSaveable>(actual);
            }

            [Theory(DisplayName = "Project Data: Source Link Constructor")]
            [AutoMoqData]
            public void SourceLinkConstructor(
                IList<IProjectLineType> projectLines,
                string projectName,
                string sourceLink
                )
            {
                // Arrange
                var expected = new ProjectData(projectLines)
                {
                    ProjectLines = projectLines,
                    ProjectName = projectName,
                    SaveFormatVersion = SaveFormatVersionEnum.Legacy,
                    SourceLink = sourceLink
                };

                // Act
                var actual = new ProjectData(projectLines, projectName, sourceLink);

                // Assert
                Assert.Equal(expected, actual);

                Assert.IsType<ProjectData>(actual);
                Assert.IsAssignableFrom<IProjectDataType>(actual);
                Assert.IsAssignableFrom<IProjectSaveable>(actual);
            }

            [Theory(DisplayName = "Project Data: Full Constructor")]
            [AutoMoqData]
            public void FullConstructor(
                IList<IProjectLineType> projectLines,
                string projectName,
                string sourceLink,
                SaveFormatVersionEnum saveFormatVersion
                )
            {
                // Arrange
                var expected = new ProjectData(projectLines)
                {
                    ProjectLines = projectLines,
                    ProjectName = projectName,
                    SaveFormatVersion = saveFormatVersion,
                    SourceLink = sourceLink
                };

                // Act
                var actual = new ProjectData(projectLines, projectName, sourceLink, saveFormatVersion);

                // Assert
                Assert.Equal(expected, actual);

                Assert.IsType<ProjectData>(actual);
                Assert.IsAssignableFrom<IProjectDataType>(actual);
                Assert.IsAssignableFrom<IProjectSaveable>(actual);
            }

            [Trait("Exception Test", "Argument Null Exception")]
            [Theory(DisplayName = "Project Data: Throws Exception with Illegal Parameters")]
            [AutoData]
            public void IllegalParams_Throws_Exception(
                string projectName,
                string sourceLink,
                SaveFormatVersionEnum saveFormatVersion
                )
            {
                // Arrange
                IList<IProjectLineType> invalidProjectLines = null;

                // Act, Assert
                Assert.Throws<ArgumentNullException>("projectLines", () => new ProjectData(invalidProjectLines));
                Assert.Throws<ArgumentNullException>("projectLines", () => new ProjectData(invalidProjectLines, projectName));
                Assert.Throws<ArgumentNullException>("projectLines", () => new ProjectData(invalidProjectLines, projectName, sourceLink));
                Assert.Throws<ArgumentNullException>("projectLines", () => new ProjectData(invalidProjectLines, projectName, sourceLink, saveFormatVersion));
            }
        }

        [Trait("Project Data", "Method Test")]
        [Trait("Category", "Unit")]
        public class Methods
        {
            private readonly ProjectData sut;

            private readonly IFixture fixture;

            public Methods()
            {
                fixture = new FixtureBuilder().Build();

                sut = fixture.Build<ProjectData>()
                            .With(x => x.ProjectLines, fixture.CreateMany<ProjectLine>(3).ToList<IProjectLineType>())
                            .Create();
            }

            [Fact(DisplayName = "Project Data: Get Save String")]
            public void GetSaveString()
            {
                // Arrange
                var expected = sut.ToJSONString();

                // Act
                var actual = sut.GetSaveString();

                // Assert
                Assert.Equal(expected, actual);
            }
        }
    }
}