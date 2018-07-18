using AutoFixture.Xunit2;
using System;
using System.Collections.Generic;
using System.IO;
using TranslatorStudioClassLibrary.Contracts.Roles;
using TranslatorStudioClassLibrary.Contracts.Types;
using TranslatorStudioClassLibrary.Factories;
using TranslatorStudioClassLibrary.Repositories.FileStore;
using TranslatorStudioClassLibrary.Tests.TestSetup;
using Xunit;

namespace TranslatorStudioClassLibrary.Tests.Repositories.FileStore
{
    public class FileWriterTests
    {
        [Trait("File Writer", "Constructor Test")]
        [Trait("Category", "Unit")]
        public class Constructor
        {
            [Theory(DisplayName = "File Writer: Default Constructor")]
            [AutoData]
            public void DefaultConstructor(string fileName)
            {
                // Arrange
                var path = Path.Combine(Path.GetTempPath(), $"{fileName}.txt");
                var fileInfo = new FileInfo(path);

                // Act
                var actual = new FileWriter(fileInfo);

                // Assert
                Assert.IsType<FileWriter>(actual);
                Assert.IsAssignableFrom<IProjectWriter>(actual);
            }

            [Trait("Exception Test", "Argument Null Exception")]
            [Theory(DisplayName = "File Writer: Throws Exception with Illegal Parameters")]
            [InlineData(null)]
            public void IllegalParams_Throws_Exception(FileInfo invalidFileInfo)
            {
                // Arrange
                
                // Act, Assert
                Assert.Throws<ArgumentNullException>("fileInfo", () => new FileWriter(invalidFileInfo));
            }
        }

        [Trait("File Writer", "Method Test")]
        [Trait("Category", "Integration")]
        public class Method
        {
            private readonly DirectoryInfo directoryInfo;
            private readonly string fileName;

            public Method()
            {
                directoryInfo = new DirectoryInfo(Path.GetTempPath());
                fileName = Path.GetFileNameWithoutExtension("FileWriterTesting");
            }

            [Theory(DisplayName = "File Writer: Write Save Project")]
            [AutoMoqData]
            public void WriteSaveProject(IEnumerable<string> content, string projectName, string sourceLink)
            {
                // Arrange
                var fileInfo = new FileInfo(Path.Combine(directoryInfo.FullName, $"{fileName}.tsproj"));
                if (fileInfo.Exists)
                    File.Delete(fileInfo.FullName);

                var projectFactory = new ProjectFactory();
                var projectData = projectFactory.BuildNewProject(content, projectName, sourceLink);

                var sut = new FileWriter(fileInfo);
                // Act
                sut.Write(projectData);

                // Assert
                Assert.True(File.Exists(fileInfo.FullName));
                File.Delete(fileInfo.FullName);
            }

            [Theory(DisplayName = "File Writer: Write Export Translation")]
            [AutoMoqData]
            public void WriteExportTranslation(IProjectDataType projectData)
            {
                // Arrange
                var fileInfo = new FileInfo(Path.Combine(directoryInfo.FullName, $"{fileName}.txt"));
                if (fileInfo.Exists)
                    File.Delete(fileInfo.FullName);

                var sut = new FileWriter(fileInfo);

                // Act
                sut.Write(projectData);

                // Assert
                Assert.True(File.Exists(fileInfo.FullName));
                File.Delete(fileInfo.FullName);
            }
        }
    }
}