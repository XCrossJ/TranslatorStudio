using AutoFixture;
using AutoFixture.Xunit2;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TranslatorStudioClassLibrary.Contracts.Roles;
using TranslatorStudioClassLibrary.Contracts.Types;
using TranslatorStudioClassLibrary.Repositories;
using TranslatorStudioClassLibrary.Repositories.FileStore;
using TranslatorStudioClassLibrary.Tests.TestSetup;
using TranslatorStudioClassLibrary.Tests.TestSetup.Builders;
using Xunit;

namespace TranslatorStudioClassLibrary.Tests.Repositories
{
    public class ProjectRepositoryTests
    {
        [Trait("Project Repository", "Constructor Test")]
        [Trait("Category", "Unit")]
        public class Constructor
        {
            [Theory(DisplayName = "Project Repository: Default Constructor")]
            [AutoMoqData]
            public void DefaultConstructor(Mock<IProjectReader> mockProjectReader, Mock<IProjectWriter> mockProjectWriter)
            {
                // Arrange
                var projectReader = mockProjectReader.Object;
                var projectWriter = mockProjectWriter.Object;

                // Act
                var actual = new ProjectRepository(projectReader, projectWriter);

                // Assert
                Assert.IsType<ProjectRepository>(actual);
                Assert.IsAssignableFrom<IProjectReader>(actual);
                Assert.IsAssignableFrom<IProjectWriter>(actual);
            }

            [Theory(DisplayName = "Project Repository: File Info Constructor")]
            [AutoData]
            public void FileInfoConstructor(string fileName)
            {
                // Arrange
                var path = Path.Combine(Path.GetTempPath(), $"{fileName}.txt");
                var fileInfo = new FileInfo(path);

                // Act
                var actual = new ProjectRepository(fileInfo);

                // Assert
                Assert.IsType<ProjectRepository>(actual);
                Assert.IsAssignableFrom<IProjectReader>(actual);
                Assert.IsAssignableFrom<IProjectWriter>(actual);
            }

            [Trait("Exception Test", "Argument Null Exception")]
            [Theory(DisplayName = "Project Repository: Throws Exception with Illegal Parameters")]
            [AutoMoqData]
            public void IllegalParams_Throws_Exception(Mock<IProjectReader> mockProjectReader, Mock<IProjectWriter> mockProjectWriter)
            {
                // Arrange
                var projectReader = mockProjectReader.Object;
                var projectWriter = mockProjectWriter.Object;

                IProjectReader invalidProjectReader = null;
                IProjectWriter invalidProjectWriter = null;
                FileInfo invalidFileInfo = null;

                // Act, Assert
                Assert.Throws<ArgumentNullException>("projectReader", () => new ProjectRepository(invalidProjectReader, projectWriter));
                Assert.Throws<ArgumentNullException>("projectWriter", () => new ProjectRepository(projectReader, invalidProjectWriter));
                Assert.Throws<ArgumentNullException>("fileInfo", () => new ProjectRepository(invalidFileInfo));
            }
        }

        [Trait("Project Repository", "Method Test")]
        [Trait("Category", "Unit")]
        public class Method
        {
            private readonly Mock<IProjectReader> mockProjectReader;
            private readonly Mock<IProjectWriter> mockProjectWriter;
            private readonly ProjectRepository sut;

            private readonly IFixture fixture;

            public Method()
            {
                fixture = new FixtureBuilder().Build();

                mockProjectReader = fixture.Create<Mock<IProjectReader>>();
                mockProjectWriter = fixture.Create<Mock<IProjectWriter>>();

                sut = new ProjectRepository(mockProjectReader.Object, mockProjectWriter.Object);
            }

            [Theory(DisplayName = "Project Repository: Read")]
            [AutoMoqData]
            public void Read(IProjectDataType projectData)
            {
                // Arrange
                var expected = projectData;

                mockProjectReader.Setup(x => x.Read()).Returns(projectData);

                // Act
                var actual = sut.Read();

                // Assert
                Assert.Equal(expected, actual);
            }

            [Theory(DisplayName = "Project Repository: Write")]
            [AutoMoqData]
            public void Write(IProjectDataType projectData)
            {
                // Arrange

                // Act
                sut.Write(projectData);

                // Assert
                mockProjectWriter.Verify(x => x.Write(It.Is<IProjectDataType>(y => y == projectData)), Times.Once);
            }
        }
    }
}
