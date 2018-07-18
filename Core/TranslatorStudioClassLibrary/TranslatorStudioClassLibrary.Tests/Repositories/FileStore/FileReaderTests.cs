using AutoFixture.Xunit2;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using TranslatorStudioClassLibrary.Contracts.Roles;
using TranslatorStudioClassLibrary.Factories;
using TranslatorStudioClassLibrary.Repositories.FileStore;
using TranslatorStudioClassLibrary.Tests.TestSetup;
using TranslatorStudioClassLibrary.Utilities;
using Xunit;

namespace TranslatorStudioClassLibrary.Tests.Repositories.FileStore
{
    public class FileReaderTests
    {
        [Trait("File Reader", "Constructor Test")]
        [Trait("Category", "Unit")]
        public class Constructor
        {
            [Theory(DisplayName = "File Reader: Default Constructor")]
            [AutoData]
            public void DefaultConstructor(string fileName)
            {
                // Arrange
                var path = Path.Combine(Path.GetTempPath(), $"{fileName}.txt");
                var fileInfo = new FileInfo(path);

                // Act
                var actual = new FileReader(fileInfo);

                // Assert
                Assert.IsType<FileReader>(actual);
                Assert.IsAssignableFrom<IProjectReader>(actual);
            }

            [Trait("Exception Test", "Argument Null Exception")]
            [Theory(DisplayName = "File Reader: Throws Exception with Illegal Parameters")]
            [InlineData(null)]
            public void IllegalParams_Throws_Exception(FileInfo invalidFileInfo)
            {
                // Arrange

                // Act, Assert
                Assert.Throws<ArgumentNullException>("fileInfo", () => new FileReader(invalidFileInfo));
            }
        }

        [Trait("File Reader", "Method Test")]
        [Trait("Category", "Integration")]
        public class Method
        {
            private readonly DirectoryInfo directoryInfo;
            private readonly string fileName;

            public Method()
            {
                directoryInfo = new DirectoryInfo(Path.GetTempPath());
                fileName = Path.GetFileNameWithoutExtension("FileReaderTesting.test");
            }

            [Theory(DisplayName = "File Reader: Read Import Project")]
            [AutoMoqData]
            public void ReadImportProject(IEnumerable<string> content, string projectName, string sourceLink)
            {
                // Arrange
                var fileInfo = new FileInfo(Path.Combine(directoryInfo.FullName, $"{fileName}.tsproj"));

                #region Create File
                var projectFactory = new ProjectFactory();
                var projectData = projectFactory.BuildNewProject(content, projectName, sourceLink);

                var json = JObject.Parse(projectData.ToJSONString());
                File.WriteAllText(fileInfo.FullName, json.ToString());
                #endregion

                var expected = projectData;

                var sut = new FileReader(fileInfo);

                // Act
                var actual = sut.Read();

                // Assert
                Assert.Equal(expected.ToJSONString(), actual.ToJSONString());
                File.Delete(fileInfo.FullName);
            }

            [Theory(DisplayName = "File Reader: Read Import Text")]
            [AutoMoqData]
            public void ReadImportText(IEnumerable<string> content)
            {
                // Arrange
                var fileInfo = new FileInfo(Path.Combine(directoryInfo.FullName, $"{fileName}.txt"));

                #region Create File
                File.WriteAllLines(fileInfo.FullName, content);
                #endregion

                var projectFactory = new ProjectFactory();
                var output = File.ReadAllLines(fileInfo.FullName);
                var projectData = projectFactory.BuildNewProject(output, fileInfo.Name, fileInfo.FullName);

                var expected = projectData;

                var sut = new FileReader(fileInfo);

                // Act
                var actual = sut.Read();

                // Assert
                Assert.Equal(expected.ToJSONString(), actual.ToJSONString());
                File.Delete(fileInfo.FullName);
            }
        }
    }
}
