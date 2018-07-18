using AutoFixture;
using AutoFixture.Xunit2;
using System.Collections.Generic;
using System.Linq;
using TranslatorStudioClassLibrary.Contracts.Types;
using TranslatorStudioClassLibrary.Factories;
using TranslatorStudioClassLibrary.Tests.TestSetup.Builders;
using TranslatorStudioClassLibrary.Types;
using Xunit;

namespace TranslatorStudioClassLibrary.Tests.Factories
{
    public class ProjectFactoryTest
    {
        [Trait("Project Factory", "Method Test")]
        [Trait("Category", "Unit")]
        public class Method
        {
            private readonly ProjectFactory sut;

            public Method()
            {
                sut = new ProjectFactory();
            }

            [Fact(DisplayName = "Project Factory: Build Project")]
            public void BuildProject()
            {
                // Arrange
                var fixture = new FixtureBuilder().Build();

                var projectData = fixture.Build<ProjectData>()
                            .With(x => x.ProjectLines, fixture.CreateMany<ProjectLine>(3).ToList<IProjectLineType>())
                            .Create();

                var expected = (IProjectDataType)projectData;

                var saveString = projectData.GetSaveString();

                // Act
                var actual = sut.BuildProject(saveString);

                // Assert
                Assert.Equal(expected.ProjectLines, actual.ProjectLines);
                Assert.Equal(expected.ProjectName, actual.ProjectName);
                Assert.Equal(expected.SourceLink, actual.SourceLink);
                Assert.Equal(expected.SaveFormatVersion, actual.SaveFormatVersion);
            }

            [Theory(DisplayName = "Project Factory: Build New Project")]
            [AutoData]
            public void BuildNewProject(IEnumerable<string> content, string projectName, string sourceLink)
            {
                // Arrange
                var projectLines = content.Select(x => new ProjectLine(x)).ToList<IProjectLineType>();
                IProjectDataType expected = new ProjectData(projectLines, projectName, sourceLink);

                // Act
                var actual = sut.BuildNewProject(content, projectName, sourceLink);

                // Assert
                Assert.Equal(expected.ProjectLines, actual.ProjectLines);
                Assert.Equal(expected.ProjectName, actual.ProjectName);
                Assert.Equal(expected.SourceLink, actual.SourceLink);
                Assert.Equal(expected.SaveFormatVersion, actual.SaveFormatVersion);
            }
        }
    }
}
